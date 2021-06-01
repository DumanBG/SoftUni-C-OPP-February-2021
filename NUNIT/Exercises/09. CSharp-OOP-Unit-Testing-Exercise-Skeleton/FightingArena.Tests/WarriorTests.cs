
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private string name;
        private int damage;
        private int hp;
        private Warrior warrior;
        private Warrior secondWarrior;
        private int MIN_ATTACK_HP = 30;

        [SetUp]
        public void Setup()
        {
            name = "Duman";
            damage = 10;
            hp = 100;
            warrior = new Warrior(name, damage, hp);
            secondWarrior = new Warrior(name + "Two", damage, hp);
        }

        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void Name_ThrowsException_WhenNullOrEmpty(string nameOfTheWarrior)
        {
            Assert.Throws<ArgumentException>(() => 
            warrior = new Warrior(nameOfTheWarrior, this.damage, this.hp), "Name should not be empty or whitespace!");
        }
        [Test]
        public void Name_ShouldBeCorrectlyAdded()
        {
            string name = "Predator";
                this.warrior = new Warrior(name, this.damage, this.hp);
            
            Assert.That(name, Is.EqualTo(this.warrior.Name));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-10)]
             public void Damage_ThrowsArgumentException_WithNegativeOrZero(int dmg)
        {
            Assert.Throws<ArgumentException>(()=>
            warrior = new Warrior(this.name, dmg, this.hp), "Damage value should be positive!");
        }
        [Test]
        [TestCase(1)]
        [TestCase(10)]
        public void Damage_CorrectlyAdded_WithPositiveValue(int dmg)
        {
            warrior = new Warrior(this.name, dmg, this.hp);
            
            Assert.That(dmg, Is.EqualTo(this.warrior.Damage));
        }
        [Test]
        [TestCase(-10)]
        [TestCase(-1)]
        public void HP_ThrowsException_ShouldBeSet_Whit_PositiveValue(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            { warrior = new Warrior(this.name, this.damage, hp); }, 
            "HP should not be negative!");

        }
        [Test]
        [TestCase(10)]
        [TestCase(0)]
        public void HP_ShouldBeSet_Whit_PositiveValueCorrectly(int hp)
        {
            int searchedHp = hp;
            warrior = new Warrior(name, damage, hp);
         
            Assert.That(searchedHp, Is.EqualTo(warrior.HP));
        }
        [Test]
        [TestCase(30)]
        [TestCase(30 - 1)]
        public void Atack_ThrowsInvalidOperationException_IfSelfHpIsLowerThanMinAtackNeeded(int hp)
        {
            warrior = new Warrior(name, damage, hp);
          
            Assert.Throws<InvalidOperationException>(() => { warrior.Attack(secondWarrior); },
                "Your HP is too low in order to attack other warriors!");

        }
        [Test]
        [TestCase(30)]
        [TestCase(30-1)]
        public void Atack_ThrowsInvOpException_IfSecondWarriorHpIsLowerThanMinAtackNeeded(int hpp)
        {
            
            secondWarrior = new Warrior(name, damage, hpp);
            Assert.Throws<InvalidOperationException>(() => { warrior.Attack(secondWarrior); },
                $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }
            [Test]
            public void Atack_ThrowsInvalidOperationException_WhenYourHpIsLowerThanEnemyDmg()
        {
            int ownHp = this.damage -1;
            warrior = new Warrior(this.name, this.damage, ownHp);

            Assert.Throws<InvalidOperationException>(() => { warrior.Attack(secondWarrior); },
                "You are trying to attack too strong enemy");

        }
        [Test]
        public void Atack_CorrectlyEnemyWarrior_OwnHPShouldDecrease()
        {
            int hpBeforeBattle = warrior.HP;
            warrior.Attack(secondWarrior);
          
            Assert.That(hpBeforeBattle - secondWarrior.Damage, Is.EqualTo(warrior.HP));
        }
        [Test]
        public void Atack_CorrectlyEnemyWarrior_EnemyHPShouldDecrease()
        {
            int hpBeforeBattle = secondWarrior.HP;
            warrior.Attack(secondWarrior);

            Assert.That(hpBeforeBattle - warrior.Damage, Is.EqualTo(secondWarrior.HP));
        }
        [Test]
        [TestCase(999)]
        [TestCase(100)]
        public void Atack_KillEnemyWarrior_WithHigherDmg(int atackerDmg)
        {
            
            warrior = new Warrior(this.name, atackerDmg, this.hp);
            secondWarrior = new Warrior(this.name+"2", this.damage, this.hp);

            warrior.Attack(secondWarrior);

            Assert.That(secondWarrior.HP, Is.EqualTo(0));


        }

    }
}