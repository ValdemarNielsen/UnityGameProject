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
        
        private Vector2 pos;

        // Properties
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        public Vector2 Pos { get => pos; set => pos = value; }
        public int PlayerId { get; set; } // unique identifier for each player

        // Constructors
        public Player()
        {
            // Default initialization
            width = 66;
            height = 66;
            movementSpeed = 10;
            pos = Vector2.zero;
            PlayerId = 1;
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

        // Method to initialize the player object
        private void InitializePlayer()
        {
            transform.position = GameManager.spawnPoint;
        }

        // Method to set default size
        private void SetDefaultSize()
        {
            // Set the default size of the player
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
            Debug.Log("called Update Position");
        }
  
    }
}
