using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_CSharp.Algorithm
{
	/// <summary>
	/// 快速排序，原理：分治思想，哨兵思想
	/// </summary>
	public class QuickSort {
        public static void Sort(int[] data) {
			//quickSort(0, data.Length - 1, data);
			//quickSortWithTailRecursion(0, data.Length - 1, data);
			quickSortWithCocktailAndPartition(0, data.Length - 1, data);
		}

		private static void quickSort(int low, int high, int[] data) {			
			if (low < high) {
				if (high - low < 9) {
                    InsertSort.Sort(data, low, high);
                    return;
                } else {
    				int middle = getPivotCocktail(low, high, data);
    				quickSort(low, middle - 1, data);
    				quickSort(middle + 1, high, data);
                }
            }
		}

		/**
		 * 尾递归，减少栈深度，但是效率下降了15%，是代码的问题？
		 * 感觉只是写法换了，栈深度并没有改变
		 */
		private static void quickSortWithTailRecursion(int low, int high, int[] data) {
			int middle;
			while (low < high) {
				middle = getPivot(low, high, data);
				quickSortWithTailRecursion(low, middle, data);
				low = middle + 1;
			}
			return;
		}

		private static int getPivot(int low, int high, int[] data) {
			int midValue = selectPivotMidOfNine(low, high, data);
			while (low < high) {
				while (low < high && midValue <= data[high])
					high--;
				Util.swap(low, high, data);

				while (low < high && data[low] <= midValue)
					low++;
				Util.swap(low, high, data);
			}
			return low;
		}


		private static int getPivotCocktail(int low, int high, int[] data) {
			int a = low;
			int midValue = selectPivotMidOfThree(low, high, data);
			while (low < high) {
				while (low < high && midValue <= data[high])
					high--;
				while (low < high && data[low] <= midValue)
					low++;

				Util.swap(a, high, data);
				Util.swap(low, high, data);
				a = low;
			}
			return low;
		}

		private static void quickSortWithCocktailAndPartition(int low, int high, int[] data) {

			if (high - low < 9)	{
				InsertSort.Sort(data, low, high);
				return;
			}

			int midValue = selectPivotMidOfNine(low, high, data);
			int a = low, b = a, c = high, d = c;
			while (b < c) {
				while (b < c && midValue <= data[c]) {
					if (midValue == data[c])
						Util.swap(c, d--, data);
					c--;
				}

				while (b < c && data[b] <= midValue) {
					if (midValue == data[b])
						Util.swap(a++, b, data);
					b++;
				}

				Util.swap(b++, c--, data);
			}
			int step;
			// 合并
			step = Math.Min(a - low, b - a);
			vecswap(low, b - step, step, data);
			step = Math.Min(high - d, d - c);
			vecswap(b + 1, high - step + 1, step, data);

			if (b - a > 1) { 
				quickSortWithCocktailAndPartition(low, low + b - a - 1, data);
			}
			if (d - c > 1) {
				quickSortWithCocktailAndPartition(high - (d - c) + 1, high, data);
			}
		}


		private static int selectPivotRandom(int low, int high, int[] data) {
			int random = new Random().Next(low, high);
			Util.swap(low, random, data);
			return data[low];
		}

		private static int selectPivotMidOfThree(int low, int high, int[] data) {
			int mid = (low + high) / 2;
			if (data[mid] > data[high])
				Util.swap(mid, high, data);
			if (data[low] > data[high])
				Util.swap(low, high, data);
			if (data[low] < data[mid])
				Util.swap(low, mid, data);

			return data[low];
		}

		private static int selectPivotMidOfNine(int low, int high, int[] data) {
			int length = high - low;
			if (length < 100) {
				return selectPivotMidOfThree(low, high, data);
			}

			int step = length / 8;
			int mid = (low + high) / 2;

			low = MedOfThree(low, low + step, low + 2 * step, data);
			mid = MedOfThree(mid - step, mid, mid + step, data);
			high = MedOfThree(high - 2 * step, high - step, high, data);

			mid = MedOfThree(low, mid, high, data);
			return data[mid];
		}

		private static int medOfThree(int x, int y, int z, int[] data) {
			return data[x] < data[y] ? (data[y] < data[z] ? y : (data[x] < data[z] ? z : x)) 
									 : (data[x] < data[z] ? x : (data[y] < data[z] ? z : y));
		}

        private static int MedOfThree(int x, int y, int z, int[] data) {

            if (data[y] > data[z])
                Util.swap(y, z, data);
            if (data[x] > data[z])
                Util.swap(x, z, data);
            if (data[x] < data[y])
                Util.swap(x, y, data);
            return x;
        }

		private static void vecswap(int a, int b, int n, int[] data) {
			for (int i = 0; i < n; i++, a++, b++)
				Util.swap(a, b, data);
		}
	}




}
