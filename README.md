# Retrovirus Integration Database Parser & Training Set Generator 
This project was created to parse the HTML pages from Retrovirus Integration Database (https://rid.ncifcrf.gov) and generate traning data to be used when training an artificial neural network.

## Getting Started

To generate training data for your neural network based on latest data in Retrovirus Integration Database (RID):
1. Download latest compiled [release](https://github.com/senadmd/RetrovirusIntegrationDatabaseParser/releases "latest release") for this project, or fork and compile it yourself using Visual Studio.
2. Download current retroviral HIV data from RID using *curl*, replace `PLACEHOLDER` with number of items you want to fetch in the command example below:  
 ``
curl -d "virusnm=HIV1&subtypenm%5B%5D=all&host=hg19&chr%5B%5D=all&site_info%5B%5D=all&multiHits=0&submit=Submit+Query" -H "Content-Type: application/x-www-form-urlencoded" --request POST -o result.html "https://rid.ncifcrf.gov/result.php?limit=PLACEHOLDER"
``
This will produce a file *result.html* that can be used in the next step to generate the retroviral insert positions file.
3. Start the executable, select option 1 to parse insert positions contained in *result.html* and generate a file containing the positions (*positions.txt*).
4. *(optional)* Shuffle the rows in the positions file (*positions.txt*) generated to remove any ordering contained in the data downloaded from RID. Shuffling of rows can easily be performed with the following command on a linux computer: 
``
sort -R positions.txt >  positions_sorted.txt
``.
  Delete now *positions.txt* and rename *positions_sorted.txt* to *positions.txt*.
5. Download and extract chromosome JSON files containing DNA sequences from the GRCh37/hg19 assembly to the same folder as the executable. These can be downloaded in full from the link below:
* ``https://kth-project.s3.eu-north-1.amazonaws.com/chrFiles.zip``
Or individually, for each chromosome using [UCSC API](http://genome.ucsc.edu/goldenPath/help/api.html), below is an examle link for the mitochondrial chromosome:
* ``https://api.genome.ucsc.edu/getData/sequence?genome=hg19;chrom=chrM``
6. Restart the executable and select option 2 this time to generate the training dataset.
### Files Generated
**Generated files using option 1**
- positions.txt - Parsed insert positions from Retrovirus Integration Database. The file is a comma-separated list of insert positions and chromosome designation. 

**Generated files using option 2**

The generation of following files requires a *positions.txt* generated using option 1.

*Training set files*
- DNAString.txt - DNA String containing 100 bp of nucleotides before the insert position and 100 bp after insert position concatenated.
- inserts.txt - Comma-separated string of DNA positions one-hot encoded for each possible nucleotide. The 200 bp of DNA has been converted to one-hot comma-separated string containg the possible nuclotides (A,C,G,T) in order. For each row, the first 200 one-hot encoded values are for A (first channel), then the next 200 values are for C (second channel), then for G (third channel), and at last for T (fourth channel). The one-hot translation is decribed below in the section "One-hot encoding table for DNA strings".
- labels.txt - Label indicating a true (1) or false (0) integration event. For every true integration event, a false, randomly sampled false integration event is generated.

*Validation set files* 
These files follow the same format as above but are generated separately for the validation data.
- DNAString_validation.txt
- inserts_validation.txt
- labels_validation.txt    

### Prerequisites

To compile this project you need Visual Studio.

### One-hot encoding table for DNA strings
DNA strings fetched using [UCSC API](http://genome.ucsc.edu/goldenPath/help/api.html) contain non-nucleotide symbols. These non-ACGT symbols designate polymorhic poisitions in the DNA. The meaning of these are described by the [IUPAC-IUB Symbols for Nucleotide Nomenclature](https://www.qmul.ac.uk/sbcs/iubmb/misc/naseq.html), but also in the [UCSC FAQ](https://genome-euro.ucsc.edu/FAQ/FAQdownloads.html#download5).
While we follow the IUPAC-IUB Symbols for Nucleotide Nomenclature to a large degree when translating the DNA into one-hot encoded string, we handle the occurrence of 'X' and 'N' differently. As many sequences contain the symbol 'N' in repeat, the DNA string containing these repeats would be translated into a string of repeating ones. This raises the opportunity for the neural network to detect this simple pattern arising from simply generating a large number of random DNA samples from the human genome. To avoid this, when generating the training set, the generator will generate a random ACGT entry at the position of the 'N' symbol or 'X' symbol.

To be specific, the following translation table is used when translating the DNA into one-hot encoded string.


| Symbol | Meaning | Translation |
| --- | --- | --- |
| A | A | Translated to 1 at position of A, all other nucleotide channels are set to 0 at the corresponding position |
| C | C | Translated to 1 at position of C, all other nucleotide channels are set to 0 at the corresponding position |
| G | G | Translated to G at position of A, all other nucleotide channels are set to 0 at the corresponding position |
| T | T | Translated to T at position of A, all other nucleotide channels are set to 0 at the corresponding position |
| M | A or C | Translated to 1 at position of M for the channels A and C, all other channels are set to zero at the corresponding position |
| R | A or G | Translated to 1 at position of R for the channels A and G, all other channels are set to zero at the corresponding position |
| W | A or T | Translated to 1 at position of W for the channels A and T, all other channels are set to zero at the corresponding position |
| S | C or G | Translated to 1 at position of S for the channels C and G, all other channels are set to zero at the corresponding position |
| Y | C or T | Translated to 1 at position of Y for the channels C and T, all other channels are set to zero at the corresponding position |
| K | G or T | Translated to 1 at position of K for the channels G and T, all other channels are set to zero at the corresponding position |
| V | A or C or G | Translated to 1 at position of V for the channels A, C, G, all other channels are set to zero at the corresponding position |
| H | A or C or T | Translated to 1 at position of H for the channels A, C, T, all other channels are set to zero at the corresponding position |
| D | A or G or T | Translated to 1 at position of D for the channels A, G, T, all other channels are set to zero at the corresponding position |
| B | C or G or T | Translated to 1 at position of B for the channels C, G, T, all other channels are set to zero at the corresponding position |
| X | G or A or T or C | One channel is randomly set to 1 at the position of X, all other channels are set to zero at the corresponding position |
| N | G or A or T or C | One channel is randomly set to 1 at the position of N, all other channels are set to zero at the corresponding position |
 
## Authors

* **Senad Matuh Delic** 



## Acknowledgments

* I thank the authors of Retrovirus Integration Database for aligning HIV insert positions from multiple studies against a single genome assembly.
*Wei Shao, Jigui Shan, Mary Kearney, Xiaolin Wu, Frank Maldarelli, John W. Mellors, Brian Luke, John M. Coffin, and Stephen H. Hughes. [Retrovirus Integration Database (RID): a public database for retroviral insertion sites into host genomes. Retrovirology 2016 13:47](http://www.retrovirology.com/content/13/1/47)*
* The UCSC genome browser team for making the genome assemblies easily accessible: *UCSC Genome Browser: Kent WJ, Sugnet CW, Furey TS, Roskin KM, Pringle TH, Zahler AM, Haussler D. [The human genome browser at UCSC](http://www.genome.org/cgi/content/abstract/12/6/996). Genome Res. 2002 Jun;12(6):996-1006.*
* *Human genome assembly: The Genome Sequencing Consortium. [Initial sequencing and analysis of the human genome](http://www.nature.com/nature/journal/v409/n6822/abs/409860a0.html). Nature. 2001 Feb 15;409(6822):860-921.*