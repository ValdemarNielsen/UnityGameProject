using UnityEngine;

namespace GameProject.Models
{
    public class Player : MonoBehaviour
    {
        
        // Serialized fields to expose in the Unity Inspector
        private int width;
        private int height;
        private int attack;
        private int hp;
        private int movementSpeed;
        
        private Vector2 pos;

        // Properties
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int Attack { get => attack; set => attack = value; }
        public int HP { get => hp; set => hp = value; }
        public int MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        public Vector2 Pos { get => pos; set => pos = value; }
        public int PlayerId { get; set; } // unique identifier for each player


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
            InitializePlayer();
            //SetDefaultSize();
        }

        // Method to initialize the player object
        private void InitializePlayer()
        {
            transform.position = GameManager.spawnPoint;
        }

    }
}
