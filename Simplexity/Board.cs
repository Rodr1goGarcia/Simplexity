using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    class Board
    {
        public int posC = 0;
        public bool shapeC = false;

        private GameManager gm;
        Column[] columns = new Column[7] { new Column(), new Column(),
                                           new Column(), new Column(),
                                           new Column(), new Column(),
                                           new Column() };
        public Column[] Columns { get { return columns; } }
        public Board(GameManager gm)
        {
            this.gm = gm;
        }
        public bool CheckHorizontal(int row)
        {
            int c, s;
            c = s = 1;
            Piece previousPiece = new Piece();
            for (int i = 0; i < 7; i++)
            {
                if (previousPiece.Color == columns[i].ToArray()[row].Color && columns[i].ToArray()[row].Color != Color.None)
                    c++;
                else
                    c = 1;
                if (previousPiece.Shape == columns[i].ToArray()[row].Shape && columns[i].ToArray()[row].Shape != Shape.None)
                    s++;
                else
                    s = 1;
            }
            if (s >= 4 || c >= 4)
                return true;
            else
                return false;
        }
        public bool CheckDiagonal(int col, int row)
        {
            Piece previousPiece = new Piece();
            int c, s;
            c = s = 1;
            int tmpRow = row;
            int tmpCol = col;
            while (tmpCol != 0 || tmpRow != 0)
            {
                tmpRow--;
                tmpCol--;
            }
            for (int i = tmpCol; i < 7 - (col - row); i++)
            {
                if (previousPiece.Color == columns[i].ToArray()[tmpRow].Color && columns[i].ToArray()[tmpRow].Color != Color.None)
                    c++;
                else
                    c = 1;
                if (previousPiece.Shape == columns[i].ToArray()[tmpRow].Shape && columns[i].ToArray()[tmpRow].Shape != Shape.None)
                    s++;
                else
                    s = 1;
                tmpRow++;
            }
            tmpRow = row;
            tmpCol = col;
            while (tmpCol != 6 || tmpRow != 0)
            {
                tmpRow--;
                tmpCol++;
            }
            for (int i = tmpCol; i > 7 - (col - row); i--)
            {
                if (previousPiece.Color == columns[i].ToArray()[tmpRow].Color && columns[i].ToArray()[tmpRow].Color != Color.None)
                    c++;
                else
                    c = 1;
                if (previousPiece.Shape == columns[i].ToArray()[tmpRow].Shape && columns[i].ToArray()[tmpRow].Shape != Shape.None)
                    s++;
                else
                    s = 1;
                tmpRow++;
            }
            if (s >= 4 || c >= 4)
                return true;
            else
                return false;
        }

        //function that draws the board
        public void Draw()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(gm.CurrentPlayerColor);
            string tmpString = null;
            for (int i = 0; i < posC; i++)
            {
                tmpString += "  ";
            }
            if (shapeC)
            {
                if (gm.CurrentPlayerColor == Color.White)
                    Console.WriteLine("    " + tmpString + "w");
                else
                    Console.WriteLine("    " + tmpString + "r");
            }
            else
            {
                if (gm.CurrentPlayerColor == Color.White)
                    Console.WriteLine("    " + tmpString + "W");
                else
                    Console.WriteLine("    " + tmpString + "R");
            }
            Console.Write("    ");
            Console.WriteLine(tmpString += "v");
            Piece[] tmpPieces = new Piece[7];
            int tmpInt = 6;
            for (int i = 0; i < columns.Length; i++)
            {
                tmpString = null;
                for (int j = 0; j < 7; j++)
                {
                    tmpPieces = columns[j].ToArray();
                    switch (tmpPieces[tmpInt].Color)
                    {
                        case Color.Red:
                            if (tmpPieces[tmpInt].Shape == Shape.Square)
                                tmpString += "R ";
                            else
                                tmpString += "r ";
                            break;
                        case Color.White:
                            if (tmpPieces[tmpInt].Shape == Shape.Square)
                                tmpString += "W ";
                            else
                                tmpString += "w ";
                            break;
                        case Color.None:
                            tmpString += "| ";
                            break;
                    }
                }
                tmpInt--;
                Console.WriteLine("    " + tmpString);
            }
            Console.WriteLine("   " + "---------------");
        }

        public void Update()
        {
            foreach (Column c in columns)
            {
                if (c.Check())
                    Console.WriteLine("TRUE");
            }
        }

    }
}
