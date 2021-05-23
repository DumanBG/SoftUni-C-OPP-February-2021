using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack;
    private int durability;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp() //Arange
    {
        attack = 5;
        durability = 6;
        axe = new Axe(attack, durability);
        dummy = new Dummy(5, 6);
    }
    [Test]
    public void When_AxeDurabilityPointsAreZero_ShouldThrowExeption() // Аssert.Exception !!!!!! NBBBBBB!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        dummy = new Dummy(100, 2); // hp . XP Иначе думи умира преди да падне дурабилити. Понеже е привайте сет. Не можем да увеличим хелта и правим ново

        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
         {
             for (int i = 0; i < durability + 1; i++)
             {
                 axe.Attack(dummy);
             }

         });
        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }
    [Test]
    public void SameTestForDurabily_SecondWay() // Аssert.Exception !!!!!! NBBBBBB!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        dummy = new Dummy(100, 2); //Иначе думи умира преди да падне дурабилити. Понеже е привайте сет. Не можем да увеличим хелта и правим ново
        string exceptionMessage = string.Empty;
        try
        {
            for (int i = 0; i < durability + 1; i++)
            {
                axe.Attack(dummy);
            }
        }
        catch (InvalidOperationException ex)
        {
            exceptionMessage = ex.Message;
        }
        Assert.That(exceptionMessage, Is.EqualTo("Axe is broken."));

    }
   
    [Test]
    public void When_AxeAttackIsCalledWithNullDummy_ShouldThroNullReffException()
    {

        Assert.Throws<NullReferenceException>(() =>   // Работи, тествано и с др. екс  InvalidOperationException
        {
            axe.Attack(null);
        });
        }
    [Test]
    public void When_AxeAttackAndDurabilityProvided_ShouldBeSetCorrectyly()
    {


        Assert.AreEqual(axe.DurabilityPoints, durability, "Axe durability points are not correcty initialized");
        Assert.AreEqual(axe.AttackPoints, attack, "Axe atack points are not correcty initialized");
    }
    [Test]
    public void When_AxeAttacks_ShouldLooseDurabilityPoints()
    {
        int axeInitialDurability = axe.DurabilityPoints;
        axe.Attack(dummy);

        //  Assert.That(axeInitialDurability, Is.GreaterThan(axe.DurabilityPoints), "Axe should loose 1 durability after attack");
        Assert.AreEqual(durability - 1, axe.DurabilityPoints, "Axe should loose 1 durability after attack");
    }

}

