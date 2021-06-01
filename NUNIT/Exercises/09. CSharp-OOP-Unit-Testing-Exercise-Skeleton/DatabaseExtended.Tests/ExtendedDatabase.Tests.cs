using System;
using NUnit.Framework;
using ExtendedDatabase;

namespace Tests
{
    public class ExtendedDatabaseTests
    {

        private ExtendedDatabase.ExtendedDatabase extended;
        [SetUp]


        public void Setup()
        {
            this.extended = new ExtendedDatabase.ExtendedDatabase();
        }
        [Test]
        public void Ctor_ThrowsException_WhenCapacityIsExeeded()
        {
            Person[] arguments = new Person[17];
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"UserName{i}");

            }
            Assert.Throws<ArgumentException>(() => this.extended = new ExtendedDatabase.ExtendedDatabase(arguments));
        }
        [Test]
        public void Ctor_AddInitialPeopleToDataBase()
        {
            int personsToAdd = 5;
            Person[] arguments = new Person[personsToAdd];
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"UserName{i}");

            }
            extended = new ExtendedDatabase.ExtendedDatabase(arguments);
            Assert.That(extended.Count, Is.EqualTo(personsToAdd));

            foreach (var person in arguments)
            {
                Person dbPerson = this.extended.FindById(person.Id);
                Assert.That(person, Is.EqualTo(dbPerson));
            }

        }
        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            LoopPersonToAdd(16); // 16 e капацитета (private фор цикъл метод)

            Assert.Throws<InvalidOperationException>(() => this.extended.Add(new Person(16, "OverFlowCapacity"))); //1 way

            Assert.That(() =>   // 2 way
            {
                this.extended.Add(new Person(16, "OverFlowCapacity"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Add_ThrowsException_WhenNameIsAlreadyOccupied()
        {
            string username = "NameOccupied";
            this.extended.Add(new Person(1, username));


            Assert.Throws<InvalidOperationException>(() => this.extended.Add(new Person(2, username)));
        }
        [Test]
        public void Add_ThrowsException_WhenIDIsAlreadyOccupied()
        {
            int id = 7;
            this.extended.Add(new Person(id, "NameOne"));


            Assert.Throws<InvalidOperationException>(() => this.extended.Add(new Person(id, "NameTwo")));
        }

        [Test]
        public void Add_Persons_CountShouldCorrectylIncrease_WithValidPersonData()
        {
            int numbersOfPersons = 5;
            LoopPersonToAdd(5);

            Assert.That(this.extended.Count, Is.EqualTo(numbersOfPersons), "Count must be equal to numberOfPersons!!");
        }
        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {

            Assert.Throws<InvalidOperationException>(() => this.extended.Remove());

        }
        [Test]
        public void Remove_DecreaseDatabaseCount()
        {
            int personToAdd = 5;
            LoopPersonToAdd(personToAdd);
            // int countBeforeRemove = extendedDatabase.Count;  no need it

            extended.Remove();

            Assert.That(extended.Count, Is.EqualTo(personToAdd - 1), "After one time remove count should be countBeforeRemove -1");


        }
        [Test]
        public void FindByUserName_With_EmptyDatabase()
        {
            string userName = "UserName";

            Assert.That(() => { extended.FindByUsername(userName); }, Throws.InvalidOperationException);

            //throw new InvalidOperationException("No user is present by this username!")

        }
        [Test]
        public void FindByUserName_With_ExistentName()
        {
            Person person = new Person(1, "Duman");
            // Person personTwo = new Person(2, "Duman2"); Just to check test
            extended.Add(person);
            Person findedPerson = extended.FindByUsername(person.UserName);

            Assert.IsNotNull(findedPerson);
            Assert.That(findedPerson, Is.EqualTo(person));

            //throw new InvalidOperationException("No user is present by this username!")

        }
        [Test]
        [TestCase("")]  // може да са няколко аргумента ("", 5) но трябва и долу в метода да иска 2
        [TestCase(null)]
        public void FindByUserName_With_NullSearchParameter(string username) // empty or null
        {
            int numbersOfUsers = 3;
            LoopPersonToAdd(numbersOfUsers);

            Assert.That(() => { extended.FindByUsername(username); }, Throws.ArgumentNullException.With.Message.EqualTo("Value cannot be null. (Parameter 'Username parameter is null!')"));
        }
        [Test]
        public void FindByUserName_WithNonExistent_UserName()
        {
            int numbersOfUsers = 2;
            LoopPersonToAdd(numbersOfUsers);
            string user = "NotUserWithThatName";

            Assert.That(() => { extended.FindByUsername(user); }, Throws.InvalidOperationException);


        }
        [Test]
        [TestCase(-1)]
        [TestCase(-20)]
        public void FindById_ThrowsException_WhenIdIsLessThanZero(int id)
        {

            Assert.Throws<ArgumentOutOfRangeException>(() => { extended.FindById(id); }, "Id should be a positive number!");

        }
        [Test]
        [TestCase(111)]
        [TestCase(55)]
        public void FindById_ThrowsException_WhenIdIsNonExistent(int userIdWeSearch)
        {
            int userToAdd = 3;
            LoopPersonToAdd(userToAdd);



            Assert.Throws<InvalidOperationException>(() => { extended.FindById(userIdWeSearch); }, "No user is present by this ID!");

        }
        [Test]
        public void FindById_CorrectlyFindUser_ById()
        {
            int id = 111;
            Person person = new Person(id, "Duman");
            extended.Add(person);

            Person findedPerson = extended.FindById(id);

            Assert.That(person, Is.EqualTo(findedPerson));
        }


        private void LoopPersonToAdd(int personToAdd)
        {
            string userNameFirstPart = "UserName";
            int addingPersons = personToAdd;
            for (int i = 0; i < addingPersons; i++)
            {
                this.extended.Add(new Person(i, $"{userNameFirstPart}{i}"));
            }
        }


    }
}