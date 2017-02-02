Public Class UserControl2


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

    Private Sub sizeTextBox_TextChanged(sender As Object, e As EventArgs) Handles sizeTextBox.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.ListMarketBook()
        Form1.CheckMarkets()
    End Sub
End Class

