using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static List<double> getList()
        {
            int amount = 5;
            String temp = "";
            String prompt = "Enter your sandwich prices";
            List<double> priceList = new List<double>();
            Console.WriteLine(prompt);
            for(int i = 0; i < amount; i++) //runs the amount per sandwich
            {
                temp = Console.ReadLine(); //take input
                double dTemp = 0; //init, dtemp will hold individually entered doubles
                while(!Double.TryParse(temp, out dTemp)) //checks for valid doubles in input
                {
                    Console.WriteLine("Invalid!!\n"+ prompt);
                    temp = Console.ReadLine();
                }
                priceList.Add(dTemp);
            }
            return priceList;
        }

        static void oldmain(string[] args)
        {
            List<double> priceList = getList();
            Console.WriteLine("Your entered values: ");
            Double average = 0;
            Double highest = Int64.MinValue;
            Double lowest = Int64.MaxValue;
            foreach(double d in priceList)
            {
                Console.WriteLine(d);
                average += d;
                if(d > highest)
                    highest = d;
                if(d < lowest)
                    lowest = d;
            }
            Console.WriteLine("Your average: "+average/5);
            Console.WriteLine("Your lowest: "+lowest);
            Console.WriteLine("Your highest: "+highest);
            Console.ReadLine();
        }
    }
}
