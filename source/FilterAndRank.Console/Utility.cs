using Alba.CsConsoleFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.ConsoleColor;

namespace FilterAndRank.Console
{
    public static class Utility
    {
        public static IEnumerable<Person> FilterAndOrder(IEnumerable<Person> people, IList<string> countries, int minRank, int maxRank, int maxCount)
        {
            if (minRank < 1) throw new ArgumentException("minRank must be greater than 0");
            if (maxRank < 1) throw new ArgumentException("maxRank must be greater than 0");
            if (maxCount < 0) throw new ArgumentException("maxCount must not be a negative number");
            if (minRank > maxRank) throw new ArgumentException("minRank must be equal to or less than maxRank");

            if (maxCount == 0) return Enumerable.Empty<Person>();

            var filteredByCounty = people.Where(x => countries.Contains(x.Country));
            var filteredByRanking = filteredByCounty.Where(x => x.Ranking >= minRank && x.Ranking <= maxRank);
            var ordered = filteredByRanking.OrderBy(x => x.Ranking).ThenBy(x => countries.IndexOf(x.Country)).ThenBy(x => x.Name);

            if (maxCount >= ordered.Count()) return ordered.ToList();

            var lastRanking = ordered.ElementAt(maxCount - 1).Ranking;
            return ordered.Where(o => o.Ranking <= lastRanking);
        }

        static readonly Dictionary<string, ConsoleColor> countryColorMap = new Dictionary<string, ConsoleColor> { { "USA", Blue }, { "Canada", Red }, { "Mexico", Green } };
        static readonly LineThickness header = new LineThickness(LineWidth.None, LineWidth.Double);
        static readonly LineThickness cell = new LineThickness(LineWidth.None, LineWidth.None, LineWidth.Single, LineWidth.None);

        public static Document BuildTableFor(IEnumerable<Person> people)
        {
            return new Document
            {
                Background = Black,
                Color = Gray,
                Children = {
                new Grid
                {
                    StrokeColor = DarkGray,
                    Columns =
                    {
                        new Column { Width = GridLength.Auto },
                        new Column { Width = GridLength.Auto },
                        new Column { Width = GridLength.Auto }
                    },
                    Children = {
                        new Cell("Name") { Stroke = header, Color = White },
                        new Cell("Ranking") { Stroke = header, Color = White },
                        new Cell("Country") { Stroke = header, Color = White },
                        people.Select(p=>new [] {
                        new Cell {
                            Stroke = cell,
                            MinWidth = 10,
                            Children = { p.Name }
                        },
                        new Cell {
                            Stroke = cell,
                            Align = Align.Right,
                            Children = { p.Ranking }
                        },
                        new Cell {
                            Stroke = cell,
                            Color = countryColorMap[p.Country],
                            MinWidth = 10,
                            Children = { p.Country },
                        }
                        })
                    }
                }
                }
            };
        }
    }
}
