# Retrovirus Integration Database Parser & Training Set Generator 
This project was created to parse the HTML pages from Retrovirus Integration Database (https://rid.ncifcrf.gov) and generate traning data to be used when training an artificial neural network.

## Getting Started

To generate training data for your neural network based on latest data in Retrovirus Integration Database (RID):
1. Download latest compiled [release](https://github.com/senadmd/RetrovirusIntegrationDatabaseParser/releases "latest release") for this project, or fork and compile it yourself using Visual Studio.
2. Download current retroviral HIV data from RID using *curl*, replace `PLACEHOLDER` with number of items you want to fetch in the command example below:  
``
curl --request GET -o result.html "https://rid.ncifcrf.gov/result.php?file=tmp/1993657596.txt&page=0&limit=PLACEHOLDER&file_
txt=tmp/1993657596.dwnld.txt"
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
#####Generated files using option 1
- positions.txt - Parsed insert positions from Retrovirus Integration Database. The file is a comma-separated list of insert positions and chromosome designation.
#####Generated files using option 2
The generation of following files requires a *positions.txt* generated using option 1.

*Training set files*
- DNAString.txt - DNA String containing 100bp of nucleotides before the insert position and 100 bp after insert position concatenated.
- inserts.txt - Comma-separated string of DNA positions one-hot encoded for each possible nucleotide. The 200 bp of DNA has been converted to one-hot comma-separated string containg the possible nuclotides (A,C,G,T) in order. For each row, the first 200 one-hot encoded values are for A, then the next 200 values are for C, then for G, and at last for T.
- labels.txt - Label indicating a true (1) or false (0) integration event. For every true integration event, a false, randomly sampled false integration event is generated.

*Validation set files - same format as above but generated separately for the validation data*
- DNAString_validation.txt
- inserts_validation.txt
- labels_validation.txt    

### Prerequisites

To compile this project you need Visual Studio.

## Authors

* **Senad Matuh Delic** 



## Acknowledgments

* I thank the authors of Retrovirus Integration Database for aligning HIV insert positions from multiple studies against a single genome assembly.
*Wei Shao, Jigui Shan, Mary Kearney, Xiaolin Wu, Frank Maldarelli, John W. Mellors, Brian Luke, John M. Coffin, and Stephen H. Hughes. [Retrovirus Integration Database (RID): a public database for retroviral insertion sites into host genomes. Retrovirology 2016 13:47](http://www.retrovirology.com/content/13/1/47)*
* The UCSC genome browser team for making the genome assemblies easily accessible: *UCSC Genome Browser: Kent WJ, Sugnet CW, Furey TS, Roskin KM, Pringle TH, Zahler AM, Haussler D. [The human genome browser at UCSC](http://www.genome.org/cgi/content/abstract/12/6/996). Genome Res. 2002 Jun;12(6):996-1006.*
* *Human genome assembly: The Genome Sequencing Consortium. [Initial sequencing and analysis of the human genome](http://www.nature.com/nature/journal/v409/n6822/abs/409860a0.html). Nature. 2001 Feb 15;409(6822):860-921.*