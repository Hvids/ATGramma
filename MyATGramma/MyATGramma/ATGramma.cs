using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATGramma
{
   partial class ATGramma
    {
        public ATGramma(string[] T, string[] V,string[] A,string S) {

            this.terminal_symbols = new TSymbol[0];
            this.non_terminal_symbols = new TSymbol[0];
            this.productions = new TRule[0];
            this.semantic_rules = new TRule[0];
            this.atributes = new TSymbol[0];

            this.setStartSymbol(S);
            this.createArrTerminaSymbol(T);
            this.createArrNonTerminalSymbol(V);
            this.createArrAtribute(V);
            
            this.count_productions = 0;
            this.count_semanic_rules = 0;
        }

        private TSymbol start_symbol;
        private TSymbol[] terminal_symbols;
        private TSymbol[] non_terminal_symbols;
        private TAttribute[] _aributes;//все атрибуты с их символами
        private TRule[] productions;
        private TRule[] semantic_rules;
        private TSymbol[] atributes;
        private TMatrix parse_tree;
        private TMatrix depend_graph;

        //Пременные используемы для подсчета

        private int count_productions;
        private int count_semanic_rules;
    }
}
