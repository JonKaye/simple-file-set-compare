Imports System.IO

Public Class Form1

    ' A simple script to compare two sets of files, to find name or size differences. The purpose is
    ' to ensure that two different locations (one specified in List A, the other in List B) have the
    ' exact same filenames and file sizes. The script reports any difference between the two sets.

    ' Basically, we create hash tables from the list of files we create, then compare the contents of the hashtables
    ' to see if they match, and report any differences.

    ' The file format for List A and List B text files is <file length in bytes>,<relative path to file>
    ' where the relative path excludes the folders above the 'root' that the user chooses.

    Private FilesHashA As Hashtable
    Private FilesHashB As Hashtable

    ' For comparing number of files in A and B
    Private FileCountInA As Long
    Private FileCountInB As Long

    ' The root folder for List A, which we use to remove the pathname above the root for comparison with List B,
    ' Since List B's contents will not have the path above the top folder we're comparing
    Private RootFolderListA As String

    ' Choose the text file that contains list of files for List B
    Private Sub SelectFileListB_Click(sender As Object, e As EventArgs) Handles SelectFileList.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "txt files (*.txt)|*.txt"
        openFileDialog1.Title = "Select Generated File List"
        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PathB.Text = openFileDialog1.FileName
        Else
            PathB.Text = ""
        End If
        openFileDialog1.Dispose()

    End Sub

    ' This routine compares files from our hashtable A (List A) with the text file contents for List B. In the process,
    ' we put the ListB files into their own hashtable, so we can check if List A has more files than what is in List B.

    Private Sub CompareFiles_Click(sender As Object, e As EventArgs) Handles CompareFiles.Click
        Dim FileMismatches As String = ""       ' A string used to collect the files that are in B but not in A
        Dim FileSizeMismatch As String = ""     ' A string used to collect all filenames whose size in A and B are different
        Dim FilesMissingFromB As String = ""    ' A string used to collect files in A that are not in B

        If PathA.Text <> "" And PathB.Text <> "" Then
            FilesHashB = New Hashtable
            CompareTB.Text = ""

            ' Read lines from List B, then check that file to see if it is in List A (look in A's hashtable).
            ' If the file is there but the two files are different sizes (and we're told to compare sizes), make a note
            ' of it for later reporting.
            '
            ' Along the way, we put files from List B into a hashtable so we can later see if
            ' there were files in A that were not in B.
            Try
                Dim sr As StreamReader = New StreamReader(PathB.Text)

                FileCountInB = 0

                Do While sr.Peek() >= 0
                    Dim fileDescrip As Array
                    Dim path As String
                    Dim bFileLength As Long

                    ' text file is of form <file length in bytes>,<path>
                    fileDescrip = Split(sr.ReadLine(), ",", 2)

                    bFileLength = CLng(fileDescrip(0))
                    path = fileDescrip(1)

                    FileCountInB += 1
                    FilesHashB.Add(path, True)

                    ' Check if the file in B is in A
                    If (Not FilesHashA.Contains(path)) Then
                        ' No, current file in B is not in A, so record this fact
                        FileMismatches &= path & vbNewLine

                    ElseIf (SizeCB.Checked) Then
                        ' Yes, file in B is in A, now check file sizes, if the user requested that check
                        Dim info As New FileInfo(RootFolderListA & "\" & path)
                        Dim aFileLength As Long = info.Length

                        ' If the file sizes don't match, record that fact
                        If (bFileLength <> aFileLength) Then
                            FileSizeMismatch &= "File <" & path & ">: (A = " & aFileLength & ") <> (B = " & bFileLength & ")" & vbNewLine
                        End If
                    End If
                Loop

                sr.Close()

                ' Report overall number of files in each set
                CompareTB.Text &= "Number of Files in A: " & FileCountInA & vbNewLine
                CompareTB.Text &= "Number of Files in B: " & FileCountInB & vbNewLine

                ' If there were any files in List B that were not in A, report them
                If FileMismatches.Length <> 0 Then
                    CompareTB.Text &= "* Files in List B Not Found in A *" & vbNewLine
                    CompareTB.Text &= FileMismatches
                End If

                ' If asked to compare sizes, report if there were any file length size mismatches
                If (SizeCB.Checked) Then
                    CompareTB.Text &= "File Length Mismatches: " & FileSizeMismatch.Split(vbNewLine).Length - 1 & vbNewLine
                End If

                ' If there were file size mismatches, write out the files that matched on name but not on file size
                If FileSizeMismatch.Length <> 0 Then
                    CompareTB.Text &= vbNewLine
                    CompareTB.Text &= "* File Length Mismatches *" & vbNewLine
                    CompareTB.Text &= FileSizeMismatch
                End If

                ' Check and report on any files that are in B but not in A
                For Each de As DictionaryEntry In FilesHashA
                    If Not FilesHashB.Contains(de.Key) Then
                        FilesMissingFromB &= de.Key & vbNewLine
                    End If
                Next de

                ' Report any files that were listed in A but not in B
                If FilesMissingFromB.Length > 0 Then
                    CompareTB.Text &= vbNewLine & "* Files in A that are not in B *" & vbNewLine
                    CompareTB.Text &= FilesMissingFromB
                End If

            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try

        Else
            MessageBox.Show("You must supply both the initial file list file (A) and the file list to compare with (B) files.")
        End If
    End Sub

    ' Read in specified directory for List A, then generate a text file with List A contents. When we compare
    ' lists, we'll compare the in-memory List A, not the written text file, but we write the text file so we
    ' can use this function to generate a text file to use for List B (on the original computer).
    '
    ' We write the file asynchronously because we don't really have to wait for the List A file to be generated to
    ' to do the comparison, we only need the written file if we're running this program to produce the file we'll
    ' ultimately use for List B.

    Private Async Sub CreateFileListA_Click(sender As Object, e As EventArgs) Handles CreateFileList.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        Dim folderBrowseDialog1 As New FolderBrowserDialog()

        folderBrowseDialog1.Description = "Select the directory to scan"
        folderBrowseDialog1.ShowNewFolderButton = False

        If folderBrowseDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            RootFolderListA = folderBrowseDialog1.SelectedPath
            FolderToScan.Text = RootFolderListA

            saveFileDialog1.Title = "Select file in which to save results"
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt"
            If saveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                PathA.Text = saveFileDialog1.FileName

                FilesHashA = New Hashtable()
                FileCountInA = 0

                Dim di As New IO.DirectoryInfo(RootFolderListA)
                Dim diar1 As IO.FileInfo() = di.GetFiles("*.*", IO.SearchOption.AllDirectories)
                Dim dra As IO.FileInfo
                Dim relPath As String

                'capture the names of all files in the specified directory
                For Each dra In diar1
                    relPath = dra.FullName.Replace(RootFolderListA & "\", "")
                    FilesHashA.Add(relPath, dra.Length)
                    FileCountInA += 1
                Next

                'Write out files from hash table
                Dim AllFilesInA As String = ""      ' String used to collect the file names and sizes in List A
                For Each de As DictionaryEntry In FilesHashA
                    AllFilesInA &= de.Value & "," & de.Key & vbNewLine
                Next de

                System.IO.File.Delete(PathA.Text)
                ' Write the stream contents to the file
                Using outfile As StreamWriter = New StreamWriter(PathA.Text, True)
                    Await outfile.WriteAsync(AllFilesInA)
                End Using
            Else
                FolderToScan.Text = ""
            End If
        End If

        folderBrowseDialog1.Dispose()
        saveFileDialog1.Dispose()
        saveFileDialog1.Dispose()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label1.Text = "This program compares two sets of files (List A and List B) that each represent a list of files from a folder and its sub-folders, to determine if the folder contents match." & vbNewLine &
                      "Step 1. Create a text file of the source folder and its sub-folders. You can select ""Create New File List (A)..."" to do this, or use some other means. That will be ""List B""." & vbNewLine &
                      "Step 2. Press ""Create New File List (A)..."" on the second folder to create a text file of the target folder and its sub-folders. This will now be ""List A""." & vbNewLine &
                      "Step 3. Press ""Select File List (B)..."" to choose the text file created/specified in Step 1." & vbNewLine &
                      "Step 4. Press ""Compare (A) and (B)"" for the program to compare and report any differences in the sets."
    End Sub

End Class
