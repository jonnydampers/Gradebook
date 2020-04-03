using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Jon's Chodbook");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);
            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter  grade is {stats.Letter}");

        }

        private static void EnterGrades(IBook book)
        {
            var input = "";
            while (!((String.Equals(input, "q")) || (String.Equals(input, "Q"))))
            {
                Console.WriteLine($"Please enter the next grade or q to quit:");
                input = Console.ReadLine();

                switch (input)
                {
                    case "q":
                        break;

                    case "Q":
                        break;

                    default:
                        try
                        {
                            var grade = double.Parse(input);
                            book.AddGrade(grade);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("**");
                        }
                        break;
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
