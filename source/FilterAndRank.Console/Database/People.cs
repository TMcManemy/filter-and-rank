using System.Collections.Generic;

namespace FilterAndRank.Console.Database
{
    public static class People
    {
        public static readonly IEnumerable<Person> All = new List<Person> {
            new Person("Frank", 1, "USA"),
            new Person("David", 2, "USA"),
            new Person("Amy", 3, "USA"),
            new Person("Dana", 3, "USA"),
            new Person("Jeff", 4, "USA"),
            new Person("Zinsky", 4, "USA"),
            new Person("Pila", 5, "USA"),
            new Person("Nord", 6, "USA"),
            new Person("Frances", 7, "USA"),
            new Person("Lulu", 8, "USA"),
            new Person("Zila", 8, "USA"),
            new Person("Derik", 8, "USA"),
            new Person("Kevin", 9, "USA"),
            new Person("Laurie", 10, "USA"),
            new Person("Maria", 11, "USA"),

            new Person("Jennifer", 1, "Canada"),
            new Person("Stacey", 2, "Canada"),
            new Person("Michael", 3, "Canada"),
            new Person("Faerfy", 4, "Canada"),
            new Person("Lonnie", 5, "Canada"),
            new Person("Zerk", 6, "Canada"),
            new Person("George", 7, "Canada"),
            new Person("Lindsly", 8, "Canada"),
            new Person("Deborah", 9, "Canada"),
            new Person("Tammy", 10, "Canada"),
            new Person("Tamarak", 11, "Canada"),
            new Person("Leah", 12, "Canada"),

            new Person("Amelia", 1, "Mexico"),
            new Person("Pamela", 2, "Mexico"),
            new Person("Ana Sofia", 2, "Mexico"),
            new Person("Maria Fernanda", 3, "Mexico"),
            new Person("Jorge", 4, "Mexico"),
            new Person("Luis", 5, "Mexico"),
            new Person("Pancho", 5, "Mexico"),
            new Person("Francisco", 5, "Mexico"),
            new Person("Denaldo", 5, "Mexico"),
            new Person("Ala", 5, "Mexico"),
            new Person("Paula", 5, "Mexico"),
            new Person("Kimberlia", 5, "Mexico"),
            new Person("Carlos", 5, "Mexico"),
            new Person("Mimi", 6, "Mexico")
        };
    }
}

public class Person
{
    public string Name { get; }
    public int Ranking { get; }
    public string Country { get; }

    public Person(string name, int ranking, string country)
    {
        Name = name;
        Ranking = ranking;
        Country = country;
    }
}
