using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private int dummyHealt;
    private int dummyExp;
    private Dummy dummy;
    private Dummy deadDummy;


    [SetUp]
    public void SetUp()
    {
        dummyHealt = 10;
        dummyExp = 10;
        dummy = new Dummy(dummyHealt, dummyExp);
        deadDummy = new Dummy(0, dummyExp);

    }
    [Test]
    public void When_HealtIsProvided_ShouldBeSetCorrectly()
    {


        Assert.That(dummyHealt, Is.EqualTo(dummy.Health), "dummy healt should be setted correctly at 10");


    }
    [Test]
    public void When_DummyIsAtaccked_ShouldLooseHealt()
    {

        int atackPoints = 3;

        dummy.TakeAttack(atackPoints);

        Assert.That(dummy.Health, Is.EqualTo(dummyHealt - atackPoints), "Dummy HP must be decreased after atack");

    }
    [Test]
    public void When_HealthIsPositive_ShouldBeAllieve()
    {

        Assert.That(dummy.IsDead(), Is.EqualTo(false), "With initial positive HP, dummy must be Alive!");



    }
    [Test]
    public void When_InitialHealthIsZero_ShouldBeDead()
    {
        

        Assert.That(deadDummy.IsDead(), Is.EqualTo(true), "Whit initial 0 HP, dummy should be dead!!");
    }
    [Test]
    public void When_NegativeInitialHealth_ShouldBeDead()
    {
        Dummy negativeHpDummy = new Dummy(-1, dummyExp);

        Assert.That(negativeHpDummy.IsDead(), Is.EqualTo(true), "Whit initial HP = -1, dummy should be dead!!");
    }

    [Test]
    public void DeadDummyWhenAttacked_ShouldThrowInvalidOperationException()
    {
        

        Assert.That(() => 
        {
            deadDummy.TakeAttack(3);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));

        //  Exception ex = Assert.Throws<InvalidOperationException>(() => { dummy.TakeAttack(1); });

        //Assert.AreEqual(ex.Message, "Dummy is dead.");
    }
    [Test]
    public void AlliveDummy_ShouldNotGiveEXP_Should_ThrowInvalidOperationException()
    {
        Assert.That(() =>
        {
            dummy.GiveExperience(); // Живо
        }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));

        //Exception ex = Assert.Throws<InvalidOperationException>(() =>
        //{
        //    dummy.GiveExperience();
        //});

        //Assert.AreEqual(ex.Message, "Target is not dead.");
    }
    [Test]
    public void DeadDummy_should_GiveExp()
    {
     
        //NB!!!!! GiveExperience() return int exp points. They must be equal than dummyExp
        Assert.That(deadDummy.GiveExperience(),Is.EqualTo(dummyExp), "when dummy is dead, should give exp");


    }
}
