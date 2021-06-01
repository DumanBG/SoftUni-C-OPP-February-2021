using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private const int dataBaseCapacity = 16;
        private Database.Database dataBase;  //За да се прати в Judje find all Coppy na Database.Database  i replaceAll s Database
        [SetUp]
        public void Setup()
        {
            this.dataBase = new Database.Database();
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsIxceeded()
        {

            for (int i = 0; i < dataBaseCapacity; i++)
            {
                dataBase.Add(i);
            }

            Assert.That(() =>
            {
                dataBase.Add(17);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void Add_IncreaseDataBaseCount_WhenAddIsSucceded()
        {
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                this.dataBase.Add(123);

            }

            Assert.That(n, Is.EqualTo(dataBase.Count), "DataBase count must be equal to n !");
        }
        [Test]
        public void Add_AddsElementToDatabase()
        {
            int newElement = 123;
            this.dataBase.Add(newElement);

            int[] coppiedElements = dataBase.Fetch();

            Assert.IsTrue(coppiedElements.Contains(newElement), "NewElements is not in the new fletched array!");
        }
        [Test]
        public void Remove_ThrowException_WhenDatabaseIsEmpty()
        {

            Assert.That(() =>
            {
                dataBase.Remove();
            }, Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));

        }

        [Test]
        public void Remove_ElementAndCount_ShouldDecrease()
        {
            int n = 3;
            for (int i = 0; i < n; i++)
            {
                dataBase.Add(i);
            }

            dataBase.Remove();

            Assert.IsTrue(n > dataBase.Count, "After remove counter should be < n !");

        }

        [Test]
        public void Remove_LastElement_ShouldBeRemoved()
        {
            int lastElement = 3;
            dataBase.Add(1);
            dataBase.Add(2);
            dataBase.Add(lastElement);
            dataBase.Remove();

            int[] elements = dataBase.Fetch();

            Assert.IsFalse(elements.Contains(lastElement), "After remove lastElement must be out of the database");
        }

        [Test]
        public void Fetch_ReturnsDatabseCopy_InsteadOfReference() //!!!!!!!!!!!!!!!!!!!!!!
        {
            this.dataBase.Add(1);
            this.dataBase.Add(2);
            this.dataBase.Add(3);
            int[] firstCoppy = dataBase.Fetch();
            
            dataBase.Add(4);
            int[] secondCoppy = dataBase.Fetch();
      
            Assert.That(firstCoppy, Is.Not.EqualTo(secondCoppy),"Second coppy should have one more element, They must not be the same");
        }

        [Test]

        public void InitialDatabaseCounterInEmptyDatabase_ShouldBeZero()
        {

            Assert.That(dataBase.Count, Is.EqualTo(0));
        }
        [Test]
        public void Ctor_ThrowsExeption_whenDatabaseCapacityIsExtended()
        {
            int [] arr = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            Assert.That(() =>
            {
            Database.Database  databaseWith16Limit = new Database.Database(arr);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));

        }
        [Test]
        public void Ctor_AddsElementsToDataBaseCorectyl()
        {
            int[] arr = new[] { 1, 2, 3, 4, };
            Database.Database database = new Database.Database(arr);

            Assert.That(database.Count, Is.EqualTo(arr.Length));
            Assert.That(database.Fetch(), Is.EquivalentTo(arr));   // NB !!!! Is.EquivalentTo  Дали 2 колекции съдържат едни и същи елементи!!!!!!!!!!!!!!!!!!!!!!!!!
           
        }
    }
}