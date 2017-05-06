'Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports Microsoft.Office.Interop

Public Class Form1

    Private filename As String = Format(Date.Now, "yyyy-MM-dd") 'declares to format for the json response saved to C:\Betfair etc line 453

    Public dataSet As DataSet = New DataSet("RaceData")
    'Protected dataTable As DataTable = dataSet.Tables.Add("Runners")
    Public dataTable As DataTable = dataSet.Tables.Add("Runners")
    'Protected dataView As DataView
    Public dataView As DataView
    Public bindingSource As New BindingSource

    Public Class MarketDetail

        Public marketId As String
        Public selectionId As String
        Public status As String
        Public inPlay As Boolean
        Public removed As Boolean
    End Class

    Protected marketDictionary As New Dictionary(Of String, MarketDetail)
    Protected bookRequestList As New List(Of String)

    Public runnerFormDictionary As New Dictionary(Of Integer, RunnerForm)

    Public Class BetDetail

        Public status As String
        Public averagePriceMatched As Double
        Public sizeMatched As Double
        Public fillOrkill As Integer
    End Class

    Public betDictionary As New Dictionary(Of String, BetDetail)


    Public Class RunnerDetail

        Public marketId As String
        Public selectionId As String
        Public status As String
        Public backPrice As Double
        Public layPrice As Double

        Public sumbacked As Double
        Public backReturn As Double
        Public avgBackPrice As Double

        Public sumLaid As Double
        Public layLiability As Double
        Public avgLayPrice As Double

        Public hedgeStake As Double
        Public hedge As Double
        'Friend runnerName As Object
    End Class

    Public runnerDictionary As New Dictionary(Of Integer, RunnerDetail)
    Public Class ChartDetail
        Public runnerName As String
        Public selectionId As Integer
        Public ChartBot As Boolean
    End Class

    'Public Property YourGridViewBindingSource As Object

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        LoginForm.Show()

    End Sub


    Public Sub Initialise()
        BuildDataGridView() 'build dataGridView
        BuildDataTable() 'build dataTable
        ListMarketCatalogue() 'get events
        BuildListMarketBookRequests() 'get prices
        Accountbalance()
        'Timer1.Enabled = True Button1 now used to start and stop 
    End Sub
    Public Sub BuildDataTable() 'a logical representation of a DataSet in memory from which DGV can be updated

        dataTable.Columns.Add("marketStartTime", GetType(System.String), Nothing) 'adds columns to DataTable in memory and defines data type for each column
        dataTable.Columns.Add("marketId", GetType(System.String), Nothing) 'result.marketId
        dataTable.Columns.Add("marketStatus", GetType(System.String), Nothing)
        dataTable.Columns.Add("inPlay", GetType(System.String), Nothing)
        dataTable.Columns.Add("Event", GetType(System.String), Nothing) 'result.event.name
        dataTable.Columns.Add("selectionId", GetType(System.String), Nothing) 'allMarkets(0).result(n).runners.Item(m).selectionId
        dataTable.Columns.Add("runnerName", GetType(System.String), Nothing)
        dataTable.Columns.Add("runnerStatus", GetType(System.String), Nothing)
        dataTable.Columns.Add("back", GetType(System.Double), Nothing)
        dataTable.Columns.Add("lay", GetType(System.Double), Nothing)
        'dataTable.Columns.Add("countryCode", GetType(System.String), Nothing) 'result.event.countryCode
        'dataTable.Columns.Add("competitionName", GetType(System.String), Nothing) 'result.competition.name
        'dataTable.Columns.Add("marketName", GetType(String), Nothing) 'result.marketName

        dataTable.PrimaryKey = New DataColumn() {dataTable.Columns("marketId"), dataTable.Columns("selectionId")} 'uses marketId and selectionId as a unique pair to search the table


        Dim dataView As DataView = dataSet.Tables("Runners").DefaultView

        'dataView.Sort = "marketStartTime" 'sort data by time
        dataView.Sort = "Event" 'sort Event alphabetically 
        'dataView.Sort = "course"
        bindingSource = New BindingSource

        DataGridView1.DataSource = bindingSource 'binds DataView to DGV so that any changes to DataSet are matched in DGV

        bindingSource.DataSource = dataView

    End Sub
    Protected Sub BuildDataGridView()


        With DataGridView1() 'a customisable view of the DataTable

            .AllowUserToAddRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            '.AutoGenerateColumns = False
            .AutoGenerateColumns = True
            .ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)

            .ColumnHeadersVisible = True
            .DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersVisible = False
            .RowTemplate.Height = 19
            .ShowCellToolTips = False

            Dim marketStartTimeColumn As New DataGridViewTextBoxColumn
            With marketStartTimeColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                ' .Name = "marketStartTime"
                .Name = "marketStartTime"
                .DataPropertyName = "marketStartTime" 'gets updated data from DataView
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 40
            End With
            .Columns.Add(marketStartTimeColumn)

            Dim marketIdColumn As New DataGridViewTextBoxColumn
            With marketIdColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "marketId"
                .DataPropertyName = "marketId"
                .Width = 80
            End With
            .Columns.Add(marketIdColumn)

            Dim marketStatusColumn As New DataGridViewTextBoxColumn
            With marketStatusColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "marketStatus"
                .DataPropertyName = "marketStatus"
                .Width = 80
            End With
            .Columns.Add(marketStatusColumn)

            'Dim inPlayColumn As New DataGridViewTextBoxColumn
            'With inPlayColumn
            '    .SortMode = DataGridViewColumnSortMode.NotSortable
            '    .Name = "Country/inPlay"
            '    .DataPropertyName = "inPlay"
            '    .DataPropertyName = "countryCode"
            '    '.DataPropertyName = "marketId"
            '    .Width = 150
            'End With
            '.Columns.Add(inPlayColumn)

            'Dim competitionColumn As New DataGridViewTextBoxColumn
            'With competitionColumn
            '    .SortMode = DataGridViewColumnSortMode.NotSortable
            '    .Name = "Competition"
            '    .DataPropertyName = "competitionName"
            '    '.DataPropertyName = "Country"
            '    .Width = 100
            'End With
            '.Columns.Add(competitionColumn)

            'Dim courseColumn As New DataGridViewTextBoxColumn
            'With courseColumn
            '    .SortMode = DataGridViewColumnSortMode.NotSortable
            '    .Name = "course"
            '    .DataPropertyName = "course"
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '    .Width = 200
            'End With
            '.Columns.Add(courseColumn)
            Dim EventColumn As New DataGridViewTextBoxColumn
            With EventColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "Event"
                .DataPropertyName = "Event"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 150
            End With
            .Columns.Add(EventColumn)

            'Dim marketNameColumn As New DataGridViewTextBoxColumn
            'With marketNameColumn
            '    .SortMode = DataGridViewColumnSortMode.NotSortable
            '    .Name = "marketName"
            '    .DataPropertyName = "marketName"
            '    .DefaultCellStyle.BackColor = Color.AntiqueWhite
            '    .DefaultCellStyle.SelectionBackColor = Color.Pink
            '    .Width = 200

            'End With
            '.Columns.Add(marketNameColumn)

            Dim selectionIdColumn As New DataGridViewTextBoxColumn
            With selectionIdColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "selectionId"
                .DataPropertyName = "selectionId"
                .Width = 60
            End With
            .Columns.Add(selectionIdColumn)

            Dim runnerNameColumn As New DataGridViewTextBoxColumn
            With runnerNameColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "runnerName"
                .DataPropertyName = "runnerName"
                .Width = 110
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(runnerNameColumn)

            'Dim marketNameColumn As New DataGridViewTextBoxColumn
            'With marketNameColumn
            '    .SortMode = DataGridViewColumnSortMode.NotSortable
            '    .Name = "marketName"
            '    .DataPropertyName = "marketName"
            '    .Width = 120
            'End With
            '.Columns.Add(marketNameColumn)

            'Dim runnerStatusColumn As New DataGridViewTextBoxColumn 'runnerstatus function disabled
            'With runnerStatusColumn
            '    .SortMode = DataGridViewColumnSortMode.NotSortable
            '    .Name = "runnerStatus"
            '    '.Name = "marketName"
            '    .DataPropertyName = "runnerStatus"
            '    .Width = 150
            'End With
            '.Columns.Add(runnerStatusColumn)

            Dim backColumn As New DataGridViewTextBoxColumn
            With backColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "back"
                .DataPropertyName = "back"
                .DefaultCellStyle.BackColor = Color.LightSkyBlue
                .DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue
                .Width = 40
            End With
            .Columns.Add(backColumn)

            Dim layColumn As New DataGridViewTextBoxColumn
            With layColumn
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Name = "lay"
                .DataPropertyName = "lay"
                .DefaultCellStyle.BackColor = Color.Pink
                .DefaultCellStyle.SelectionBackColor = Color.Pink
                .Width = 40
            End With
            .Columns.Add(layColumn)
        End With
    End Sub


    Protected Sub ListMarketCatalogue() 'data loaded automatically on initialise
        Dim requestList As New List(Of MarketCatalogueRequest)
        Dim request As New MarketCatalogueRequest
        Dim params As New Params

        Dim eventTypeIds As New List(Of String)
        eventTypeIds.Add("1") 'soccer
        'eventTypeIds.Add("7") 'horses
        params.filter.eventTypeIds = eventTypeIds

        Dim competitionIds As New List(Of String)
        competitionIds.Add("10932509") 'EPL
        competitionIds.Add("117") 'ESP
        'competitionIds.Add("2005") 'Europa League
        competitionIds.Add("9404054") 'Dutch Eredivisie
        competitionIds.Add("59") 'Bundesliga 1
        competitionIds.Add("81") 'Serie A
        'competitionIds.Add("7129730") 'The Championship
        competitionIds.Add("99") 'Primeira Liga
        competitionIds.Add("55") 'French Ligue One
        ' competitionIds.Add("89979") 'Belgian Jupiler League
        ''competitionIds.Add("5984496") 'IT Pro Liga
        ''competitionIds.Add("7129730") 'Champ
        'competitionIds.Add("228") 'Champions League
        ''competitionIds.Add("61") 'Bundesliga 2
        ''competitionIds.Add("35") 'League 1
        ''competitionIds.Add("37") 'League 2
        'competitionIds.Add(5614746) '2018 FIFA World Cup
        ''competitionIds.Add(801976) 'Egyptian Premier
        'competitionIds.Add("10765348") 'International Friendly
        params.filter.competitionIds = competitionIds

        Dim marketCountries As New List(Of String)
        'marketCountries.Add("GB")
        'marketCountries.Add("ES")
        'marketCountries.Add("FR")
        'marketCountries.Add("IT")
        'marketCountries.Add("NL")
        'marketCountries.Add("DE")
        'marketCountries.Add("INT") 'International
        'marketCountries.Add("NZ")
        'marketCountries.Add("AU")
        params.filter.marketCountries = marketCountries

        Dim marketProjection As New List(Of String)
        marketProjection.Add("MARKET_START_TIME")
        marketProjection.Add("RUNNER_DESCRIPTION")
        marketProjection.Add("EVENT")
        marketProjection.Add("COMPETITION") 'added by me
        params.marketProjection = marketProjection

        Dim marketTypeCodes As New List(Of String)
        ' marketTypeCodes.Add("MATCH_ODDS")
        marketTypeCodes.Add("OVER_UNDER_35")
        marketTypeCodes.Add("OVER_UNDER_45")
        'marketTypeCodes.Add("WIN")
        'marketTypeCodes.Add("HALF_TIME_FULL_TIME")
        marketTypeCodes.Add("CORRECT_SCORE")
        marketTypeCodes.Add("HALF_TIME_SCORE")
        marketTypeCodes.Add("FIRST_HALF_GOALS_15")

        params.filter.marketTypeCodes = marketTypeCodes

        Dim marketStartTime As New StartTime

        If Today.IsDaylightSavingTime() Then

            marketStartTime.from = Format(Date.Now, "yyyy-MM-dd") & "T" & Format(Now.AddHours(-1), "Long Time") & "Z"
            'see what happens when clocks go forward
        Else

            marketStartTime.from = Format(Date.Now, "yyyy-MM-dd") & "T" & Format(Now, "Long Time") & "Z"

        End If

        marketStartTime.to = Today.ToString("u").Replace(" ", "T").Replace("00:00", "23:00")
        params.filter.marketStartTime = marketStartTime

        request.params = params
        requestList.Add(request)

        Dim allMarkets() As MarketCatalogueResponse

        allMarkets = DeserializeMarketCatalogueResponse(SerializeMarketCatalogueRequest(requestList))

        For n = 0 To allMarkets(0).result.Count - 1 'loop through all markets returned in RESULT part of JSON response

            Dim detail As New MarketDetail
            detail.marketId = allMarkets(0).result(n).marketId
            detail.removed = False

            marketDictionary.Add(allMarkets(0).result(n).marketId, detail)

            For m = 0 To allMarkets(0).result(n).runners.Count - 1 'loops through each runner within each market

                Dim course() As String

                course = Split(allMarkets(0).result(n).event.name)


                'Print(Format(allMarkets(0).result(n).marketStartTime, "Short Time") & " " & course(0) & " " & allMarkets(0).result(n).marketName & " " & allMarkets(0).result(n).runners.Item(m).runnerName)

                'Event = Split(allMarkets(0).result(n).event.name)
                'Dim competitionIds As String
                'competitionIds = (allMarkets(0).result(n).competitionIds)

                Try 'add runner to dataTable
                    'dataTable.Rows.Add(Format(allMarkets(0).result(n).marketStartTime, "Short Time"), allMarkets(0).result(n).marketId, "", "", course(0) & " " & allMarkets(0).result(n).marketName, allMarkets(0).result(n).runners.Item(m).selectionId, allMarkets(0).result(n).runners.Item(m).runnerName)

                    'dataTable.Rows.Add(Format(allMarkets(0).result(n).marketStartTime, "Short Time"), allMarkets(0).result(n).marketId, "", "", allMarkets(0).result(n).event.name, allMarkets(0).result(n).runners.Item(m).selectionId, allMarkets(0).result(n).runners.Item(m).runnerName)
                    'dataTable.Rows.Add(Format(allMarkets(0).result(n).marketStartTime, "Short Time"), allMarkets(0).result(n).marketId, "", allMarkets(0).result(n).event.countryCode, allMarkets(0).result(n).event.name & " " & allMarkets(0).result(n).marketName, allMarkets(0).result(n).runners.Item(m).selectionId, allMarkets(0).result(n).runners.Item(m).runnerName, allMarkets(0).result(n).marketName)
                    'dataTable.Rows.Add(Format(allMarkets(0).result(n).marketStartTime, "Short Time"), allMarkets(0).result(n).marketId, "", allMarkets(0).result(n).event.countryCode, allMarkets(0).result(n).event.name, allMarkets(0).result(n).runners.Item(m).selectionId, allMarkets(0).result(n).runners.Item(m).runnerName, allMarkets(0).result(n).marketName)
                    ' dataTable.Rows.Add(Format(allMarkets(0).result(n).marketStartTime, "Short Time"), allMarkets(0).result(n).marketId, "", allMarkets(0).result(n).event.countryCode, allMarkets(0).result(n).event.name, allMarkets(0).result(n).runners.Item(m).selectionId, allMarkets(0).result(n).runners.Item(m).runnerName, allMarkets(0).result(n).marketName, allMarkets(0).result(n).competitionName)
                    dataTable.Rows.Add(Format(allMarkets(0).result(n).marketStartTime, "Short Time"), allMarkets(0).result(n).marketId, "", allMarkets(0).result(n).event.countryCode, allMarkets(0).result(n).event.name, allMarkets(0).result(n).runners.Item(m).selectionId, allMarkets(0).result(n).runners.Item(m).runnerName, allMarkets(0).result(n).marketName) ', allMarkets(0).result(n).competitionName)
                    'dataTable.Rows.Add(Format(allMarkets(0).result(n).marketStartTime, "Short Time"), allMarkets(0).result(n).marketId, "", "", allMarkets(0).result(n).event.name, allMarkets(0).result(n).runners.Item(m).selectionId, allMarkets(0).result(n).runners.Item(m).runnerName, allMarkets(0).result(n).event.countryCode, allMarkets(0).result(n).competitionName) ', allMarkets(0).result(n).marketName)

                    If Not runnerDictionary.ContainsKey(allMarkets(0).result(n).runners.Item(m).selectionId) Then
                        Dim data As New RunnerDetail
                        data.marketId = allMarkets(0).result(n).marketId
                        runnerDictionary.Add(allMarkets(0).result(n).runners.Item(m).selectionId, data)
                    End If

                Catch ex As Exception
                End Try

            Next
        Next
    End Sub
    Protected Sub BuildListMarketBookRequests()

        Dim count As Integer = 0
        Dim marketIdList As New List(Of String)
        bookRequestList.Clear()

        Dim pair As KeyValuePair(Of String, MarketDetail)

        For Each pair In marketDictionary

            If pair.Value.removed = False Then
                marketIdList.Add(pair.Value.marketId)
            End If

        Next

        For n As Integer = 0 To (marketIdList.Count \ 9)

            Dim jsonRequest As String
            Dim requestList As New List(Of MarketBookRequest)
            Dim request As New MarketBookRequest
            Dim params As New MarketBookParams

            If n = (marketIdList.Count \ 9) Then

                For m As Integer = 1 To marketIdList.Count Mod 9
                    params.marketIds.Add(marketIdList.Item(count))
                    count += 1
                Next

            Else

                For m As Integer = 1 To 9
                    params.marketIds.Add(marketIdList.Item(count))
                    count += 1
                Next

            End If

            params.priceProjection.priceData.Add("EX_BEST_OFFERS")
            'params.priceProjection.priceData.Add("EX_TRADED")
            'params.orderProjection = "ALL"
            params.orderProjection = "EXECUTABLE"

            request.params = params

            requestList.Add(request)

            jsonRequest = SerializeMarketBookRequest(requestList)

            bookRequestList.Add(jsonRequest)

        Next

    End Sub


    'Protected Sub ListMarketBook()
    Public Sub ListMarketBook()

        Dim keys(1) As Object
        Dim foundRow As DataRow

        For n As Integer = 0 To bookRequestList.Count - 1

            Dim jsonResponse As String = GetRawBook(bookRequestList.Item(n))

            'If CheckBox1.CheckState = 1 Then

            '    Using writer As StreamWriter = File.AppendText("C:\Betfair\" & filename & ".json")
            '        writer.WriteLine(Now & "*" & jsonResponse)
            '    End Using
            'End If

            jsonResponse = ""

            Do
                jsonResponse = GetRawBook(bookRequestList.Item(n))
                'If jsonResponse = "" Then
                '    Print("jsonResponse empty - retrying")
                'End If
            Loop While jsonResponse = ""

            Dim book() As MarketBookResponse = DeserializeRawBook(jsonResponse)

            For bookCount As Integer = 0 To book(0).result.Count - 1

                For runnerCount As Integer = 0 To book(0).result(bookCount).runners.Count - 1

                    'Dim Counter As Integer
                    'Dim Workarea(250) As String
                    ''ProgressBar1.Minimum = LBound(Workarea)
                    ''ProgressBar1.Maximum = UBound(Workarea)
                    'ProgressBar1.Visible = True

                    'Set the Progress's Value to Min.
                    'ProgressBar1.Value = ProgressBar1.Minimum

                    ' CheckedListBox1.Items.Clear()
                    'ListMarketBook()

                    'Loop through the array.
                    'For Counter = 0 To book(0).result(bookCount).runners.Count - 1 '= LBound(Workarea) To UBound(Workarea)
                    '    '    'Set initial values for each item in the array.
                    '    Workarea(Counter) = "Initial value" & Counter
                    '    ProgressBar1.Value = Counter
                    'Next Counter
                    ''ProgressBar1.Visible = False
                    ''ProgressBar1.Value = ProgressBar1.Minimum


                    With book(0).result(bookCount).runners(runnerCount)

                            keys(0) = book(0).result(bookCount).marketId
                            keys(1) = .selectionId
                            foundRow = dataSet.Tables("Runners").Rows.Find(keys) 'looks in dataSet to find marketId&selectionId pair

                            foundRow("marketStatus") = book(0).result(bookCount).status 'updates status for each pair

                            marketDictionary.Item(book(0).result(bookCount).marketId).status = book(0).result(bookCount).status

                            marketDictionary.Item(book(0).result(bookCount).marketId).inPlay = book(0).result(bookCount).inplay

                            If book(0).result(bookCount).inplay = True Then
                                foundRow("inPlay") = "inPlay"
                            Else
                                'foundRow("inPlay") = "" 'removes countryCode and replaces with "" (preplay)
                            End If

                            'foundRow("runnerStatus") = .status don't need runnerstatus, replaced with marketName except it records winning/losing status which might be useful
                            'runnerDictionary(.selectionId).status = .status

                            'If .status = "ACTIVE" Then

                            '    foundRow("runnerStatus") = "ACTIVE"

                            If .ex.availableToback.Count > 0 Then
                                runnerDictionary(.selectionId).backPrice = .ex.availableToback(0).price
                                foundRow("back") = .ex.availableToback(0).price
                            End If

                            If .ex.availableToLay.Count > 0 Then
                                runnerDictionary(.selectionId).layPrice = .ex.availableToLay(0).price
                                foundRow("lay") = .ex.availableToLay(0).price
                            End If

                            If .orders.Count > 0 Then
                                ProcessOrders(.selectionId, .orders)
                            End If
                            'End If

                        End With
                    Next

                Next
        Next
    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick 'enabled by Start button

        ListMarketBook()
        CheckMarkets()
        UpdateRunnerForms()

    End Sub

    'Protected Sub CheckMarkets()
    Public Sub CheckMarkets()
        Dim racesRemoved As Boolean = False

        Dim pair As KeyValuePair(Of String, MarketDetail)

        For Each pair In marketDictionary

            If pair.Value.status = "CLOSED" And pair.Value.removed = False Then
                pair.Value.removed = True
                racesRemoved = True
            End If

        Next

        If racesRemoved = True Then
            BuildListMarketBookRequests()
        End If
    End Sub

    Function PlaceOrders(ByVal selectionId As Integer, ByVal marketId As String, ByVal side As String, ByVal size As Double, ByVal price As Double)

        Dim requestList As New List(Of PlaceOrdersRequest) 'request object

        Dim request As New PlaceOrdersRequest 'holds data for request object

        Dim params As New PlaceOrdersParams

        params.marketId = marketId

        Dim instructions As New PlaceInstructions
        instructions.selectionId = selectionId
        instructions.handicap = 0
        instructions.side = side
        instructions.orderType = "LIMIT"

        Dim limitOrder As New LimitOrder
        limitOrder.size = size
        limitOrder.price = price
        'limitOrder.persistenceType = "LAPSE"
        limitOrder.persistenceType = "PERSIST"
        instructions.limitOrder = limitOrder

        params.instructions.Add(instructions)

        request.params = params

        requestList.Add(request)

        Dim orders() As PlaceOrdersResponse

        orders = DeserializePlaceOrdersResponse(SerializePlaceOrdersRequest(requestList))

        'Return (orders(0).result.instructionReports(0).betId)
        Return (orders(0).result.instructionReports(0).betId)
    End Function

    Function PlaceSub2Orders(ByVal selectionId As Integer, ByVal marketId As String, ByVal side As String, ByVal preferredSize As Double, ByVal preferredprice As Double)

        Dim requestList As New List(Of PlaceOrdersRequest)
        Dim request As New PlaceOrdersRequest
        Dim params As New PlaceOrdersParams
        params.marketId = marketId

        Dim instructions As New PlaceInstructions
        instructions.selectionId = selectionId
        instructions.handicap = 0
        instructions.side = side
        instructions.orderType = "LIMIT"

        Dim limitOrder As New LimitOrder
        limitOrder.size = 2

        If side = "BACK" Then
            limitOrder.price = 1000
        Else
            limitOrder.price = 1.01
        End If

        limitOrder.persistenceType = "LAPSE"
        instructions.limitOrder = limitOrder
        params.instructions.Add(instructions)

        request.params = params
        requestList.Add(request)

        Dim orders() As PlaceOrdersResponse
        orders = DeserializePlaceOrdersResponse(SerializePlaceOrdersRequest(requestList))

        Dim betId As String = orders(0).result.instructionReports(0).betId
        betId = CancelOrders(betId, marketId, 2 - preferredSize)
        betId = ReplaceOrders(betId, marketId, preferredprice)

        Return betId
    End Function

    Public Function CancelOrders(ByVal betId As String, ByVal marketId As String, ByVal sizereduction As Double)

        Dim requestList As New List(Of CancelOrdersRequest)
        Dim request As New CancelOrdersRequest

        Dim params As New CancelOrdersParams
        params.marketId = marketId

        Dim instructions As New CancelInstructions
        instructions.betId = betId
        instructions.sizeReduction = sizereduction
        params.instructions.Add(instructions)

        request.params = params

        requestList.Add(request)

        Dim orders() As CancelOrdersResponse

        orders = DeserializeCancelOrdersResponse(SerializeCancelOrdersRequest(requestList))

        Return orders(0).result.instructionReports(0).instruction.betId

    End Function

    Public Function ReplaceOrders(ByVal betId As String, ByVal marketId As String, ByVal newPrice As Double)

        Dim requestList As New List(Of ReplaceOrdersRequest)
        Dim request As New ReplaceOrdersRequest

        Dim params As New ReplaceOrdersParams
        params.marketId = marketId

        Dim instructions As New ReplaceInstructions
        instructions.betId = betId
        instructions.newPrice = newPrice
        params.instructions.Add(instructions)

        request.params = params

        requestList.Add(request)

        Dim orders() As ReplaceOrdersResponse

        orders = DeserializeReplaceOrdersResponse(SerializeReplaceOrdersRequest(requestList))

        Return orders(0).result.instructionReports(0).placeInstructionReport.betId

    End Function
    Public Function SendBet(ByVal marketId As String, ByVal selectionId As Integer, ByVal side As String, ByVal size As Double, ByVal price As Double)

        Dim betId As String

        If size < 2 Then
            betId = PlaceSub2Orders(selectionId, marketId, side, size, price)
        Else
            betId = PlaceOrders(selectionId, marketId, side, size, price)
        End If

        Return betId
    End Function

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    'ListMarketCatalogue()
    'BuildListMarketBookRequests()
    'Timer1.Enabled = True
    'End Sub

    Protected Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        'If e.ColumnIndex = 8 Then
        If e.ColumnIndex = 8 Then
            Accountbalance()
            Dim runnerForm As New RunnerForm(DataGridView1.Item("back", e.RowIndex).Value & "/" & DataGridView1.Item("lay", e.RowIndex).Value & " " & DataGridView1.Item("runnerStatus", e.RowIndex).Value & " " & DataGridView1.Item("runnerName", e.RowIndex).Value & " - " & DataGridView1.Item("marketStartTime", e.RowIndex).Value & " " & DataGridView1.Item("Event", e.RowIndex).Value, DataGridView1.Item("marketId", e.RowIndex).Value, DataGridView1.Item("selectionId", e.RowIndex).Value)

        End If


        'If e.ColumnIndex = 9 Then
        If e.ColumnIndex = 9 Then
            Accountbalance()
            Dim runnerForm2 As New RunnerForm2(DataGridView1.Item("back", e.RowIndex).Value & "/" & DataGridView1.Item("lay", e.RowIndex).Value & " " & DataGridView1.Item("runnerStatus", e.RowIndex).Value & "" & DataGridView1.Item("runnerName", e.RowIndex).Value & " - " & DataGridView1.Item("marketStartTime", e.RowIndex).Value & " " & DataGridView1.Item("Event", e.RowIndex).Value, DataGridView1.Item("marketId", e.RowIndex).Value, DataGridView1.Item("selectionId", e.RowIndex).Value)

            'runnerFormDictionary.Add(DataGridView1.Item("selectionId", e.RowIndex).Value, runnerForm2)
        End If
        If e.ColumnIndex = 4 Then

            Dim runnerList As New List(Of ChartDetail)

            For Each row As DataGridViewRow In DataGridView1.Rows

                If Not IsDBNull(row.Cells.Item("runnerStatus").Value) Then
                    If row.Cells.Item("marketId").Value = DataGridView1.Item("marketId", e.RowIndex).Value And row.Cells.Item("runnerStatus").Value = "ACTIVE" Then

                        Dim runner As New ChartDetail
                        runner.runnerName = row.Cells.Item("runnerName").Value
                        runner.selectionId = row.Cells.Item("selectionId").Value
                        runner.ChartBot = False
                        runnerList.Add(runner)
                    End If
                End If

            Next

            If runnerList.Count > 0 Then

                Dim marketForm As New MarketForm(DataGridView1.Item("marketId", e.RowIndex).Value, DataGridView1.Item("marketStarttime", e.RowIndex).Value & " " & DataGridView1.Item("course", e.RowIndex).Value, runnerList)

            End If
        End If
    End Sub

    Private Sub UpdateRunnerForms()
        Dim pair As KeyValuePair(Of Integer, RunnerForm)
        For Each pair In runnerFormDictionary
            runnerFormDictionary(pair.Key).MonitorBets()
        Next


    End Sub
    'Process previously traded orders
    Private Sub ProcessOrders(ByVal selectionId As Integer, ByVal orders As List(Of Order))

        Dim sumBacked As Double = 0
        Dim sumLaid As Double = 0
        Dim backReturn As Double = 0
        Dim layLiability As Double

        For m As Integer = 0 To orders.Count - 1

            If Not betDictionary.ContainsKey(orders(m).betId) Then
                Dim betDetail As New BetDetail
                betDictionary.Add(orders(m).betId, betDetail)
            End If

            betDictionary(orders(m).betId).status = orders(m).status
            betDictionary(orders(m).betId).averagePriceMatched = orders(m).avgPriceMatched
            betDictionary(orders(m).betId).sizeMatched = orders(m).sizeMatched

            If orders(m).side = "BACK" Then
                sumBacked += orders(m).sizeMatched
                backReturn += orders(m).sizeMatched * orders(m).avgPriceMatched
            Else
                sumLaid += orders(m).sizeMatched
                layLiability += orders(m).sizeMatched * orders(m).avgPriceMatched
            End If

        Next

        runnerDictionary(selectionId).sumbacked = sumBacked
        runnerDictionary(selectionId).backReturn = backReturn

        If sumBacked > 0 Then

            runnerDictionary(selectionId).avgBackPrice = Math.Round(backReturn / sumBacked, 2)

        Else

            runnerDictionary(selectionId).avgBackPrice = 0

        End If

        runnerDictionary(selectionId).sumLaid = sumLaid
        runnerDictionary(selectionId).layLiability = layLiability

        If sumLaid > 0 Then

            runnerDictionary(selectionId).avgLayPrice = Math.Round(layLiability / sumLaid, 2)

        Else

            runnerDictionary(selectionId).avgLayPrice = 0

        End If

        Dim hedgeStake As Double = 0

        If backReturn > layLiability Then 'hedge excess return

            hedgeStake = Math.Round(((backReturn - layLiability) / runnerDictionary(selectionId).layPrice), 2)

            If hedgeStake <> 0 Then

                runnerDictionary(selectionId).hedge = Math.Round(hedgeStake - (sumBacked - sumLaid), 2)

            Else

                runnerDictionary(selectionId).hedge = 0
            End If
        End If

        If layLiability > backReturn Then 'hedge excess layLiability

            hedgeStake = Math.Round(((layLiability - backReturn) / runnerDictionary(selectionId).backPrice), 2)

            If hedgeStake <> 0 Then
                runnerDictionary(selectionId).hedge = Math.Round(hedgeStake - (sumBacked - sumLaid), 2)

            Else

                runnerDictionary(selectionId).hedge = 0
            End If
        End If

        runnerDictionary(selectionId).hedgeStake = hedgeStake

    End Sub


    Protected Sub BuildKeyFiles() 'called by Start button 

        Dim market As String = ""
        ' Dim row As DataGridViewRow
        'Format(Now, "hh:mm")

        'Dim Now As New DateTime()
        'Dim NowFormat As String
        ' NowFormat = Now.GetDateTimeFormats() '.......declare now in same format as marketStartTime

        For Each row As DataGridViewRow In DataGridView1.Rows

            ' If Now = (row.Cells.Item("marketStartTime").Value) Then

            Using writer As StreamWriter = File.AppendText("C:\Betfair\" & "runnerKeys-" & Format(Date.Now, "yyyy-MM-dd") & ".csv")

                writer.WriteLine(row.Cells.Item("selectionId").Value & "," & "'" & row.Cells.Item("runnerName").Value)
                'writer.WriteLine(row.Cells.Item("selectionId").Value & row.Cells.Item("marketId").Value & "," & "'" & row.Cells.Item("runnerName").Value)

            End Using
            'End If

            If Not row.Cells.Item("marketId").Value = market Then
                'If Now = (row.Cells.Item("marketStartTime").Value) Then
                Using writer As StreamWriter = File.AppendText("C:\Betfair\" & "marketKeys-" & Format(Date.Now, "yyyy-MM-dd") & ".csv")

                    'writer.WriteLine(row.Cells.Item("marketId").Value & "," & row.Cells.Item("marketStartTime").Value & " " & row.Cells.Item("course").Value)
                    writer.WriteLine(row.Cells.Item("marketId").Value & "," & row.Cells.Item("marketStartTime").Value & " " & row.Cells.Item("Event").Value)
                    'writer.WriteLine(row.Cells.Item("marketId").Value & "," & row.Cells.Item("marketStartTime").Value & "," & row.Cells.Item("Event").Value & " " & "'" & row.Cells.Item("runnerName").Value)

                End Using

                market = row.Cells.Item("marketId").Value
                ' End If
            End If
        Next
    End Sub
    'Refresh button
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click 'Refresh button = takes a snapshot, loads prices in DGV and stores JSON response in C:\Betfair etc
        Accountbalance()
        CheckedListBox1.Items.Clear()
        ListMarketBook()

        'Dim Counter As Integer
        'Dim Workarea(250) As String
        'ProgressBar1.Minimum = LBound(Workarea)
        'ProgressBar1.Maximum = UBound(Workarea)
        'ProgressBar1.Visible = True

        ''Set the Progress's Value to Min.
        'ProgressBar1.Value = ProgressBar1.Minimum

        '' CheckedListBox1.Items.Clear()
        ''ListMarketBook()

        ''Loop through the array.
        'For Counter = LBound(Workarea) To UBound(Workarea)
        '    'Set initial values for each item in the array.
        '    Workarea(Counter) = "Initial value" & Counter
        '    ProgressBar1.Value = Counter
        'Next Counter
        'ProgressBar1.Visible = False
        'ProgressBar1.Value = ProgressBar1.Minimum
        ' ListMarketBook()
        'CheckMarkets()
        BuildBetList()
        CheckedListBox1.Sorted = True
    End Sub




    Private Sub BuildBetList()


        'Dim filter1 = " back  <'10' and back >'4.9' and runnerName = 'Over 4.5 Goals' and inPlay = 'DE'" 'Bund O45 lay
        Dim filter2 = " back > '2.9'  and back <'3.31' and runnerName = 'Over 3.5 Goals' and inPlay = 'GB'" 'EPL O45 Lay
        Dim filter3 = "back >'5.1' and back <'12' and runnerName='Over 3.5 Goals' and inPlay='PT'" 'Port O35 Lay
        Dim filter4 = "back >'4.9' and back <'10' and runnername='Over 4.5 Goals' and inPlay='ES' " 'ESP O45 Lay
        Dim filter5 = "back >'2.3' and back <'3.1' and runnername='Over 3.5 Goals' and inPlay='NL' " 'Holland O45 Lay
        Dim filter6 = "back >'3.9' and back <'4.5' and runnername='Over 3.5 Goals' and inPlay='FR' " 'France O45 Back
        Dim filter7 = " back >'9.9' and back <'12.9' and runnerName = '2 - 1' and inPlay = 'GB'and runnerStatus = 'Correct Score'" 'EPL CS 2-2 back
        Dim filter8 = " back > '10.9'  and back <'15.9' and runnerName = '0 - 1' and inPlay = 'DE'and runnerStatus = 'Correct Score'" 'Bund CS 2-0 back
        Dim filter9 = " back > '18'  and back <'50' and runnerName = '0 - 3' and inPlay = 'GB'and runnerStatus = 'Correct Score'" 'EPL CS 0-3 back
        Dim filter10 = " back > '20'  and back <'30' and runnerName = '3 - 0' and inPlay = 'GB'and runnerStatus = 'Correct Score'" 'EPL CS 1-0 back
        Dim filter11 = " back > '18'  and back <'25' and runnerName = '2 - 2' and inPlay = 'ES'and runnerStatus = 'Correct Score'" 'ESP CS 1-2 back
        Dim filter12 = " back > '50' and runnerName = '3 - 0' and inPlay = 'FR'and runnerStatus = 'Correct Score'" 'FR CS 0-1 back
        Dim filter13 = " back > '15.9' and back < '49.9' and runnerName = '0 - 0' and inPlay = 'NL'and runnerStatus = 'Correct Score'" 'Holland CS 1-1 back
        Dim filter14 = " back > '12.9' and back < '19.9' and runnerName = '1 - 3' and inPlay = 'PT'and runnerStatus = 'Correct Score'" 'Portugal CS 1-3 back
        Dim filter15 = " back > '3.9' and runnerName = '0 - 0' and inPlay = 'IT'and runnerStatus = 'Half Time Score'" 'Serie A HTCS 1-2 back
        Dim filter16 = " back > '3.9'  and back <'4.9' and runnerName = '1 - 0' and inPlay = 'DE'and runnerStatus = 'Half Time Score'" 'Bund HTCS 1-1 back
        Dim filter17 = " back > '3.9'  and back <'4.9' and runnerName = '0 - 0' and inPlay = 'DE'and runnerStatus = 'Half Time Score'" 'Bund HTCS 0-0 lay
        Dim filter18 = " back < '3.0'  and runnerName = 'Over 1.5 Goals' and inPlay = 'DE'and runnerStatus = 'First Half Goals 1.5'" 'Bund HTCS 2-1 back
        Dim filter19 = " back > '9.9'  and back < '11.9' and runnerName = 'Any Unquoted' and inPlay = 'GB'and runnerStatus = 'Half Time Score'" 'EPL HTCS 0-0 lay
        Dim filter20 = " back > '9.9'  and back < '13.9' and runnerName = '2 - 0' and inPlay = 'GB'and runnerStatus = 'Half Time Score'" 'EPL HTCS 1-0 lay
        Dim filter21 = " back < '10' and runnerName = 'Any Unquoted' and inPlay = 'DE'and runnerStatus = 'Half Time Score'" 'Bund HTCS AUQ lay
        Dim filter22 = " back < '3.0'  and runnerName = 'Over 1.5 Goals' and inPlay = 'FR'and runnerStatus = 'First Half Goals 1.5'" 'France HTCS 2-0 back
        Dim filter23 = " back > '6.9'  and back < '12' and runnerName = '2 - 0' and inPlay = 'ES'and runnerStatus = 'Half Time Score'" 'ESP HTCS 2-0 back
        Dim filter24 = " back > '6.9'  and back < '12' and runnerName = '2 - 0' and inPlay = 'ES'and runnerStatus = 'Half Time Score'" 'ESP HTCS 0-0 lay
        Dim filter25 = " back < '3.5'  and runnerName = 'Any Unquoted' and inPlay = 'ES'and runnerStatus = 'Half Time Score'" 'ESP HTCS AUQ lay 
        Dim filter26 = " back > '10.9'  and back < '12.9' and runnerName = '1 - 1' and inPlay = 'PT'and runnerStatus = 'Half Time Score'" 'PT HTCS 0-0 lay
        Dim filter27 = " back > '6.9'  and back < '15.9' and runnerName = '2 - 0' and inPlay = 'PT'and runnerStatus = 'Half Time Score'" 'PT HTCS 1-0 back
        Dim filter28 = " back < '12'  and runnerName = 'Any Unquoted' and inPlay = 'PT'and runnerStatus = 'Half Time Score'" 'PT HTCS AUQ lay
        'Dim FilteredRows1 As DataRow() = dataSet.Tables("Runners").Select(filter1)
        Dim FilteredRows2 As DataRow() = dataSet.Tables("Runners").Select(filter2)
        Dim FilteredRows3 As DataRow() = dataSet.Tables("Runners").Select(filter3)
        Dim FilteredRows4 As DataRow() = dataSet.Tables("Runners").Select(filter4)
        Dim FilteredRows5 As DataRow() = dataSet.Tables("Runners").Select(filter5)
        Dim FilteredRows6 As DataRow() = dataSet.Tables("Runners").Select(filter6)
        Dim FilteredRows7 As DataRow() = dataSet.Tables("Runners").Select(filter7)
        Dim FilteredRows8 As DataRow() = dataSet.Tables("Runners").Select(filter8)
        Dim FilteredRows9 As DataRow() = dataSet.Tables("Runners").Select(filter9)
        Dim FilteredRows10 As DataRow() = dataSet.Tables("Runners").Select(filter10)
        Dim FilteredRows11 As DataRow() = dataSet.Tables("Runners").Select(filter11)
        Dim FilteredRows12 As DataRow() = dataSet.Tables("Runners").Select(filter12)
        Dim FilteredRows13 As DataRow() = dataSet.Tables("Runners").Select(filter13)
        Dim FilteredRows14 As DataRow() = dataSet.Tables("Runners").Select(filter14)
        Dim FilteredRows15 As DataRow() = dataSet.Tables("Runners").Select(filter15)
        Dim FilteredRows16 As DataRow() = dataSet.Tables("Runners").Select(filter16)
        Dim FilteredRows17 As DataRow() = dataSet.Tables("Runners").Select(filter17)
        Dim FilteredRows18 As DataRow() = dataSet.Tables("Runners").Select(filter18)
        Dim FilteredRows19 As DataRow() = dataSet.Tables("Runners").Select(filter19)
        Dim FilteredRows20 As DataRow() = dataSet.Tables("Runners").Select(filter20)
        Dim FilteredRows21 As DataRow() = dataSet.Tables("Runners").Select(filter21)
        Dim FilteredRows22 As DataRow() = dataSet.Tables("Runners").Select(filter22)
        Dim FilteredRows23 As DataRow() = dataSet.Tables("Runners").Select(filter23)
        Dim FilteredRows24 As DataRow() = dataSet.Tables("Runners").Select(filter24)
        Dim FilteredRows25 As DataRow() = dataSet.Tables("Runners").Select(filter25)
        Dim FilteredRows26 As DataRow() = dataSet.Tables("Runners").Select(filter26)
        Dim FilteredRows27 As DataRow() = dataSet.Tables("Runners").Select(filter27)
        Dim FilteredRows28 As DataRow() = dataSet.Tables("Runners").Select(filter28)
        'For Each row As DataRow In FilteredRows1
        '    ListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "O4.5 Lay 4.9 - 10"))
        'Next
        For Each row As DataRow In FilteredRows2
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "O4.5 Lay <6.9"))
        Next
        For Each row As DataRow In FilteredRows3
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "O3.5 Lay 5.1 - 12"))
        Next
        For Each row As DataRow In FilteredRows4
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "O4.5 Lay 4.9 - 12"))
        Next
        For Each row As DataRow In FilteredRows5
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "O4.5 Lay < 6.75"))
        Next
        For Each row As DataRow In FilteredRows6
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "O4.5 Back > 8"))
        Next

        For Each row As DataRow In FilteredRows7
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "CS 2-2 Back > 11.4"))
        Next

        For Each row As DataRow In FilteredRows8
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "CS 2-0 Back > 6.5"))
        Next
        For Each row As DataRow In FilteredRows9
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "CS 0-3 Back 18 - 50"))
        Next
        For Each row As DataRow In FilteredRows10
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "CS 1-0 Back > 6.5"))
        Next
        For Each row As DataRow In FilteredRows11
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "CS 1-2 Back > 8.0"))
        Next
        For Each row As DataRow In FilteredRows12
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "CS 0-1 Back > 6.0"))
        Next
        For Each row As DataRow In FilteredRows13
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "CS 1-1 Back > 8.0"))
        Next
        For Each row As DataRow In FilteredRows14
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "CS 1-3 Back 13 - 20"))
        Next
        For Each row As DataRow In FilteredRows15
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS 2-1 Back > 19"))
        Next
        For Each row As DataRow In FilteredRows16
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS 1-1 Back > 7.5"))
        Next
        For Each row As DataRow In FilteredRows17
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS 0-0 Lay 3.9 - 4.9"))
        Next
        For Each row As DataRow In FilteredRows18
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS 2-1 Back 14 - 40"))
        Next
        For Each row As DataRow In FilteredRows19
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS 0-0 Lay < 4.5"))
        Next
        For Each row As DataRow In FilteredRows20
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS 1-0 Lay < 5"))
        Next
        For Each row As DataRow In FilteredRows21
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS AUQ Lay < 10"))
        Next
        For Each row As DataRow In FilteredRows22
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS 2-0 Back > 4.5"))
        Next
        For Each row As DataRow In FilteredRows23
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS 2-0 Back 6.9 - 12"))
        Next
        For Each row As DataRow In FilteredRows24
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS 0-0 Lay"))
        Next
        For Each row As DataRow In FilteredRows25
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS AUQ Lay < 12"))
        Next
        For Each row As DataRow In FilteredRows26
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS 0-0 Lay < 5"))
        Next
        For Each row As DataRow In FilteredRows27
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS 1-0 Back"))
        Next
        For Each row As DataRow In FilteredRows28
            CheckedListBox1.Items.Add(String.Format("{0},{1},{2},", row("marketStartTime"), row("Event"), "HTCS AUQ Lay < 12"))
        Next

    End Sub
    'sort listbox button
    Private Sub AscendingButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
 Handles AscendingButton.Click
        CheckedListBox1.Sorted = True
    End Sub
    'clear listbox
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        CheckedListBox1.Items.Clear()
    End Sub
    'export listbox
    Dim oItem As Object
    Dim OffS As Integer
    Dim MsExcel As Excel.Application
    Dim Wb As Excel.Workbook
    Private Sub exportButton_Click(sender As Object, e As EventArgs) Handles exportButton.Click
        MsExcel = CreateObject("Excel.Application")

        Wb = MsExcel.Workbooks.Open("C:\Users\simon_000\Desktop\BuildBetList.xlsx")
        OffS = 0
        For Each oItem In CheckedListBox1.Items
            Wb.Sheets(1).Range("A1").Offset(OffS, 0).Value = Now & "," & oItem
            OffS = OffS + 1
        Next oItem

        Wb.SaveAs()
        'DoEvents
        Wb.Close()
        'MsExcel.Visible = True
    End Sub

    Private Sub buildBetListButton_Click(sender As Object, e As EventArgs) Handles buildBetListButton.Click
        BuildBetList()
    End Sub
    Private Sub Accountbalance()
        Dim balance() As AccountBalanceResponse = DeserializeAccountBalanceResponse("[{""jsonrpc"":""2.0"",""method"":""AccountAPING/v1.0/getAccountFunds"",""params"":{},""id"":1}]")
        TextBox2.Text = ("Balance" & "" & " " & "£" & balance(0).result.availableToBetBalance)
        TextBox3.Text = ("Exposure" & "" & " " & "£" & balance(0).result.exposure)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        KeepAlive()
    End Sub


End Class


