using ExamaModule1Code.Procedures;
using ExamaModule1Code.Utils;
using System;

namespace ExamaModule1Code
{
    class Program
    {
        static void Main(string[] args)
        {
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 10);
            FunzioniListaProduct.InserisciNumeroArbitrarioProductInLista(selezione);
        }
    }

    
}
