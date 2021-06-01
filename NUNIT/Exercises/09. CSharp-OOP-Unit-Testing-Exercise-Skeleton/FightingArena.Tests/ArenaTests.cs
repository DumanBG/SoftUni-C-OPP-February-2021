
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }
        [Test]
        public void Ctor_InitializedWorriers()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }
        [Test]
        public void Count_IsZero_WhenArenaIsEmpty()
        {
            Assert.That(arena.Count, Is.EqualTo(0));
        }
        [Test]
        public void Enrol_ThrowsException_WhenTryToAddSameWarriorNameMoreTimes()
        {
            string name = "warrior";

            this.arena.Enroll(new Warrior(name, 10, 100));

            Assert.Throws<InvalidOperationException>(() =>
            { this.arena.Enroll(new Warrior(name, 50, 80)); }, "Warrior is already enrolled for the fights!");

        }
        [Test]
        public void Enrol_ReadOnlineGetAddedWarriorByName()
        {
            string name = "Duman";
            arena.Enroll(new Warrior(name, 50, 100));

            Assert.That(this.arena.Warriors.Any(w => w.Name == name), Is.True);

        }
        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void Enrol_EncreasesArenaCount(int warriorToAdd)
        {
            for (int i = 0; i < warriorToAdd; i++)
            {
                Warrior warrior = new Warrior($"w{i}", 50, 100);
                arena.Enroll(warrior);
            }
            Assert.That(warriorToAdd, Is.EqualTo(arena.Count));
        }
        
        [Test]
        public void Fight_ThrowsException_WhenAttackerDeosNotExist()
        {
            string attacker = "Attacker";
            string missingName = "Defender";

            this.arena.Enroll(new Warrior(attacker, 50, 100));

            Assert.Throws<InvalidOperationException>(() => { arena.Fight(attacker, missingName); },
                $"There is no fighter with name {missingName} enrolled for the fights!");
        }
        [Test]
        public void Fight_ThrowsException_WhenDeffenderDeosNotExist()
        {
            string deffender = "Defender";
            string missingName = "Attacker";

            this.arena.Enroll(new Warrior(deffender, 50, 100));

            Assert.Throws<InvalidOperationException>(() => { arena.Fight(missingName, deffender); },
                $"There is no fighter with name {missingName} enrolled for the fights!");

        }
        [Test]
        public void Fight_ThrowsException_WhenBothDoesNotExist()
        {
            string defender = "deff";
            string attacker = "atack";
            Assert.Throws<InvalidOperationException>(() => { arena.Fight(attacker, defender); });
        }
        [Test]
        public void Fight_CorrectAtack_WithExistBothWarriorsAndLooseHp()
        {
            int attackerHpBefore = 100;
            int defenderHpBefore = 110;
            Warrior attacker = (new Warrior("Attacker", 50, attackerHpBefore));
            
            arena.Enroll(attacker);
           Warrior defender = (new Warrior("Defender", 50, defenderHpBefore));
            arena.Enroll(defender);
            this.arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP,Is.EqualTo(attackerHpBefore - defender.Damage));
            Assert.That(defender.HP,Is.EqualTo(defenderHpBefore - attacker.Damage));


        }

    }

}

