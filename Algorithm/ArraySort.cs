/********************************************************************
	created:	2017/12/08
	filename: 	ArraySort.cs
	author:		dyman
	
	purpose:	Java中Array.Sort()的源码
*********************************************************************/
using System;

public class ArraySort {

	public static void Sort(int[] data) {
		sort1(data, 0, data.Length);
	}

	private static void sort1(int[] x, int off, int len) {
		if (len < 7) {
			//	直接插入排序
			for (int i = off; i < len + off; i++)
				for (int j = i; j > off && x[j - 1] > x[j]; j--)
					swap(x, j, j - 1);
			return;
		}

		//	基准点的选择（三点式、九点式）
		int m = off + (len >> 1);
		if (len > 7) {
			int l = off;
			int n1 = off + len - 1;
			if (len > 40) {
				int step = len / 8;
				l = med3(x, l, l + step, l + 2 * step);
				m = med3(x, m - step, m, m + step);
				n1 = med3(x, n1 - 2 * step, n1 - step, n1);
			}
			m = med3(x, l, m, n1);
		}
		int v = x[m];

		//	分堆
		int a = off, b = a, c = off + len - 1, d = c;
		while (true)
		{
			while (b <= c && x[b] <= v)
			{
				if (x[b] == v)
					swap(x, a++, b);
				b++;
			}
			while (c >= b && x[c] >= v)
			{
				if (x[c] == v)
					swap(x, c, d--);
				c--;
			}
			if (b > c)
				break;
			swap(x, b++, c--);
		}

		//	聚合
		int s, n = off + len;
		s = Math.Min(a - off, b - a); vecswap(x, off, b - s, s);
		s = Math.Min(d - c, n - d - 1); vecswap(x, b, n - s, s);

		//	递归
		if ((s = b - a) > 1)
			sort1(x, off, s);
		if ((s = d - c) > 1)
			sort1(x, n - s, s);
	}

	private static void swap(int[] x, int a, int b)
	{
		int t = x[a];
		x[a] = x[b];
		x[b] = t;
	}


	private static void vecswap(int[] x, int a, int b, int n)
	{
		for (int i = 0; i < n; i++, a++, b++)
			swap(x, a, b);
	}

	/**
     * Returns the index of the median of the three indexed integers.
     */
	private static int med3(int[] x, int a, int b, int c)
	{
		return (x[a] < x[b] ?
				(x[b] < x[c] ? b : x[a] < x[c] ? c : a) :
				(x[b] > x[c] ? b : x[a] > x[c] ? c : a));
	}
}

