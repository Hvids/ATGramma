using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATGramma
{
   partial class ATGramma
    {
        private void resizeDependGraph(TAttribute symbol)
        {
            Array.Resize(ref this._aributes, this._aributes.Length + 1);
            this._aributes[this._aributes.Length - 1] = symbol;

            Array.Resize(ref this.depend_graph.matrix, this.depend_graph.matrix.Length + 1);
            if (this.depend_graph.matrix.Length == 1)
            {
                this.depend_graph.matrix[0] = new int[1];
                this.depend_graph.matrix[0][0] = 0;
                return;
            }
            for (int i = 0; i < this.depend_graph.matrix.Length; i++)
            {
                if (i == this.depend_graph.matrix.Length - 1)
                {
                    this.depend_graph.matrix[i] = new int[this._aributes.Length];
                    for (int j = 0; j < this.depend_graph.matrix[i].Length; j++)
                    {
                        this.depend_graph.matrix[i][j] = 0;
                    }
                    continue;
                }
                Array.Resize(ref this.depend_graph.matrix[i], this.depend_graph.matrix[i].Length + 1);
                this.depend_graph.matrix[i][this.depend_graph.matrix[i].Length - 1] = 0;
            }

        }

        private void cDependGraph(char[] terms,int start)
        {
            

            foreach (var atr in this._aributes)
            {
                int heigth = 0, width = 0;
                foreach (var rule in this.semantic_rules)
                {
                    if (atr.str == rule.left) {
                        string[] new_rules = rule.rigth.Split(terms);
                        foreach (var item in new_rules)
                        {

                            bool find = false;
                            for (int i = 0; i < this._aributes.Length; i++ )
                            {
                                if (this._aributes[i].str == item && i < start)
                                {
                                    heigth = i;
                                    find = true;
                                }

                                if (atr.str==this._aributes[i].str )
                                {
                                    width = i;
                                }
                            }
                            if (!find)
                            {
                               
                                string[] str = item.Split('.');

                               
                                
                                TAttribute addarr;
                                addarr.atribute = str[1];
                                addarr.symbol = str[0];
                                addarr.str = item;
                                this.resizeDependGraph(addarr);
                                heigth = this._aributes.Length - 1;
                            }

                            this.depend_graph.matrix[heigth][width] = 1;
                        }

                       
                        
                    }

                   
                }
            }
        }

        private void createArrAtributes()
        {
            foreach (var rule in this.semantic_rules)
            {
                string[] str = rule.left.Split(new char[] { '.' });
                TAttribute atr;
                atr.str = rule.left;
                atr.atribute = str[1];
                atr.symbol = str[0];
                Array.Resize(ref this._aributes, this._aributes.Length + 1);
                this._aributes[this._aributes.Length - 1] = atr;
             }
        }
        
       
        public void createDependGraph()
        {
            this._aributes = new TAttribute[0];
            this.createArrAtributes();
            this.depend_graph.keys = new TSymbol[0];
           
            this.depend_graph.matrix = new int[this._aributes.Length][];
            for (int i = 0; i < this._aributes.Length; i++)
            {
                this.depend_graph.matrix[i] = new int[this._aributes.Length];
            }

            char[] terms = new char[0];
            foreach (var T in this.terminal_symbols)
            {
                bool find = false;
                foreach (var atr in this._aributes)
                {
                    if (atr.symbol == T.symbol)
                    {
                        find = true;
                        break;
                    }
                }
                if (!find)
                {
                    Array.Resize(ref terms, terms.Length + 1);
                    terms[terms.Length - 1] = T.symbol[0];
                }

            }
            this.cDependGraph(terms,this._aributes.Length);
        }
    }
    
 }
