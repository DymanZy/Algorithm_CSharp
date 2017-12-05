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
	public class QuickSort
	{
		public static void Sort(List<int> data)
		{
			quickSort(0, data.Count - 1, data);
		}

		private static void quickSort(int low, int high, List<int> data)
		{
			if (low < high) {
				int middle = getPivot(low, high, data);
				quickSort(low, middle - 1, data);
				quickSort(middle + 1, high, data);
			}

		}

		private static int getPivot(int low, int high, List<int> data)
		{
			int midValue = selectPivotMidOfNine(low, high, data);
			//int midValue = selectPivotMidOfThree(low, high, data);
			//int midValue = selectPivotRandom(low, high, data);
			//int midValue = data[low];

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

		private static int selectPivotMidOfThree(int low, int high, List<int> data) {
			int mid = (low + high) >> 1;
			if (data[mid] > data[high])
				Util.swap(mid, high, data);
			if (data[low] > data[high])
				Util.swap(low, high, data);
			if (data[low] > data[mid])
				Util.swap(low, mid, data);

			return data[mid];
		}

		private static int selectPivotMidOfNine(int low, int high, List<int> data) {
			int length = high - low;
			if (length < 40) {
				return selectPivotMidOfThree(low, high, data);
			}

			int step = length / 8;
			int mid = (low + high) >> 1;

			low = medOfThree(low, low + step, low + 2 * step, data);
			mid = medOfThree(mid - step, mid, mid + step, data);
			high = medOfThree(high - 2 * step, high - step, high, data);

			mid = medOfThree(low, mid, high, data);
			return data[mid];
		}


		private static int medOfThree(int x, int y, int z, List<int> data) {
			return data[x] < data[y] ? (data[y] < data[z] ? y : (data[x] < data[z] ? z : x)) 
									 : (data[x] < data[z] ? x : (data[y] < data[z] ? z : y));
		}
	}
}
