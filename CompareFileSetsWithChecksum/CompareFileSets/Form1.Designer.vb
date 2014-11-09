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
        Me.SelectFileListA = New System.Windows.Forms.Button()
        Me.SelectFileListB = New System.Windows.Forms.Button()
        Me.CompareFiles = New System.Windows.Forms.Button()
        Me.OutputTB = New System.Windows.Forms.TextBox()
        Me.PathA = New System.Windows.Forms.TextBox()
        Me.PathB = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AChecksumButton = New System.Windows.Forms.Button()
        Me.BChecksumButton = New System.Windows.Forms.Button()
        Me.AChecksumPath = New System.Windows.Forms.TextBox()
        Me.BChecksumPath = New System.Windows.Forms.TextBox()
        Me.BTitleBox = New System.Windows.Forms.TextBox()
        Me.ATitleBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'SelectFileListA
        '
        Me.SelectFileListA.Location = New System.Drawing.Point(34, 235)
        Me.SelectFileListA.Margin = New System.Windows.Forms.Padding(2)
        Me.SelectFileListA.Name = "SelectFileListA"
        Me.SelectFileListA.Size = New System.Drawing.Size(160, 34)
        Me.SelectFileListA.TabIndex = 0
        Me.SelectFileListA.Text = "Select File List (A) for Comparison"
        Me.SelectFileListA.UseVisualStyleBackColor = True
        '
        'SelectFileListB
        '
        Me.SelectFileListB.Location = New System.Drawing.Point(431, 233)
        Me.SelectFileListB.Margin = New System.Windows.Forms.Padding(2)
        Me.SelectFileListB.Name = "SelectFileListB"
        Me.SelectFileListB.Size = New System.Drawing.Size(160, 36)
        Me.SelectFileListB.TabIndex = 1
        Me.SelectFileListB.Text = "Select File List (B) for Comparison"
        Me.SelectFileListB.UseVisualStyleBackColor = True
        '
        'CompareFiles
        '
        Me.CompareFiles.Location = New System.Drawing.Point(37, 339)
        Me.CompareFiles.Margin = New System.Windows.Forms.Padding(2)
        Me.CompareFiles.Name = "CompareFiles"
        Me.CompareFiles.Size = New System.Drawing.Size(350, 33)
        Me.CompareFiles.TabIndex = 2
        Me.CompareFiles.Text = "Compare (A) and (B)"
        Me.CompareFiles.UseVisualStyleBackColor = True
        '
        'OutputTB
        '
        Me.OutputTB.HideSelection = False
        Me.OutputTB.Location = New System.Drawing.Point(37, 393)
        Me.OutputTB.Margin = New System.Windows.Forms.Padding(2)
        Me.OutputTB.Multiline = True
        Me.OutputTB.Name = "OutputTB"
        Me.OutputTB.ReadOnly = True
        Me.OutputTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.OutputTB.Size = New System.Drawing.Size(769, 247)
        Me.OutputTB.TabIndex = 6
        '
        'PathA
        '
        Me.PathA.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PathA.Enabled = False
        Me.PathA.Location = New System.Drawing.Point(198, 239)
        Me.PathA.Margin = New System.Windows.Forms.Padding(2)
        Me.PathA.Name = "PathA"
        Me.PathA.Size = New System.Drawing.Size(194, 20)
        Me.PathA.TabIndex = 7
        '
        'PathB
        '
        Me.PathB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PathB.Enabled = False
        Me.PathB.Location = New System.Drawing.Point(612, 239)
        Me.PathB.Margin = New System.Windows.Forms.Padding(2)
        Me.PathB.Name = "PathB"
        Me.PathB.Size = New System.Drawing.Size(194, 20)
        Me.PathB.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(3)
        Me.Label1.Size = New System.Drawing.Size(772, 165)
        Me.Label1.TabIndex = 10
        '
        'AChecksumButton
        '
        Me.AChecksumButton.Location = New System.Drawing.Point(34, 283)
        Me.AChecksumButton.Margin = New System.Windows.Forms.Padding(2)
        Me.AChecksumButton.Name = "AChecksumButton"
        Me.AChecksumButton.Size = New System.Drawing.Size(160, 34)
        Me.AChecksumButton.TabIndex = 11
        Me.AChecksumButton.Text = "Select (A) FCIV Checksum File"
        Me.AChecksumButton.UseVisualStyleBackColor = True
        '
        'BChecksumButton
        '
        Me.BChecksumButton.Location = New System.Drawing.Point(431, 283)
        Me.BChecksumButton.Margin = New System.Windows.Forms.Padding(2)
        Me.BChecksumButton.Name = "BChecksumButton"
        Me.BChecksumButton.Size = New System.Drawing.Size(160, 34)
        Me.BChecksumButton.TabIndex = 12
        Me.BChecksumButton.Text = "Select (B) FCIV Checksum File"
        Me.BChecksumButton.UseVisualStyleBackColor = True
        '
        'AChecksumPath
        '
        Me.AChecksumPath.BackColor = System.Drawing.SystemColors.ControlLight
        Me.AChecksumPath.Enabled = False
        Me.AChecksumPath.Location = New System.Drawing.Point(198, 291)
        Me.AChecksumPath.Margin = New System.Windows.Forms.Padding(2)
        Me.AChecksumPath.Name = "AChecksumPath"
        Me.AChecksumPath.Size = New System.Drawing.Size(194, 20)
        Me.AChecksumPath.TabIndex = 13
        '
        'BChecksumPath
        '
        Me.BChecksumPath.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BChecksumPath.Enabled = False
        Me.BChecksumPath.Location = New System.Drawing.Point(612, 291)
        Me.BChecksumPath.Margin = New System.Windows.Forms.Padding(2)
        Me.BChecksumPath.Name = "BChecksumPath"
        Me.BChecksumPath.Size = New System.Drawing.Size(194, 20)
        Me.BChecksumPath.TabIndex = 14
        '
        'BTitleBox
        '
        Me.BTitleBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTitleBox.Location = New System.Drawing.Point(612, 185)
        Me.BTitleBox.Name = "BTitleBox"
        Me.BTitleBox.Size = New System.Drawing.Size(194, 35)
        Me.BTitleBox.TabIndex = 15
        Me.BTitleBox.Text = "B"
        '
        'ATitleBox
        '
        Me.ATitleBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ATitleBox.Location = New System.Drawing.Point(198, 185)
        Me.ATitleBox.Name = "ATitleBox"
        Me.ATitleBox.Size = New System.Drawing.Size(189, 35)
        Me.ATitleBox.TabIndex = 16
        Me.ATitleBox.Text = "A"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 25)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Title for List A"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(426, 191)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 25)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Title for List B"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(830, 663)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ATitleBox)
        Me.Controls.Add(Me.BTitleBox)
        Me.Controls.Add(Me.BChecksumPath)
        Me.Controls.Add(Me.AChecksumPath)
        Me.Controls.Add(Me.BChecksumButton)
        Me.Controls.Add(Me.AChecksumButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PathB)
        Me.Controls.Add(Me.PathA)
        Me.Controls.Add(Me.OutputTB)
        Me.Controls.Add(Me.CompareFiles)
        Me.Controls.Add(Me.SelectFileListB)
        Me.Controls.Add(Me.SelectFileListA)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "Compare File Sets with Checksum"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SelectFileListA As System.Windows.Forms.Button
    Friend WithEvents SelectFileListB As System.Windows.Forms.Button
    Friend WithEvents CompareFiles As System.Windows.Forms.Button
    Friend WithEvents OutputTB As System.Windows.Forms.TextBox
    Friend WithEvents PathA As System.Windows.Forms.TextBox
    Friend WithEvents PathB As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AChecksumButton As System.Windows.Forms.Button
    Friend WithEvents BChecksumButton As System.Windows.Forms.Button
    Friend WithEvents AChecksumPath As System.Windows.Forms.TextBox
    Friend WithEvents BChecksumPath As System.Windows.Forms.TextBox
    Friend WithEvents BTitleBox As System.Windows.Forms.TextBox
    Friend WithEvents ATitleBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
