using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_CSharp.Algorithm
{
	/// <summary>
	/// 鸡尾酒冒泡排序，原理：来回双向冒泡排序
	/// </summary>
	public class CocktailSort
	{
		public static void Sort(List<int> data)
		{
			bool isChanged = false;
			int leftIndex = 0, rightIndex = 0;
			for (int i = 0; i < data.Count; i++)
			{
				if (i % 2 == 0)
				{
					for (int j = leftIndex; j < data.Count - rightIndex - 1; j++)
					{
						if (data[j] > data[j + 1])
						{
							isChanged = true;
							Util.swap(j, j + 1, data);
						}
					}

					if (!isChanged)
						break;
					rightIndex++;
				}
				else
				{
					for (int k = data.Count - rightIndex; k > leftIndex; k--)
					{
						if (data[k - 1] > data[k])
						{
							isChanged = true;
							Util.swap(k - 1, k, data);
						}
					}

					if (!isChanged)
						break;
					leftIndex++;
				}
			}

		}
	}
}