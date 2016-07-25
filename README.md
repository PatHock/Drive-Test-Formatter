# Drive-Test-Formatter
Rearranges .csv files into a format that Mapinfo can process

-Delete any rows that do not have both longitude and latitude
-Simplify frequency data to just the numbers before the decimal point (ex, change 2110.0001000, 2110.0001500... to 2110)
-Simplify a RSSI (received signal strength figures) to the first 7 digits(ex, -110.151, -76.005,... to -110.15)
-Split the document into two documents, based on the columns containing frequency and RSSI data
