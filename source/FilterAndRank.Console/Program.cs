using System;
using Alba.CsConsoleFormat;

namespace FilterAndRank.Console
{
    class Program
    {
        /// <summary>
        /// Demo app for filtering, ordering, and displaying data
        /// </summary>
        /// <param name="country">Country</param>
        /// <param name="minRank">Minimum rank</param>
        /// <param name="maxRank">Maximum rank</param>
        /// <param name="maxCount">How many results to return?</param>
        static void Main(string[] country, int minRank = 1, int maxRank = 15, int maxCount = 5)
        {
            try
            {
                var results = Utility.FilterAndOrder(Database.People.All, country, minRank, maxRank, maxCount);
                var output = Utility.BuildTableFor(results);
                ConsoleRenderer.RenderDocument(output);
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
