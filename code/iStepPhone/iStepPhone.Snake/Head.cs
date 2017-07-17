using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Snake
{
    class Head
    {
        public Point head_position;
        public char Head_IMG { get; set; } = '☺';

        public Head()
        {
            head_position.X = 5;
            head_position.Y = 5;
        }

        public void head_move(string direction)
        {
            Console.SetCursorPosition(head_position.X, head_position.Y);
            Console.Write(' ');
            if (direction.Equals("up"))
            {
                head_position.Y--;
            }
            if (direction.Equals("down"))
            {
                head_position.Y++;
            }
            if (direction.Equals("left"))
            {
                head_position.X--;
            }
            if (direction.Equals("right"))
            {
                head_position.X++;
            }
            Console.SetCursorPosition(head_position.X, head_position.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Head_IMG);
            Console.ResetColor();
        }
    }
}
