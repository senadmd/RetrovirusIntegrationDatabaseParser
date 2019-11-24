using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrovirusDBParser
{
    public static class DatasetGeneratorUtil
    {
        static Random rnd = new Random();
        static int numberOfCharactersToInclude = 100;
        static int chr1Max = 249250621 - numberOfCharactersToInclude;
        static int chr2Max = 243199373 - numberOfCharactersToInclude;
        static int chr3Max = 198022430 - numberOfCharactersToInclude;
        static int chr4Max = 191154276 - numberOfCharactersToInclude;
        static int chr5Max = 180915260 - numberOfCharactersToInclude;
        static int chr6Max = 171115067 - numberOfCharactersToInclude;
        static int chr7Max = 159138663 - numberOfCharactersToInclude;
        static int chr8Max = 146364022 - numberOfCharactersToInclude;
        static int chr9Max = 141213431 - numberOfCharactersToInclude;
        static int chr10Max = 135534747 - numberOfCharactersToInclude;
        static int chr11Max = 135006516 - numberOfCharactersToInclude;
        static int chr12Max = 133851895 - numberOfCharactersToInclude;
        static int chr13Max = 115169878 - numberOfCharactersToInclude;
        static int chr14Max = 107349540 - numberOfCharactersToInclude;
        static int chr15Max = 102531392 - numberOfCharactersToInclude;
        static int chr16Max = 90354753 - numberOfCharactersToInclude;
        static int chr17Max = 81195210 - numberOfCharactersToInclude;
        static int chr18Max = 78077248 - numberOfCharactersToInclude;
        static int chr19Max = 59128983 - numberOfCharactersToInclude;
        static int chr20Max = 63025520 - numberOfCharactersToInclude;
        static int chr21Max = 48129895 - numberOfCharactersToInclude;
        static int chr22Max = 51304566 - numberOfCharactersToInclude;
        static int chrXMax = 155270560 - numberOfCharactersToInclude;
        static int chrYMax = 59373566 - numberOfCharactersToInclude;

        public static KeyValuePair<string, int> getRandomPostion(System.Collections.Hashtable existingPositionsSorted)
        {
            int chrRnd = rnd.Next(1, 25);
            int posRnd = 0;
            string chromosome = "";
            switch (chrRnd)
            {
                case 1:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr1Max);
                    chromosome = "chr1";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr1Max);
                    }
                    break;
                case 2:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr2Max);
                    chromosome = "chr2";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr2Max);
                    }
                    break;
                case 3:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr3Max);
                    chromosome = "chr3";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr3Max);
                    }
                    break;
                case 4:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr4Max);
                    chromosome = "chr4";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr4Max);
                    }
                    break;
                case 5:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr5Max);
                    chromosome = "chr5";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr5Max);
                    }
                    break;
                case 6:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr6Max);
                    chromosome = "chr6";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr6Max);
                    }
                    break;
                case 7:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr7Max);
                    chromosome = "chr7";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr7Max);
                    }
                    break;
                case 8:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr8Max);
                    chromosome = "chr8";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr8Max);
                    }
                    break;
                case 9:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr9Max);
                    chromosome = "chr9";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr9Max);
                    }
                    break;
                case 10:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr10Max);
                    chromosome = "chr10";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr10Max);
                    }
                    break;
                case 11:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr11Max);
                    chromosome = "chr11";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr11Max);
                    }
                    break;
                case 12:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr12Max);
                    chromosome = "chr12";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr12Max);
                    }
                    break;
                case 13:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr13Max);
                    chromosome = "chr13";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr13Max);
                    }
                    break;
                case 14:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr14Max);
                    chromosome = "chr14";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr14Max);
                    }
                    break;
                case 15:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr15Max);
                    chromosome = "chr15";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr15Max);
                    }
                    break;
                case 16:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr16Max);
                    chromosome = "chr16";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr16Max);
                    }
                    break;
                case 17:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr17Max);
                    chromosome = "chr17";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr17Max);
                    }
                    break;
                case 18:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr18Max);
                    chromosome = "chr18";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr18Max);
                    }
                    break;
                case 19:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr19Max);
                    chromosome = "chr19";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr19Max);
                    }
                    break;
                case 20:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr20Max);
                    chromosome = "chr20";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr20Max);
                    }
                    break;
                case 21:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr21Max);
                    chromosome = "chr21";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr21Max);
                    }
                    break;
                case 22:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chr22Max);
                    chromosome = "chr22";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chr22Max);
                    }
                    break;
                case 23:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chrXMax);
                    chromosome = "chrX";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chrXMax);
                    }
                    break;
                case 24:
                    posRnd = rnd.Next(numberOfCharactersToInclude, chrYMax);
                    chromosome = "chrY";
                    while (positionTaken((List<int>)existingPositionsSorted[chromosome], posRnd))
                    {
                        posRnd = rnd.Next(numberOfCharactersToInclude, chrYMax);
                    }
                    break;
            }
            return new KeyValuePair<string, int>(chromosome, posRnd);
        }
        public static bool positionTaken(List<int> positionsForChromosome, int positionToCheck)
        {
            if (positionsForChromosome == null) return false;
            if (positionsForChromosome.Contains(positionToCheck)) return true;
            int positionLimitBack = positionToCheck - numberOfCharactersToInclude;
            int positionLimitTop = positionToCheck + numberOfCharactersToInclude;
            int prevPos = 0;
            int cnt = 0;
            foreach (int pos in positionsForChromosome)
            {
                if (prevPos > positionLimitBack) return true;
                if (positionsForChromosome.Count > cnt + 1 && pos >= positionToCheck && positionsForChromosome[cnt + 1] < positionLimitTop) return true;
                if (pos > positionToCheck) return false;
                cnt++;
                prevPos = pos;
            }
            return false;
        }
        public static System.Collections.Hashtable getExistingPositionsSorted(string positionsFile)
        {
            System.Collections.Hashtable existingPositionsHash = new System.Collections.Hashtable();
            List<int> existingPositions;
            string tmp;
            string[] splitted;
            if (!File.Exists(positionsFile)) return existingPositionsHash;
            using (FileStream fs = File.Open(positionsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                while (sr.Peek() != -1)
                {
                    tmp = sr.ReadLine();
                    splitted = tmp.Split(',');
                    int position = Int32.Parse(splitted[0]);
                    if (!existingPositionsHash.ContainsKey(splitted[1]))
                    {
                        existingPositions = new List<int>(100000);
                        existingPositionsHash.Add(splitted[1], existingPositions);
                    }
                    else
                    {
                        existingPositions = (List<int>)existingPositionsHash[splitted[1]];
                    }
                    existingPositions.Add(position);
                }

            }
            foreach (System.Collections.DictionaryEntry dict in existingPositionsHash)
            {
                ((List<int>)existingPositionsHash[dict.Key]).Sort();
            }
            return existingPositionsHash;
        }
        public static DNATuple getDNASequence(int position, string chromosome)
        {
            try
            {
                position--; // to get same alignment as UCSC genome browser
                using (FileStream fs = File.Open(Program.workingDirectoryFilePath + chromosome + ".json", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    int index = 0;
                    List<char> chArr = new List<char>();
                    char[] chBuff = new char[3];
                    //skip the next 5 attributes
                    readUntilCharacter(sr, ',', ref index);
                    readUntilCharacter(sr, ',', ref index);
                    readUntilCharacter(sr, ',', ref index);
                    readUntilCharacter(sr, ',', ref index);
                    readUntilCharacter(sr, ',', ref index);
                    readUntilCharacter(sr, '"', ref index);
                    char tmpChar;
                    while (chBuff[0] != 'e' || chBuff[1] != 'n' || chBuff[2] != 'd')
                    {
                        tmpChar = (char)sr.Read(chBuff, 0, 3);
                        index += 3;
                        if (tmpChar == '\0') throw new Exception("Reached EOF for:" + chromosome);
                    }
                    readUntilCharacter(sr, ' ', ref index);
                    tmpChar = (char)sr.Read();
                    index++;
                    while (Char.IsDigit(tmpChar))
                    {
                        chArr.Add(tmpChar);
                        tmpChar = (char)sr.Read();
                        index++;
                    }
                    string chromosomeLength = new String(chArr.ToArray());
                    int chromosomeMaxLength = Int32.Parse(chromosomeLength);
                    if (position > chromosomeMaxLength || position < 0) throw new ArgumentException("Position:" + position.ToString() + " exeeds length:" + chromosomeMaxLength + " in chromosome:" + chromosome);
                    readUntilCharacter(sr, ':', ref index);
                    readUntilCharacter(sr, '"', ref index);
                    //ready to seek DNA 
                    string strBeforePos;
                    string strAfterPos;
                    chArr = new List<char>();
                    //go to position
                    sr.BaseStream.Seek(index + (position - numberOfCharactersToInclude) + 1, SeekOrigin.Begin);
                    using (StreamReader srNew = new StreamReader(sr.BaseStream))
                    {

                        index = (position - numberOfCharactersToInclude) + 1;
                        while (index <= position)
                        {
                            index++;
                            chArr.Add((char)srNew.Read());
                        }
                        strBeforePos = new String(chArr.ToArray());
                        chArr = new List<char>();
                        //get endStr
                        while (index <= (position + numberOfCharactersToInclude))
                        {
                            index++;
                            tmpChar = (char)srNew.Read();
                            if (tmpChar == '"') break; //guard for EOF
                            else chArr.Add(tmpChar);
                        }
                    }
                    strAfterPos = new String(chArr.ToArray());
                    return new DNATuple() { beforePosition = strBeforePos, afterPosition = strAfterPos };
                }
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }
            catch (ArgumentException lex)
            {
                return null;
            }
        }
        public static void readUntilCharacter(StreamReader sr, char character)
        {
            char tmp = (char)sr.Read();
            while (tmp != character)
                tmp = (char)sr.Read();
        }
        public static void readUntilCharacter(StreamReader sr, char character, ref int index)
        {
            char tmp = (char)sr.Read();
            index++;
            while (tmp != character)
            {
                tmp = (char)sr.Read();
                index++;
            }

        }
       public static string DNAStringToOneHotEncoding(string DNAStr)
        {
            List<char> chArrA = new List<char>();
            List<char> chArrC = new List<char>();
            List<char> chArrG = new List<char>();
            List<char> chArrT = new List<char>();
            foreach (char baseStr in DNAStr)
            {
                if (baseStr == 'A' || baseStr == 'a' || baseStr == 'M' || baseStr == 'm'
                     || baseStr == 'R' || baseStr == 'r' || baseStr == 'W' || baseStr == 'w'
                    || baseStr == 'V' || baseStr == 'v' || baseStr == 'H' || baseStr == 'h'
                    || baseStr == 'D' || baseStr == 'd')
                {
                    if (chArrA.Count > 0) chArrA.Add(',');
                    chArrA.Add('1');
                }
                else if (baseStr != 'X' && baseStr != 'x'
                    && baseStr != 'N' && baseStr != 'n')
                {
                    if (chArrA.Count > 0) chArrA.Add(',');
                    chArrA.Add('0');
                }
                if (baseStr == 'C' || baseStr == 'c' || baseStr == 'M' || baseStr == 'm'
 || baseStr == 'S' || baseStr == 's' || baseStr == 'Y' || baseStr == 'y'
|| baseStr == 'V' || baseStr == 'v' || baseStr == 'H' || baseStr == 'h'
|| baseStr == 'B' || baseStr == 'b')
                {
                    if (chArrC.Count > 0) chArrC.Add(',');
                    chArrC.Add('1');
                }
                else if (baseStr != 'X' && baseStr != 'x'
                    && baseStr != 'N' && baseStr != 'n')
                {
                    if (chArrC.Count > 0) chArrC.Add(',');
                    chArrC.Add('0');
                }
                if (baseStr == 'G' || baseStr == 'g' || baseStr == 'R' || baseStr == 'r'
|| baseStr == 'S' || baseStr == 's' || baseStr == 'K' || baseStr == 'k'
|| baseStr == 'V' || baseStr == 'v' || baseStr == 'D' || baseStr == 'd'
|| baseStr == 'B' || baseStr == 'b')
                {
                    if (chArrG.Count > 0) chArrG.Add(',');
                    chArrG.Add('1');
                }
                else if (baseStr != 'X' && baseStr != 'x'
                    && baseStr != 'N' && baseStr != 'n')
                {
                    if (chArrG.Count > 0) chArrG.Add(',');
                    chArrG.Add('0');
                }
                if (baseStr == 'T' || baseStr == 't' || baseStr == 'W' || baseStr == 'w'
|| baseStr == 'Y' || baseStr == 'y' || baseStr == 'K' || baseStr == 'k'
|| baseStr == 'H' || baseStr == 'h' || baseStr == 'D' || baseStr == 'd'
|| baseStr == 'B' || baseStr == 'b')
                {
                    if (chArrT.Count > 0) chArrT.Add(',');
                    chArrT.Add('1');
                }
                else if (baseStr != 'X' && baseStr != 'x'
                    && baseStr != 'N' && baseStr != 'n')
                {
                    if (chArrT.Count > 0) chArrT.Add(',');
                    chArrT.Add('0');
                }
                if (baseStr == 'X' || baseStr == 'x'
                    || baseStr == 'N' || baseStr == 'n')
                {
                    int baseRnd = rnd.Next(1, 5);
                    switch (baseRnd)
                    {
                        case 1:
                            if (chArrA.Count > 0) chArrA.Add(',');
                            chArrA.Add('1');
                            if (chArrC.Count > 0) chArrC.Add(',');
                            chArrC.Add('0');
                            if (chArrG.Count > 0) chArrG.Add(',');
                            chArrG.Add('0');
                            if (chArrT.Count > 0) chArrT.Add(',');
                            chArrT.Add('0');
                            break;
                        case 2:
                            if (chArrC.Count > 0) chArrC.Add(',');
                            chArrC.Add('1');
                            if (chArrA.Count > 0) chArrA.Add(',');
                            chArrA.Add('0');
                            if (chArrG.Count > 0) chArrG.Add(',');
                            chArrG.Add('0');
                            if (chArrT.Count > 0) chArrT.Add(',');
                            chArrT.Add('0');
                            break;
                        case 3:
                            if (chArrG.Count > 0) chArrG.Add(',');
                            chArrG.Add('1');
                            if (chArrA.Count > 0) chArrA.Add(',');
                            chArrA.Add('0');
                            if (chArrC.Count > 0) chArrC.Add(',');
                            chArrC.Add('0');
                            if (chArrT.Count > 0) chArrT.Add(',');
                            chArrT.Add('0');
                            break;
                        case 4:
                            if (chArrT.Count > 0) chArrT.Add(',');
                            chArrT.Add('1');
                            if (chArrA.Count > 0) chArrA.Add(',');
                            chArrA.Add('0');
                            if (chArrC.Count > 0) chArrC.Add(',');
                            chArrC.Add('0');
                            if (chArrG.Count > 0) chArrG.Add(',');
                            chArrG.Add('0');
                            break;
                        default:
                            throw new Exception("Random integer received was not within range!");
                    }

                }
            }
            return new String(chArrA.ToArray()) + "," + new String(chArrC.ToArray()) + "," + new String(chArrG.ToArray()) + "," + new String(chArrT.ToArray());

        }

    }
}
