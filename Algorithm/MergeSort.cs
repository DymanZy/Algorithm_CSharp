using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_CSharp.Algorithm
{
	/// <summary>
	/// 归并排序，原理：将两个有序的数列，比较合并成一个有序的数列
	/// </summary>
	public class MergeSort
	{
		public static List<int> Sort(List<int> data) {
			List<int> result = MergeSortOnlyList(data, 0, data.Count - 1);
			return result;
		}


		private static List<int> MergeSortOnlyList(List<int> data, int low, int high) {

			if (low == high)
				return new List<int> { data[low] };

			List<int> mergeList = new List<int>();
			int middle = (low + high) / 2;
			List<int> leftMerge = MergeSortOnlyList(data, low, middle);
			List<int> rightMerge = MergeSortOnlyList(data, middle + 1, high);

			int i = 0, j = 0;
			while (true) {
				if (leftMerge[i] < rightMerge[j]) {
					mergeList.Add(leftMerge[i]);
					if (++i == leftMerge.Count) {
						mergeList.AddRange(rightMerge.GetRange(j, rightMerge.Count - j));
						break;
					}
				} else {
					mergeList.Add(rightMerge[j]);
					if (++j == rightMerge.Count) {
						mergeList.AddRange(leftMerge.GetRange(i, leftMerge.Count - i));
						break;
					}
				}
			}
			return mergeList;
		}
	}
}
