using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;
using System;

namespace FilterAndRank.Console.UnitTest
{
    [TestFixture]
    public class Utility
    {
        [TestCase(-1)]
        [TestCase(0)]
        public void Invalid_MinRank_Throws_Exception(int minRank)
        {
            Assert.Throws<ArgumentException>(() => Console.Utility.FilterAndOrder(Database.People.All, new List<string>() { }, minRank, 1, 5));
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void Invalid_MaxRank_Throws_Exception(int maxRank)
        {
            Assert.Throws<ArgumentException>(() => Console.Utility.FilterAndOrder(Database.People.All, new List<string>() { }, 1, maxRank, 5));
        }

        [Test]
        public void Negative_MaxCount_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => Console.Utility.FilterAndOrder(Database.People.All, new List<string>() { }, 1, 1, -1));
        }

        [Test]
        public void MinRank_Greater_Than_MaxRate_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => Console.Utility.FilterAndOrder(Database.People.All, new List<string>() { }, 2, 1, 5));
        }
        
        [Test]
        public void MaxCount_0_Returns_Empty_Collection()
        {
            var actual = Console.Utility.FilterAndOrder(Database.People.All, new List<string>() { "USA" }, 1, 1, 0);

            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public void Canada_Ranked_1()
        {
            var expected = new List<Person>
            {
                new Person("Jennifer", 1, "Canada"),
            };
            var actual = Console.Utility.FilterAndOrder(Database.People.All, new List<string>() { "Canada" }, 1, 1, 5);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Canada_And_Mexico_Max_5()
        {
            var expected = new List<Person>
            {
                new Person("Jennifer", 1, "Canada"),
                new Person("Amelia", 1, "Mexico"),
                new Person("Stacey", 2, "Canada"),
                new Person("Ana Sofia", 2, "Mexico"),
                new Person("Pamela", 2, "Mexico")
            };
            var actual = Console.Utility.FilterAndOrder(Database.People.All, new List<string>() { "Canada", "Mexico" }, 1, 10, 5);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Canada_And_Mexico_Max_3()
        {
            var expected = new List<Person>
            {
                new Person("Jennifer", 1, "Canada"),
                new Person("Amelia", 1, "Mexico"),
                new Person("Stacey", 2, "Canada"),
                new Person("Ana Sofia", 2, "Mexico"),
                new Person("Pamela", 2, "Mexico")
            };
            var actual = Console.Utility.FilterAndOrder(Database.People.All, new List<string>() { "Canada", "Mexico" }, 1, 10, 3);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Mexico_And_Canada_Max_5()
        {
            var expected = new List<Person>
            {
                new Person("Amelia", 1, "Mexico"),
                new Person("Jennifer", 1, "Canada"),
                new Person("Ana Sofia", 2, "Mexico"),
                new Person("Pamela", 2, "Mexico"),
                new Person("Stacey", 2, "Canada")
            };
            var actual = Console.Utility.FilterAndOrder(Database.People.All, new List<string>() { "Mexico", "Canada" }, 1, 10, 5);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void USA_9_To_20_Max_2()
        {
            var expected = new List<Person>
            {
                new Person("Kevin", 9, "USA"),
                new Person("Laurie", 10, "USA"),
            };
            var actual = Console.Utility.FilterAndOrder(Database.People.All, new List<string>() { "USA" }, 9, 20, 2);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void USA_12()
        {
            var actual = Console.Utility.FilterAndOrder(Database.People.All, new List<string>() { "USA" }, 12, 12, 2);

            CollectionAssert.IsEmpty(actual);
        }
    }
}
