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

			if (high - low < 15) {
				//	长度小于15则使用直接插入排序，效率可提高35%
				List<int> insertList = data.GetRange(low, high - low + 1);
				InsertSort.Sort(insertList, 0, insertList.Count - 1);
				return insertList;
			}

			List<int> mergeList = new List<int>();
			int middle = (low + high) / 2;
			List<int> leftMerge = MergeSortOnlyList(data, low, middle);
			List<int> rightMerge = MergeSortOnlyList(data, middle + 1, high);

			//	当两个子数组已经有序，直接合并
			if (leftMerge[leftMerge.Count - 1] <= rightMerge[0]) {
				mergeList = leftMerge;
				mergeList.AddRange(rightMerge.GetRange(0, rightMerge.Count));
				return mergeList;
			}

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
