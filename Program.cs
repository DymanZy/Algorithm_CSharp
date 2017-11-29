using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithm_CSharp.Algorithm;

namespace Algorithm_CSharp
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());

			List<int> data = new List<int>();
			Random rd = new Random();

			for (int i = 0; i < 20; i++)
			{
				data.Add(rd.Next(1, 100));
			}

			//BubbleSort.Sort(data);
			//CocktailSort.Sort(data);
			//MergeSort.Sort(data);
			SelectionSort.Sort(data);
			string arr = string.Join(",", data);
			Console.WriteLine("arr = " + arr);
		}
	}
}
