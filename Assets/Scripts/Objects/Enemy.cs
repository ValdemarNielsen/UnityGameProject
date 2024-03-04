using log4net.Util;
using UnityEngine;
using Assets.Scripts.Objects;

namespace GameProject.Models
{
    public class Enemy : Character
    {
        public string MonsterType { get; set; }
        public float ChaseDistance { get; set; }

        public void Initialize(string monsterType, Sprite idleSprite)
        {
            MonsterType = monsterType;

            // Set the size of the enemy GameObject
            SetMonsterSize();
        }

        // Method to set default size
        private void SetMonsterSize()
        {
            // Set the scale of the enemy GameObject to be larger than the default size
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }

        private void SetMonsterChaseDistance(string monsterType)
        {
            switch (MonsterType)
            {
                case "Skeleton(Clone)":
                    ChaseDistance = 10f;
                    break;
                case "Goblin(Clone)":
                    ChaseDistance = 15f;
                    break;
                case "zombie":
                    ChaseDistance = 7.5f;
                    break;
            }
        }
    }
}
