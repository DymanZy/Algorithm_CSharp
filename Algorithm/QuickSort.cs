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
			int value = data[low];

			while (low < high) {
				while (low < high && value <= data[high])
					high--;
				Util.swap(low, high, data);
				while (low < high && data[low] <= value)
					low++;
				Util.swap(low, high, data);
			}
			return low;
		}
	}
}
