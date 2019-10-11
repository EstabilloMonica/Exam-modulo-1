using ExamaModule1Code.Enteties;
using ExamaModule1Code.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamaModule1Code.Procedures
{
    public static class FunzioniListaProduct
    {
        public static void InserisciNumeroArbitrarioProductInLista(int selezione)
        {
           

            //Richiamo la funzione che genera la rubrica
 
            List<Product> listaProduct = new List<Product>();

            //4) Itero per il numero di prodotti richiesto
            for (int index = 0; index < selezione; index++)
            {
                //Richiamo una funzione a cui passo la lista
                //e l'indice corrente e questa mi aggiunge il prodotto
                AggiungiProductInListaInPosizione(listaProduct);
            }

            //9) Itero la lista e stampo a video (con for) tutti i product
            StampaRubrica(listaProduct);

            //Cerimonia finale
            ConsoleUtils.ConfermaUscita();
        }


        private static void AggiungiProductInListaInPosizione(List<Product> listaProduct)
        {
            //5) Richiedo il code e il nome del prodotto
            Console.Write("code: ");
            var code = Console.ReadLine();
            Console.Write("name: ");
            var name = Console.ReadLine();

            //6) Creo oggetto Product da inserire in lista
            Product product = new Product
            {
                Code = code,
                Name = name
            };

            //7) Aggiungo prodotto a lista
            listaProduct.Add(product);

            //Aggiungo la persona al file database
            SalvaProductInFile(product);

            //8) Se ho inserito tutti i prodotti termino il ciclo
        }

        private static void SalvaProductInFile(Product product)
        {
            //Assicuriamoci che esista la folder per il file di archivio
            string archiveFolder = FunzioniFileSystem.AssicuratiCheEsistaCartellaDiArchivio();
            //** Arrivo a questo punto e sono sicuro al 100% che la cartella dove
            //** sarà conservato il file database esiste: ne ottengo il percorso

            string datiDellaPersonaInFormatoStringa = ConvertiProductInStringa(product);

            //Aggiungi testo a file
            FunzioniFileSystem.AggiungiTestoAFileDatabase(datiDellaPersonaInFormatoStringa, archiveFolder);
        }

        private static string ConvertiProductInStringa(Product product)
        {
            
            return $"{product.Code},{product.Name}";
            
        }

        private static void StampaRubrica(List<Product> listProduct)
        {
            Console.WriteLine("*** Visualizzazione contenuto lista***");
            for (var index = 0; index < listProduct.Count; index++)
            {
                Console.WriteLine($" => {listProduct[index].Code}, {listProduct[index].Name}");
            }
        }

       



    }
}
