using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace iStepPhone.Snake
{
    public class Tail
    {
        public Point Tail_position { get; set; } = new Point();
        private char tail_IMG = '☻';

        public void move_tail()
        {
            Console.SetCursorPosition(Tail_position.X, Tail_position.Y);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(tail_IMG);
            Console.ResetColor();
            Console.SetCursorPosition(0, 21);
        }
    }
}
