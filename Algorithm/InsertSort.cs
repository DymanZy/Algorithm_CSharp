using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_CSharp.Algorithm
{
	/// <summary>
	/// 插入排序，原理：取出未排序的数，插入到已排序的数列中
	/// </summary>
	public class InsertSort
	{
		public static void Sort(List<int> data) {
			for (int i = 1; i < data.Count; i++) {
				for (int j = i - 1; j >= 0; j--) {

					if (data[j] > data[j + 1]) {
						Util.swap(j, j + 1, data);	//	这样是插入排序？！ 2233
					} else {
						break;
					}
				}
			}
		}
	}
}
