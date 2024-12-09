using System;
using ChezarShifr;
using static System.Console;
using System.IO;
using System.Collections.Generic;
namespace CaesarShifrConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите смещение:");
            int key = int.Parse(ReadLine());
            WriteLine("Введите имя файла:");
            string FileName = ReadLine();
            if (File.Exists(FileName)==true)
            {
                StreamReader sr = File.OpenText(FileName);
                List<string> list = new List<string>();
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
                sr.Close();
                WriteLine("Выберите действие: 1-зашифровать, 2-расшифровать");
                int ch = int.Parse(ReadLine());
                switch (ch)
                {
                    case 1:
                        StreamWriter st = File.CreateText(FileName);
                        for (int i = 0; i < list.Count; i++)
                        {
                            st.WriteLine(CaesarCrypt.Encrypt(list[i], key));
                        }
                        st.Close();
                        WriteLine("Зашифровано");
                        break;
                    case 2:
                        StreamWriter sy = File.CreateText(FileName);
                        for (int i = 0; i < list.Count; i++)
                        {
                            sy.WriteLine(CaesarCrypt.Decrypt(list[i], key));
                        }
                        sy.Close();
                        WriteLine("Расшифровано");
                        break;
                    default: WriteLine("Нет такой функции");
                        break;
                }
            }
            else
            {
                WriteLine("Нет такого файла...");
            }
        }
    }
}
