using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace iStepPhone.Snake
{
    class Eat
    {
        public char EatIMG { get; set; } = '♥';
        public Point eat_position;
        private Random rand = new Random();

        public Eat()
        {
            createEat();
        }
        public void createEat()
        {
            eat_position.X = rand.Next(2, 19);
            eat_position.Y = rand.Next(2, 19);
            Console.SetCursorPosition(eat_position.X, eat_position.Y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(EatIMG);
            Console.ResetColor();
        }
    }
}
