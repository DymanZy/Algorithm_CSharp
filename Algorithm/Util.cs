using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_CSharp.Algorithm
{
	class Util
	{
		public static void swap(int i, int j, List<int> data)
		{
			int temp = data[i];
			data[i] = data[j];
			data[j] = temp;
		}

        public static void swap(int i, int j, int[] data)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
	}
}
