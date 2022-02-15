# WordCount
Quickly count occurences of non-trivial words in a file

## Usage
The program takes in two arguments: a file to look through, and a floor on number of occurences.
By default, a file named "q" will be parsed, with anything below or equal to 1 occurence being removed.
Both arguments are optional: not specifying either will use the defaults, and only specifying the filename will remove anything with just 1 occurence.

The format is as follows:
```sh
./WordCount <FILENAME> <COUNT>
```


The program accounts for symbols like commas, question marks, and braces, and removes them accordingly. Similarly, some common English words like "the" are automatically removed as well.

## Building
```sh
dotnet build
```

should cover the actual compilation process. Check under bin/Debug/net6.0/WordCount for the final binary.
