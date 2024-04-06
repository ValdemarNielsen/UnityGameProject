using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class Character: MonoBehaviour
    {


        private float attack;
        private float hp;
        private int movementSpeed;

        private Vector2 pos;
        // Properties

        public float Attack { get => attack; set => attack = value; }
        public float HP { get => hp; set => hp = value; }
        public int MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        public Vector2 Pos { get => pos; set => pos = value; }

        public Character()
        {
            // Initialize properties with default values
            Pos = Vector2.zero;
            Attack = 0;
            HP = 0;
            MovementSpeed = 0;
        }




    }
}
