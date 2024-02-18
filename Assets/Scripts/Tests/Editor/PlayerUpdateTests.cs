using GameProject.Models;
using GameProject.Services;
using NUnit.Framework;
using UnityEngine;

namespace GameProject.Tests
{
    [TestFixture]
    public class PlayerUpdateTests
    {
        private GameObject playerGameObject;
        private Player player;

        [SetUp]
        public void Setup()
        {
            // Create a GameObject and add the Player component to it
            playerGameObject = new GameObject("Player");
            player = playerGameObject.AddComponent<Player>();
            player.Pos = new Vector2(0, 0);
            player.Attack = 10;
            player.HP = 100;
            player.MovementSpeed = 10;
        }

        [TearDown]
        public void Teardown()
        {
            // Destroy the GameObject after each test
            Object.DestroyImmediate(playerGameObject);
        }

        [Test]
        public void UpdateHP_ShouldIncreaseHP_WhenPositiveDeltaHP()
        {
            // Arrange
            int initialHP = player.HP;
            int deltaHP = 10;

            // Act
            PlayerUpdateService.UpdateHP(player, deltaHP);

            // Assert
            Assert.That(initialHP + deltaHP, Is.EqualTo(player.HP));
        }

        [Test]
        public void UpdateAtt_ShouldIncreaseAtt_WhenPositiveDeltaAtt()
        {
            // Arrange
            int initialAtt = player.Attack;
            int deltaAtt = 5;

            // Act
            PlayerUpdateService.UpdateAttack(player, deltaAtt);

            // Assert
            Assert.That(initialAtt + deltaAtt, Is.EqualTo(player.Attack));
        }
    }
}
