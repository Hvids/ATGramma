using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyATGramma
{
    class Program
    {
        static void Main(string[] args)
        {
            ATGramma at_gramma = new ATGramma(new string[] { "+" }, new string[] { "A", "B","C","digit" }, new string[] { "val","lexval" }, "A");
            at_gramma.addProduction("A->B+C");
            at_gramma.addProduction("C->digit");
            at_gramma.addProduction("B->digit");
            at_gramma.addSemanticRule("A.val=B.val+C.val");
            at_gramma.addSemanticRule("B.val=digit.lexval");
            at_gramma.addSemanticRule("C.val=digit.lexval");
            at_gramma.Print();
            at_gramma.createParserTree();
            at_gramma.printParserTree();
            at_gramma.createDependGraph();
            at_gramma.printDependGraph();
            Console.Read();
        }
    }
}
