using System;

namespace MoodAnalyserApplication
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MoodAnalyser obj = new MoodAnalyser("iam so happy today");
            string message = obj.AnalyseMood();
            Console.WriteLine(message);
        }
    }
}
