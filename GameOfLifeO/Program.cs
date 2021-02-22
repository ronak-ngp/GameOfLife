using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeO
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int Rows = 0;
                int Columns = 0;
                int Generations = 0;
                Console.WriteLine("Please endter board size");
                Console.WriteLine("Rows");
                Rows = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Columns");
                Columns = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Number of Generations");

                Generations = Convert.ToInt32(Console.ReadLine());

                GameOfLife gameOfLife = new GameOfLife();

                StringBuilder stringBuilder = gameOfLife.GameOfLifestr(Rows, Columns, Generations);

                Console.WriteLine(stringBuilder);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }

    public enum Status
    {
        Dead,
        Alive,
    }
}
