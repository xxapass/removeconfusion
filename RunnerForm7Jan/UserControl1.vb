Public Class UserControl1

    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With DataGridView1

            .AllowUserToAddRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AutoGenerateColumns = False
            .ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)

            .ColumnHeadersVisible = False
            .DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersVisible = False
            .RowTemplate.Height = 19
            .ShowCellToolTips = False

            Dim sideColumn As New DataGridViewTextBoxColumn
            With sideColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "side"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 40
            End With
            .Columns.Add(sideColumn)

            Dim sizeRequestedColumn As New DataGridViewTextBoxColumn
            With sizeRequestedColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "sizeRequested"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 40
            End With
            .Columns.Add(sizeRequestedColumn)

            Dim priceRequestedColumn As New DataGridViewTextBoxColumn
            With priceRequestedColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "priceRequested"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 40
            End With
            .Columns.Add(priceRequestedColumn)

            Dim fillOrkillColumn As New DataGridViewTextBoxColumn
            With fillOrkillColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "fillOrkill"
                .DataPropertyName = "fillOrkill"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 40
            End With
            .Columns.Add(fillOrkillColumn)

            Dim sizeMatchedColumn As New DataGridViewTextBoxColumn
            With sizeMatchedColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "sizeMatched"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
            End With
            .Columns.Add(sizeMatchedColumn)

            Dim avgPriceMatchedColumn As New DataGridViewTextBoxColumn
            With avgPriceMatchedColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "avgPriceMatched"
                .DataPropertyName = "fillOrkill"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
            End With
            .Columns.Add(avgPriceMatchedColumn)

            Dim betIdColumn As New DataGridViewTextBoxColumn
            With betIdColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "betId"
                .DataPropertyName = "betId"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 120
            End With
            .Columns.Add(betIdColumn)

        End With
    End Sub

    Private Sub refreshButton_Click(sender As Object, e As EventArgs) Handles refreshButton.Click
        Form1.ListMarketBook()
        Form1.CheckMarkets()
    End Sub


    'Public Sub New()
    '    InitializeTimePicker()

    'End Sub
    'Private timePicker As DateTimePicker


    'Private Sub InitializeTimePicker()
    '    timePicker = New DateTimePicker()
    '    timePicker.Format = DateTimePickerFormat.Time
    '    timePicker.ShowUpDown = True
    '    timePicker.Location = New Point(10, 10)
    '    timePicker.Width = 100
    '    Controls.Add(timePicker)

    'End Sub
End Class
