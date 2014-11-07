simple-file-set-compare
=======================

A simple Visual Basic (VB) example of how to compare two sets of folders/files based on file name and size. The vb document has comments that explain its functionality and operation. Essentially, it compares a List A (and generates file that lists all files and folders, with sizes) with a List B (the same format as what was produced in List A.

Suppose you have two folders in which you want to compare files, for example, you want to make sure that the two folders have the same files in them. The use is as follows:

1. Run this CompareFileSet program (or use cscript to run the script "FolderList.vbs" in this repo) and choose your folder as List A, the folder with the contents you want to dump out
2. The program will create a text file with the files and their sizes

Now go to the other folder you want to compare results with.

3. Choose that folder as List A, and optionally you can save that file list in a file (but it is not necessary).
4. Choose the original file you made in step 2 as your List B.
5. Press "Compare". The program will list any discrepancies (missing files from List A or B, and mismatched file sizes) in the output box.
