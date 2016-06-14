# SimpleLoad

Command line tool for simple requesting of the URL several times and measuring of average time taken to get response and read HTML content from the stream.
The tool initially taken from this [blog post](https://jermdavis.wordpress.com/2016/06/13/finding-places-to-improve-performance/) and was updated a bit.

## Usage
The tool accepts 2 parameters: URL of the page that should be requested and number of requests. Example:
simpleload.exe http://someHostName/page/this/one 1000
So during running of this tool, the page http://someHostName/page/this/one will be warmed up (who knows probably that is a local web app that has been just restarted) and then requests that page 1000 times and gives timings and avarege time to the console output.