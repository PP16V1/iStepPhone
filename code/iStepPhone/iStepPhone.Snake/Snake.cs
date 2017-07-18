using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace iStepPhone.Snake
{

    public class Snake
    {
        private Score score = new Score();
        private Field field = new Field();
        private List<Point> waypiont = new List<Point>();
        private Eat eat = new Eat();
        private int speed = 500;
        private ConsoleKey key=ConsoleKey.RightArrow;
        private bool up, down, left, right;

        public Snake()
        {
            Console.Title = "Snake";
            Console.CursorVisible = false;
            Thread keyHandl = new Thread(keyHandler);
            keyHandl.Start();
            startGame();
        }

        private void startGame()
        {    
            do
            {
                if (right)
                {
                    if (key == ConsoleKey.LeftArrow)
                    {
                        key = ConsoleKey.RightArrow;
                    }
                }
                if (left)
                {
                    if (key == ConsoleKey.RightArrow)
                    {
                        key = ConsoleKey.LeftArrow;
                    }
                }
                if (up)
                {
                    if (key == ConsoleKey.DownArrow)
                    {
                        key = ConsoleKey.UpArrow;
                    }
                }
                if (down)
                {
                    if (key == ConsoleKey.UpArrow)
                    {
                        key = ConsoleKey.DownArrow;
                    }
                }
                if (key == ConsoleKey.UpArrow)
                {
                    field.Head.head_move("up");
                    right = false;
                    left = false;
                    up = true;
                    down = false;
                }
                if (key == ConsoleKey.DownArrow)
                {
                    field.Head.head_move("down");
                    right = false;
                    left = false;
                    up = false;
                    down = true;
                }
                if (key == ConsoleKey.RightArrow)
                {
                    field.Head.head_move("right");
                    right = true;
                    left = false;
                    up = false;
                    down = false;
                }
                if (key == ConsoleKey.LeftArrow)
                {
                    field.Head.head_move("left");
                    right = false;
                    left = true;
                    up = false;
                    down = false;
                }
                waypiont.Add(field.Head.head_position);
                tailMove();
                isEat();
                isDie();
                Console.SetCursorPosition(0, 21);
                System.Threading.Thread.Sleep(speed);
            } while (key!=ConsoleKey.Escape);
        }

        private void tailMove()
        {
            for(int i = 0; i<field.Tail.Count; i++)
            {
                field.Tail[i].Tail_position = waypiont[waypiont.Count - i-2];
                field.Tail[i].move_tail();
            }
            if (field.Tail.Count>=1)
            {
                Console.SetCursorPosition(waypiont[waypiont.Count - field.Tail.Count-2].X, waypiont[waypiont.Count - field.Tail.Count - 2].Y);
                Console.Write(' ');
                Console.SetCursorPosition(0, 21);

            }

        }

        private void isDie()
        {
            if(field.Head.head_position.X>18||
                field.Head.head_position.X<1||
                field.Head.head_position.Y>19||
                field.Head.head_position.Y < 2)
            {
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(5, 6);

                Console.WriteLine("Score: "+score.Scores);
                Console.SetCursorPosition(0, 21);
                key = ConsoleKey.Spacebar;
            }
        }

        private void isEat()
        {
            if (field.Head.head_position.Equals(eat.eat_position))
            {
                score.Scores += 10;
                score.showScore();
                field.Tail.Add(new Tail());
                eat.createEat();
                if (speed > 300)
                {
                    speed -= 30;
                }
            }
        }

        private void keyHandler()
        {
            while (key != ConsoleKey.Escape)
            {
                key = Console.ReadKey().Key;
            }
        }
    }
}
