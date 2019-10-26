using Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data
{
    public class HeroRepository
    {
        public List<Hero> data;
        public int Count => this.data.Count();

        public HeroRepository()
        {
            data = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            foreach (var hero in data)
            {
                if(hero.Name==name)
                {
                    data.Remove(hero);
                    return;
                }
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            int strenghtMax = int.MinValue;
            Item item = new Item(0, 0, 0);
            Hero bestHero=new Hero(string.Empty,0,item);

            foreach (var hero in this.data)
            {
                if(hero.Item.Strength>strenghtMax)
                {
                    strenghtMax = hero.Item.Strength;
                    bestHero = hero;
                }
            }
            return bestHero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            int abilityMax = int.MinValue;
            Item item = new Item(0, 0, 0);
            Hero bestHero = new Hero(string.Empty, 0, item);
            foreach (var hero in data)
            {
                if (hero.Item.Strength > abilityMax)
                {
                    abilityMax = hero.Item.Strength;
                    bestHero = hero;
                }
            }
            return bestHero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int intelligenceMax = int.MinValue;
            Item item = new Item(0, 0, 0);
            Hero bestHero = new Hero(string.Empty, 0, item);
            foreach (var hero in data)
            {
                if (hero.Item.Strength > intelligenceMax)
                {
                    intelligenceMax = hero.Item.Strength;
                    bestHero = hero;
                }
            }
            return bestHero;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.data);
        }
    }
}
