using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PR14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Практическая работа №14");
            Console.WriteLine("Выполнили студентка 2 курса группы ИСП.20А");
            Console.WriteLine("Немтырёва Ксения");
            StreamReader sr = new StreamReader(@"Input.txt");
            string Text = sr.ReadToEnd();
            Console.WriteLine(Text);
            string[] TextArray = Text.Split(' ');

            Console.WriteLine("-------");
            Console.WriteLine("Вариант 1");
            Console.WriteLine("Файл содержит текст на русском языке. Определить, входит ли заданное слово в текст, и если входит, то сколько раз.");
            Console.WriteLine("Введите искомое слово:");
            string word = Console.ReadLine();
            Console.WriteLine($"Входит ли искомое слово в текст? {TextArray.Contains(word)}");
            StreamWriter sw = new StreamWriter(@"Rezult.txt", false, Encoding.Default);
            Console.WriteLine(TextArray.Count(x => DeletePunctuation(x) == word));
            sw.WriteLine("1 Вариант");
            sw.WriteLine($"Входит ли искомое слово в текст? {TextArray.Contains(word)}");
            sw.WriteLine(TextArray.Count(x => DeletePunctuation(x) == word));

            Console.WriteLine("-------");
            Console.WriteLine("Вариант 2");
            Console.WriteLine("Файл содержит текст на русском языке. Определить, сколько раз встречается в нем самое длинное слово.");
            int[] lengthArray1 = new int[TextArray.Length];
            lengthArray1 = TextArray.Select(x => DeletePunctuation(x).Length).ToArray();
            Console.WriteLine($"Длина самого длинного слова: {lengthArray1.Max()}");
            int Count1 = TextArray.Count(x => DeletePunctuation(x).Length == lengthArray1.Max());
            Console.WriteLine($"Количество самых длинных слов: {Count1}");            
            sw.WriteLine("Вариант 2");
            sw.WriteLine($"Количество самых длинных слов {Count1}");

            Console.WriteLine("-------");
            Console.WriteLine("Вариант 3");
            Console.WriteLine("Файл содержит текст на русском языке. Составить в алфавитном порядке список всех слов, встречающихся в тексте.");
            sw.WriteLine("3 Вариант");
            foreach (string w in TextArray.OrderBy(x => x).Distinct())
            {
                Console.WriteLine(DeletePunctuation(w));
                sw.WriteLine(DeletePunctuation(w));
            }

            Console.WriteLine("-------");
            Console.WriteLine("Вариант 4");
            Console.WriteLine("Файл содержит текст на русском языке. Определить, сколько раз встречается в нем самое короткое слово.");
            int[] lengthArray = new int[TextArray.Length];
            lengthArray = TextArray.Select(x => DeletePunctuation(x).Length).ToArray();
            Console.WriteLine($"Длина самого короткого слова: {lengthArray.Min()}");
            int Count = TextArray.Count(x => x.Length == lengthArray.Min());
            Console.WriteLine($"Количество самых коротких слов: {Count}");            
            sw.WriteLine("Вариант 4");
            sw.WriteLine($"Количество самых коротких слов {Count}");          
            Console.ReadKey();

            Console.WriteLine("-------");
            Console.WriteLine("Вариант 6");
            Console.WriteLine("Файл содержит текст из русских и английских слов. Определить, каких букв в тексте больше – русских или английских.");
            //string alph = "";
            //for (Char c='а'; c<='я'; c++)
            //{
            //    alph += $"\"{c}\",";
            //}
            //Console.WriteLine(alph);
            string rusalhavit = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя" ;
            string englishalhavit = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int ruscount = Text.Count(x => rusalhavit.Contains(x));
            int englishcount = Text.Count(x => englishalhavit.Contains(x));            
            Console.WriteLine("Каких букв больше?");
            if(ruscount > englishcount)
                Console.WriteLine("Русских букв больше");
            else if (ruscount < englishcount)
                Console.WriteLine("Английскич букв больше");
            else
                Console.WriteLine("Одинаковое количество русских и английских букв");
            sw.WriteLine("Каких букв больше?");
            if (ruscount > englishcount)
                sw.WriteLine("Русских букв больше");
            else if (ruscount < englishcount)
                sw.WriteLine("Английскич букв больше");
            else
                sw.WriteLine("Одинаковое количество русских и английских букв");

            Console.WriteLine("-------");
            Console.WriteLine("Вариант 7");
            Console.WriteLine("Файл содержит текст на русском языке и цифры. Определить, сколько букв в тексте, сколько цифр и сколько знаков препинания.");
            string punctuation1 = ".,!?;:-\"\'";
            int countallsumbols = 0;
            int countpunct = 0;
            //foreach (string s in TextArray)
            //{
            //   if(s != " ")
            //    {
            //        countallsumbols++;
            //    }
            //    Messagebox
            //}
            Console.WriteLine(countpunct);
            Console.WriteLine(countallsumbols);


            Console.WriteLine("-------");
            Console.WriteLine("Вариант 8");
            Console.WriteLine("Файл содержит текст из русских и английских слов. Заменить в исходном тексте все прописные буквы на строчные, и наоборот.");
            string newtext = " ";
            foreach (char c in Text)
            {
                if (Char.IsUpper(c))
                    newtext += c.ToString().ToLower();
                else
                    newtext += c.ToString().ToUpper();
            }
            Console.WriteLine(newtext);
            sw.WriteLine("Вариант 8");
            sw.WriteLine($"{newtext}");

            sw.Close();
            Console.ReadKey();
        }
        //Удаление знаков
        private static string DeletePunctuation (string inputword)
        {
            string outword = " ";
            string punctuation = ".,!?;:-\"\'";
            foreach (char simvol in inputword)
                if (!punctuation.Contains(simvol)) outword += simvol;
            return outword;
        }
    }
}
