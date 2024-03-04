using Assets.Scripts.Objects;
using UnityEngine;

namespace GameProject.Models
{
    public class Player : Character
    {
        // Serialized fields to expose in the Unity Inspector
        private int width;
        private int height;
        private int movementSpeed;
        

        // Properties
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int MovementSpeed { get => movementSpeed; set => movementSpeed = value; }

        // Constructors
        public Player()
        {
            // Default initialization
            width = 40;
            height = 66;
            movementSpeed = 10;
        }

        public Player(Vector2 startingPos, int width, int height, int attack, int hp, int movementSpeed)
        {
            Pos = startingPos;
            Width = width;
            Height = height;
            Attack = attack;
            HP = hp;
            MovementSpeed = movementSpeed;
        }

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            SetDefaultSize();
        }

        

        // Method to set default size
        private void SetDefaultSize()
        {
            // Set the default size of the player
            transform.localScale = new Vector3(0.3f, 0.6f, 1f);
        }
    }
}
