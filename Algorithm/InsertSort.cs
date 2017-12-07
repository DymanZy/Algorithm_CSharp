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
		public static void Sort(int[] a) {
            int temp;  
            int j;  
            for(int i=1;i<a.Length;i++){  
                if(a[i]<a[i-1]){  
                    temp = a[i];  
                    j = i;  
                    do{  
                        a[j] = a[j-1];  
                        j--;  
                    }while(j>0&&a[j-1]>temp);  
                    a[j] = temp;  
                }  
            }  
		}


        public static void Sort(int[] a, int low, int high)
        {
            int temp;
            int j;
            for (int i = 1 + low; i <= high; i++)
            {
                if (a[i] < a[i - 1])
                {
                    temp = a[i];
                    j = i;
                    do
                    {
                        a[j] = a[j - 1];
                        j--;
                    } while (j > 0 && a[j - 1] > temp);
                    a[j] = temp;
                }
            }
        }
	}
}
