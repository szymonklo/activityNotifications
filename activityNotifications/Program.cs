using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the activityNotifications function below.
    static int activityNotifications(int[] expenditure, int d)
    {
        int n = expenditure.Length;
        int i = d;
        int notifications = 0;
        int[] counters = new int[200];
        //Queue queue = new Queue(expenditure.Take(d).ToArray());

        if (d % 2 != 0)
        {
            for (i = 0; i < d; i++)
            {
                int exp = expenditure[i];
                counters[exp]++;
            }
            int numToMed = 0;
            int median = 0;
            for (int j = 0; j < 200; j++)
            {
                numToMed += counters[j];
                if (numToMed >= (d + 1) / 2)
                {
                    median = j;
                    break;
                }
            }
            for (; i < n; i++)
            {
                int exp = expenditure[i];
                int expToDelete = expenditure[i - d];
                if (exp >= 2*median)
                {
                    Console.WriteLine($"Exp: {exp}, 2*Med:{median}");
                    notifications++;
                }
                counters[exp]++;
                counters[expToDelete]--;
                numToMed = 0;
                for (int j = 0; j < 200; j++)
                {
                    numToMed += counters[j];
                    if (numToMed >= (d + 1) / 2)
                    {
                        median = j;
                        break;
                    }
                }
            }
        }
        else
        {
            for (i = 0; i < d; i++)
            {
                int exp = expenditure[i];
                counters[exp]++;
            }
            int numToMed = 0;
            int median1 = 0;
            int median2 = 0;
            bool m1Found = false;

            for (int j = 0; j < 200; j++)
            {
                numToMed += counters[j];
                if (numToMed >= d/2 && numToMed >= d / 2 + 1)
                {
                    if (!m1Found)
                        median1 = j;
                    median2 = j;
                    break;
                }
                else if (numToMed >= d / 2  && numToMed < d / 2 + 1)
                {
                    median1 = j;
                    m1Found = true;
                }
            }
            double median = 0.5*(median1 + median2);
            //median /= 2;
            for (; i < n; i++)
            {
                int exp = expenditure[i];
                int expToDelete = expenditure[i - d];
                if (exp >= 2 * median)
                {
                    Console.WriteLine($"Exp: {exp}, 2*Med:{median}");
                    notifications++;
                }
                counters[exp]++;
                counters[expToDelete]--;
                numToMed = 0;
                m1Found = false;
                for (int j = 0; j < 200; j++)
                {
                    numToMed += counters[j];
                    if (numToMed >= d / 2 && numToMed >= d / 2 + 1)
                    {
                        if (!m1Found)
                            median1 = j;
                        median2 = j;
                        break;
                    }
                    else if (numToMed >= d / 2 && numToMed < d / 2 + 1)
                    {
                        median1 = j;
                        m1Found = true;
                    }
                }
                median = 0.5 * (median1 + median2);

            }
        }
        return notifications;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp))
        ;
        //DateTime start = DateTime.Now;
        int result = activityNotifications(expenditure, d);
        //Console.WriteLine(DateTime.Now-start);
        //Console.Clear();
        Console.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
