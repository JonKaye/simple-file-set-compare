Imports System.IO
Imports System.Xml


Public Class Form1

    ' A simple script to compare two sets of files, to find name, size, or checksum differences. The purpose is
    ' to ensure that two different locations (one specified in List A, the other in List B) have the
    ' exact same files. The script reports any difference between the two sets in the output text box as
    ' well as a CSV file.

    ' Basically, we create hash tables from the lists of files the user wants to compuare, then we compare the
    ' contents of the hashtables to see if they match, and report any differences.

    ' The file format for List A and List B text files is <file length in bytes>,<relative path to file>
    ' where the relative path excludes the folders above the 'root' that the user chooses.
    ' The checksum files are produced by FCIV, and have the formatt:
    ' <FCIV>
    '    <FILE_ENTRY>
    '       <name>path and filename</name>
    '       <MD5>MD5 checksum value</MD5>
    '       <SHA1>SHA1 checksum value</SHA1>
    '   </FILE_ENTRY>
    '   ...
    ' </FCIV>

    ' Hashtables used for List A and List B, respectively
    Private FilesHashA As Hashtable
    Private FilesHashB As Hashtable

    ' For comparing number of files in A and B
    Private FileCountInA As Long
    Private FileCountInB As Long

    ' The root folder for List A, which we use to remove the pathname above the root for comparison with List B,
    ' Since List B's contents will not have the path above the top folder we're comparing
    Private RootFolderListA As String

    ' Private class for information stored in the list hashtables: file size and checksums. The hashtable keys are the file paths,
    ' so they do not have to be stored in these instances.
    Private Class FileValues
        Public size As Integer = 0
        Public ChecksumValue_MD5 As String
        Public ChecksumValue_SHA1 As String
    End Class

    ' Choose the text file that contains list of files for List A, then fill the List A Hashtable with names and file sizes
    Private Sub SelectFileListA_Click(sender As Object, e As EventArgs) Handles SelectFileListA.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "txt files (*.txt)|*.txt"
        openFileDialog1.Title = "Select Generated File List"
        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PathA.Text = openFileDialog1.FileName
            FilesHashA = New Hashtable()
            FileCountInA = 0
            FillFileHash(PathA.Text, FilesHashA, FileCountInA)

        Else
            PathA.Text = ""
        End If
        openFileDialog1.Dispose()



    End Sub

    ' Choose the text file that contains list of files for List B, then fill the List A Hashtable with names and file sizes
    Private Sub SelectFileListB_Click(sender As Object, e As EventArgs) Handles SelectFileListB.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "txt files (*.txt)|*.txt"
        openFileDialog1.Title = "Select Generated File List"
        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PathB.Text = openFileDialog1.FileName
            FilesHashB = New Hashtable()
            FileCountInB = 0
            FillFileHash(PathB.Text, FilesHashB, FileCountInB)

        Else
            PathB.Text = ""
        End If
        openFileDialog1.Dispose()

    End Sub


    ' Read in the files under the rootFolderPath and create a hashtable of the files with the names and file sizes
    Private Sub FillFileHash(rootFolderPath As String, ByRef hashTable As Hashtable, ByRef fileCount As Integer)
        Try
            Dim sr As StreamReader = New StreamReader(rootFolderPath)

            fileCount = 0

            Do While sr.Peek() >= 0
                Dim fileDescrip As Array
                Dim path As String
                Dim fileLength As Long

                ' text file is of form <file length in bytes>,<path>
                fileDescrip = Split(sr.ReadLine(), ",", 2)

                fileLength = CLng(fileDescrip(0))
                path = fileDescrip(1)

                fileCount += 1
                hashTable.Add(path, New FileValues With {.size = fileLength, .ChecksumValue_MD5 = Nothing, .ChecksumValue_SHA1 = Nothing})
            Loop

            sr.Close()

        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label1.Text = "This program compares two sets of files (List A and List B) that each represent a list of files from a folder and its sub-folders, to determine if the folder contents match." & vbNewLine &
                      "Step 1. Create the file lists using our cscript script or CompareFileSet program." & vbNewLine &
                      "Step 2. Press ""Select File List (A)..."" to choose the text file for folder List A" & vbNewLine &
                      "Step 3. Press ""Select (A) FCIV File"" and choose the FCIV output XML for List A" & vbNewLine &
                      "Step 4. Press ""Select File List (B)..."" to choose the text file for folder List B" & vbNewLine &
                      "Step 5. Press ""Select (B) FCIV File"" and choose the FCIV output XML for List B" & vbNewLine &
                      "Step 6. Press ""Compare (A) and (B)"" for the program to produce a CSV matching records report."

    End Sub

    ' Read in the checksum file created with FCIV for List A, then add the checksum to the List A file hashtable
    Private Sub AChecksumButton_Click(sender As Object, e As EventArgs) Handles AChecksumButton.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "XML files (*.xml)|*.xml"
        openFileDialog1.Title = "Select FCIV Checksum File"
        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            AChecksumPath.Text = openFileDialog1.FileName
            AddFileChecksum(AChecksumPath.Text, FilesHashA)

        Else
            AChecksumPath.Text = ""
        End If
        openFileDialog1.Dispose()
    End Sub

    ' Read in the checksum file created with FCIV for List A, then add the checksum to the List A file hashtable
    Private Sub BChecksumButton_Click(sender As Object, e As EventArgs) Handles BChecksumButton.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "XML files (*.xml)|*.xml"
        openFileDialog1.Title = "Select FCIV Checksum File"
        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            BChecksumPath.Text = openFileDialog1.FileName
            AddFileChecksum(BChecksumPath.Text, FilesHashB)

        Else
            BChecksumPath.Text = ""
        End If
        openFileDialog1.Dispose()
    End Sub

    ' Load the given checksum file given by filePath and add the MD5 and SHA1 values to the hashtable for the given list.
    ' The routine assumes MD5 and SHA1 checksums have been generated and are in the checksum file.
    Private Sub AddFileChecksum(filePath As String, ByRef fileHash As Hashtable)
        Dim reader As XmlTextReader = New XmlTextReader(filePath)

        Dim xmlDoc As New XmlDocument()
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim filename As String
        Dim md5Checksum As String
        Dim sha1Checksum As String
        Dim thisFilesValues As FileValues

        xmlDoc.Load(filePath)
        xmlnode = xmlDoc.GetElementsByTagName("FILE_ENTRY")
        If (xmlnode IsNot Nothing) Then
            For i = 0 To xmlnode.Count - 1
                md5Checksum = Nothing
                sha1Checksum = Nothing
                filename = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()

                Select Case xmlnode(i).ChildNodes.Item(1).Name.ToUpper
                    Case "MD5"
                        md5Checksum = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()

                    Case "SHA1"
                        sha1Checksum = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()
                End Select

                Select Case xmlnode(i).ChildNodes.Item(2).Name.ToUpper
                    Case "MD5"
                        md5Checksum = xmlnode(i).ChildNodes.Item(2).InnerText.Trim()
                    Case "SHA1"
                        sha1Checksum = xmlnode(i).ChildNodes.Item(2).InnerText.Trim()
                End Select

                If (fileHash.Contains(filename)) Then
                    thisFilesValues = fileHash(filename)
                    thisFilesValues.ChecksumValue_MD5 = md5Checksum
                    thisFilesValues.ChecksumValue_SHA1 = sha1Checksum
                Else
                    Throw New Exception("Filename " & filename & " discovered in FCIV-Checksum-verification prep but was not in hash table already.")
                End If
            Next
        End If


    End Sub

    ' Clicked to compare the contents of the List A and List B hashtables.
    ' Once the report has been compiled and placed in the output textbox, it prompts
    ' the user for a file location to store a CSV file (for later documentation and manipulation).
    Private Sub CompareFiles_Click(sender As Object, e As EventArgs) Handles CompareFiles.Click
        Dim currentLine As String
        Dim hashAEntry As FileValues
        Dim hashBEntry As FileValues
        Dim outputCSV As String

        If FilesHashA Is Nothing Then
            MessageBox.Show("You must select a non-empty data set and FCIV Checksum dump for List A.")
            Exit Sub
        End If
        If FilesHashB Is Nothing Then
            MessageBox.Show("You must select a non-empty data set and FCIV hash dump for List B.")
            Exit Sub
        End If

        outputCSV = "Files in " & ATitleBox.Text & " = " & FilesHashA.Count & ",Files in " & BTitleBox.Text & " = " & FilesHashB.Count & vbNewLine & vbNewLine
        outputCSV &= "Path,In " & ATitleBox.Text & ",In " & BTitleBox.Text & ",File On Both,File Sizes Mismatch,MD5 Mismatch,SHA1 Mismatch" & vbNewLine

        ' Go through all files in List A to find them in List B and compare their sizes and checksums
        For Each de As DictionaryEntry In FilesHashA
            currentLine = de.Key & ",X,"

            hashBEntry = FilesHashB(de.Key)
            If hashBEntry IsNot Nothing Then
                ' on B, Files on Both
                currentLine &= "X,X,"

                ' Test if file size matches
                If de.Value.size = hashBEntry.size Then
                    currentLine &= " ,"
                Else
                    currentLine &= "X,"
                End If

                ' Test if Hash MD5 matches
                If de.Value.ChecksumValue_MD5 = hashBEntry.ChecksumValue_MD5 Then
                    currentLine &= " ,"
                Else
                    currentLine &= "X,"
                End If

                ' Test if Hash SHA1 matches
                If de.Value.ChecksumValue_SHA1 = hashBEntry.ChecksumValue_SHA1 Then
                    currentLine &= " ,"
                Else
                    currentLine &= "X,"
                End If

            Else
                ' the file in List A is not in List B, so mark it as such and checksums as missing
                currentLine &= " , ,MISSING,MISSING,MISSING"
            End If

            currentLine &= vbNewLine
            outputCSV &= currentLine

        Next de

        ' Find files in List A that are not in List B, then mark them missing/cannot compare
        For Each de As DictionaryEntry In FilesHashB

            hashAEntry = FilesHashA(de.Key)
            If hashAEntry Is Nothing Then
                ' on B, Files on Both
                outputCSV &= de.Key & ", ,X, ,MISSING,MISSING,MISSING" & vbNewLine
            End If


        Next

        OutputTB.Text = outputCSV

        SaveOutputAsCSV()
    End Sub

    ' Allow user to choose a file to save the results as CSV
    Private Async Sub SaveOutputAsCSV()
        Dim saveFileDialog1 As New SaveFileDialog()
        Dim outputFileName As String

        saveFileDialog1.Title = "Choose file in which to save results"
        saveFileDialog1.Filter = "csv files (*.csv)|*.csv"
        If saveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            outputFileName = saveFileDialog1.FileName

            System.IO.File.Delete(outputFileName)
            ' Write the stream contents to the file
            Using outfile As StreamWriter = New StreamWriter(outputFileName, True)
                Await outfile.WriteAsync(OutputTB.Text)
            End Using

        End If
    End Sub
End Class
