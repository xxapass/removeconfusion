Public Class ChartBotForm
    Inherits Form

    Private pictureBoxes As PictureBox() 'array of picture boxes to hold charts
    Private labels As Label() 'array of runner name labels

    Private urlList As New List(Of String)

    Private refreshLabel As New Label
    Private WithEvents nudSeconds As New NumericUpDown 'time inetrval selector
    Private secsLabel As New Label

    Private WithEvents timer As New Timer 'timer
    Sub New(ByVal marketId As String, ByVal course As String, ByVal runners As List(Of Form1.ChartDetail), ByVal selectedCount As Integer)

        Me.Width = 5 + (350 * selectedCount) + 5
        Me.Height = 320
        Me.Text = course
        Me.FormBorderStyle = FormBorderStyle.FixedToolWindow
        Me.BackColor = Color.White
        Me.Show()

        'redim as you know how many runners there are now
        ReDim pictureBoxes(selectedCount)
        ReDim labels(selectedCount)
        Dim leftPos As Integer = 0
        Dim pictureCount As Integer = 0
        For n As Integer = 0 To runners.Count - 1
            If runners.Item(n).ChartBot = True Then
                pictureBoxes(pictureCount) = New PictureBox

                With pictureBoxes(pictureCount)
                    .Left = leftPos 'set left position
                    .Top = -25
                    .Width = 350
                    .Height = 255
                    .SizeMode = PictureBoxSizeMode.AutoSize

                    Dim urlString As String =
                        "http://uk.sportsiteexweb.betfair.com/betting/LoadRunnerInfoChartAction.do?marketId=" & marketId.Replace("1.", "") & "&selectionId=" & runners.Item(n).selectionId

                    pictureBoxes(pictureCount).Load(urlString)
                    urlList.Add(urlString)

                End With
                Controls.Add(pictureBoxes(pictureCount)) 'add picture box to form

                labels(pictureCount) = New Label

                Dim myfont As New Font("sans serif", 12, FontStyle.Regular)

                With labels(pictureCount)
                    .Left = leftPos
                    .Top = 231
                    .Width = 350
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Text = runners.Item(n).runnerName
                    .BackColor = Color.White
                    .Font = myfont
                End With
                Controls.Add(labels(pictureCount)) 'add label to form

                pictureCount += 1
                leftPos += 351
            End If
        Next

        With refreshLabel
            .left = 10
            .top = 265
            .width = 45
            .text = "Refresh"
        End With
        Controls.Add(refreshLabel)
        With nudSeconds
            .Left = 60
            .Top = 263
            .Width = 40
            .Minimum = 15 '15 sec minimum interval
            .Maximum = 300 '5 min max
            .Increment = 15
            .Value = 60 'initial value set to 60 secs
        End With
        Controls.Add(nudSeconds)
        With secsLabel
            .Left = 110
            .Top = 265
            .Text = "seconds"
        End With
        Controls.Add(secsLabel)

        With timer
            .Enabled = True
            .Interval = 60000 'initial int 60000 lillisecs = 60 secs
        End With
    End Sub
    Private Sub timer_tick(sender As Object, e As EventArgs) Handles timer.Tick
        For n As Integer = 0 To urlList.Count - 1
            pictureBoxes(n).Load(Me.urlList.Item(n)) 'refresh charts

        Next

    End Sub
    Private Sub nudSeconds_ValueChanged(sender As Object, e As EventArgs) Handles nudSeconds.ValueChanged
        timer.Interval = nudSeconds.Value * 1000 'change timer int to nud value*1000
    End Sub
    Private Sub ChartBotForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        timer.Enabled = False

    End Sub

End Class
