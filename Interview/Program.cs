using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            char request = 'y';
            while (request != 'n' || request != 'N')
            {
                Console.Clear();
                Console.WriteLine("Enter the Requirement Number to Inspect: ");
                int _case = Convert.ToInt16(Console.ReadLine());
                switch (_case)
                {
                    case 1:
                        //Extension Method
                        Requirement1();
                        break;
                    case 2:
                        //Divisors L.C.M.
                        Requirement2();
                        break;
                    case 3:
                        //Custom Exception Handling
                        Requirement3();
                        break;
                    case 4:
                        //Popular Items in an array
                        Requirement4();
                        break;
                    case 5:
                        //Caesar Cipher
                        Requirement5();
                        break;
                    case 6:
                        //Checked Keyword
                        Requirement6();
                        break;
                    case 7:
                        //DateTime Parsing
                        Requirement7();
                        break;
                    case 8:
                        //Max of 3 Numbers
                        Requirement8();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }

                Console.WriteLine("\n\n Press N to discontinue?");
                request = Convert.ToChar(Console.ReadLine());
            }
        }

        #region MCSA

        private static void Requirement8()
        {
            int[] num = new int[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter number {0} :", (i + 1));
                num[i] = Convert.ToInt16(Console.ReadLine());
            }

            int highestnum = Math.Max(Math.Max(num[0], num[1]), num[2]);
            Console.WriteLine("Highest number :" + highestnum + " Other Max - " + num.Max());
        }

        private static void Requirement7()
        {
            var inputdate = Console.ReadLine();
            bool valid = DateTime.TryParse(inputdate, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal, out DateTime validatedDate);

            Console.WriteLine("\nWhen: " + valid + " New Time: " + validatedDate + " For Input Value: " + inputdate);
        }

        private static void Requirement6()
        {
            int value = 485454201;
            checked
            {
                try
                {
                    int square = value * value;
                    Console.WriteLine("{0} ^ 2 = {1}", value, square);
                }
                catch (OverflowException)
                {
                    double square = Math.Pow(value, 2);
                    Console.WriteLine("Exception Caught: {0} > {1}", square, Int32.MaxValue);
                }
            }
        }

        private static void Requirement5()
        {
            Console.WriteLine("Input Text for Caesar Cipher - Key13");
            string input = Console.ReadLine();
            string output = string.Empty;
            try
            {
                if (input is null || input.Length == 0)
                    Console.WriteLine("Output Text is Empty Or Null. " + output);
                else
                {
                    foreach (char c in input)
                    {
                        if (!char.IsLetter(c))
                            output += c;
                        else
                        {
                            char d = char.IsUpper(c) ? 'A' : 'a';
                            output += (char)(((c + 13 - d) % 26) + d);
                        }
                    }
                    Console.WriteLine("Output Text - Key13: " + output);
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region Interview Questions
        private static void Requirement4()
        {
            Console.WriteLine("Enter the Number of Values:- ");
            try
            {
                int val = Convert.ToInt16(Console.ReadLine());
                int[] sample = new int[val];
                int Counter, temp = 0;
                Console.WriteLine("Values Are:- ");
                for (int i = 0; i < val; i++)
                {
                    Console.WriteLine("Enter the Value : {0} => ", (i + 1));
                    sample[i] = Convert.ToInt16(Console.ReadLine());
                }

                Array.Sort(sample, (a, b) => a.CompareTo(b));

                List<int> Popularitems = new List<int>();
                foreach (int i in sample)
                {
                    Counter = 1;
                    foreach (int j in sample)
                    {
                        if (j == i)
                            Counter++;
                        else
                            Counter = 1;
                        if (Counter == temp)
                            Popularitems.Add(i);
                        if (Counter > temp)
                        {
                            Popularitems.Clear();
                            Popularitems.Add(i);
                            temp = Counter;
                        }
                    }
                }

                Console.WriteLine("The popular values are : \n");

                foreach (int k in Popularitems.Distinct())
                    Console.Write(k + ", ");
            }
            catch (InvalidCastException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();

        }

        private static void Requirement1()
        {
            Console.WriteLine("Enter Sample Text :");
            try
            {
                String strdata = Console.ReadLine();
                if (strdata.IsNullOrEmpty())
                    Console.WriteLine("Not Allowed");
                else
                    Console.WriteLine(strdata);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();

        }

        private static void Requirement2()
        {
            Console.WriteLine("\nEnter a number to get Divisors");
            try
            {
                int.TryParse(Console.ReadLine(), out int num);
                var divisors = new List<int>();
                for (int i = num; i > 0; i--)
                {
                    if (num % i == 0)
                    {
                        divisors.Add(i);
                    }
                }
                Console.WriteLine("All the Divisors are: ");
                foreach (int values in divisors)
                {
                    Console.Write(values + ", ");
                }
            }
            catch (InvalidCastException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();

        }

        private static void Requirement3()
        {
            Console.WriteLine("\nEnter the 3 sides of triangle :");
            int[] sides = new int[3];
            checked
            {
                try
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Enter the Side {0} of triangle :", (i + 1));
                        sides[i] = Convert.ToInt16(Console.ReadLine());
                    }

                    int area = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (sides[i] > 0)
                        {
                            area += sides[i] * sides[i];
                        }
                        else
                            throw new InvalidTriangleException("Invalid Triangle");
                    }

                    int lng = sides.Max();
                    if (lng * lng == area - lng * lng)
                    {
                        Console.WriteLine("Area of the Valid Triangle : " + area);
                    }
                    else
                    {
                        throw new InvalidTriangleException("Invalid Triangle");
                    }
                }
                catch (InvalidTriangleException)
                {
                }
                catch (InvalidCastException)
                {
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.Read();

        }
        #endregion
    }
}