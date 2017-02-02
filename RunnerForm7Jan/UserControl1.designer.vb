<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BetButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.returnPriceTextBox = New System.Windows.Forms.TextBox()
        Me.returnSizeTextBox = New System.Windows.Forms.TextBox()
        Me.fillorkillTextBox = New System.Windows.Forms.TextBox()
        Me.priceTextBox = New System.Windows.Forms.TextBox()
        Me.sizeTextBox = New System.Windows.Forms.TextBox()
        Me.layRadioButton = New System.Windows.Forms.RadioButton()
        Me.backRadioButton = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.hedgeValueLabel = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.laidLabel = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.backedLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.layStopTextBox = New System.Windows.Forms.TextBox()
        Me.backStopTextBox = New System.Windows.Forms.TextBox()
        Me.layCheckBox = New System.Windows.Forms.CheckBox()
        Me.backCheckBox = New System.Windows.Forms.CheckBox()
        Me.cancelButton1 = New System.Windows.Forms.Button()
        Me.hedgeButton = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Side"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(121, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(178, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Price"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(235, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fill/Kill"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(324, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Matched"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(402, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Avg Price"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(498, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Bet Id"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(67, 48)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(574, 53)
        Me.DataGridView1.TabIndex = 7
        '
        'BetButton
        '
        Me.BetButton.Location = New System.Drawing.Point(73, 396)
        Me.BetButton.Name = "BetButton"
        Me.BetButton.Size = New System.Drawing.Size(75, 44)
        Me.BetButton.TabIndex = 16
        Me.BetButton.Text = "Bet"
        Me.BetButton.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(73, 195)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 17
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.returnPriceTextBox)
        Me.GroupBox1.Controls.Add(Me.returnSizeTextBox)
        Me.GroupBox1.Controls.Add(Me.fillorkillTextBox)
        Me.GroupBox1.Controls.Add(Me.priceTextBox)
        Me.GroupBox1.Controls.Add(Me.sizeTextBox)
        Me.GroupBox1.Controls.Add(Me.layRadioButton)
        Me.GroupBox1.Controls.Add(Me.backRadioButton)
        Me.GroupBox1.Location = New System.Drawing.Point(73, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(568, 100)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Side"
        '
        'returnPriceTextBox
        '
        Me.returnPriceTextBox.Location = New System.Drawing.Point(276, 72)
        Me.returnPriceTextBox.Name = "returnPriceTextBox"
        Me.returnPriceTextBox.Size = New System.Drawing.Size(100, 22)
        Me.returnPriceTextBox.TabIndex = 6
        '
        'returnSizeTextBox
        '
        Me.returnSizeTextBox.Location = New System.Drawing.Point(146, 72)
        Me.returnSizeTextBox.Name = "returnSizeTextBox"
        Me.returnSizeTextBox.Size = New System.Drawing.Size(100, 22)
        Me.returnSizeTextBox.TabIndex = 5
        '
        'fillorkillTextBox
        '
        Me.fillorkillTextBox.Location = New System.Drawing.Point(411, 21)
        Me.fillorkillTextBox.Name = "fillorkillTextBox"
        Me.fillorkillTextBox.Size = New System.Drawing.Size(100, 22)
        Me.fillorkillTextBox.TabIndex = 4
        '
        'priceTextBox
        '
        Me.priceTextBox.Location = New System.Drawing.Point(277, 22)
        Me.priceTextBox.Name = "priceTextBox"
        Me.priceTextBox.Size = New System.Drawing.Size(100, 22)
        Me.priceTextBox.TabIndex = 3
        '
        'sizeTextBox
        '
        Me.sizeTextBox.Location = New System.Drawing.Point(146, 21)
        Me.sizeTextBox.Name = "sizeTextBox"
        Me.sizeTextBox.Size = New System.Drawing.Size(100, 22)
        Me.sizeTextBox.TabIndex = 2
        '
        'layRadioButton
        '
        Me.layRadioButton.AutoSize = True
        Me.layRadioButton.Location = New System.Drawing.Point(15, 66)
        Me.layRadioButton.Name = "layRadioButton"
        Me.layRadioButton.Size = New System.Drawing.Size(52, 21)
        Me.layRadioButton.TabIndex = 1
        Me.layRadioButton.Text = "Lay"
        Me.layRadioButton.UseVisualStyleBackColor = True
        '
        'backRadioButton
        '
        Me.backRadioButton.AutoSize = True
        Me.backRadioButton.Checked = True
        Me.backRadioButton.Location = New System.Drawing.Point(15, 21)
        Me.backRadioButton.Name = "backRadioButton"
        Me.backRadioButton.Size = New System.Drawing.Size(60, 21)
        Me.backRadioButton.TabIndex = 0
        Me.backRadioButton.TabStop = True
        Me.backRadioButton.Text = "Back"
        Me.backRadioButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.hedgeValueLabel)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.laidLabel)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.backedLabel)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.layStopTextBox)
        Me.GroupBox2.Controls.Add(Me.backStopTextBox)
        Me.GroupBox2.Controls.Add(Me.layCheckBox)
        Me.GroupBox2.Controls.Add(Me.backCheckBox)
        Me.GroupBox2.Location = New System.Drawing.Point(73, 235)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(568, 141)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "stop when"
        '
        'hedgeValueLabel
        '
        Me.hedgeValueLabel.AutoSize = True
        Me.hedgeValueLabel.Location = New System.Drawing.Point(408, 107)
        Me.hedgeValueLabel.Name = "hedgeValueLabel"
        Me.hedgeValueLabel.Size = New System.Drawing.Size(16, 17)
        Me.hedgeValueLabel.TabIndex = 10
        Me.hedgeValueLabel.Text = "£"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(273, 107)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 17)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Hedged"
        '
        'laidLabel
        '
        Me.laidLabel.AutoSize = True
        Me.laidLabel.Location = New System.Drawing.Point(410, 69)
        Me.laidLabel.Name = "laidLabel"
        Me.laidLabel.Size = New System.Drawing.Size(16, 17)
        Me.laidLabel.TabIndex = 8
        Me.laidLabel.Text = "£"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(274, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 17)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Laid"
        '
        'backedLabel
        '
        Me.backedLabel.AutoSize = True
        Me.backedLabel.Location = New System.Drawing.Point(411, 26)
        Me.backedLabel.Name = "backedLabel"
        Me.backedLabel.Size = New System.Drawing.Size(16, 17)
        Me.backedLabel.TabIndex = 6
        Me.backedLabel.Text = "£"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(273, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 17)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Backed"
        '
        'layStopTextBox
        '
        Me.layStopTextBox.Location = New System.Drawing.Point(146, 69)
        Me.layStopTextBox.Name = "layStopTextBox"
        Me.layStopTextBox.Size = New System.Drawing.Size(100, 22)
        Me.layStopTextBox.TabIndex = 3
        '
        'backStopTextBox
        '
        Me.backStopTextBox.Location = New System.Drawing.Point(146, 22)
        Me.backStopTextBox.Name = "backStopTextBox"
        Me.backStopTextBox.Size = New System.Drawing.Size(100, 22)
        Me.backStopTextBox.TabIndex = 2
        '
        'layCheckBox
        '
        Me.layCheckBox.AutoSize = True
        Me.layCheckBox.Location = New System.Drawing.Point(15, 69)
        Me.layCheckBox.Name = "layCheckBox"
        Me.layCheckBox.Size = New System.Drawing.Size(101, 21)
        Me.layCheckBox.TabIndex = 1
        Me.layCheckBox.Text = "lay price @"
        Me.layCheckBox.UseVisualStyleBackColor = True
        '
        'backCheckBox
        '
        Me.backCheckBox.AutoSize = True
        Me.backCheckBox.Location = New System.Drawing.Point(15, 21)
        Me.backCheckBox.Name = "backCheckBox"
        Me.backCheckBox.Size = New System.Drawing.Size(113, 21)
        Me.backCheckBox.TabIndex = 0
        Me.backCheckBox.Text = "back price @"
        Me.backCheckBox.UseVisualStyleBackColor = True
        '
        'cancelButton1
        '
        Me.cancelButton1.Location = New System.Drawing.Point(293, 396)
        Me.cancelButton1.Name = "cancelButton1"
        Me.cancelButton1.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton1.TabIndex = 20
        Me.cancelButton1.Text = "Cancel"
        Me.cancelButton1.UseVisualStyleBackColor = True
        '
        'hedgeButton
        '
        Me.hedgeButton.Location = New System.Drawing.Point(484, 396)
        Me.hedgeButton.Name = "hedgeButton"
        Me.hedgeButton.Size = New System.Drawing.Size(75, 23)
        Me.hedgeButton.TabIndex = 21
        Me.hedgeButton.Text = "Hedge"
        Me.hedgeButton.UseVisualStyleBackColor = True
        '
        'UserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Controls.Add(Me.hedgeButton)
        Me.Controls.Add(Me.cancelButton1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.BetButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(1306, 590)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BetButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents returnPriceTextBox As TextBox
    Friend WithEvents returnSizeTextBox As TextBox
    Friend WithEvents fillorkillTextBox As TextBox
    Friend WithEvents priceTextBox As TextBox
    Friend WithEvents sizeTextBox As TextBox
    Friend WithEvents layRadioButton As RadioButton
    Friend WithEvents backRadioButton As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents layStopTextBox As TextBox
    Friend WithEvents backStopTextBox As TextBox
    Friend WithEvents layCheckBox As CheckBox
    Friend WithEvents backCheckBox As CheckBox
    Friend WithEvents hedgeValueLabel As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents laidLabel As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents backedLabel As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cancelButton1 As Button
    Friend WithEvents hedgeButton As Button
End Class
