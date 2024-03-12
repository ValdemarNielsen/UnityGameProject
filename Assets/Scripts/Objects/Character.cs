using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace Assets.Scripts.Objects
{
    public class Character: MonoBehaviour
    {

        // Serialized fields to expose in the Unity Inspector
        private int width;
        private int height;
        private float attack;
        private float hp;
        private int movementSpeed;

        private Vector2 pos;
        // Properties
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public float Attack { get => attack; set => attack = value; }
        public float HP { get => hp; set => hp = value; }
        public int MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        public Vector2 Pos { get => pos; set => pos = value; }

        public Character()
        {
            // Initialize properties with default values
            Pos = Vector2.zero;
            Width = 0;
            Height = 0;
            Attack = 0;
            HP = 0;
            MovementSpeed = 0;
        }




    }
}
