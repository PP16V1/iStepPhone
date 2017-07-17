using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace iStepPhone.Snake
{

    public class Snake
    {
        private Score score = new Score();
        private Field field = new Field();
        private Eat eat = new Eat();
        private ConsoleKey key;

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
                if (key == ConsoleKey.UpArrow)
                {
                    field.Head.head_move("up");
                }
                if (key == ConsoleKey.DownArrow)
                {
                    field.Head.head_move("down");
                }
                if (key == ConsoleKey.RightArrow)
                {
                    field.Head.head_move("right");
                }
                if (key == ConsoleKey.LeftArrow)
                {
                    field.Head.head_move("left");
                }
                isEat();
                isDie();

                Console.SetCursorPosition(0, 21);
                System.Threading.Thread.Sleep(500);
            } while (key!=ConsoleKey.Escape);
        }

        private void isDie()
        {
            if(field.Head.head_position.X>19||
                field.Head.head_position.X<1||
                field.Head.head_position.Y>19||
                field.Head.head_position.Y < 1)
            {
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(5, 6);

                Console.WriteLine("Score: "+score.Scores);
                Console.SetCursorPosition(0, 21);
            }
        }

        private void isEat()
        {
            if (field.Head.head_position.Equals(eat.eat_position))
            {
                score.Scores += 10;
                score.showScore();
                eat.createEat();
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
