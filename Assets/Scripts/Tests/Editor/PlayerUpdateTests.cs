using NUnit.Framework;
using System.Drawing;
using GameProject.Models;
using GameProject.Services;

namespace GameProject.Tests
{
    [TestFixture]
    public class PlayerUpdateTests
    {
        [Test]
        public void UpdateHP_ShouldIncreaseHP_WhenPositiveDeltaHP()
        {
            // Arrange the player with a HP stat
            Player player = new Player(new Point(0, 0));
            int initialHP = player.HP;
            int deltaHP = 10;


            PlayerUpdateService.UpdateHP(player, deltaHP);

            // Asssert whether the changes made to the HP stat is correct
            Assert.That(initialHP + deltaHP, Is.EqualTo(player.HP));
        }

        [Test]
        public void UpdateAtt_ShouldIncreaseAtt_WhenPositiveDeltaAtt()
        {
            // Arrange the player with a Attack stat
            Player player = new Player(new Point(0, 0));
            int initialAtt = player.Attack;
            int deltaAtt = 5;


            PlayerUpdateService.UpdateAttack(player, deltaAtt);

            // Assert whether the changes made to the Attack stat is correct
            Assert.That(initialAtt + deltaAtt, Is.EqualTo(player.Attack));
        }

    }
}
