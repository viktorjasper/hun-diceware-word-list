
# Table of Contents

1.  [Hungarian DiceWare word list](#orga5d79e1)
    1.  [Design goals](#org5922a8d)
        1.  [The words must be easy to remember.](#org8e4faad)
        2.  [The words must be easy to type](#orgcd497b9)
        3.  [The words must be short](#org5fb4797)
        4.  [The words cannot be proper nouns.](#org9c8d194)
    2.  [Method](#orge8bf674)
        1.  [Candidate words are extracted from a Hungarian spelling dictionary](#orga6327b6)
        2.  [The candidate extracted words are filtered](#org3d7680c)
        3.  [Candidate words are stored into a database.](#orge58f36c)
        4.  [Supporting words are extracted from the classical books.](#org345f060)
        5.  [Supporting words are stored in a database](#org70b7099)
        6.  [Candidate words are assigned two properties: length and support strength](#orgf3db6b1)
        7.  [Candidate words are narrowed by support strength.](#org1b1fd6b)
        8.  [Candidate words are ordered by lenght and the first 7776 word remain.](#org0385331)
        9.  [Candidate words are exported to a text file.](#orgcbd5a07)
    3.  [Removing extra notation used by the dictionary](#orgc20eba6)
    4.  [Removing words having letters outside of [a-z] english to avoid confusion](#org6b40d5f)
    5.  [Removing duplicates](#orgfe5540c)
    6.  [Prefixing lines with the line lengths](#orgb27311b)
    7.  [Sort lines (the result will be sorted by word length)](#org5ecabf9)
    8.  [Remove words having only 0-3 letters](#orgc4df16f)
    9.  [Remove words which are longer than ten characters](#org306f962)
    10. [Leave only the first 7776 words.](#orgd60b933)
    11. [Remove length prefixes and leave only the words.](#org97c8750)
    12. [sort lines alphabetically](#org7b9b450)


<a id="orga5d79e1"></a>

# Hungarian DiceWare word list


<a id="org5922a8d"></a>

## Design goals


<a id="org8e4faad"></a>

### The words must be easy to remember.

Words used in classical litrature books are extracted. These are the
books that every Hungarian probably have read. Words that are used
more frequent are considered easier to remember.


<a id="orgcd497b9"></a>

### The words must be easy to type

Ony words with no accent are selected. These are easier to type even
on a foreign keyboard. (Probably the letters y and z should be
excluded too.)


<a id="org5fb4797"></a>

### The words must be short

Short words are easier to remember and type.


<a id="org9c8d194"></a>

### The words cannot be proper nouns.


<a id="orge8bf674"></a>

## Method


<a id="orga6327b6"></a>

### Candidate words are extracted from a Hungarian spelling dictionary

1.  Download latest Hungarian spelling dictionary used by LibreOffice

    <https://raw.githubusercontent.com/LibreOffice/dictionaries/master/hu_HU/hu_HU.dic>


<a id="org3d7680c"></a>

### The candidate extracted words are filtered

The candidate words will contain only words confirming to the [Design
goals](#org5922a8d).


<a id="orge58f36c"></a>

### Candidate words are stored into a database.


<a id="org345f060"></a>

### Supporting words are extracted from the classical books.

The supporting words must confirm to the [Design goals](#org5922a8d) 


<a id="org70b7099"></a>

### Supporting words are stored in a database


<a id="orgf3db6b1"></a>

### Candidate words are assigned two properties: length and support strength


<a id="org1b1fd6b"></a>

### Candidate words are narrowed by support strength.

So that only twice the needed words will remain.

1.  Extreme weak words are removed.


<a id="org0385331"></a>

### Candidate words are ordered by lenght and the first 7776 word remain.


<a id="orgcbd5a07"></a>

### Candidate words are exported to a text file.

1.  Candidate words are prefixed with the 6 digit number

    Copy pasting the numbers from the beale wordlist.


<a id="orgc20eba6"></a>

## Removing extra notation used by the dictionary

M-x replace-regex "\(\w*\)[ 	/-].\*" with \\1


<a id="org6b40d5f"></a>

## Removing words having letters outside of [a-z] english to avoid confusion


<a id="orgfe5540c"></a>

## Removing duplicates


<a id="orgb27311b"></a>

## Prefixing lines with the line lengths

awk '{print length(), $0}' diceware.words.hun


<a id="org5ecabf9"></a>

## Sort lines (the result will be sorted by word length)


<a id="orgc4df16f"></a>

## Remove words having only 0-3 letters


<a id="org306f962"></a>

## Remove words which are longer than ten characters


<a id="orgd60b933"></a>

## Leave only the first 7776 words.


<a id="org97c8750"></a>

## Remove length prefixes and leave only the words.

.\* \(.*\) with: \\1


<a id="org7b9b450"></a>

## sort lines alphabetically

