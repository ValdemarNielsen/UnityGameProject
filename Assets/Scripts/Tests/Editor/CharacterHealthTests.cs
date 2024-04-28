using NUnit.Framework;
using UnityEngine;

namespace Assets.Scripts.Tests.Editor
{
    public class CharacterHealthTests
    {
        [Test]
        public void TakeDamage_ReduceHealth_Correctly()
        {
            // Arrange
            var characterObject = new GameObject();
            var characterHealth = characterObject.AddComponent<CharacterHealth>();
            characterHealth.startingHealth = 100; // Set starting health
            characterHealth.currentHealth = 100; // Set initial health
            var damage = 20;

            // Act
            characterHealth.TakeDamage(damage);

            // Assert
            Assert.AreEqual(characterHealth.startingHealth - damage, characterHealth.currentHealth);
        }

        [Test]
        public void TakeDamage_ClampHealthToZero_WhenDamageExceedsCurrentHealth()
        {
            // Arrange
            var characterObject = new GameObject();
            var characterHealth = characterObject.AddComponent<CharacterHealth>();
            characterHealth.startingHealth = 100; // Set starting health
            characterHealth.currentHealth = 20; // Set initial health
            var damage = 30;

            // Act
            characterHealth.TakeDamage(damage);

            // Assert
            Assert.AreEqual(0, characterHealth.currentHealth);
        }

        [Test]
        public void CharacterDeath_DestroyCharacter_WhenHealthReachesZero()
        {
            // Arrange
            var characterObject = new GameObject();
            var characterHealth = characterObject.AddComponent<CharacterHealth>();
            characterHealth.startingHealth = 100; // Set starting health
            characterHealth.currentHealth = 0; // Set health to zero

            // Act
            characterHealth.CharacterDeath();

            // Assert
            Assert.IsNull(characterHealth.character); // Ensure character is destroyed
        }
    }
}
