using System;

namespace NaturalNumsLib
{
    public static class NaturalNumbers
    {
        /// <summary>
        /// Определяет, является ли данное число чётным
        /// </summary>
        /// <param name="Number">Положительное целое число для проверки на чётность</param>
        /// <returns>Возвращает true, если число чётное</returns>
        public static bool IsEven(int Number)
        {
            //throw new NotImplementedException("Не реализован");
            return Number%2==0;
        }
        /// <summary>
        /// Вычисляет НОД для двух целых положительных чисел
        /// </summary>
        /// <param name="A">Первое число</param>
        /// <param name="B">Второе число</param>
        /// <returns>Возвращает значение НОД</returns>
        public static int GCD(int A, int B)
        {
            while (A != B)
            {
                if (A > B)
                {
                    A = A - B;
                }
                else
                {
                    B = B - A;
                }
            }
            return A;
        }
        public static bool IsPrime(int Number)
        {
            for (int i=2; i<Number; i++)
            {
                if (Number % i == 0)
                {
                    return false;
                    break;
                }
            }
            return true;
        }
    }
}
