/*
 Given a 2-dimensional grid consisting of 1's (land blocks) and 0's (water blocks), count the number of islands present in the grid. 
 The definition of an island is as follows:
    1.) Must be surrounded by water blocks.
    2.) Consists of land blocks (1's) connected to adjacent land blocks (either vertically or horizontally).
 Assume all edges outside of the grid are water.

 Example:
 Input: 
    10001
    11000
    10110
    00000
 
 Output: 3
*/

using System;
using System.Collections.Generic;

namespace NumberOfIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WorldIslands worldIslands = new())
            {
                const int totalRows = 4;
                const int totalCol = 5;
                int[,] gridMap = new int[totalRows, totalCol] { { 1,0,0,0,1 }, { 1,1,0,0,0 }, { 1,0,1,1,0 }, { 0,0,0,0,0 } };

                worldIslands.NumberOfIslands(gridMap, totalRows, totalCol);
            }

            Console.ReadKey();
        }

        public class WorldIslands : IDisposable
        {
            private bool disposedValue;

            public void PrintMap(int[,] map, int numRow, int numCol)
            {
                int count = 0;
                foreach (var item in map)
                {
                    Console.Write(item.ToString());
                    count++;
                    if (count == numCol)
                    {
                        Console.WriteLine("");
                        count = 0;
                    }
                }
            }

            public int NumberOfIslands(int[,] map, int totalRows, int totalCol)
            {
                int islands = 0;
                List<Tuple<int, int>> islandsFounded = new List<Tuple<int, int>>();

                for (int row = 0; row <= totalRows - 1; row++)
                {
                    for (int col = 0; col <= totalCol - 1; col++)
                    {
                        Console.Write(map[row,col]);

                        if(ThisPointIsAnIsland(map, row, col) && ShouldCountIsland(map, row, col))
                        {
                            islandsFounded.Add(new Tuple<int, int>(row, col));
                            islands++;
                        }
                    }

                    Console.WriteLine("");
                }

                Console.WriteLine(islands);

                return 0;
            }

            public bool ThisPointIsAnIsland(int[,] map, int row, int col)
            {
                return map[row, col] == 1;
            }

            public bool ShouldCountIsland(int[,] map, int row, int col)
            {
                int landsFounded = 0;

                //UP
                if (row != 0)
                {
                    if (IsEqualToPreviousPosition(map[row, col], map[row - 1, col]))
                        landsFounded++;
                }   

                //LEFT
                if (col != 0)
                {
                    if (IsEqualToPreviousPosition(map[row, col], map[row, col - 1]))
                        landsFounded++;
                }

                if (landsFounded > 0)
                    return false;

                return true;
                    
            }

            public bool IsEqualToPreviousPosition(int actual, int previous)
            {
                return actual == previous;
            }

            #region Disposable
            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects)
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                    // TODO: set large fields to null
                    disposedValue = true;
                }
            }

            // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
            // ~WorldIslands()
            // {
            //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            //     Dispose(disposing: false);
            // }

            public void Dispose()
            {
                // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
            #endregion
        }
    }
}
