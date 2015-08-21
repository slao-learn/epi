using System;
using System.Collections.Generic;

public class P19_2
{
    public class Coordinate
    {
        public int x, y;
        public Coordinate prev; // used for BFS

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    // DFS easier to implement but not shortest path
    public static List<Coordinate> SearchMazeDFS(int[][] maze, Coordinate s, Coordinate e)
    {
        maze[s.y][s.x] = 1;

        if (s.x == e.x && s.y == e.y)
        {
            return new List<Coordinate>() { s };
        }

        List<Coordinate> adjacent = GetAdjacent(maze, s);
        foreach ( Coordinate a in adjacent )
        {
            List<Coordinate> path = SearchMazeDFS(maze, a, e);
            if (path != null)
            {
                path.Insert(0, s);
                return path;
            }
        }
        return null;
    }

    // BFS guarantees shortest path
    public static List<Coordinate> SearchMazeBFS(int[][] maze, Coordinate s, Coordinate e)
    {
        maze[s.y][s.x] = 1;
        s.prev = null;
        Queue<Coordinate> queue = new Queue<Coordinate>();
        queue.Enqueue(s);

        while (queue.Count > 0)
        {
            Coordinate c = queue.Dequeue();
            if (c.x == e.x && c.y == e.y)
            {
                List<Coordinate> path = new List<Coordinate>();
                while (c != null)
                {
                    path.Insert(0, c);
                    c = c.prev;
                }
                return path;
            }

            List<Coordinate> adjacent = GetAdjacent(maze, c);
            foreach ( Coordinate a in adjacent )
            {
                maze[a.y][a.x] = 1;
                a.prev = c;
                queue.Enqueue(a);
            }
        }

        return null;
    }

    private static List<Coordinate> GetAdjacent(int[][] maze, Coordinate c)
    {
        int width = maze[c.y].Length;
        int height = maze.Length;

        List<Coordinate> a = new List<Coordinate>();

        if (c.x - 1 >= 0 && maze[c.y][c.x - 1] == 0)
        {
            a.Add(new Coordinate(c.x - 1, c.y));
        }
        if (c.x + 1 < width && maze[c.y][c.x + 1] == 0)
        {
            a.Add(new Coordinate(c.x + 1, c.y));
        }
        if (c.y - 1 >= 0 && maze[c.y - 1][c.x] == 0)
        {
            a.Add(new Coordinate(c.x, c.y - 1));
        }
        if (c.y + 1 < height && maze[c.y + 1][c.x] == 0)
        {
            a.Add(new Coordinate(c.x, c.y + 1));
        }

        return a;
    }

    public static void RunTests()
    {
        Console.WriteLine("DFS");
        int[][] maze = new int[][] {
            new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
            new int[] { 1, 0, 1, 1, 0, 0, 0, 1, 1, 1 },
            new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 1, 1, 0, 0, 1, 0, 1, 1, 0 },
            new int[] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 1, 1, 1, 0, 0, 1, 0 },
            new int[] { 1, 0, 1, 0, 0, 1, 1, 0, 1, 1 },
            new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 1, 0, 0, 0, 0, 0, 1, 1, 0, 0 }
        };
        List<Coordinate> path = SearchMazeDFS(maze, new Coordinate(0, 0), new Coordinate(9, 9));
        if (path != null)
        {
            foreach (var c in path)
            {
                Console.WriteLine(c.x + " " + c.y);
            }
            Console.WriteLine("Number of steps = " + (path.Count - 1));
        } else
        {
            Console.WriteLine("No path exists");
        }

        Console.WriteLine("\nBFS");
        maze = new int[][] {
            new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
            new int[] { 1, 0, 1, 1, 0, 0, 0, 1, 1, 1 },
            new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 1, 1, 0, 0, 1, 0, 1, 1, 0 },
            new int[] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 1, 1, 1, 0, 0, 1, 0 },
            new int[] { 1, 0, 1, 0, 0, 1, 1, 0, 1, 1 },
            new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 1, 0, 0, 0, 0, 0, 1, 1, 0, 0 }
        };
        path = SearchMazeBFS(maze, new Coordinate(0, 0), new Coordinate(9, 9));
        if (path != null)
        {
            foreach (var c in path)
            {
                Console.WriteLine(c.x + " " + c.y);
            }
            Console.WriteLine("Number of steps = " + (path.Count - 1));
        } else
        {
            Console.WriteLine("No path exists");
        }

    }
}
