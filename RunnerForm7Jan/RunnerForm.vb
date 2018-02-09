Public Class RunnerForm

    Inherits Form

    Private control As New UserControl1

    Private marketId As String
    Private selectionId As Integer


    Private openPosition As Boolean
    Private betId As String


    Sub New(ByVal details As String, ByVal marketId As String, ByVal selectionId As Integer)

        Me.FormBorderStyle = FormBorderStyle.FixedToolWindow
        Me.Size = New Size(550, 235)
        Me.Text = details
        Me.Show()

        Me.marketId = marketId
        Me.selectionId = selectionId

        With control
            .Left = 0
            .Top = 0
        End With
        Controls.Add(control)

        'control handlers
        AddHandler control.BetButton.Click, AddressOf betButton_Click
        control.cancelButton.Enabled = False
        AddHandler control.cancelButton.Click, AddressOf cancelButton_Click
        AddHandler control.refreshButton.Click, AddressOf hedgeButton_Click

        openPosition = False

    End Sub

    Public Sub MonitorBets()

        '    control.backedLabel.Text = "£" & Form1.runnerDictionary(Me.selectionId).sumbacked & " @ " & Form1.runnerDictionary(Me.selectionId).avgBackPrice

        '    control.laidLabel.Text = "£" & Form1.runnerDictionary(Me.selectionId).sumLaid & " @ " & Form1.runnerDictionary(Me.selectionId).avgLayPrice


        '    control.hedgeValueLabel.Text = "£" & Form1.runnerDictionary(Me.selectionId).hedge

        '    'back side stop handler
        '    If control.backCheckBox.Checked = True Then 'hedge out

        '        If Form1.runnerDictionary(Me.selectionId).backPrice >= CDbl(control.backStopTextBox.Text) Then
        '            hedgePosition()
        '        End If
        '        End If

        '        'lay side stop handler

        '        If control.layCheckBox.Checked = True Then 'hedge out

        '            If Form1.runnerDictionary(Me.selectionId).layPrice <= CDbl(control.layStopTextBox.Text) Then

        '            hedgePosition()
        '                End If
        '            End If

        '    'monitor open position handler
        If openPosition = True Then
            Dim lastRowIndex = control.DataGridView1.Rows.Count - 1
            Dim betId = control.DataGridView1.Item("betId", lastRowIndex).Value

            control.DataGridView1.Item("sizeMatched", lastRowIndex).Value = Form1.betDictionary(betId).sizeMatched

            control.DataGridView1.Item("avgPriceMatched", lastRowIndex).Value = Form1.betDictionary(betId).averagePriceMatched

            '        If Form1.betDictionary(betId).fillOrkill > 0 Then

            '            Form1.betDictionary(betId).fillOrkill -= 1

            '            control.DataGridView1.Item("fillOrkill", control.DataGridView1.Rows.Count - 1).Value = Form1.betDictionary(betId).fillOrkill

            '        ElseIf Form1.betDictionary(betId).fillOrkill = 0 Then

            '            Form1.CancelOrders(control.DataGridView1.Item("betId", control.DataGridView1.Rows.Count - 1).Value, Me.marketId, control.DataGridView1.Item("sizeRequested", control.DataGridView1.Rows.Count - 1).Value)

            '            control.DataGridView1.Item("betId", control.DataGridView1.Rows.Count - 1).Value = "CANCELLED"

            '            control.BetButton.Enabled = True
            '            control.cancelButton.Enabled = False
            '            openPosition = False

        End If
        '    End If

        '    'bet matched handler

        If Form1.betDictionary(betId).status = "EXECUTION_COMPLETE" Then

                '            If Not control.returnSizeTextBox.Text = " " And Not control.returnPriceTextBox.Text = "" Then

                '                If control.backRadioButton.Checked = True Then 'if backed then lay

                '                    PlaceBet("LAY", CDbl(control.returnSizeTextBox.Text), CDbl(control.returnPriceTextBox.Text), -1)

                '                Else 'else back

                '                    PlaceBet("BACK", CDbl(control.returnPriceTextBox.Text), CDbl(control.returnPriceTextBox.Text), -1)

                '                End If

                control.BetButton.Enabled = False
                control.cancelButton.Enabled = True 'enable cancel button
                openPosition = True 'flag position open
                'End If
            End If


            control.BetButton.Enabled = True
        openPosition = False


    End Sub



    Private Sub betButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim side As String = "BACK"

        'If control.layRadioButton.Checked = True Then
        '    side = "LAY"
        'End If

        Dim size As Double = CDbl(control.sizeTextBox.Text)
        'Dim price As Double = CDbl(control.priceTextBox.Text)
        Dim price As Double = CDbl(control.priceComboBox.Text)
        Dim fillOrkill As Integer

        'If control.fillorkillTextBox.Text = "" Then
        '    fillOrkill = -1
        'Else
        '    fillOrkill = CDbl(control.fillorkillTextBox.Text)
        'End If

        PlaceBet(side, size, price, fillOrkill)
    End Sub

    'Private Sub PlaceBet(ByVal side As String, ByVal size As Double, ByVal price As Double, ByVal fillOrkill As Integer)
    Public Sub PlaceBet(ByVal side As String, ByVal size As Double, ByVal price As Double, ByVal fillOrkill As Integer)
        Dim betId As String

        betId = Form1.SendBet(Me.marketId, Me.selectionId, side, size, price)

        Dim detail As New Form1.BetDetail
        detail.fillOrkill = fillOrkill
        Form1.betDictionary.Add(betId, detail)

        control.DataGridView1.Rows.Add(side, size, price, fillOrkill, 0, 0, betId)

        control.BetButton.Enabled = False
        control.cancelButton.Enabled = True
        'control.sizeTextBox.Text = ""
        'control.priceTextBox.Text = ""
        'control.fillorkillTextBox.Text = ""

        openPosition = True

    End Sub
    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Form1.CancelOrders(control.DataGridView1.Item("betId", control.DataGridView1.Rows.Count - 1).Value, Me.marketId, control.DataGridView1.Item("sizeRequested", control.DataGridView1.Rows.Count - 1).Value)

        control.DataGridView1.Item("betId", control.DataGridView1.Rows.Count - 1).Value = "CANCELLED"

        control.BetButton.Enabled = True
        control.cancelButton.Enabled = False
        openPosition = False

    End Sub

    Private Sub hedgeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        hedgePosition()
    End Sub

    Private Sub hedgePosition()

        If Form1.runnerDictionary(Me.selectionId).backReturn > Form1.runnerDictionary(Me.selectionId).layLiability Then

            PlaceBet("LAY", Form1.runnerDictionary(Me.selectionId).hedgeStake, Form1.runnerDictionary(Me.selectionId).layPrice, -1)

        End If

            If Form1.runnerDictionary(Me.selectionId).layLiability > Form1.runnerDictionary(Me.selectionId).backReturn Then

            PlaceBet("BACK", Form1.runnerDictionary(Me.selectionId).hedgeStake, Form1.runnerDictionary(Me.selectionId).backPrice, -1)

        End If
    End Sub
    'Public Sub BindpriceComboBox()
    '    'Dim dataset As System.Data.DataSet.Tables("Runners")
    '    UserControl1.priceComboBox.DataSource = Form1.dataSet.Tables("Runners")
    '    priceComboBox.DisplayMember = "back"
    'End Sub
    Private Sub RunnerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Form1.runnerFormDictionary.Remove(Me.selectionId)

    End Sub
End Class



