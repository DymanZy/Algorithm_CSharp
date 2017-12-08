using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SimpleTimSort
{

	private static int MIN_MERGE = 16;
	private int[] a;
	private int[] aux;

	private int[] runsBase = new int[40];
	private int[] runsLen = new int[40];
	private int stackTop = 0;


	public static void Sort(int[] data) {
	}


	private void inserSort(int[] data, int from, int to, int n) { }


	private int maxAscendingLen(int[] data, int from) { return 1; }


	private void pushRun(int baseIndex, int len) { }


	private int needMerge() { return -1; }


	private int gallopLeft(int[] data, int baseIndex, int len, int value) { return 0; }


	private int gallopRight(int[] data, int baseIndex, int len, int value) { return 0; }


	private void mergeAt(int x) { }


	private void forceMerge() { }
}