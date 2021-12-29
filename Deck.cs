using System;

namespace Deck
{
  public class Node
  {
    public int data;
    public Node next = null;
    public Node previous = null;
  }

  public class Deck
  {
    private Node Head;
    private Node Tail;
    protected int count;
    public ulong schet;

    public Deck()
    {
      count = 0;
      Head = null;
      Tail = null;
      schet = 0;
      schet += 3;
    }

    public void AddFirst(int value)
    {
      schet += 2;
      if (Head == null)
      {
        Head = new Node();
        Head.data = value;
        Tail = Head;
        schet += 6;
      }
      else
      {
        Node temp = Head;
        Head = new Node();
        Head.next = temp;
        Head.data = value;
        temp.previous = Head;
        schet += 10;
      }

      count++;
    }

    public void AddLast(int value)
    {
      schet += 2;
      if (Tail == null)
      {
        Tail = new Node();
        Tail.data = value;
        Head = Tail;
        schet += 6;
      }
      else
      {
        Node temp = Tail;
        Tail = new Node();
        Tail.previous = temp;
        Tail.data = value;
        temp.next = Tail;
        schet += 10;
      }

      count++;
    }

    public int PopLast()
    {
      schet += 2;
      if (IsEmpty())
        throw new NullReferenceException("Дек пуст!");
      schet += 2;
      int res = Tail.data;
      schet += 1;
      if (count == 1)
      {
        count--;
        schet += 2;
        return res;
      }

      Node temp = Tail.previous;


      Tail = temp;
      Tail.next = null;
      count--;
      schet += 7;
      return res;
    }

    public int PopFirst()
    {
      schet += 2;
      if (IsEmpty())
        throw new NullReferenceException("Дек пуст!");
      schet += 2;
      int res = Head.data;
      schet += 1;
      if (count == 1)
      {
        schet += 2;
        count--;
        return res;
      }


      Node temp = Head.next;
      Head = temp;
      Head.previous = null;
      count--;
      schet += 7;
      return res;
    }


    public void Print()
    {
      Node temp = Head;
      while (temp != null)
      {
        Console.Write(temp.data + " ");
        temp = temp.next;
      }
      Console.WriteLine();
    }

    public int PeekFirst() => !IsEmpty() ? Head.data : throw new Exception("Пусто");
    public int PeekLast() => !IsEmpty() ? Tail.data : throw new Exception("Пусто");

    public bool IsEmpty() => Head == null;

    public int Count
    {
      get => count;
    }
    public int Get(int position)
    {
      schet += 4;
      if (position < 0 || position > Count)
        throw new Exception("Перепроверьте введенные данные");

      int size = Count;
      schet += 3;
      for (int i = 0; i < position; ++i)
      {
        AddLast(PopFirst());
        schet += 4;
      }

      int result = PeekFirst();
      schet += 2;

      for (int i = position; i < size; ++i)
      {
        AddLast(PopFirst());
        schet += 4;
      }
      schet += 1;
      return result;
    }

    public void Set(int position, int val)
    {
      schet += 5;
      if (position < 0 || position > Count)
        throw new Exception("Перепроверьте введенные данные");

      int size = Count;
      schet += 3;
      for (int i = 0; i < position; ++i)
      {
        AddLast(PopFirst());
        schet += 4;
      }
      PopFirst();
      schet += 2;
      AddFirst(val);
      schet += 2;
      for (int i = position; i < size; ++i)
      {
        schet += 4;
        AddLast(PopFirst());
      }
    }

    public void Swap(int i, int j)
    {
      int temp = Get(i);
      Set(i, Get(j));
      Set(j, temp);
      schet += 7;
    }

  }

  public class Sorting : Deck
  {
    private int Partition(int start, int end)
    {
      int x = Get((start + end) / 2);
      int i = start;
      int j = end;
      schet += 10;
      while (i <= j)
      {
        while (Get(j) > x) { --j; schet += 3; };
        while (Get(i) < x) { ++i; schet += 3; };
        schet += 1;
        if (i >= j)
          break;
        Swap(i++, j--);
        schet += 3;
      }
      schet += 1;
      return j;

    }

    public int FindPivot(int i, int j, int k)
    {
      schet += 3;
      if (Get(i) > Get(j))
      {
        schet += 3;
        if (Get(k) > Get(i)) { schet += 4; return i; };
        schet += 3;
        if (Get(j) > Get(k))
        {
          schet += 4;
          return j;
        }
        else return k;
      }
      schet += 3;
      if (Get(k) > Get(j))
      {
        schet += 4;
        return j;
      }
      schet += 4;
      return Get(i) > Get(k) ? i : k;
    }
    public void QuickSort(int start, int end)
    {
      schet += 2;
      if (start < end)
      {
        schet += 1;
        int p = FindPivot(start, (start + end) / 2, end);
        schet += 4;
        Swap(p, (start + end) / 2);
        schet += 3;
        int q = Partition(start, end);
        schet += 2;
        schet += 2;
        QuickSort(start, q);
        QuickSort(q + 1, end);
      }
    }
  }
}