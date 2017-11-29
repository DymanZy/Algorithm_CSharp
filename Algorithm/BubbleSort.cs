using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_CSharp.Algorithm
{
	/// <summary>
	/// 冒泡排序法
	/// </summary>
	public class BubbleSort
	{
		public static void Sort(List<int> data)
		{
			
			bool isChanged = false;
			for (int i = 0; i < data.Count; i++)
			{
				isChanged = false;
				for (int j = data.Count - 1; j > i; j--)
				{
					if (data[j-1] > data[j])
					{
						isChanged = true;
						Util.swap(j-1, j, data);
					}
				}

				if (!isChanged)
					break;
			}
		}
	}
}
