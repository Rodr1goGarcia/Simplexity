using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    class Column
    {
        private Piece[] pieces = null;
        public void PlacePiece(Piece p)
        {
            pieces = new Piece[pieces.Length + 1];
            pieces[pieces.Length] = p;
        }
        public Piece RemovePiece()
        {
            Piece tmp = pieces[pieces.Length];
            pieces = new Piece[pieces.Length - 1];
            return tmp;
        }
        public bool Check(Color color)
        {
            int c = 0, s = 0;
            for(int i = 0; i < pieces.Length;i++)
            {
                if(pieces[i].)
            }
            return true;
        }
    }
}
