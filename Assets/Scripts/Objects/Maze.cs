namespace GameProject.Models
{
    public class Maze
    {
        public Room[,] Rooms { get; private set; }
        public Maze(int size)
        {
            Rooms = new Room[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Rooms[i, j] = new Room();
                }
            }   
        }
    }
}
