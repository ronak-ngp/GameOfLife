using System.Security.Cryptography;
using System.Text;
using System;

namespace GameOfLifeO
{
    public class GameOfLife
    {
        public StringBuilder GameOfLifestr(int Rows, int Columns, int Generations)
        {
            var grid = new Status[Rows, Columns];
            int counter = 0;
            StringBuilder str = new StringBuilder();
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    var generator = new Random();

                    grid[row, column] = (Status)generator.Next(0, 2);
                }
            }
            while (counter <= Generations)
            {
                str.Append(counter == 0 ? "initial state \n" : "Generation " + counter + " state \n");
                str.Append(Print(grid, Rows, Columns));
                grid = NextGeneration(grid, Rows, Columns);
                counter++;
            }

            return str;
        }


        public Status[,] NextGeneration(Status[,] currentGrid, int Rows, int Columns)
        {
            var nextGeneration = new Status[Rows, Columns];
            for (var row = 1; row < Rows - 1; row++)
                for (var column = 1; column < Columns - 1; column++)
                {
                    var aliveNeighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            aliveNeighbors += currentGrid[row + i, column + j] == Status.Alive ? 1 : 0;
                        }
                    }
                    var currentCell = currentGrid[row, column];
                    aliveNeighbors -= currentCell == Status.Alive ? 1 : 0;
                    // Cell is lonely and dies 
                    if (currentCell.HasFlag(Status.Alive) && aliveNeighbors < 2)
                    {
                        nextGeneration[row, column] = Status.Dead;
                    }
                    // Cell dies due to over population 
                    else if (currentCell.HasFlag(Status.Alive) && aliveNeighbors > 3)
                    {
                        nextGeneration[row, column] = Status.Dead;
                    }
                    // A new cell is born 
                    else if (currentCell.HasFlag(Status.Dead) && aliveNeighbors == 3)
                    {
                        nextGeneration[row, column] = Status.Alive;
                    }
                    else
                    {
                        nextGeneration[row, column] = currentCell;
                    }
                }
            return nextGeneration;
        }

        public StringBuilder Print(Status[,] future, int Rows, int Columns)
        {
            var stringBuilder = new StringBuilder();
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    var cell = future[row, column];
                    stringBuilder.Append(cell == Status.Alive ? "X" : "0");
                }
                stringBuilder.Append("\n");
            }
            return stringBuilder;
        }


    }
}
