using UnityEngine;

namespace GameProject.Models
{
    public class Player : MonoBehaviour
    {
        // Serialized fields to expose in the Unity Inspector
        [SerializeField]
        private int width = 60;
        [SerializeField]
        private int height = 100;
        [SerializeField]
        private int attack = 10;
        [SerializeField]
        private int hp = 100;
        [SerializeField]
        private int movementSpeed = 10;
        [SerializeField]
        private Vector2 pos; // Position of the player

        // Public properties
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public int Attack { get { return attack; } set { attack = value; } }
        public int HP { get { return hp; } set { hp = value; } }
        public int MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
        public Vector2 Pos { get { return pos; } set { pos = value; } }

        // Constructor
        public Player(Vector2 startingPos, int width = 60, int height = 100, int attack = 10, int hp = 100, int movementSpeed = 10)
        {
            Pos = startingPos;
            Attack = attack;
            HP = hp;
            MovementSpeed = movementSpeed;
        }


        // Start is called before the first frame update
        void Start()
        {
            // Initialize the player object
            InitializePlayer();
        }

        // Method to initialize the player object
        private void InitializePlayer()
        {
            // Set the initial position of the player
            transform.position = pos;
        }

        // Method to get the position of the player
        public Vector2 GetPosition()
        {
            return pos;
        }
    }
}
