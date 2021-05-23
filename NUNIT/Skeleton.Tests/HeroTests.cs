using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private string heroName;
    private Hero hero;
    // int experience = 0;
    //Axe axe = new Axe(10, 10);
    [SetUp]
    public void SetUp()
    {
        heroName = "Duman";
         hero = new Hero(heroName);

    }

    [Test]
    public void HeroName_Should_InitialCorrectly()
    {
        Assert.That(heroName, Is.EqualTo(hero.Name),"Hero name should be Duman!");

    }
    [Test]
    public void HeroEXP_Should_InitialCorrectlyWithZero()
    {

        Assert.That(hero.Experience, Is.EqualTo( 0), "After kill dummy should take 10XP!");
    }
    [Test]
    public void HeroInitWeapon_ShouldBeAxe10to10()
    {
        Axe axeInitAxe = new Axe(10, 10);
        
        Assert.That(axeInitAxe.ToString(), Is.EqualTo(hero.Weapon.ToString()), "Initial weapon should be Axe");
    }

    [Test]
    public void HeroExp_ShouldEncreaseAfterKillDummy()
    {
        Dummy dummy = new Dummy(1, 10);

        hero.Attack(dummy);


        Assert.That(hero.Experience > 0, "After kill dummy should take 10XP!");

    }
    [Test]
    public void HeroExp_ShouldNotEncreaseAfter_WhenNotKillDummy()
    {
        Dummy dummy = new Dummy(100, 10);
        int initHeroExp = 0;

        hero.Attack(dummy);


        Assert.That(hero.Experience == initHeroExp, "After attack that not kill dummy should not take XP!");

    }

}