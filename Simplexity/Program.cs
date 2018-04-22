using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gamemanager = new GameManager();
            Board test = new Board(gamemanager);
            Player[] players = new Player[] { new Player(), new Player() };
            Console.WriteLine("Player 1 want to play with wich color?" + "\n" + "1) White" + "\n" + "2)Red");
            if (Console.ReadKey().Key == ConsoleKey.NumPad1)
            {
                players[0].AssignColor(Color.White);
                players[1].AssignColor(Color.Red);
            }
            else
            {
                players[0].AssignColor(Color.White);
                players[1].AssignColor(Color.Red);
            }

            for (; ; )
            {
                //gamemanager.Update(test, players[gamemanager.CurrentPlayer]);
           
                test.Draw();
                
                players[gamemanager.CurrentPlayer].Play(test.Columns);
                gamemanager.Update(test, players[gamemanager.CurrentPlayer]);
                test.Draw();
                

            }

        }
    }
}
