using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RetrovirusDBParser
{
    class Program
    {
        public static string workingDirectoryFilePath = Directory.GetCurrentDirectory() + "\\";

        static void Main(string[] args)
        {
            Console.WriteLine("Choose operation by writing the corresponding choice (1 or 2):");
            Console.WriteLine("(1) Parse Retrovirus Database Html Dump And Generate Positions File");
            Console.WriteLine("(2) Generate Training and Validation Set From Existing Positions File");
            string optionChosen = Console.ReadLine();
            while (!optionChosen.Contains("1") && !optionChosen.Contains("2"))
            {
                Console.WriteLine("Unknown option selected, please choose (1 or 2)!");
                Console.WriteLine("(1) Parse Retrovirus Database Html Dump And Generate Positions File");
                Console.WriteLine("(2) Generate Training and Validation Set From Existing Positions File");
                optionChosen = Console.ReadLine();
            }
            string positionsPath = workingDirectoryFilePath + "positions.txt";
            string labelsPath = workingDirectoryFilePath + "labels.txt";
            string insertsPath = workingDirectoryFilePath + "inserts.txt";
            string DNAFileOutPath = workingDirectoryFilePath + "DNAString.txt";
            string DNAFileOutValidationPath = workingDirectoryFilePath + "DNAString_validation.txt";
            string validationInsertsPath = workingDirectoryFilePath + "inserts_validation.txt";
            string validationLabelsPath = workingDirectoryFilePath + "labels_validation.txt";

            if (optionChosen.Contains("1")) {
                Console.WriteLine("Make sure that you have the dump (result.html) in same path as this executable.");
                Console.WriteLine("Press ENTER to continue parsing the dump and generating the positions file");
                Console.ReadLine();
                Parser.generatePositionsFile(positionsPath, new System.Collections.Hashtable());
                Console.WriteLine("DONE!, Press ENTER to exit");
                Console.ReadLine();
            }
            else if (optionChosen.Contains("2"))
            {
                Console.WriteLine("Make sure that you have the positions file (positions.txt) in same path as this executable.");
                Console.WriteLine("Press ENTER to continue parsing the dump and generating the positions file");
                Console.ReadLine();
                Console.WriteLine("Reading existing positions...");
                System.Collections.Hashtable existingPositionsHash = DatasetGeneratorUtil.getExistingPositionsSorted(positionsPath);
                Console.WriteLine("Done reading positions, generating data..");
                DatasetFileGenerator.getExistingPositionsAndGenerateData(positionsPath, labelsPath, insertsPath, validationInsertsPath, validationLabelsPath, DNAFileOutPath, DNAFileOutValidationPath, existingPositionsHash);
                Console.WriteLine("DONE!, Press ENTER to exit");
                Console.ReadLine();
            }
         }
    }
}
