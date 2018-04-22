using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    public enum Color
    {
        White,Red, None
    }
    public enum Shape
    {
        Circle, Square, None
    }
    class GameManager
    {

        private int currentPlayer = 0;
        public int CurrentPlayer { get; set; }
        private Player[] players = new Player[2] { new Player(), new Player() };

        public void NextTurn()
        {
            if (currentPlayer == 1)
                currentPlayer = 0;
            else
                currentPlayer++;
        }

        public void Update(Board board, Player player)
        {
            board.shapeC = player.shapeC;
            board.posC = player.posC;
        }

    }
}
