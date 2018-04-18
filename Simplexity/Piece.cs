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
        private Shape shape;
        public Piece(Color color, Shape shape)
        {
            this.color = color;
            this.shape = shape;
        }
        public Shape Shape { get; set; }
        public Color Color { get; set; }
    }
}
