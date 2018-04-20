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
        public Piece()
        {
            this.color = Color.None;
            this.shape = Shape.None;
        }
        public Shape Shape { get { return this.shape; } }
        public Color Color { get { return this.color; } }
    }
}
