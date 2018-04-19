using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    class Board
    {
        Column[] columns = new Column[7] { new Column(), new Column(), new Column(), new Column(), new Column(), new Column(), new Column() };
        public Board()
        {

        }
        public void Draw()
        {
            //string tmpString = null;
            //for (int i = columns.Length; i > 0; i--)
            //{
            //    tmpString = null;
            //    for (int j = 0; j < 7; j++)
            //    {
            //        if (columns[i] == null)
            //        {
            //            tmpString += "| ";
            //        }
            //        switch (columns[i].GetPiece(j).Shape)
            //        {
            //            case Shape.Circle:
            //                tmpString += "C ";
            //                break;
            //            case Shape.Square:
            //                tmpString += "S ";
            //                break;
            //        }
            //        //tmpString += "| ";
            //    }
            //    Console.WriteLine(tmpString);
            //}
            for (int i = 0; i < columns.Length; i++)
            {
                for (int j = 0; j < columns[i].Count; j++)
                {
                    switch (columns[i].GetPiece(j).Color)
                    {
                        case Color.Red:
                            if (columns[i].GetPiece(j).Shape == Shape.Square)
                                Console.Write("R ");
                            else
                                Console.Write("r ");
                            break;
                        case Color.White:
                            if (columns[i].GetPiece(j).Shape == Shape.Square)
                                Console.Write("W ");
                            else
                                Console.Write("w ");
                            break;
                    }
                }
                Console.WriteLine();
            }

        }

        void Update()
        {

        }
        public void Fill()
        {
            int wC, rC, wS, rS;
            wC = rC = 10;
            wS = rS = 11;
            int wP = 21, rP = 21;
            int tmpCol, tmp;
            Random random = new Random(100);
            while (wP > 0 || rP > 0)
            {
                tmpCol = random.Next(0, 7);
                if (columns[tmpCol].Count < 7)
                {
                    tmp = random.Next(1, 101);
                    if (tmp > 50 && wP > 0)
                    {
                        if (tmp % 2 == 0 && wC > 0)
                        {
                            columns[tmpCol].PlacePiece(new Piece(Color.White, Shape.Circle));
                            wC--;
                            wP--;
                        }
                        else if (wS > 0)
                        {
                            columns[tmpCol].PlacePiece(new Piece(Color.White, Shape.Square));
                            wS--;
                            wP--;
                        }
                        else
                        {
                            columns[tmpCol].PlacePiece(new Piece(Color.White, Shape.Square));
                            wC--;
                            wP--;
                        }
                    }
                    else if (rP > 0)
                    {
                        if (tmp % 2 == 0 && rC > 0)
                        {
                            columns[tmpCol].PlacePiece(new Piece(Color.Red, Shape.Circle));
                            rC--;
                            rP--;
                        }
                        else if (rS > 0)
                        {
                            columns[tmpCol].PlacePiece(new Piece(Color.Red, Shape.Square));
                            rS--;
                            rP--;
                        }
                        else
                        {
                            columns[tmpCol].PlacePiece(new Piece(Color.Red, Shape.Circle));
                            rC--;
                            rP--;
                        }
                    }
                }
            }

        }
    }
}
