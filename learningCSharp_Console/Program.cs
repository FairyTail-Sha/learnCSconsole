
#region Using 
using System;
using static System.Console;
using System.Diagnostics;
#endregion

#region 主程序
namespace Csharp学习
{
    class Program
    {
        delegate double ProcessDelegate(double param1, double param2);
        static double Multiply(double param1, double param2) => param1 * param2;
        static double Divide(double param1, double param2) => param1 / param2;
        struct CustomerName
        {
            public string firstName, lastName;
            public string Name() => firstName + " " + lastName;
        }
        struct order
        {
            public string itemName;
            public int unitCount;
            public double unitCost;
            public double GetSum()
            {
                return unitCount * unitCost;
            }
            public string Show()
            {
                return $"Order Information: {this.unitCount} " +
                    $"{this.itemName} items at ${this.unitCost} each, " +
                    $"total cost ${this.GetSum()}";
            }
        }
        //static void Main(string[] args)
        //{
        //    #region 数组测试
        //    // string[] friendNames = { "Qa Ws", "Ws Es", "Esa Rt" };
        //    // int [][] jag = {new int[] {1,2,3},
        //    //                 new int[] {2,3,4,5},
        //    //                 new int[] {9,5,6,7,8}};
        //    // Console.WriteLine($"Here are {friendNames.Length} of my friends!");
        //    // for(int i = 0; i<friendNames.Length;i++)
        //    // {
        //    //     Console.WriteLine(friendNames[i]);
        //    // }
        //    // foreach(string s in friendNames)
        //    // {
        //    //     Console.WriteLine(s);
        //    // }
        //    #endregion
        //    #region 字符串测试

        //    // string myString = "A string";
        //    // char[] myChar = myString.ToCharArray();
        //    // foreach(char character in myChar){
        //    //     Console.WriteLine($"{character}");
        //    // }

        //    // string myString = Console.ReadLine();
        //    // WriteLine($"You typed {myString.Length} characters.");

        //    // string userResponse = ReadLine();
        //    // char[] trimChars = {' ', 'e','s'};
        //    // //删除字符串前后的空格 
        //    // userResponse = userResponse.Trim(trimChars: trimChars);
        //    // if(userResponse.ToLower() == "y")
        //    // {
        //    //     WriteLine($"YES!");
        //    // }

        //    // string myString = "Aligned";
        //    // WriteLine($"You typed {myString.Length} characters.");
        //    // myString = myString.PadRight(10,'+');
        //    // WriteLine($"myString has {myString.Length} characters.");
        //    // WriteLine($"myString is {myString}");

        //    // string myString = "This is a test.";
        //    // char[] separator = {' '};
        //    // string[] myWords;
        //    // myWords = myString.Split(separator);
        //    // foreach(string word in myWords){
        //    //     WriteLine($"*{word}*");
        //    // }
        //    // ReadKey();

        //    #endregion
        //    #region 日历测试
        //    // MyTime myTime = new MyTime(2018,1,20);
        //    //WriteLine($"2017,10,21是{myTime.GetWeek()}");
        //    // myTime.ShowCalender();
        //    #endregion
        //    #region 函数测试
        //    // double n = double.Parse(ReadLine());
        //    // double m = double.Parse(ReadLine());
        //    // WriteLine($"{n} * {m} = {Product(n,m)}");
        //    //WriteLine($"sum of (1~5) = {SumVals(1,2,3,4,5)}");
        //    ///out输出参数
        //    //SumVals(new int[]{1,2,3,4,5},out int sum);
        //    //WriteLine($"sum of (1~5) = {sum}");
        //    ///ref值参数
        //    //SumVals(ref sum);
        //    //WriteLine($"sum +sum of (1~5) = {sum}");
        //    ///Main()函数
        //    //WriteLine($"{args.Length} command line arguments were apecified:");
        //    //foreach(string arg in args)
        //    //{
        //    //    WriteLine(arg);
        //    //}
        //    ///结构函数
        //    //CustomerName myCustomer;
        //    //myCustomer.firstName = "Jhon";
        //    //myCustomer.lastName = "Franklin";
        //    //WriteLine(myCustomer.Name());
        //    //ReadKey();
        //    ///委托 delegate
        //    //ProcessDelegate process;
        //    //WriteLine("Enter 2 number separated with a comma:");
        //    //string input = ReadLine();
        //    //int commaPos = input.IndexOf(',');
        //    //double param1 = double.Parse(input.Substring(0, commaPos));
        //    //double param2 = double.Parse(input.Substring(commaPos + 1, input.Length - commaPos - 1));
        //    //WriteLine("Enter M to multiply or D to divide:");
        //    //input = ReadLine();
        //    //if(input=="M")
        //    //{
        //    //    process = new ProcessDelegate(Multiply);
        //    //}
        //    //else
        //    //{
        //    //    process = new ProcessDelegate(Divide);
        //    //}
        //    //WriteLine($"Result: {process(param1, param2)}");
        //    //order myoder = new order();
        //    //myoder.itemName = "螺丝";
        //    //myoder.unitCost = 0.5;
        //    //myoder.unitCount = 200;
        //    //WriteLine(myoder.Show());
        //    //ReadKey();
        //    #endregion
        //    #region 调试和错误处理
        //    //int[] testArray = { 4, 7, 4, 2, 7, 3, 7, 8, 3, 9, 1, 9 };
        //    //int[] maxValIndices;
        //    ////找出最大元素，并记录最大元素出现的次数
        //    //int maxVal = Maxima(testArray, out maxValIndices);
        //    //WriteLine($"Maximum value {maxVal} found at element indices:");
        //    ////Debug.Assert(maxVal > 10, "myVal is 10 or greater.", "Assertion occurred in Main()");
        //    ////Trace.Assert(maxVal > 10, "Variable out of bounds", "Please contact vendor with the error code KCW001.");
        //    //foreach (int index in maxValIndices)
        //    //{
        //    //     WriteLine(index);
        //    //}
        //    //错误处理
        //    //int[] myMrray = new int[] { 1, 2, 3, 4, 5 };
        //    //int m = myMrray[5];
        //    //ReadLine();
        //    #endregion
        //}
        private static int Maxima(int[] integers, out int[] indices)
        {
            //Debug.WriteLine("Maximum value search started.");
            indices = new int[1];
            int maxVal = integers[0];
            indices[0] = 0;
            int count = 1;
            //Debug.WriteLine(string.Format(
            //    $"Maximum value initialized to {maxVal}, at element index 0."));
            for (int i = 1; i < integers.Length; i++)
            {
                //Debug.WriteLine(string.Format(
                //    $"Maximum value inialized to {maxVal}, at element index 0."));
                if (integers[i] > maxVal)
                {
                    maxVal = integers[i];
                    count = 1;
                    indices = new int[1];
                    indices[0] = i;
                    //Debug.WriteLine(string.Format(
                    //    $"New maximum found. New value is {maxVal}, at element index {i}."));
                }
                else
                {
                    if (integers[i] == maxVal)
                    {
                        count++;
                        int[] oldIndices = indices;
                        indices = new int[count];
                        oldIndices.CopyTo(indices, 0);
                        indices[count - 1] = i;
                        //Debug.WriteLine(string.Format(
                        //    $"Duplicate maximum found at element index {i}."));
                    }
                }
            }
            //Trace.WriteLine(string.Format(
            //    $"Maximum value {maxVal} found, with {count} occurrence."));
            //Debug.WriteLine("Maximum value search completed.");
            return maxVal;
        }
        private static double Product(double number1, double number2) => number1 * number2;
        private static int SumVals(params int[] vals)
        {
            int sum = 0;
            foreach (int val in vals)
            {
                sum += val;
            }
            return sum;
        }
        private static void SumVals(int[] vals, out int sum)
        {
            sum = 0;
            foreach (int val in vals)
            {
                sum += val;
            }
        }
        private static void SumVals(ref int sum)
        {
            int[] vals = new int[] { 1, 2, 3, 4, 5 };
            foreach (int val in vals)
            {
                sum += val;
            }
        }
        private static void MyFunc(string s) => WriteLine($"{s} is showing.");
    }

}
#endregion