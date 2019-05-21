
# Table of Contents

1.  [Hungarian DiceWare word list](#orge827ba7)
    1.  [Design goals](#orga244821)
        1.  [Easy to remember.](#orgea9fe2d)
        2.  [Easy to type](#orgb908657)
        3.  [Use short words if possible](#orgcea898d)
        4.  [The words should not be names or abbreviations.](#orgbf10165)
    2.  [Method](#org2d4eee1)
        1.  [Candidate words are extracted from a Hungarian spelling dictionary](#org113a3c9)
        2.  [The candidate extracted words are filtered](#orgd47623f)
        3.  [Supporting words are extracted from the classical books.](#orgd369562)
        4.  [Candidate words are filtered using the words in the supporting word list](#org6a2cbd7)
        5.  [Candidate words which are one or two characters long are removed from the candidate list.](#org59bffb0)
        6.  [Candidate words are cut down to 7776 words](#orga8695aa)
        7.  [Candidate words are exported to a text file.](#org88e4108)


<a id="orge827ba7"></a>

# Hungarian DiceWare word list


<a id="orga244821"></a>

## Design goals


<a id="orgea9fe2d"></a>

### Easy to remember.

Words used in classical literature books are extracted. These are the
books that every Hungarian probably have read. Words that are used
more frequent are considered easier to remember.


<a id="orgb908657"></a>

### Easy to type

Only words with no accent are selected. These are easier to type even
on a foreign keyboard. (Probably the letters y and z should be
excluded too. But there are not enough confirming words for that.)


<a id="orgcea898d"></a>

### Use short words if possible

Short words are easier to remember and type.


<a id="orgbf10165"></a>

### The words should not be names or abbreviations.

Some of the names and abbreviations are cryptic and hard to remember.


<a id="org2d4eee1"></a>

## Method


<a id="org113a3c9"></a>

### Candidate words are extracted from a Hungarian spelling dictionary

The latest Hungarian spelling dictionary used by LibreOffice is
downloaded:
<https://raw.githubusercontent.com/LibreOffice/dictionaries/master/hu_HU/hu_HU.dic>


<a id="orgd47623f"></a>

### The candidate extracted words are filtered

The candidate words will contain only words confirming to the [Design
goals](#orga244821).


<a id="orgd369562"></a>

### Supporting words are extracted from the classical books.

The supporting words must also confirm to the [Design goals](#orga244821).  Only
unique words are added to the candidate list.


<a id="org6a2cbd7"></a>

### Candidate words are filtered using the words in the supporting word list

If a candidate word is found amongst the supporting words the word is
confirmed and used in final word list.


<a id="org59bffb0"></a>

### Candidate words which are one or two characters long are removed from the candidate list.

These short words usually come from Latin quotations or
Acronyms. These may not have meaning which makes them harder to
remember.


<a id="orga8695aa"></a>

### Candidate words are cut down to 7776 words

Candidate words are ordered by length and the first 7776 word is
selected.


<a id="org88e4108"></a>

### Candidate words are exported to a text file.

Words are prefixed with the 6 digit number.

