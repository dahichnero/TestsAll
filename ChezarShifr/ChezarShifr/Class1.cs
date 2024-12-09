using System;

namespace ChezarShifr
{
    public static class CaesarCrypt
    {
        public static string Encrypt(string text, int key)
        {
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alphabetCaps = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            char[] textx = text.ToCharArray();
            int index = 0;
            int j = 0;
            for (int i = 0; i < textx.Length; i++)
            {
                for (j = 0; j < alphabet.Length; j++)
                {
                    if (textx[i] == alphabet[j] || textx[i]==alphabetCaps[j])
                    {
                        index = j;
                        break;
                    }
                }
                if (j != 33)
                {
                    index = index + key;
                    if (index > 32)
                    {
                        index = index - 33;
                    }
                    if (alphabet.Contains(textx[i]) == true)
                    {
                        textx[i] = alphabet[index];
                    }
                    else if (alphabetCaps.Contains(textx[i]) == true)
                    {
                        textx[i] = alphabetCaps[index];
                    }
                }
            }
            string res = "";
            for (int i = 0; i < textx.Length; i++)
            {
                res = res + textx[i];
            }
            return res;
        }
        public static string Decrypt(string text, int key)
        {
            char[] textx = text.ToCharArray();
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alphabetCaps = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            int j = 0;
            int index = 0;
            for (int i = 0; i < textx.Length; i++)
            {
                for (j = 0; j < alphabet.Length; j++)
                {
                    if (textx[i] == alphabet[j] || textx[i]==alphabetCaps[j])
                    {
                        index = j;
                        break;
                    }
                }
                if (j != 33)
                {
                    index = index - key;
                    if (index < 0)
                    {
                        index = index + 33;
                    }
                    if (alphabet.Contains(textx[i]) == true)
                    {
                        textx[i] = alphabet[index];
                    }
                    else if (alphabetCaps.Contains(textx[i]) == true)
                    {
                        textx[i]=alphabetCaps[index];
                    }
                }

            }
            string res = "";
            for (int i = 0; i < textx.Length; i++)
            {
                res = res + textx[i];
            }
            return res;
        }
    }
}
