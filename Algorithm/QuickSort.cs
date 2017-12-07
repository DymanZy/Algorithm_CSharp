﻿using System;
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
		public static void Sort(List<int> data) {
			//quickSort(0, data.Count - 1, data.ToArray());
		}

        public static void Sort(int[] data) {
			quickSort(0, data.Length - 1, data);
			//quickSortWithTailRecursion(0, data.Length - 1, data);
		}

		private static void quickSort(int low, int high, int[] data) {
			if (low < high) {
				//	经验值为8
                if(high - low < 9) {
                    //  使用直接插入排序，实测提高约 3%
                    InsertSort.Sort(data, low, high);
                    return;
                } else {
                    //  使用快排
    				int middle = getPivot(low, high, data);
    				quickSort(low, middle - 1, data);
    				quickSort(middle + 1, high, data);
                }
            }
		}

		//	尾递归，减少栈深度，但是效率下降了15%，是代码的问题？
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

		private static int selectPivotRandom(int low, int high, List<int> data) {
			int random = new Random().Next(low, high);
			Util.swap(low, random, data);
			return data[low];
		}

		private static int selectPivotMidOfThree(int low, int high, int[] data) {
			int mid = (low + high) >> 1;
			if (data[mid] > data[high])
				Util.swap(mid, high, data);
			if (data[low] > data[high])
				Util.swap(low, high, data);
			if (data[low] > data[mid])
				Util.swap(low, mid, data);

			return data[mid];
		}

		private static int selectPivotMidOfNine(int low, int high, int[] data) {
			int length = high - low;
			if (length < 100) {
				return selectPivotMidOfThree(low, high, data);
			}

			int step = length / 8;
			int mid = (low + high) >> 1;

			low = MedOfThree(low, low + step, low + 2 * step, data);
			mid = MedOfThree(mid - step, mid, mid + step, data);
			high = MedOfThree(high - 2 * step, high - step, high, data);

			mid = MedOfThree(low, mid, high, data);
			return data[mid];
		}

		private static int medOfThree(int x, int y, int z, List<int> data) {
			return data[x] < data[y] ? (data[y] < data[z] ? y : (data[x] < data[z] ? z : x)) 
									 : (data[x] < data[z] ? x : (data[y] < data[z] ? z : y));
		}

        //  交换比不交换的效率提高20%
        private static int MedOfThree(int x, int y, int z, int[] data) {

            if (data[y] > data[z])
                Util.swap(y, z, data);
            if (data[x] > data[z])
                Util.swap(x, z, data);
            if (data[x] > data[y])
                Util.swap(x, y, data);
            return y;
        }

	}
}
