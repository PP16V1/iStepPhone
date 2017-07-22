using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStepPhone.FileManager;

namespace FileManagerTester
{
    class Program
    {
        static void Main(string[] args)
        {
            new FileManager(@"D:\ДЗ\C#\Source Files\ExamProject\iStepPhone").Show();
        }
    }
}
