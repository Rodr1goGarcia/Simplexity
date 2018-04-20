using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    class Board
    {
        int posC = 0;
        bool shapeC = true;
        Column[] columns = new Column[7] { new Column(), new Column(), new Column(), new Column(), new Column(), new Column(), new Column() };
        public Board()
        {

        }

        public void PlacePiece()
        {
            switch(Console.ReadKey().Key)
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
                    if (shapeC)
                        columns[posC].PlacePiece(new Piece(Color.White, Shape.Circle));
                    else
                        columns[posC].PlacePiece(new Piece(Color.White, Shape.Square));
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
            
        }
        public void Draw()
        {
            Console.Clear();
            string tmpString = null;
            for (int i = 0; i < posC;i++)
            {
                tmpString += "  ";
            }
            if (shapeC)
            {
                Console.WriteLine(tmpString + "W");

            }
            else
                Console.WriteLine(tmpString + "w");
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
                Console.WriteLine(tmpString);
                
               
            }
           
            
        }

        public void Update()
        {
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i].Check(Color.White))
                    Console.WriteLine("TRUE");
            }
        }
        public void Fill()
        {
            int wC, rC, wS, rS;
            wC = rC = 10;
            wS = rS = 11;
            int wP = 21, rP = 21;
            int tmpCol, tmp;
            Random random = new Random();
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
