using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Практика_16_1_2
{
    class Program
    {
        static bool Check(string text)
        {
            bool check = false;
            text = text.ToUpper();
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                char spase = ' ';
                if (c == spase)
                {
                    continue;
                }
                else
                    { 
                    if (c >= 'А' && c <= 'Я')
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
            }
            return check;
        }
        static string ReadFile(string namefile)
        {
            Stack<string> stack = new Stack<string>();
            StreamReader sr = new StreamReader(namefile);
            string line = "";
            string glasnie = "ауоыиэяюёе";
            char[] s = glasnie.ToCharArray();
            string exit_text = "";
            if (File.Exists(namefile))
            {
                line = File.ReadAllText(namefile);
                /*while (!sr.EndOfStream)
                {
                    line += sr.ReadLine();
                }*/
                sr.Close();
            }
            else
                return "Такого файла нет";
            for (int i = 0; i < line.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (line[i] == s[j])
                    {
                        stack.Push(line[i].ToString());
                    }
                }
            }
            for (int i = -1; i < stack.Count; i++)
            {
                exit_text += stack.Pop();
            }
            return exit_text;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите текст для записи в файл: ");
                string text = Console.ReadLine();
                if (Check(text) == true)
                {

       
                    StreamWriter sw = File.AppendText("text1.txt");
                    sw.WriteLine(text);
                    sw.Close();
                    Console.WriteLine("Гласные из файла в обратном порядке:");
                    Console.WriteLine(ReadFile("text1.txt"));
                }
                else
                {
                    Console.WriteLine("В тексте должны использоваться только русские буквы");
                }
            }
        }
    }
}
