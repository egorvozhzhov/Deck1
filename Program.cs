using System;

namespace Deck
{
  class Program
  {
    static void Main(string[] args)
    {
      Sorting sort = new Sorting();

      for (int i = 0; i < 300; ++i)
      {
        var t = new Random();
        sort.AddFirst(t.Next(-100, 100));
      }

      var myStopwatch = new System.Diagnostics.Stopwatch();
      myStopwatch.Start();
      sort.QuickSort(0, sort.Count - 1);
      myStopwatch.Stop();
      Console.WriteLine($@" Количество отсортированных элементов: {sort.Count}. 
        Потрачено времени на выполнение: {myStopwatch.Elapsed}. 
        Количество операций (N_op):  {sort.schet}");
    }
  }
}