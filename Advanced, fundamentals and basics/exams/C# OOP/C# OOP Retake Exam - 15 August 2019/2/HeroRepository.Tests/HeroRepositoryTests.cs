using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void TestWhenHeroIsNull()
    {
        string name = null;
        var level = 15;
        var heroRepo = new HeroRepository();

        var hero = new Hero(name,level);

        Assert.Throws<ArgumentNullException>(() => heroRepo.Create(null));
    }
    [Test]
    public void TestWhenHeroAlreadyExist()
    {
        string name = "Ivan1";
        var level = 15;
        var heroRepo = new HeroRepository();

        var hero = new Hero(name, level);
        heroRepo.Create(hero);

        var anotherHero = new Hero("Ivan1", 15);

        Assert.Throws<InvalidOperationException>(() => heroRepo.Create(anotherHero));
    }
    [Test]
    public void SuccessefulAddedHero()
    {
        string name = "Ivan1";
        var level = 15;
        var heroRepo = new HeroRepository();

        var hero = new Hero(name, level);

        Assert.AreEqual($"Successfully added hero {name} with level {level}", heroRepo.Create(hero));
    }
    [TestCase(null)]
    [TestCase("")]
    public void TestWhenRemoveNameIsNullOrWhiteSpace(string name)
    {
        var level = 15;
        var heroRepo = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => heroRepo.Remove(name));
    }

    [Test]
    public void SuccessfullyRemovedHero()
    {
        var name = "Ivan1";
        var level = 15;
        var heroRepo = new HeroRepository();

        var hero = new Hero(name, level);
        heroRepo.Create(hero);

        Assert.AreEqual(true, heroRepo.Remove(name));
    }

    [Test]
    public void GetHeroWithighestLevel()
    {
        var name1 = "Ivan1";
        var level1 = 15;
        var name2 = "Ivan2";
        var level2 = 10;
        var heroRepo = new HeroRepository();

        var hero1 = new Hero(name1, level1);
        var hero2 = new Hero(name2, level2);
        heroRepo.Create(hero1);
        heroRepo.Create(hero2);

        Assert.AreEqual(hero1, heroRepo.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroByName()
    {
        var name1 = "Ivan1";
        var level1 = 15;
        var name2 = "Ivan2";
        var level2 = 10;
        var heroRepo = new HeroRepository();

        var hero1 = new Hero(name1, level1);
        var hero2 = new Hero(name2, level2);
        heroRepo.Create(hero1);
        heroRepo.Create(hero2);

        Assert.AreEqual(hero1, heroRepo.GetHero(name1));
    }

}