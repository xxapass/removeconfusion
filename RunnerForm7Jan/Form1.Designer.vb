<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.buildBetListButton = New System.Windows.Forms.Button()
        Me.AscendingButton = New System.Windows.Forms.Button()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1157, 736)
        Me.DataGridView1.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'Timer2
        '
        Me.Timer2.Interval = 3000000
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(749, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 58)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Refresh"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'buildBetListButton
        '
        Me.buildBetListButton.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.buildBetListButton.BackColor = System.Drawing.Color.Ivory
        Me.buildBetListButton.Location = New System.Drawing.Point(926, 0)
        Me.buildBetListButton.Margin = New System.Windows.Forms.Padding(2)
        Me.buildBetListButton.Name = "buildBetListButton"
        Me.buildBetListButton.Size = New System.Drawing.Size(206, 33)
        Me.buildBetListButton.TabIndex = 2
        Me.buildBetListButton.Text = "Build betList"
        Me.buildBetListButton.UseVisualStyleBackColor = False
        '
        'AscendingButton
        '
        Me.AscendingButton.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.AscendingButton.BackColor = System.Drawing.Color.LightBlue
        Me.AscendingButton.Location = New System.Drawing.Point(926, 33)
        Me.AscendingButton.Margin = New System.Windows.Forms.Padding(2)
        Me.AscendingButton.Name = "AscendingButton"
        Me.AscendingButton.Size = New System.Drawing.Size(86, 25)
        Me.AscendingButton.TabIndex = 3
        Me.AscendingButton.Text = "Sort"
        Me.AscendingButton.UseVisualStyleBackColor = False
        '
        'ClearButton
        '
        Me.ClearButton.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ClearButton.BackColor = System.Drawing.Color.DarkKhaki
        Me.ClearButton.Location = New System.Drawing.Point(1035, 33)
        Me.ClearButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(97, 25)
        Me.ClearButton.TabIndex = 10
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = False
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CheckedListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(744, 63)
        Me.CheckedListBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(414, 596)
        Me.CheckedListBox1.TabIndex = 11
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(797, 403)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(135, 23)
        Me.TextBox2.TabIndex = 14
        Me.TextBox2.Text = "£"
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Red
        Me.TextBox3.Location = New System.Drawing.Point(969, 403)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(135, 23)
        Me.TextBox3.TabIndex = 15
        Me.TextBox3.Text = "£"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(1166, 736)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.ClearButton)
        Me.Controls.Add(Me.AscendingButton)
        Me.Controls.Add(Me.buildBetListButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents buildBetListButton As Button
    Friend WithEvents AscendingButton As Button
    Friend WithEvents ClearButton As Button
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
End Class
