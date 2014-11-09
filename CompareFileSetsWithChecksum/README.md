fileset-compare-with-checksum
=============================

A Visual Basic .NET Windows Form program to compare two sets of files &amp; folders based on file length and FCIV checksums.

The program compares the output of our simple-file-set-compare program (https://github.com/JonKaye/simple-file-set-compare)
run on two separate folders that you are trying to see whether their contents match or not. You can use that programs to
generate the file list, or use the cscript file included in this repo. The comparison also uses the output of FCIV
(File Checksum Integrity Verifier) from Microsoft, which generates checksums of the files using MD5 and SHA1. For the
comparison, we require the checksum generation of both MD5 and SHA1. Example code
for producing the FCIV results is included in this repo under "example-fciv-commands.txt", but the FCIV software is not.

Like the simple-file-set-compare routine, this executable performs a matching record process on the two file sets, checking
file name, size, and MD5 and SHA1 checksums. The program displays the results as a CSV text in an output box as well as
a file the user can save. The file lists all the files from both lists and indicates:

Whether each files exists in the other list (i.e., file exists in List A, in List B, and whether in both)
Whether the files (if both exist) match in size
Whether the MD5 checksum matches
Whether the SHA1 checksum matches.
