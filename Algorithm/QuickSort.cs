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
		public static void Sort(List<int> data) {
			//quickSort(0, data.Count - 1, data.ToArray());

			getPivotWithIntegrate(0, data.Count - 1, data.ToArray());
		}

        public static void Sort(int[] data) {
            //quickSort(0, data.Length - 1, data);

			getPivotWithIntegrate(0, data.Length - 1, data);
		}

		private static void quickSort(int low, int high, int[] data) {
			if (low < high) {
                if(high - low < 10) {
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

		private static int getPivot(int low, int high, int[] data) {
			int midValue = selectPivotMidOfNine(low, high, data);
			Console.WriteLine("midValue = " + midValue);
			while (low < high) {
				while (low < high && midValue <= data[high])
					high--;
				Util.swap(low, high, data);
				Console.WriteLine("current state = " + string.Join(",", data));

				while (low < high && data[low] <= midValue)
					low++;
				Util.swap(low, high, data);
				Console.WriteLine("current state = " + string.Join(",", data));
			}
			return low;
		}

		private static int getPivotWithIntegrate(int low, int high, int[] data) {
			int midValue = selectPivotMidOfNine(low, high, data);
			Console.WriteLine("midValue = " + midValue);
			int lAnchor = low, rAnchor = high, leftIndex = low, rightIndex = high;

			while (low < high) {
				while (low < high && midValue < data[high])
					high--;
				if (midValue == data[high]) {
					Util.swap(high, rightIndex, data);
					rightIndex--;
				} else {
					Util.swap(low, high, data);
				}
				Console.WriteLine("current state = " + string.Join(",", data));

				while (low < high && data[low] < midValue)
					low++;
				if (data[low] == midValue) {
					Util.swap(low, leftIndex, data);
					leftIndex++;
				} else {
					Util.swap(low, high, data);
				}
				Console.WriteLine("current state = " + string.Join(",", data));
			}

			/*
			Console.WriteLine(" ===========聚堆============ ");
			//	聚堆
			for (int i = 0; i < leftIndex - lAnchor; i++)
			{
				Util.swap(lAnchor + i, low - 1 - i, data);
				Console.WriteLine("current state = " + string.Join(",", data));
			}
			for (int i = 0; i < rAnchor - rightIndex; i++)
			{
				Util.swap(low + 1 + i, rAnchor - i, data);
				Console.WriteLine("current state = " + string.Join(",", data));
			}
			*/

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
