using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATGramma
{
   partial class ATGramma
    {
        private void createArrTerminaSymbol(string[] T)
        {
            //Метод создает из массива строк терминальных символов массив структры TSymbol

            int i = 0;
            foreach (string s in T)
            {
                i++;
                Array.Resize(ref this.terminal_symbols, this.terminal_symbols.Length + 1);
                TSymbol symbol;
                symbol.key = i;
                symbol.symbol = s;
                symbol.type = 0;
                this.terminal_symbols[i - 1] = symbol;
            }
        }

        private void createArrNonTerminalSymbol(string[] V)
        {
            //Метод создает из массива строк нетерминальных символов массив структры TSymbol

            int i = 1;
            foreach (string s in V)
            {
                if (s == this.start_symbol.symbol)
                    continue;
                i++;
                Array.Resize(ref this.non_terminal_symbols, this.non_terminal_symbols.Length + 1);
                TSymbol symbol;
                symbol.key = i;
                symbol.symbol = s;
                symbol.type = 1;
                this.non_terminal_symbols[this.non_terminal_symbols.Length -1] = symbol;
            }
        }
        private void createArrAtribute(string[] A)
        {
            //Метод создает из массива строк атрибутов символов массив структры TSymbol

            int i = 0;
            foreach (string s in A)
            {
                i++;
                Array.Resize(ref this.atributes, this.atributes.Length+1 );
                TSymbol symbol;
                symbol.key = i;
                symbol.symbol = s;
                symbol.type = 2;
                this.atributes[i - 1] = symbol;
            }
        }
        private void setStartSymbol(string start)
        {
            //Устанавливаем начальный символ
            Array.Resize(ref this.non_terminal_symbols, 1);
            TSymbol s;
            s.key = 1;
            s.symbol = start;
            s.type = 1;
            this.start_symbol =s;
            this.non_terminal_symbols[0] = s;
        }
        public void Print()
        {
            Console.WriteLine("Терминальные символы:");
            foreach(TSymbol symbol in this.terminal_symbols)
            {
                symbol.DisplayInfo();
            }
            Console.WriteLine("Нетерминальные символы:");
            foreach (TSymbol symbol in this.non_terminal_symbols)
            {
                symbol.DisplayInfo();
            }
            Console.WriteLine("Атрибуты:");
            foreach (TSymbol symbol in this.atributes)
            {
                symbol.DisplayInfo();
            }

            Console.WriteLine("Начальный символ: {this.start_symbol}");

            Console.WriteLine("Продукции:");
            foreach (TRule rule in this.productions)
            {
                rule.DisplayInfo();
            }

            Console.WriteLine("Семантические правила:");
            foreach (TRule rule in this.semantic_rules)
            {
                rule.DisplayInfo();
            }
        }
        public void printParserTree()
        {
            int maxlength = 0;

            foreach (var item in this.parse_tree.keys)
            {
                if (maxlength < item.symbol.Length)
                    maxlength = item.symbol.Length;
            }
            Console.WriteLine("Дерево разбора");
            for (int j = 0; j < maxlength+2; j++)
                   Console.Write(" ");
            
            maxlength += 1;
            for (int i = 0; i < this.parse_tree.keys.Length; i++)
            {
                Console.Write($"{this.parse_tree.keys[i].symbol} ");
                for (int j = 0; j < maxlength - this.parse_tree.keys[i].symbol.Length; j++)
                    Console.Write(" ");
            }
            Console.WriteLine();
            
            for (int i = 0; i < this.parse_tree.keys.Length; i++)
            {   
                for (int j = 0; j < parse_tree.keys.Length; j++)
                {
                    
                    if (j == 0)
                    {
                        Console.Write($"{this.parse_tree.keys[i].symbol} ");
                        for (int k = 0; k < maxlength - this.parse_tree.keys[i].symbol.Length; k++)
                            Console.Write(" ");
                    }
                        
                    Console.Write($"{this.parse_tree.matrix[i][j]} ");
                    for (int k = 0; k < maxlength - 1; k++)
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void printDependGraph()
        {
            int maxlength = 0;
            for (int i = 0; i < this._aributes.Length; i++)
            {
                if (maxlength < this._aributes[i].atribute.Length)
                    maxlength = this._aributes[i].atribute.Length;
            }
            Console.WriteLine("Граф зависимости");
            for (int k = 0; k < maxlength+1 ; k++)
                Console.Write(" ");

            for (int i = 0; i < this._aributes.Length; i++)
            {
                Console.Write($"{this._aributes[i].atribute} ");
                for (int k = 0; k < maxlength - this._aributes[i].atribute.Length; k++)
                    Console.Write(" ");
            }
            Console.WriteLine();

            for (int i = 0; i < this._aributes.Length; i++)
            {
                for (int j = 0; j < this._aributes.Length; j++)
                {

                    if (j == 0)
                    {
                        Console.Write($"{this._aributes[i].atribute} ");
                        for (int k = 0; k < maxlength - this._aributes[i].atribute.Length; k++)
                            Console.Write(" ");
                    }

                    Console.Write($"{this.depend_graph.matrix[i][j]} ");
                    for (int k = 0; k < maxlength - 1; k++)
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
