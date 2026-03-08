using System.Numerics;
using System.Collections.Generic;
using System;
namespace work_3_6
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello world"); //Task1
            Task2 task2 = new Task2();
            int batchSize = 10; 
            int firstnumber = task2.input();
            int lastnumber = task2.input();
            for(int i = firstnumber; i <= lastnumber; i++)
            {
                task2.checkNumber(i);
            }
            Task2.PrintListByBatch(task2.array, batchSize);
        }
    }


    class Task2
    {
        public List<int>array = new List<int>();
        public bool isPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void checkNumber(int number)
        {
            if(isPrime(number))
            {
                array.Add(number);
            }
        }
        public int input()
        {
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }
       public static void PrintListByBatch(List<int> list, int batchSize)
    {
        if (list == null || list.Count == 0)
        {
            Console.WriteLine("List为空，无内容可输出！");
            return;
        }

        int currentCount = 0;
        foreach (int num in list)
        {
            Console.Write(num + " ");
            currentCount++;

            if (currentCount % batchSize == 0)
            {
                Console.WriteLine(); // 换行
            }
        }
        if (currentCount % batchSize != 0)
        {
            Console.WriteLine();
        }
    }
    }
}