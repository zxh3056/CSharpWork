using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneAndEvent
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            head = null;
            tail = null;
        }
        public Node<T> Head { get => head; }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void Foreach(Action<T> act)
        {
            Node<T> n = head;
            while(n != null)
            {
                act(n.Data);
                n = n.Next;
            }
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            GenericList<int> list_1 = new GenericList<int>();
            int sum = 0; int max = 0; int min = int.MaxValue;
            for(int i = 0; i <= 10; i++)
            {
                list_1.Add(i);
            }
            list_1.Foreach(m => sum += m);//这个Lambda表达式对应act委托，m就是act委托的参数，所以m就对应于n.Data
            Console.WriteLine(sum);
            list_1.Foreach((m) => max = m > max ? m : max);
            Console.WriteLine(max);
            list_1.Foreach(m => min = m < min ? m : min);
            Console.WriteLine(min);
        }
    }
}
   

