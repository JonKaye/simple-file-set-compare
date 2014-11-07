' Uses cscript to create a listing of a giving folder structure (all files) along with their
' file size, in the format <file size in bytes>,<full path to file>
' To use this script, issue in a command prompt:
'    cscript FolderList.vbs
' It will then open a dialog box asking for the source folder (the folder to explore recursively).
' After you hit OK, it will then ask you for the output file path and name, and then it will
' go off and create it.
'
' by Jonathan Kaye, Sept. 2014
'
' Derived from the work of Fred Coleman, found here: http://www.ericphelps.com/scripting/samples/
' Email_Address: fredkc@local.net		
' Original example: takes a drive/folder name from input and return an HTML file listing of contents
'**************************************************************

Option Explicit

Dim rootFolderPath
rootFolderPath = InputBox("Please Enter a starting folder", "User Input","")

Dim outputFilePath
outputFilePath = InputBox("Please Enter an output file (full path)", "User Input","")

Dim fileSystemObject
' not sure why "set" is needed here, but without it, shell complains about this statement
set fileSystemObject = CreateObject("Scripting.FileSystemObject")

Dim outputFileHandle
' open the file writing 
set outputFileHandle = fileSystemObject.openTextFile(outputFilePath, 2, True, -1)

' Go for it!
ProcessDirectory rootFolderPath

 ' Close the output file
 outputFileHandle.close
 
 ' Tell the user that we're done
 Dim doneMsg
 doneMsg = MsgBox("File cataloging completed!", vbOKOnly + vbInformation, "Beer Time" )

' ----------------------
' Recursive routine to discover and log files in the given folder
sub ProcessDirectory(curFolderPath)
  
  Dim curFolder, curSubFolders, curFolderFiles
  set curFolder = fileSystemObject.GetFolder(curFolderPath)
  set curSubFolders = curFolder.SubFolders
  set curFolderFiles = curFolder.Files
  
  ' First process all the sub-folders in the current folder
  Dim subFolderObj
  For each subFolderObj in curSubFolders
	'go to each one
	ProcessDirectory subFolderObj
  Next
 
  ' Prepare to add a backslash if needed for referencing the files in the current folder
  Dim needsSlash
  If Right(curFolderPath, 1) <> "\" Then
    needsSlash = "\"
  Else
    needsSlash = ""
  End If
  
  ' Go through each file, writing out the details to the output file
  Dim relativeFilePath, fileObj, fileData, filename, filesize
  For each fileData in curFolderFiles
	
	set fileObj = fileSystemObject.GetFile(curFolderPath & needsSlash & fileData.Name)
	relativeFilePath = Replace(curFolderPath, rootFolderPath & "\", "")
	
	filename = fileData.Name
	filesize = fileObj.Size
	
	If curFolderPath = rootFolderPath Then
		outputFileHandle.WriteLine(filesize & "," & filename)
	Else
		outputFileHandle.WriteLine(filesize & "," & relativeFilePath & "\" & filename)
	End If
  next
  
end sub	
