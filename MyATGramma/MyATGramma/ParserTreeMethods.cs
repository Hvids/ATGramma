using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATGramma
{
    partial class ATGramma
    {
    
        
        private bool findSymbolInArr(TSymbol[] arr, TSymbol s)
        {
            foreach (var item in arr)
            {
                if (item.symbol == s.symbol) 
                    return true;
            }
            return false;
        }
        
        private void resizeParserTree(TSymbol symbol)
        {
            Array.Resize(ref this.parse_tree.keys, this.parse_tree.keys.Length + 1);
            this.parse_tree.keys[this.parse_tree.keys.Length - 1] = symbol;

            Array.Resize(ref this.parse_tree.matrix, this.parse_tree.matrix.Length + 1);
            if (this.parse_tree.matrix.Length == 1)
            {
                this.parse_tree.matrix[0] = new int[1];
                this.parse_tree.matrix[0][0] = 0;
                return;
            }
            for (int i = 0; i < this.parse_tree.matrix.Length; i++)
            {
                if(i== this.parse_tree.matrix.Length - 1)
                {
                    this.parse_tree.matrix[i] = new int[this.parse_tree.keys.Length];
                    for (int j = 0; j < this.parse_tree.matrix[i].Length; j++)
                    {
                        this.parse_tree.matrix[i][j] = 0;
                    }
                    continue;
                }
                Array.Resize(ref this.parse_tree.matrix[i], this.parse_tree.matrix[i].Length + 1);
                this.parse_tree.matrix[i][this.parse_tree.matrix[i].Length - 1] = 0;
            }
            
        }
        private void cParserTree(TSymbol symbol)
        {
            int heigth = 0;
            int width=0;
            TRule rule;
            rule.left = "";
            rule.symbol = new TSymbol[0];
      
            
               
                if (!findSymbolInArr(this.parse_tree.keys, symbol))
                {
                    
                    this.resizeParserTree(symbol);
                    width = this.parse_tree.matrix.Length - 1;
                }
                else
                {
                    for (int i = 0; i < this.parse_tree.keys.Length; i++)
                    {
                        if(symbol.symbol == this.parse_tree.keys[i].symbol)
                        {
                            width = i;
                            break;
                        }
                    }
                }
                foreach (var item in this.productions)
                {
                    if(item.rigth==symbol.symbol)
                    {
                        rule = item;
                        break;
                    }
                }
                foreach (var item in rule.symbol)
                {
                if (item.type == 1) {
                    
                    bool find = false;
                    for (int i = 0; i < this.parse_tree.keys.Length; i++)
                    {
                        if(item.symbol== this.parse_tree.keys[i].symbol)
                        {
                            heigth = i;
                            find = true;
                            break;
                        }
                    }
                    if (!find)
                    {
              
                        this.resizeParserTree(item);
                        heigth = this.parse_tree.matrix[0].Length - 1;
                    }
                    this.parse_tree.matrix[heigth][width]=1;
                    if (symbol.symbol != this.parse_tree.keys[heigth].symbol)
                        this.cParserTree(this.parse_tree.keys[heigth]);
                }
                else
                {
                    this.resizeParserTree(item);
                    heigth = this.parse_tree.matrix[0].Length - 1;
                    this.parse_tree.matrix[heigth][width] = 1;
                }
               }
           
            

        }
        public void createParserTree()
        {
            this.parse_tree.keys = new TSymbol[0];
            this.parse_tree.matrix = new int[0][];
            this.cParserTree(this.start_symbol);
        }
        
    }
}
