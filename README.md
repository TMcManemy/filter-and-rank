## Filter and Order

### Requirements

Given a collection of `Person` objects, with the following fields:

* `name` (string)
* `ranking` (integer)
* `country` (string)

Write a filtering and ordering function such that:

* Persons should be filtered by a list of countries, so that only those persons in the specified countries are returned.  All non matching persons are filtered out.  Country names are not guarnateed to be normalized to any specific case (case insensitive).
* Persons should be filtered by a range of rankings so that all persons are between `minRank` and `maxRank` inclusively.
* Persons should be ordered by their ranking, and when there is a tie, they should be ordered by the countries to match the same order as specified in the `countries` list, and any further tie should be broken by the order of their names (case insensitive).
* The function should return at most `maxCount` items unless this would divide a rank, and in that case more items should be returned so that all persons of the same rank are returned.   See the exampe below for more information.

### Executing the program

Because I really enjoy staying on the command line as much as possible, I wanted to try to expose the application via a somewhat elegant .NET command line application.

You can run with the application by `cd`'ing to `\source\FilterAndRank.Console\bin\Release\`. The `System.CommandLine.DragonFruit` package provides a friendly help menu: `.\FilterAndRank.Console.exe --help`. For example, if you wanted to view the top 5 `Person`s from the USA and Canada with a ranking between 2 and 4, you would specify the following: `.\FilterAndRank.Console.exe --country USA --country Canada --min-rank 2 --max-rank 4`

The output from the applicaiton is being formatted by a library called `CsConsoleFormat`. The was my lame attempt to produce visual output that was closer to something you might find in Bash. Clearly, the output is nowehere near as elegant as what you might find on Linux/MacOS. But hey, I tried...

### Building and running unit tests

There's a `build.cmd` script at the root of the project. It compiles the application and runs the test project through `NUnit`'s console runner. The script makes an assumption about where `MSBuild` resides on the target machine. Adjust `VISUALSTUDIO_PATH` and `MSBUILD_PATH` if you must.