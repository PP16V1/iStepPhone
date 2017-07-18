using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.Snake
{
    class Field
    {
        public Head Head { get; set; } = new Head();
        public List<Tail> Tail { get; set; } = new List<Tail>();
        public Field()
        {
            initField();
        }
        private void initField()
        {
            for(int i = 0; i < 20; i++)
            {
                for(int k = 0; k < 20; k++)
                {
                    if (i == 0 || i == 19)
                    {
                        Console.Write('*');
                    } else if (k == 0 || k == 19)
                    {
                        Console.Write('*');
                    }else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
