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
        int n = expenditure.Length; //5
        int i = d;  //3
        int notifications = 0;
        List<int> lastExp = expenditure.Take(d).OrderBy(x => x).ToList();   //[10, 20,30]
        if (d % 2 != 0)
        {
            int index = (d - 1) / 2; //1
            for (; i < n; i++)
            {
                lastExp = expenditure.Take(d).OrderBy(x => x).ToList();   //[10, 20,30]
                int median = lastExp[index];    //20
                if (expenditure[i] > median)    //40
                    notifications++;
            }
        }
        else
        {
            int index1 = d/2-1; //1
            int index2 = d/2; //1

            for (; i < n; i++)
            {
                lastExp = expenditure.Take(d).OrderBy(x => x).ToList();   //[10, 20,30]
                int median = (lastExp[index1]+ lastExp[index2])/2;    //20
                if (expenditure[i] > median)    //40
                    notifications++;
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

        Console.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
