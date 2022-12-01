using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment5
{
    [TestFixture]
    internal class CharacterTest
    {
        private Character hero;
        private int HeroHP = 100;

        [SetUp]
        public void SetUp()
        {
            hero = new Character("Bob", RaceCategory.Human, HeroHP);
        }

        [TearDown]
        public void CleanUp()
        {
            hero = null;
        }

        [Test]
        public void TakeDamage()
        {
            int Damage = 120;
            hero.TakeDamage(Damage);
            Assert.AreEqual((Damage > HeroHP) ? 0 : HeroHP - Damage, hero.Health);
            Assert.IsFalse(hero.IsAlive);
        }

        [Test]
        public void RestoreHealth()
        {
            int HPtoAdd = 150;
            hero.RestoreHealth(HPtoAdd);
            Assert.IsTrue(hero.IsAlive);
        }
    }
}
