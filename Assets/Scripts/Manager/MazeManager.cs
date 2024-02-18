using GameProject.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public int mazeSize = 5;
    public Maze maze { get; private set; }

    void Start()
    {
        maze = new Maze(mazeSize);
    }
}
