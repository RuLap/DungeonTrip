using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTests
    {
        [Test]
        public void PlayerStatsTest()
        {
            PlayerStats stats = PlayerStats.LoadFromJson();
            Assert.IsNotNull(stats);
        }

        [Test]
        public void PlayerXPCreateTest()
        {
            PlayerXP xp = PlayerXP.LoadFromJson("PlayerXP");
            Assert.IsNotNull(xp);
        }

        [Test]
        public void PlayerXPAddPointsTest()
        {
            PlayerXP xp = PlayerXP.LoadFromJson("PlayerXP");
            xp.points = 0;
            int points = 1;
            xp.AddPoints(1);
            Assert.IsTrue(xp.points == points);

            xp.points = xp.maxPoints - 1;
            int lvl = xp.currentLevel;
            xp.AddPoints(2);
            Assert.IsTrue(xp.currentLevel == (lvl + 1));
        }

        [Test]
        public void PlayerXPGetFillAmountTest()
        {
            PlayerXP xp = PlayerXP.LoadFromJson("PlayerXP");
            xp.points = 0;
            Assert.IsTrue(xp.GetFillAmount() == 0);

            xp.points = xp.maxPoints / 2;
            Assert.IsTrue(xp.GetFillAmount() == 0.5);

            xp.points = xp.maxPoints;
            xp.AddPoints(2);
            Assert.IsTrue(xp.GetFillAmount() <= 1);
        }
    }
}
