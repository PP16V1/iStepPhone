using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace iStepPhone.XO
{
    public class XO
    {
        private Cell[,] cell = new Cell[3, 3];
        private bool isXStep = true;

        public XO()
        {
            Console.CursorVisible = true;
            loadField();
            initCells();
            Console.SetCursorPosition(cell[1, 1].location.X, cell[1, 1].location.Y);
            startGame();
        }

        private void startGame()
        {
            int row = 1;
            int col = 1;
            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow)
                {
                    row--;
                    if (row < 0) row = 0;
                    Console.SetCursorPosition(cell[row, col].location.X-1, cell[row, col].location.Y);
                }
                if (key == ConsoleKey.DownArrow)
                {
                    row++;
                    if (row > 2) row = 2;
                    Console.SetCursorPosition(cell[row, col].location.X-1, cell[row, col].location.Y);
                }
                if (key == ConsoleKey.LeftArrow)
                {
                    col--;
                    if (col < 0) col = 0;
                    Console.SetCursorPosition(cell[row, col].location.X-1, cell[row, col].location.Y);
                }
                if (key == ConsoleKey.RightArrow)
                {
                    col++;
                    if (col > 2) col = 2;
                    Console.SetCursorPosition(cell[row, col].location.X-1, cell[row, col].location.Y);
                }
                if (key == ConsoleKey.Enter)
                {
                    if (isXStep)
                    {
                        drowX(cell[row, col].location);
                        cell[row, col].sign = "X";
                        isXStep = false;
                        if (checkWinner())
                        {
                            key = ConsoleKey.Escape;
                            return;
                        }          
                        pcStep();
                    }
                }
            } while (key != ConsoleKey.Escape);
        }

        private void pcStep()
        {
            System.Threading.Thread.Sleep(500);
            Random rand = new Random();
            int col = rand.Next(0, 3);
            int row = rand.Next(0, 3);
            while (cell[col, row].sign != null)
            {
                col = rand.Next(0, 3);
                row = rand.Next(0, 3);
            }
            drowO(cell[col, row].location);
            cell[col,row].sign = "O";
            isXStep = true;
            checkWinner();
        }


        private void initCells()
        {
            Point[,] tmp = { { new Point(2, 1),new Point(12, 1),new Point(21, 1) },
                            { new Point(2, 7),new Point(12, 7),new Point(21, 7) },
                              { new Point(2, 13),new Point(12, 13),new Point(21, 13) } };


            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    cell[i, k] = new Cell();
                    cell[i, k].location = tmp[i,k];
                }
            }

        }

        private bool checkWinner()
        {
            bool check = false;
            int power = 0;
            string sign;

            if (cell[0, 0].sign != null)
            {
                sign = cell[0, 0].sign;
                for (int i = 1; i < 3; i++)
                {
                    if (cell[0, i].sign == sign)
                    {
                        power++;
                    }
                }
                if (power > 1)
                {
                    check = true;
                    Console.Clear();
                    Console.WriteLine(sign+" winner");
                }else
                {
                    power = 0;
                }
            }

            if (cell[1, 0].sign != null)
            {
                sign = cell[1, 0].sign;
                for (int i = 1; i < 3; i++)
                {
                    if (cell[1, i].sign == sign)
                    {
                        power++;
                    }
                }
                if (power > 1)
                {
                    check = true;
                    Console.Clear();
                    Console.WriteLine(sign + " winner");
                }
                else
                {
                    power = 0;
                }
            }

            if (cell[2, 0].sign != null)
            {
                sign = cell[2, 0].sign;
                for (int i = 1; i < 3; i++)
                {
                    if (cell[2, i].sign == sign)
                    {
                        power++;
                    }
                }
                if (power > 1)
                {
                    check = true;
                    Console.Clear();
                    Console.WriteLine(sign + " winner");
                }
                else
                {
                    power = 0;
                }
            }
            return check;
        }

        private void loadField()
        {
            string[] field = File.ReadAllLines("./MarketResources/games/XO/Field.txt");
            for(int i = 0; i < field.Length; i++)
            {
                Console.WriteLine(field[i]);
            }
        }

        private void drowX(Point location)
        {
            string[] sign_IMG = File.ReadAllLines("./MarketResources/games/XO/X.txt");
            for (int i = 0; i < sign_IMG.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(location.X, location.Y + i);
                Console.Write(sign_IMG[i]);               
            }
            Console.ResetColor();
        }

        private void drowO(Point location)
        {
            string[] sign_IMG = File.ReadAllLines("./MarketResources/games/XO/O.txt");
            for (int i = 0; i < sign_IMG.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(location.X, location.Y + i);
                Console.Write(sign_IMG[i]);
            }
            Console.ResetColor();
        }
    }
}
