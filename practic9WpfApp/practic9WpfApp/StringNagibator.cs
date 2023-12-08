using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic9WpfApp
{
    internal class StringNagibator
    {
        string alphabet = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮqwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM ";

        #region StringSplit
        /// <summary>
        /// Разбивает строку на слова и возвращает их ввиде листа
        /// </summary>
        /// <param name="userString">Строка, которую надо разбить на слова</param>
        /// <returns>Лист слов</returns>
        public List<string> StringSplit(string userString)
        {
            if (!String.IsNullOrEmpty(userString))
            {
                string tempStr;
                string[] tempList;
                List<string> result = new List<string>();

                tempStr = CleanString(userString);
                tempList = tempStr.Split(' ');

                result.AddRange(tempList);

                return result;
            }
            else
            {
                List<string> result = new List<string>();
                result.Add("Твоя строка пахнет слабостью");
                return result;
            }


        }
        #endregion

        #region ReverseString
        /// <summary>
        /// Переворачивает слова в передаваемом тексте
        /// </summary>
        /// <param name="userStr">Текст, слова в котором надо перевернуть</param>
        /// <returns>Строку с обратным порядком слов</returns>
        public string ReverseString(string userStr)
        {
            if (!String.IsNullOrEmpty(userStr))
            {
                string resultStr = "";
                List<string> tempList = new List<string>();

                tempList = StringSplit(userStr);
                tempList.Reverse();

                foreach (string str in tempList)
                {
                    resultStr += $"{str} ";
                }

                return resultStr;
            }
            else
            {
                return "Твоя строка не пахнет даже слабостью";
            }

        }
        #endregion

        #region CleanString
        /// <summary>
        /// Очищает строку от лишних символов (лишними символами считаются все, невходящие в алфавит)
        /// </summary>
        /// <param name="str">Строка, которую надо почистить</param>
        /// <returns></returns>
        private string CleanString(string str)
        {
            string tempStr = "";

            foreach (char c in str) // Удаление ненужных символов
            {
                bool inAlphabet = false;

                foreach (char c2 in alphabet)
                {
                    if (c == c2)
                    {
                        inAlphabet = true;
                        break;
                    }
                }

                if (inAlphabet)
                {
                    tempStr += c;
                }
            }

            tempStr = tempStr.Trim();

            return tempStr;
        }
        #endregion
    }
}
