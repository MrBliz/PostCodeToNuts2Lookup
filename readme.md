# Postcodes to Nuts Lookup

Simple console app to turn PostCodes into NUTS 2 regions. 

I couldn't find anything that had postcodes and NUTS2 data in the same table (perhaps for a good reasons) online so i made it myself.


It's a two stage lookup. First the tool will  convert your postcodes into LAU2 data using the National Statistics Post Code Lookup from the [ONS Open Geography Portal](https://geoportal.statistics.gov.uk/search?q=National%20Statistics%20Postcode%20Lookup&sort=-modified&tags=nspl&type=csv%20collection). And then Hop from LAU2 data to Nuts 2 again using [ONS data](https://geoportal.statistics.gov.uk/search?collection=Dataset&sort=name&tags=all(LUP_LAU2_LAU1_NUTS3_NUTS2_NUTS1)) 

To use the Tool, you will need to download the latest versions of both csvs.

The csvs in the repo are for example use only, they are incomplete datasets.

You will need to provide your Postcodes in a postcodes.csv file in the `Data` directory. That file should have a column called Postcode.

Rename the downloaded NSPL file to `NSPL.csv` and the LAU data file to `LAU2_to_LAU1_to_NUTS3_to_NUTS2_to_NUTS1.csv` and put both in the data directory, replacing the existing files.

