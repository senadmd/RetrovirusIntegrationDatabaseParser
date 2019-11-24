using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrovirusDBParser
{
    static class Parser
    {
        static String targetFileName = "result.html";
        public static void generatePositionsFile(string positionsPath, System.Collections.Hashtable existingPositionsHash)
        {
            List<int> existingPositions;
            float percentDone;
            int lineCounter = 0;
            float totalTargetLength;
            String origin_id = "";
            String chr = "";
            String insert_position = "";
            String LTR = "";
            String insert_orientation = "";
            String count = "";
            String inserted_gene = "";
            String gene_id = "";
            String gene_orientation = "";
            String exon_intron = "";
            String nearest_gene = "";
            String nearest_gene_id = "";
            String nearest_gene_orientation = "";
            String nearest_gene_distance = "";
            String comment = "";
            String pubmed_id = "";
            using (StreamWriter swPos = File.AppendText(positionsPath))
            {
                String patternStop = "<td nowrap='nowrap' align='center'>";
                using (FileStream fs = File.Open(Program.workingDirectoryFilePath + targetFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    totalTargetLength = ((float)sr.BaseStream.Length);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(patternStop))
                        {
                            int posStart = line.IndexOf("'>") + 2;
                            int posEnd = line.IndexOf("</td>");
                            String colValue = line.Substring(posStart, posEnd - posStart);
                            colValue = colValue.Replace("&nbsp", "");
                            while (colValue.Contains("<")) //contains inline html
                            {
                                string tmp = colValue;
                                posEnd = colValue.IndexOf("<");
                                colValue = colValue.Substring(0, posEnd);
                                posStart = tmp.IndexOf(">") + 1;
                                posEnd = tmp.IndexOf("</");
                                if (posEnd == -1)
                                    posEnd = tmp.IndexOf("/>"); //single html element
                                if (posStart < posEnd)
                                    tmp = tmp.Substring(posStart, posEnd - posStart);
                                else tmp = "";
                                colValue += tmp;
                            }
                            switch (lineCounter)
                            {
                                case 0:
                                    origin_id = colValue;
                                    break;
                                case 1:
                                    chr = colValue;
                                    break;
                                case 2:
                                    insert_position = colValue;
                                    break;
                                case 3:
                                    LTR = colValue;
                                    break;
                                case 4:
                                    insert_orientation = colValue;
                                    break;
                                case 5:
                                    count = colValue;
                                    break;
                                case 6:
                                    inserted_gene = colValue;
                                    break;
                                case 7:
                                    gene_id = colValue;
                                    break;
                                case 8:
                                    gene_orientation = colValue;
                                    break;
                                case 9:
                                    exon_intron = colValue;
                                    break;
                                case 10:
                                    nearest_gene = colValue;
                                    break;
                                case 11:
                                    nearest_gene_id = colValue;
                                    break;
                                case 12:
                                    nearest_gene_orientation = colValue;
                                    break;
                                case 13:
                                    nearest_gene_distance = colValue;
                                    break;
                                case 14:
                                    comment = colValue;
                                    break;
                                case 15:
                                    pubmed_id = colValue;
                                    break;
                            }
                            lineCounter++;
                            if (lineCounter == 16)
                            {
                                int position = Int32.Parse(insert_position);
                                if (!existingPositionsHash.ContainsKey(chr))
                                {
                                    existingPositions = new List<int>(100000);
                                    existingPositionsHash.Add(chr, existingPositions);
                                }
                                else
                                {
                                    existingPositions = (List<int>)existingPositionsHash[chr];
                                }
                                if (!existingPositions.Contains(position))
                                {
                                    existingPositions.Add(position);
                                    swPos.WriteLine(position.ToString() + "," + chr);
                                    percentDone = ((float)sr.BaseStream.Position) / totalTargetLength;
                                    Console.WriteLine("Creating files:" + percentDone.ToString() + "%");
                                }
                                lineCounter = 0;
                            }
                        }
                        else if (lineCounter == 14)
                        {
                            Console.WriteLine("EXPECTED LINE NOT FOUND!");
                            Console.ReadLine();
                            lineCounter = 0;
                        }

                    }
                    swPos.Flush();
                    Console.WriteLine("DONE!");
                    Console.ReadLine();
                }
            }

        }
    }
}
