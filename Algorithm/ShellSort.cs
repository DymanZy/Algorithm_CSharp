using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_CSharp.Algorithm
{
	/// <summary>
	/// 希尔排序（凌波微步），原理：也是插入排序的一种，但使用的是特别的插入步长
	/// </summary>
	public class ShellSort
	{
		public static void Sort(int[] data) {
			int gap, i, j, temp;
			int length = data.Length;
			for (gap = length / 2; gap > 0; gap /= 2)
			{
				for (i = gap; i < length; i++)
				{
					for (j = i - gap; j >= 0 && data[j] > data[j + gap]; j -= gap)
					{
						temp			= data[j];
						data[j]			= data[j + gap];
						data[j + gap]	= temp;
					}
				}
			}
		}
	}
}
