using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATGramma
{
    struct TAttribute
    {
        public string str;
        public string atribute;
        public string symbol;
    }
    struct TRule
    {
        //Структура данный для правил

        public int key;
        public string rigth;
        public string left;
        public TSymbol[] symbol;
        public void DisplayInfo()
        {
            Console.WriteLine($"{left} -> {rigth}");
        } 
    }
    struct TSymbol
    {
        //Структура данных для символ 0-t 1-nt 2-at
        public int type;
        public int key;
        public string symbol;

        public void DisplayInfo()
        {
            Console.WriteLine($"[{key}] = {symbol}");
        }

    }
    struct TMatrix
    {
        //Сруктура данных для матриц дерева разбора и графа зависимости
        
        public TSymbol[] keys;
        public int[][] matrix;
    }
}
