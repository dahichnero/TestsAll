using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace Shtirlitz
{
    public class ShtirlitzClass : BaseEncryptionAlgorithm
    {
        private string letters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";//буквы
        //private string textkey = "аэрофотосъёмка ландшафта уже выявила земли богачей и процветающих крестьян";
        public int[] Key = new int[33]; //массив позиций из текста-ключа
        public string textkey { get; set; } //основной ключ-текст из которого берутся позиции

        private void ReadKey()//заполнение массива позиций Key
        {
            textkey.ToLower();
            for (int i = 0; i < letters.Length; i++)
            {
                for(int j = 0; j < textkey.Length; j++)
                {
                    if (textkey[j] == letters[i])
                    {
                        Key[i] = j;
                        break;
                    }
                }
            }
        }

        public override string Encrypt(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                ReadKey();
                text = text.ToLower();
                string[] textchar = new string[text.Length];
                for (int i = 0; i < text.Length; i++)
                {
                    if (letters.Contains(text[i]))
                    {
                        for (int j = 0; j < Key.Length; j++)
                        {
                            if (text[i] == letters[j])
                            {
                                //string keyStr = $"*{Key[j]}*";
                                textchar[i] = $"*{Key[j]}*";
                            }
                        }
                    }
                    else
                        textchar[i] = text[i].ToString();
                }
                string result = String.Join("", textchar);
                return result;
            }
            return "Введите текст!!!";
        }

        public override string Decrypt(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                ReadKey();
                string result = text;
                for (int i=0; i<letters.Length; i++)
                {
                    result = result.Replace($"*{Key[i]}*", letters[i].ToString());
                }
                return result;
            }
            return "Введите текст!!!";
        }
    }
}
