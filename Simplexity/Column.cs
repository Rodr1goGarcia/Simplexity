using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    class Column
    {
        private Stack<Piece> pieces = new Stack<Piece>();

        public Column()
        {
            for (int i = 0; i < 6; i++)
            {
                PlacePiece(new Piece(Color.Red, Shape.Square));
            }
        }

        public Piece GetPiece(int pos)
        {
            return pieces.ElementAt(pos);
        }
        //places a piece at the top of the stack
        public void PlacePiece(Piece p)
        {
            pieces.Push(p);
        }
        // removes and returns the top piece of the stack
        public Piece RemovePiece()
        {
            return pieces.Pop();
        }
        //checks if someone won at the column in the column
        public bool Check(Color color)
        {
            // c:Color, s:Shape
            int c = 0, s = 0;
            bool result = false;
            if(pieces.Count >= 4)
            {
                Piece previousPiece = null;
                foreach(Piece p in pieces)
                {
                    if(p.Color == previousPiece.Color)
                        c++;
                    else  
                        c = 0;

                    if (p.Shape == previousPiece.Shape)
                        s++;
                    else
                        s = 0;

                    previousPiece = p;
                }
            }
            if (s >= 4 || c >= 4)
                result = true;

                return result;
        }

        //converts the stack to array
        public Piece[] ToArray()
        {
            return pieces.ToArray();
        }
        public int Count { get { return pieces.Count; } }
            
    }
}
