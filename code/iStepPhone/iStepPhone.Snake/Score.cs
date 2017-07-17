using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Snake
{
    class Score
    {
        public int Scores { get; set; } = 0;
        private const int X_CURSOR_POSITION = 8;
        private const int Y_CURSOR_POSITION = 0;

        public Score()
        {
            Console.WriteLine("Score : "+Scores);
        }
        
        public void showScore()
        {
            Console.SetCursorPosition(X_CURSOR_POSITION, Y_CURSOR_POSITION);
            Console.Write(Scores);
        }
    }
}
