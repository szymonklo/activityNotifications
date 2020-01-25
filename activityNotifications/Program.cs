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
        List<int> lastExp = expenditure.Take(d).OrderBy(x => x).ToList();
        List<int> newLastExp = new List<int>();

        if (d % 2 != 0)
        {
            int index = (d - 1) / 2;
            for (; i < n; i++)
            {
                int exp = expenditure[i];
                int median2 = 2 * lastExp[index];
                if (exp >= median2)
                {
                    //Console.WriteLine($"Exp: {exp}, 2*Med:{median2}");
                    notifications++;
                }
                for (int j = 0; j < d; j++)
                {
                    if (exp < lastExp[j])
                    {
                        newLastExp.Clear();
                        newLastExp.AddRange(lastExp.Take(j));
                        newLastExp.Add(exp);
                        newLastExp.AddRange(lastExp.Skip(j).Take(d-j));
                        lastExp.Clear();
                        lastExp.AddRange(newLastExp);
                        break;
                    }
                }
                if (exp > lastExp[(d - 1)])
                {
                    //newLastExp.Clear();
                    List<int> newLastExp2 = new List<int>(lastExp.Skip(1).Take(d - 1));
                    newLastExp2.Add(exp);
                    lastExp.Clear();
                    lastExp.AddRange(newLastExp2);
                }
            }
        }
        else
        {
            int index1 = d/2-1;
            int index2 = d/2;

            for (; i < n; i++)
            {
                int exp = expenditure[i];
                int median2 = 2 * (lastExp[index1]+ lastExp[index2])/2;    //20
                if (expenditure[i] >= median2)
                {
                    //Console.WriteLine($"Exp: {exp}, 2*Med:{median2}");
                    notifications++;
                }
                for (int j = 0; j < d; j++)
                {
                    if (exp < lastExp[j])
                    {
                        newLastExp.Clear();
                        newLastExp.AddRange(lastExp.Take(j));
                        newLastExp.Add(exp);
                        newLastExp.AddRange(lastExp.Skip(j).Take(d - j));
                        lastExp.Clear();
                        lastExp.AddRange(newLastExp);
                        break;
                    }
                }
                if (exp > lastExp[(d - 1)])
                {
                    //newLastExp.Clear();
                    List<int> newLastExp2 = new List<int>(lastExp.Skip(1).Take(d - 1));
                    newLastExp2.Add(exp);
                    lastExp.Clear();
                    lastExp.AddRange(newLastExp2);
                }
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
        int result = activityNotifications(expenditure, d);
        //Console.Clear();
        Console.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
