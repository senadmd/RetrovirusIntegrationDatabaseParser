using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrovirusDBParser
{
    static class DatasetFileGenerator
    {
      public static async void getExistingPositionsAndGenerateData(string positionsFile, string labelsFileOutputPath,
      string insertsFileOutputPath, string validationFileOutputPath, string validationLabelsFileOutputPath,
      string DNAStringOutputFilePath, string DNAStringOutputValidationFilePath, System.Collections.Hashtable existingPositionsHash)
        {
            float totalTargetLength;
            float percentDone;
            List<int> existingPositions = new List<int>();
            string tmp;
            string[] splitted;
            int position;
            Task<DNATuple> tskTup1;
            Task<DNATuple> tskTup2;
            DNATuple tup;
            bool printToValidation = false;
            KeyValuePair<string, int> randomFalsePosition;
            using (FileStream fs = File.Open(positionsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                using (StreamWriter swValidation = File.AppendText(validationFileOutputPath))
                {
                    using (StreamWriter swValidationLabels = File.AppendText(validationLabelsFileOutputPath))
                    {
                        using (StreamWriter swLabels = File.AppendText(labelsFileOutputPath))
                        {
                            using (StreamWriter swInserts = File.AppendText(insertsFileOutputPath))
                            {
                                using (StreamWriter swDNAOutput = File.AppendText(DNAStringOutputFilePath))
                                {
                                    using (StreamWriter swDNAValidationOutput = File.AppendText(DNAStringOutputValidationFilePath))
                                    {
                                        totalTargetLength = sr.BaseStream.Length;
                                        while (sr.Peek() != -1)
                                        {
                                            tmp = sr.ReadLine();
                                            splitted = tmp.Split(',');
                                            position = Int32.Parse(splitted[0]);
                                            tskTup1 = Task<DNATuple>.Factory.StartNew(() => DatasetGeneratorUtil.getDNASequence(position, splitted[1].Replace("_", "")));
                                            randomFalsePosition = DatasetGeneratorUtil.getRandomPostion(existingPositionsHash);
                                            tskTup2 = Task<DNATuple>.Factory.StartNew(() => DatasetGeneratorUtil.getDNASequence(randomFalsePosition.Value, randomFalsePosition.Key));
                                            tskTup1.Wait();
                                            tup = tskTup1.Result;
                                            if (tup == null) continue; //unknown chromosome file specified, continue
                                            tmp = DatasetGeneratorUtil.DNAStringToOneHotEncoding(tup.beforePosition + tup.afterPosition);
                                            if (printToValidation)
                                            {
                                                swDNAValidationOutput.WriteLine(tup.beforePosition + tup.afterPosition);
                                                swValidation.WriteLine(tmp);
                                                swValidationLabels.WriteLine("1");
                                            }
                                            else
                                            {
                                                swDNAOutput.WriteLine(tup.beforePosition + tup.afterPosition);
                                                swInserts.WriteLine(tmp);
                                                swLabels.WriteLine("1");
                                            }
                                            tskTup2.Wait();
                                            tup = tskTup2.Result;
                                            tmp = DatasetGeneratorUtil.DNAStringToOneHotEncoding(tup.beforePosition + tup.afterPosition);
                                            if (printToValidation)
                                            {
                                                swDNAValidationOutput.WriteLine(tup.beforePosition + tup.afterPosition);
                                                swValidation.WriteLine(tmp);
                                                swValidationLabels.WriteLine("0");
                                            }
                                            else
                                            {
                                                swDNAOutput.WriteLine(tup.beforePosition + tup.afterPosition);
                                                swInserts.WriteLine(tmp);
                                                swLabels.WriteLine("0");
                                            }
                                            percentDone = ((float)sr.BaseStream.Position) / totalTargetLength;
                                            if (percentDone > 0.90f) printToValidation = true;
                                            Console.WriteLine("Creating files:" + percentDone.ToString("0.0000") + "%");
                                        }
                                        swInserts.Flush();
                                        swLabels.Flush();
                                        swValidation.Flush();
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
