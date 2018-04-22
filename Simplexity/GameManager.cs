using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    //some global enums
    public enum Color
    {
        White, Red, None
    }
    public enum Shape
    {
        Round, Square, None
    }
    class GameManager
    {
       
        private int currentPlayer = 0;
        private Color currentPlayerColor = Color.None;
        public int CurrentPlayer { get; set; }
        public Color CurrentPlayerColor { get { return this.currentPlayerColor; } }
        private Player[] players = new Player[2] { new Player(), new Player() };
        public GameManager()
        {

        }
        
        
        // method that changes the currentPlayer
        public void NextTurn()
        {
            if (currentPlayer == 1)
                currentPlayer = 0;
            else
                currentPlayer++;
        }
        public void Update(Board board, Player player)
        {
            this.currentPlayerColor = player.Color;
            board.shapeC = player.shapeC;
            board.posC = player.posC;
        }
        
    }
}
