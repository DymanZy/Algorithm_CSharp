using System;
using System.Collections.Generic;
namespace Algorithm_CSharp.Algorithm
{
	/// <summary>
	/// 桶排序，原理：空间换时间。取出若干个桶，将数据放到对应桶中，然后将空桶剔除，完成排序。
	/// </summary>
    public class BucketSort
    {
        public static List<int> Sort(List<int> data, int maxNumber) {
            int[] sorted = new int[maxNumber + 1];
            for (int i = 0; i < data.Count; i++) {
                sorted[data[i]] = data[i];
            }

            int index = 0;
            foreach(int v in sorted) {
                if(v > 0) {
                    data[index] = v;
                    index++;
                }
            }

            return data;

        }
    }
}
