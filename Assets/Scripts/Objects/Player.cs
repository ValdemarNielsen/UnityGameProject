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
        public string PlayerId { get; set; }
        private Vector2 pos;

        // Properties
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int Attack { get => attack; set => attack = value; }
        public int HP { get => hp; set => hp = value; }
        public int MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        public Vector2 Pos { get => pos; set => pos = value; }

        // Constructors
        public Player()
        {
            // Default initialization
            width = 66;
            height = 66;
            attack = 10;
            hp = 100;
            movementSpeed = 10;
            pos = Vector2.zero;
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
            InitializePlayer();
            SetDefaultSize();
        }

        // Method to initialize the player object
        private void InitializePlayer()
        {
            // Set the initial position of the player
            transform.position = pos;
        }

        // Method to set default size
        private void SetDefaultSize()
        {
            // Set the default size of the player
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
