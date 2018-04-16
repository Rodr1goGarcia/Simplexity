using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simplexity
{
    class Piece
    {

        private Color color;
        private string shape = null;
        Piece(Color color, string shape)
        {
            this.color = color;
            this.shape = shape;
        }
        
    }
}
