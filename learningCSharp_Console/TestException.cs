using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace learningCSharp_Console
{   class TestException
    {
        static string[] eTypes = { "none", "simple", "index", "neated index", "filter" };
        enum Orientation:byte
        {
            North = 1,
            South = 2,
            East = 3,
            West = 4
        }

        private static void T2(string[] args)
        {
            
            Orientation myDirction;
            for(byte myByte = 2; myByte < 10; myByte++)
            {
                try
                {
                    myDirction = checked((Orientation)myByte);
                    if(myDirction < Orientation.North || myDirction > Orientation.West)
                    {
                        throw new ArgumentOutOfRangeException("myByte", myByte, "Value must be between 1 and 4");
                    }

                }
                catch (ArgumentOutOfRangeException e)
                {
                    //If this section is reached then myByte<1 or myByte>4
                    WriteLine(e.Message);
                    WriteLine("Assigning default value, Orientation.North.");
                    myDirction = Orientation.North;
                }
                WriteLine($"myDirction = {myDirction}");
                WriteLine();
            }
            ReadKey();            
        }
        private static void T1()
        {
            foreach(string eType in eTypes)
            {
                try
                {
                    WriteLine("Main try block reached.");
                    WriteLine($"ThrowException(\"{eType}\") called.");
                    ThrowException(eType);
                    WriteLine("Main() try block continues.");
                }
                catch (System.IndexOutOfRangeException e)when(eType == "filter")
                {
                    WriteLine("Main() FILTERED System.IndexOutOfRangeException" +
                        $"catch block reached.Message:\n\"{e.Message}\"");
                }
                catch
                {
                    WriteLine("Main() general catch block reached.");
                }
                finally
                {
                    WriteLine("Main() finally block reached");
                }
                WriteLine();
            }
            ReadKey();
        }
        private static void ThrowException(string ExceptionType)
        {
            WriteLine($"ThrowException(\"{ExceptionType}\") reached.");
            switch (ExceptionType)
            {
                case "none":
                    WriteLine("Not throwing an exception.");
                    break;
                case "simple":
                    WriteLine("Throwing System.Exception.");
                    throw new System.Exception();
                case "index":
                    WriteLine("Throwing System.IndexOutOfRangeException.");
                    eTypes[5] = "errer";
                    break;
                case "neated index":
                    try
                    {
                        WriteLine("ThrowException(\"nested index\")" +
                            "try block reached.");
                        WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index");
                    }
                    catch
                    {
                        WriteLine("ThrowException(\"nested index\") general" +
                            "catch block reached.");
                    }
                    finally
                    {
                        WriteLine("ThrowException(\"nested index\") finally" +
                            " block reached."); 
                    }
                    break;
                case "filter":
                    try
                    {
                        WriteLine("ThrowException(\"filter\")" +
                            "try block reached.");
                        WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index");
                    }
                    catch
                    {
                        WriteLine("ThrowException(\"filter\") general catch block reached.");
                    }
                    break;
            }
            //throw new NotImplementedException();
        }
    }
}
