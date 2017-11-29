using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_CSharp.Algorithm
{
	/// <summary>
	/// 选择排序法，原理：找出最小值，放到末尾
	/// </summary>
	public class SelectionSort
	{
		public static void Sort(List<int> data)
		{
			for (int i = 0; i < data.Count(); i++)
			{
				int minIndex = i;
				int temp = data[i];

				for (int j = i + 1; j < data.Count(); j++)
				{
					if (data[j] < temp)
					{
						minIndex = j;
						temp = data[j];
					}
				}

				if (minIndex != i)
				{
					Util.swap(i, minIndex, data);
				}
			}
		}
	}
}
