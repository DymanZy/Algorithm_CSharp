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
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (data[j] < data[j - 1])
                    {
                        Util.swap(j, j - 1, data);
                    }
                    else
                    {
                        break;
                    }
                }
            }
		}
	}
}
