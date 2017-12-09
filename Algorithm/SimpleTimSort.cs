using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 其实TimSort是适合于对象排序的，而非数组排序
/// </summary>
public class SimpleTimSort
{

	private static int MIN_MERGE = 16;
	private int[] a;
	private int[] aux;

	private int[] runsBase = new int[40];
	private int[] runsLen = new int[40];
	private int stackTop = 0;


	public SimpleTimSort(int[] data) {
		a = data;
		Type elementType = data.GetType().GetElementType();
		aux = new int[a.Length];
		Array.Copy(a, 0, aux, 0, a.Length);
	}

	public void Sort() {
		int n = a.Length;

		if (n < 2) return;

		if (n < MIN_MERGE) {
			insertSort(a, 0, 0, a.Length - 1);
			return;
		}

		int baseIndex = 0;
		while (n > 0) {
			int len = maxAscendingLen(a, baseIndex);
			if (len < MIN_MERGE) {
				int abscent = n > MIN_MERGE ? MIN_MERGE - len : n - len;
				insertSort(a, baseIndex, baseIndex + len - 1, abscent);
				len = len + abscent;
			}
			pushRun(baseIndex, len);
			n = n - len;
			baseIndex = baseIndex + len;

			int x;
			while ((x = needMerge()) >= 0) {
				mergeAt(x);
			}
		}
		forceMerge();


	}

    //  data[from, to]已有序，data[to]以后的n元素插入到有序的序列中
	private void insertSort(int[] data, int from, int to, int n) {
        int i = to + 1;
        while (n > 0) {
            int temp = data[i];
            int j;
            for (j = i - 1; j >= from && temp < data[j]; j--) {
                data[j + 1] = data[j];
            }
            data[++j] = temp;
            i++;
            n--;
        }
    }

    //  返回从data[from]开始的最长有序片段的个数
	private int maxAscendingLen(int[] data, int from) {
        int n = 1;
        int i = from;

        if(i >= data.Length)
            return 0;

        if (i == data.Length - 1)
            return 1;

        if (data[i] < data[i+1]) {
            while(i + 1 <= data.Length - 1 && data[i] < data[i + 1]) {
                i++;
                n++;
            }
            return n;
        } else {
            while (i + 1 <= data.Length - 1 && data[i] > data[i + 1]) {
                i++;
                n++;
            }

            int j = from;
            while (j < i) {
                int temp = data[i];
                data[i] = data[j];
                data[j] = temp;
                j++;
                i--;
            }
            return n;
        }
    }


	private void pushRun(int baseIndex, int len) {
        runsBase[stackTop] = baseIndex;
        runsLen[stackTop] = len;
        stackTop++;
    }


	private int needMerge() {
        if (stackTop > 1) { //  至少两个run序列
            int x = stackTop - 2;
            //x > 0 表示至少三个run序列
            if (x > 0 && runsLen[x - 1] <= runsLen[x] + runsLen[x + 1]) {
                if (runsLen[x - 1] < runsLen[x + 1]) {
                    //说明 runsLen[x+1]是runsLen[x]和runsLen[x-1]中最大的值
                    //应该先合并runsLen[x]和runsLen[x-1]这两段run
                    return --x;
                } else {
                    return x;
                }
            } else if (runsLen[x] <= runsLen[x + 1]) {
                return x;
            } else {
                return -1;
            }
        }
        return -1;
    }


	private int gallopLeft(int[] data, int baseIndex, int len, int value) { 
        int i = baseIndex;
        while (i <= baseIndex + len - 1) {
            if (value >= data[i]) {
                i++;
            } else {
                break;
            }
        }
        return i; 
    }


	private int gallopRight(int[] data, int baseIndex, int len, int value) { 
        int i = baseIndex + len - 1;
        while (i >= baseIndex) {
            if (value <= a[i]) {
                i--;
            } else {
                break;
            }
        }
        return i;
    }


	private void mergeAt(int x) {
		int base1 = runsBase[x];
		int len1 = runsLen[x];

		int base2 = runsBase[x];
		int len2 = runsLen[x];

		runsLen[x] = len1 + len2;
		if (stackTop == x + 3) {
			runsBase[x + 1] = runsBase[x + 2];
			runsLen[x + 1] = runsLen[x + 2];
		}
		stackTop--;

		int from = gallopLeft(a, base1, len1, a[base2]);
		if (from == base1 + len1) {
			return;
		}

		int to = gallopRight(a, base2, len2, a[base1 + len1 - 1]);

		Array.Copy(a, from, aux, from, to - from + 1);
		int i = from;
		int iend = base1 + len1 - 1;

		int j = base2;
		int jend = to;

		int k = from;
		int kend = to;

		while (k <= kend) {
			if (i > iend) {
				a[k] = aux[j++];
			} else if(j > jend) {
				a[k] = aux[i++];
			} else if(aux[i] <= aux[j]) {
				a[k] = aux[i++];
			} else {
				a[k] = aux[j++];
			}
			k++;
		}
	}


	private void forceMerge() { 
        while (stackTop > 1) {
            mergeAt(stackTop - 2);
        }
    }
}