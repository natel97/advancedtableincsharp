using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            begin:
            Console.Title = "Created by Nathanial Lubitz";
            int beginA = 0;
            int beginB = 0;
            int endA = 0;
            int endB = 0;
            string input;
            Console.WriteLine("Enter a value: ");
            input = Console.ReadLine();
            while (!getValues(ref input, ref beginA, ref endA))
            {
                Console.WriteLine("Error! Please try again!");
                input = Console.ReadLine();
            }
            Console.WriteLine("Enter B value: ");
            input = Console.ReadLine();
            while (!getValues(ref input, ref beginB, ref endB))
            {
                Console.WriteLine("Error! Please try again!");
                input = Console.ReadLine();
            }
            bool isCalculating = true;
            int total = endA - beginA + 1;
            double currentPos = 0.00;
            string result = "";
            double time = 0.00;
            new Thread(() =>
            {

                Thread.CurrentThread.IsBackground = true;
                int amnt = 1;
                var watch = System.Diagnostics.Stopwatch.StartNew();
                watch.Start();

                for (int aLoop = beginA; aLoop <= endA; aLoop++)
                {
                    result += "\n\n" + aLoop + " * x\n\n";
                    for (int bLoop = beginB; bLoop <= endB; bLoop++)
                    {
                            result += "\n" + aLoop + " * " + bLoop + " = " + aLoop * bLoop + "\t";
                            
                      
                    }
                    
                    currentPos = (double)(aLoop - beginA) / (endA - beginA + 1);
                }
                watch.Stop();
                time = watch.Elapsed.TotalMilliseconds;
                isCalculating = false;

            }).Start();
            int pos = 1;
            string loading = "Loading..";
            while (isCalculating)
            {
                if (!isCalculating)
                    return;
                Console.Clear();
                switch (pos)
                {
                    case 1:
                        Console.WriteLine(loading + "\t\t--------------------\t" + currentPos.ToString("##.##%"));
                        break;
                    case 2:
                        Console.WriteLine(loading + "\t\t////////////////////\t" + currentPos.ToString("##.##%"));
                        break;
                    case 3:
                        Console.WriteLine(loading + "\t\t||||||||||||||||||||\t" + currentPos.ToString("##.##%"));
                        break;
                    case 4:
                        Console.WriteLine(loading + "\t\t\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\t" + currentPos.ToString("##.##%"));
                        pos = 0;
                        loading += ".";
                        break;
                }
                Console.WriteLine("Part a => {0}; Part b => {1}", beginA == endA ? beginA.ToString() : "Begin: " + beginA.ToString() + ", End: " + endA.ToString(), beginB == endB ? beginB.ToString() : "Begin: " + beginB.ToString() + ", End: " + endB.ToString());
                pos++;
                if (loading.Length > 13)
                    loading = "loading..";
                if ((endA - beginA) * (endB - beginB) > 28000 || endA - beginA > 2000)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Warning: Contents of output may not fit within screen! Some results may be lost!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Thread.Sleep(100);
            }

            Thread.Sleep(1000);
            Console.WriteLine(result);
            Console.WriteLine("Part a => {0}; Part b => {1}", beginA == endA ? beginA.ToString() : "Begin: " + beginA.ToString() + ", End: " + endA.ToString(), beginB == endB ? beginB.ToString() : "Begin: " + beginB.ToString() + ", End: " + endB.ToString());
            Console.WriteLine("Made {0} calculations in {1} Milliseconds", (endA - beginA + 1) * (endB - beginB + 1), time.ToString());
            Console.ReadLine();
            goto begin;

        }
        
            private static bool getValues(ref string input, ref int retA, ref int retB)
        {
            bool secondPart = false;
            string partA = "";
            string partB = "";
            foreach (char ii in input)
            {
                if (ii == '-')
                {
                    secondPart = true;
                }
                if (!secondPart && ii != '-')
                {
                    partA += ii;
                }
                else if (secondPart && ii != '-')
                {
                    partB += ii;
                }
            }
            try
            {
                retA = Convert.ToInt32(partA);
                if (partB != "")
                {
                    retB = Convert.ToInt32(partB);
                }
                else
                {
                    retB = retA;
                }
                if (retA > retB)
                    return false;
                else
                    return true;
            }
            catch
            {
                retA = 0;
                retB = 0;
                return false;
            }
        }
        
    }
}