using System;
namespace Algorithm_CSharp.Algorithm
{
    /// <summary>
    /// Heap sort.
    /// </summary>
    public class HeapSort {
        
        public static void Sort(int[] list) {
            Console.WriteLine("排序前： " + string.Join(",", list));
            //  循环建立初始堆
            for (int i = list.Length / 2; i >= 0; i--) {
                HeapAdjust(list, i, list.Length);
            }
            Console.WriteLine("最大堆： " + string.Join(",", list));

            //  进行 n-1 次循环，完成排序
            for (int i = list.Length - 1; i > 0; i--) {
                int temp = list[i];
                list[i] = list[0];
                list[0] = temp;

                HeapAdjust(list, 0, i);
                Console.WriteLine("一次排序之后： " + string.Join(",", list));
            }
        }


        /// <summary>
        /// parent 为当前结点
        /// 左孩子结点为： 2 * i + 1
        /// 右孩子结点为： 2 * i + 2
        /// 父结点为   ： (i-1) / 2
        /// </summary>
        private static void HeapAdjust(int[] array, int parent, int length) {
            int temp = array[parent];       // temp保存当前父节点
            int child = 2 * parent + 1;     // 先获得左孩子

            while (child < length) {
                // 如果有右孩子结点，并且右孩子结点的值大于左孩子结点，则选取右孩子结点
                if(child + 1 < length && array[child] < array[child + 1]) {
                    child++;
                }

                // 如果父结点的值已经大于孩子结点的值，则直接结束
                if (temp >= array[child]) {
                    break;
                }

                // 把孩子结点的值赋给父结点
                array[parent] = array[child];

                // 选取孩子结点的左孩子结点，继续向下筛选
                parent = child;
                child = 2 * child + 1;
            }

            array[parent] = temp;
        }
    }
}
