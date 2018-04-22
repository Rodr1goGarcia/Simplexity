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


        public Piece GetPiece(int pos)
        {
            return pieces.ElementAt(pos);
           
        }
        //places a piece at the top of the stack
        public void PlacePiece(Piece p)
        {
            pieces.Push(p); 
        }
        //checks if someone won at the column in the column
        public bool Check(Color color)
        {
            // c:Color, s:Shape
            int c = 1, s = 1;
            bool result = false;
            
                Piece previousPiece = new Piece();
                foreach (Piece p in pieces)
                {
                    if (p.Color == previousPiece.Color)
                        c++;
                    else
                        c = 1;

                    if (p.Shape == previousPiece.Shape)
                        s++;
                    else
                        s = 1;

                    previousPiece = p;
                }
                Console.WriteLine("c: " + c + " s = " + s);
            
            if (s >= 4 || c >= 4)
                result = true;

            return result;
        }

        //converts the stack to array
        public Piece[] ToArray()
        {
            Piece[] tmp = new Piece[7] { new Piece(), new Piece(),
                                         new Piece(), new Piece(),
                                         new Piece(), new Piece(),
                                         new Piece()};

            pieces.CopyTo(tmp, tmp.Length - pieces.Count);
            return InvertArray(tmp);
        }
        // invert the position of the elements of the array
        Piece[] InvertArray(Piece[] a)
        {
            Piece[] tmp1 = new Piece[a.Length];
            int tmp = a.Length -1;
            
            for (int i = 0; i < tmp1.Length;i++)
            {
                tmp1[i] = a[tmp--];
                
            }
            return tmp1;

        }
        public int Count { get { return pieces.Count; } }

    }
}
