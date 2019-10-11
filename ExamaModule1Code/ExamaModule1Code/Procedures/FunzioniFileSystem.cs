using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExamaModule1Code.Procedures
{
    public static class FunzioniFileSystem
    {
        public static string AssicuratiCheEsistaCartellaDiArchivio()
        {
            //1) Compongo il percorso della cartella di lavoro
            var workingFolder = AppDomain.CurrentDomain.BaseDirectory;

            const string DataFolderName = "data";

            //Composizone del percorso della folder
            var folderPath = Path.Combine(workingFolder, DataFolderName);

            //Se non esiste, la creo
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            return folderPath;
        }


        internal static void AggiungiTestoAFileDatabase(string testoDiProva, string archiveFolder)
        {
            string databasePath = ComponiPercorsoFileDatabase(archiveFolder);

            //Se il file non esiste, creo il file e aggiungo il testo
            if (!File.Exists(databasePath))
            {
                //Creazione dello stream in Create
                using (StreamWriter writer = File.CreateText(databasePath))
                {
                    writer.WriteLine(testoDiProva);
                    writer.Close();
                }
            }
            else
            {
                //Creazione dello stream in Append
                using (StreamWriter writer = File.AppendText(databasePath))
                {
                    writer.WriteLine(testoDiProva);
                    writer.Close();
                }
            }
        }

        private static string ComponiPercorsoFileDatabase(string archiveFolder)
        {
            
                const string DataBaseFileName = "database.txt";

                //Composizione del percorso del file database
                string databasePath = Path.Combine(archiveFolder, DataBaseFileName);

                //Ritorno il percorso
                return databasePath;
            
        }


    }
}
