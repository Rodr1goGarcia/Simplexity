using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    class Player
    {
        private Color color;
        private int roundPieces;
        private int squarePieces;
        public int posC;
        public bool shapeC;
        //public int PosC { get{ return this.posC; } set { this.posC = value; } }
        //public bool ShapeC { get { return this.ShapeC; } set { this.ShapeC = value; } }
    

        private GameManager gm;

        public int RoundPieces { get { return this.roundPieces; } set { this.roundPieces = value; } }
        public int SquarePieces { get { return this.squarePieces; } set { this.squarePieces = value; } }
        public Color Color { get { return this.color; } }
        public void AssignColor(Color color)
        {
            this.color = color;
        }
        public Player(GameManager gm)
        {
            this.gm = gm;
            this.roundPieces = 10;
            this.squarePieces = 11;
        }
        public Player()
        {
            this.roundPieces = 10;
            this.squarePieces = 11;
        }
       
        public void Play(Column[] col)
        {
            bool pressedEnter = false;
            Piece tmpP = new Piece();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    if (posC <= 0)
                        posC = 6;
                    else
                        posC--;
                    break;
                case ConsoleKey.RightArrow:
                    if (posC >= 6)
                        posC = 0;
                    else
                        posC++;
                    break;
                case ConsoleKey.Enter:
                    if (shapeC && col[posC].Count < 7)
                        tmpP = new Piece(this.color, Shape.Round);
                    else if (col[posC].Count < 7)
                        tmpP = new Piece(this.color, Shape.Square);
                    pressedEnter = true;
                    break;
                case ConsoleKey.UpArrow:
                    if (shapeC)
                        shapeC = false;
                    else
                        shapeC = true;
                    break;
                case ConsoleKey.DownArrow:
                    if (shapeC)
                        shapeC = false;
                    else
                        shapeC = true;
                    break;
            }
            if(pressedEnter)
            {
                col[posC].PlacePiece(tmpP);
            }
        }

    }
}
