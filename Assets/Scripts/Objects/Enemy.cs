using Assets.Scripts.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace GameProject.Models
{
    public class Enemy: Character
    {
        public Vector2 Pos { get; set; }
        public int Width { get; }
        public int Height { get; }
        public float Attack { get; set; }
        public float HP { get; set; }
        
        public int MovementSpeed {  get; set; }


        public Enemy (Character character)
        {
            Pos = character.Pos;
            Width = character.Width;
            Height = character.Height;
            Width = character.Width;
            Attack = character.Attack;
            HP = character.HP;
            MovementSpeed = character.MovementSpeed;
        }

        public void InitializeEnemy()
        {


        }
        
    }
}
