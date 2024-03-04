using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class Character : MonoBehaviour
    {

        private int attack;
        private int hp;
        private Vector2 pos;



        public int Attack { get => attack; set => attack = value; }
        public int HP { get => hp; set => hp = value; }
        public Vector2 Pos { get => pos; set => pos = value; }

        public Character()
        {
            attack = 10;
            hp = 100;
            pos = Vector2.zero;
        }

        // Method to initialize the player object
        public void InitializePlayer()
        {
            // Set the initial position of the player
            transform.position = pos;
        }

        private void Awake()
        { 
        InitializePlayer();
        }
        }
}
