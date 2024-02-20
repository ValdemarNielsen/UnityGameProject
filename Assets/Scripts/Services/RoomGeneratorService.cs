using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
/// RoomGeneratorService.cs (optional): If our rooms require complex initialization or configuration beyond just connecting them with doors 
/// (e.g., assigning types, generating puzzles, placing items), this service would handle the logic of 
/// creating and initializing Room instances with those specific attributes.
namespace GameProject.Services
{
    public class RoomGeneratorService : MonoBehaviour
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
    }

}
