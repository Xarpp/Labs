using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Caesars_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] words = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'};
            Algorithm algorithm = new Algorithm();
            void menu()
            {
                WriteLine("--------------------MENU--------------------");
                WriteLine("1 - Зашифровать слово");
                WriteLine("2 - Расшифровать слово");
                WriteLine("3 - Взломать слово");
                WriteLine("--------------------------------------------");
                Write("Выберете вариант из меню: ");
                string choice = ReadLine();
                switch (choice)
                {
                    case "1":
                        algorithm.EncryptKey(words);
                        if (check_answer()) menu();
                        break;
                    case "2":
                        algorithm.DecryptKey(words);
                        if (check_answer()) menu();
                        break;
                    case "3":
                        algorithm.CrackKey(words);
                        if (check_answer()) menu();
                        break;
                    default:
                        WriteLine("\nВведен неверый пункт меню, попробуйте еще раз...\n");
                        menu();
                        break;
                }
            }
            bool check_answer()
            {
                Write("Повторить снова? (Y/N): ");
                string answer = ReadLine().ToLower();
                if (answer == "y") return true;
                else return false;
            }
            menu();
        }

        public class Algorithm
        {
            public  void EncryptKey(char[] words)
            {
                string encrypt_word ="";
                string source_word;
                char[] word;
                int key;

                Write("Введите слово для шифрования: ");
                source_word = ReadLine();
                word =source_word.ToLower().ToCharArray();
                Write("Введите ключ: ");
                key = Convert.ToInt32(ReadLine());

                for (int i = 0; i < word.Length; i++)
                {
                    int NewIndexWord = (Array.IndexOf(words, word[i]) + key)%33;
                    encrypt_word += words[NewIndexWord];
                }
                WriteLine($"Исходное слово - {source_word}\nЗашифрованное слово - {encrypt_word}");


            }
            public void DecryptKey(char[] words)
            {
                string encrypt_word = "";
                string source_word;
                char[] word;
                int key;

                Write("Введите слово для расшифровки: ");
                source_word = ReadLine();
                word = source_word.ToLower().ToCharArray();
                Write("Введите ключ: ");
                key = Convert.ToInt32(ReadLine())%33;

                for (int i = 0; i < word.Length; i++)
                {
                    int NewIndexWord = Array.IndexOf(words, word[i]) - key;
                    if (NewIndexWord < 0) NewIndexWord += 33;  
                    encrypt_word += words[NewIndexWord];
                }
                WriteLine($"Исходное слово - {source_word}\nЗашифрованное слово - {encrypt_word}");
            }
            public void CrackKey(char[] words)
            {
                string encrypt_word;
                string source_word;
                char[] word;

                Write("Введите слово для взлома: ");
                source_word = ReadLine();
                word = source_word.ToLower().ToCharArray();

                WriteLine($"\nИсходное слово - {source_word}\nПопытка взлома...\n");
                for (int j = 1; j < 34; j++)
                {
                    encrypt_word = "";
                    for (int i = 0; i < word.Length; i++)
                    {
                        int NewIndexWord = Array.IndexOf(words, word[i]) - j;
                        if (NewIndexWord < 0) NewIndexWord += 33;
                        encrypt_word += words[NewIndexWord];
                    }
                    Write($"Итерация {j} - {encrypt_word}\n");
                }
            }
        }
    }
}
