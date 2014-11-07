<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CreateFileList = New System.Windows.Forms.Button()
        Me.SelectFileList = New System.Windows.Forms.Button()
        Me.CompareFiles = New System.Windows.Forms.Button()
        Me.FilenameCB = New System.Windows.Forms.CheckBox()
        Me.SizeCB = New System.Windows.Forms.CheckBox()
        Me.CompareTB = New System.Windows.Forms.TextBox()
        Me.PathA = New System.Windows.Forms.TextBox()
        Me.PathB = New System.Windows.Forms.TextBox()
        Me.FolderToScan = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CreateFileList
        '
        Me.CreateFileList.Location = New System.Drawing.Point(51, 316)
        Me.CreateFileList.Name = "CreateFileList"
        Me.CreateFileList.Size = New System.Drawing.Size(200, 70)
        Me.CreateFileList.TabIndex = 0
        Me.CreateFileList.Text = "Create New File List (A) from Folder"
        Me.CreateFileList.UseVisualStyleBackColor = True
        '
        'SelectFileList
        '
        Me.SelectFileList.Location = New System.Drawing.Point(50, 399)
        Me.SelectFileList.Name = "SelectFileList"
        Me.SelectFileList.Size = New System.Drawing.Size(200, 59)
        Me.SelectFileList.TabIndex = 1
        Me.SelectFileList.Text = "Select File List (B) for Comparison"
        Me.SelectFileList.UseVisualStyleBackColor = True
        '
        'CompareFiles
        '
        Me.CompareFiles.Location = New System.Drawing.Point(55, 481)
        Me.CompareFiles.Name = "CompareFiles"
        Me.CompareFiles.Size = New System.Drawing.Size(200, 51)
        Me.CompareFiles.TabIndex = 2
        Me.CompareFiles.Text = "Compare (A) and (B)"
        Me.CompareFiles.UseVisualStyleBackColor = True
        '
        'FilenameCB
        '
        Me.FilenameCB.AutoSize = True
        Me.FilenameCB.Checked = True
        Me.FilenameCB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FilenameCB.Enabled = False
        Me.FilenameCB.Location = New System.Drawing.Point(300, 495)
        Me.FilenameCB.Name = "FilenameCB"
        Me.FilenameCB.Size = New System.Drawing.Size(152, 24)
        Me.FilenameCB.TabIndex = 3
        Me.FilenameCB.Text = "Filename && Path"
        Me.FilenameCB.UseVisualStyleBackColor = True
        '
        'SizeCB
        '
        Me.SizeCB.AutoSize = True
        Me.SizeCB.Checked = True
        Me.SizeCB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SizeCB.Location = New System.Drawing.Point(473, 495)
        Me.SizeCB.Name = "SizeCB"
        Me.SizeCB.Size = New System.Drawing.Size(95, 24)
        Me.SizeCB.TabIndex = 4
        Me.SizeCB.Text = "File Size"
        Me.SizeCB.UseVisualStyleBackColor = True
        '
        'CompareTB
        '
        Me.CompareTB.HideSelection = False
        Me.CompareTB.Location = New System.Drawing.Point(50, 551)
        Me.CompareTB.Multiline = True
        Me.CompareTB.Name = "CompareTB"
        Me.CompareTB.ReadOnly = True
        Me.CompareTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CompareTB.Size = New System.Drawing.Size(899, 324)
        Me.CompareTB.TabIndex = 6
        '
        'PathA
        '
        Me.PathA.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PathA.Enabled = False
        Me.PathA.Location = New System.Drawing.Point(290, 348)
        Me.PathA.Name = "PathA"
        Me.PathA.Size = New System.Drawing.Size(352, 26)
        Me.PathA.TabIndex = 7
        '
        'PathB
        '
        Me.PathB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PathB.Enabled = False
        Me.PathB.Location = New System.Drawing.Point(290, 411)
        Me.PathB.Name = "PathB"
        Me.PathB.Size = New System.Drawing.Size(352, 26)
        Me.PathB.TabIndex = 8
        '
        'FolderToScan
        '
        Me.FolderToScan.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FolderToScan.Enabled = False
        Me.FolderToScan.Location = New System.Drawing.Point(290, 316)
        Me.FolderToScan.Name = "FolderToScan"
        Me.FolderToScan.Size = New System.Drawing.Size(352, 26)
        Me.FolderToScan.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(5)
        Me.Label1.Size = New System.Drawing.Size(881, 254)
        Me.Label1.TabIndex = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(993, 887)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FolderToScan)
        Me.Controls.Add(Me.PathB)
        Me.Controls.Add(Me.PathA)
        Me.Controls.Add(Me.CompareTB)
        Me.Controls.Add(Me.SizeCB)
        Me.Controls.Add(Me.FilenameCB)
        Me.Controls.Add(Me.CompareFiles)
        Me.Controls.Add(Me.SelectFileList)
        Me.Controls.Add(Me.CreateFileList)
        Me.Name = "Form1"
        Me.Text = "Compare File Sets"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CreateFileList As System.Windows.Forms.Button
    Friend WithEvents SelectFileList As System.Windows.Forms.Button
    Friend WithEvents CompareFiles As System.Windows.Forms.Button
    Friend WithEvents FilenameCB As System.Windows.Forms.CheckBox
    Friend WithEvents SizeCB As System.Windows.Forms.CheckBox
    Friend WithEvents CompareTB As System.Windows.Forms.TextBox
    Friend WithEvents PathA As System.Windows.Forms.TextBox
    Friend WithEvents PathB As System.Windows.Forms.TextBox
    Friend WithEvents FolderToScan As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
