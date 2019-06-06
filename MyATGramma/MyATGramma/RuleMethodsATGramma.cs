using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATGramma
{
    partial class ATGramma
    {
        
        public void addProduction(string rule)
        {
            //метод добвлет продукции
            this.count_productions += 1;
            int index = rule.IndexOf('-');
         
            string rigth = rule.Substring(0, index);
            string left = rule.Substring(index+2,rule.Length-(index+2));

            TRule new_rule;
            new_rule.key = this.count_productions;
            new_rule.left = left;
            new_rule.rigth = rigth;
            new_rule.symbol = new TSymbol[0];
            foreach (var item in left)
            {
                foreach(var T in this.non_terminal_symbols)
                {   

                    if (T.symbol[0] == item) {

                        Array.Resize(ref new_rule.symbol, new_rule.symbol.Length + 1);
                        new_rule.symbol[new_rule.symbol.Length-1] = T;
                        break;
                    }
                }
                foreach (var T in this.terminal_symbols)
                {

                    if (T.symbol[0] == item)
                    {

                        Array.Resize(ref new_rule.symbol, new_rule.symbol.Length + 1);
                        new_rule.symbol[new_rule.symbol.Length - 1] = T;
                        break;
                    }
                }
            }
            Array.Resize(ref this.productions, this.productions.Length + 1);
            this.productions[this.count_productions - 1]=new_rule;

        }

        public void addSemanticRule(string rule)
        {
            //метод добвлет семантическое правило
            this.count_semanic_rules += 1;
            int index = rule.IndexOf('=');
            string left = rule.Substring(0, index);
            string rigth = rule.Substring(index + 1, rule.Length - (index + 1));

            TRule new_rule;
            new_rule.key = this.count_semanic_rules;
            new_rule.left = left;
            new_rule.rigth = rigth;
            new_rule.symbol = new TSymbol[0];
            Array.Resize(ref this.semantic_rules, this.semantic_rules.Length + 1);
            this.semantic_rules[this.count_semanic_rules - 1] = new_rule;
        }
        
    }
}
