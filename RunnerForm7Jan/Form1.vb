Imports System.IO

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
        LoginForm.Show()
    End Sub


    Public Sub Initialise()
        BuildDataGridView() 'build dataGridView
        BuildDataTable() 'build dataTable
        ListMarketCatalogue() 'get events
        BuildListMarketBookRequests() 'get prices
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
        dataTable.Columns.Add("countryCode", GetType(System.String), Nothing) 'result.event.countryCode
        'dataTable.Columns.Add("competitionName", GetType(System.String), Nothing) 'result.competition.name
        'dataTable.Columns.Add("marketName", GetType(System.String), Nothing) 'result.marketName

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

            '        .ColumnHeadersVisible = True
            '        .DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '        .DefaultCellStyle.SelectionBackColor = Color.White
            '        .DefaultCellStyle.SelectionForeColor = Color.Black
            '        .RowHeadersVisible = False
            '        .RowTemplate.Height = 19
            '        .ShowCellToolTips = False

            '        Dim marketStartTimeColumn As New DataGridViewTextBoxColumn
            '        With marketStartTimeColumn
            '            .SortMode = DataGridViewColumnSortMode.NotSortable
            '            ' .Name = "marketStartTime"
            '            .Name = "Time"
            '            .DataPropertyName = "marketStartTime" 'gets updated data from DataView
            '            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '            .Width = 40
            '        End With
            '        .Columns.Add(marketStartTimeColumn)

            '        Dim marketIdColumn As New DataGridViewTextBoxColumn
            '        With marketIdColumn
            '            .SortMode = DataGridViewColumnSortMode.NotSortable
            '            .Name = "marketId"
            '            .DataPropertyName = "marketId"
            '            .Width = 80
            '        End With
            '        .Columns.Add(marketIdColumn)

            '        Dim marketStatusColumn As New DataGridViewTextBoxColumn
            '        With marketStatusColumn
            '            .SortMode = DataGridViewColumnSortMode.NotSortable
            '            .Name = "marketStatus"
            '            .DataPropertyName = "marketStatus"
            '            .Width = 80
            '        End With
            '        .Columns.Add(marketStatusColumn)

            '        Dim inPlayColumn As New DataGridViewTextBoxColumn
            '        With inPlayColumn
            '            .SortMode = DataGridViewColumnSortMode.NotSortable
            '            .Name = "Country/inPlay"
            '            '.DataPropertyName = "inPlay"
            '            ' .DataPropertyName = "countryCode"
            '            .DataPropertyName = "marketId"
            '            .Width = 50
            '        End With
            '        .Columns.Add(inPlayColumn)

            '        Dim competitionColumn As New DataGridViewTextBoxColumn
            '        With competitionColumn
            '            .SortMode = DataGridViewColumnSortMode.NotSortable
            '            .Name = "Competition"
            '            .DataPropertyName = "competitionName"
            '            '.DataPropertyName = "Country"
            '            .Width = 100
            '        End With
            '        .Columns.Add(competitionColumn)

            '        'Dim courseColumn As New DataGridViewTextBoxColumn
            '        'With courseColumn
            '        '    .SortMode = DataGridViewColumnSortMode.NotSortable
            '        '    .Name = "course"
            '        '    .DataPropertyName = "course"
            '        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '        '    .Width = 200
            '        'End With
            '        '.Columns.Add(courseColumn)
            '        Dim EventColumn As New DataGridViewTextBoxColumn
            '        With EventColumn
            '            .SortMode = DataGridViewColumnSortMode.NotSortable
            '            .Name = "Event"
            '            .DataPropertyName = "Event"
            '            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '            .Width = 150
            '        End With
            '        .Columns.Add(EventColumn)

            '        'Dim marketNameColumn As New DataGridViewTextBoxColumn
            '        'With marketNameColumn
            '        '    .SortMode = DataGridViewColumnSortMode.NotSortable
            '        '    .Name = "marketName"
            '        '    .DataPropertyName = "marketName"
            '        '    .DefaultCellStyle.BackColor = Color.AntiqueWhite
            '        '    .DefaultCellStyle.SelectionBackColor = Color.Pink
            '        '    .Width = 200

            '        'End With
            '        '.Columns.Add(marketNameColumn)

            '        Dim selectionIdColumn As New DataGridViewTextBoxColumn
            '        With selectionIdColumn
            '            .SortMode = DataGridViewColumnSortMode.NotSortable
            '            .Name = "selectionId"
            '            .DataPropertyName = "selectionId"
            '            .Width = 60
            '        End With
            '        .Columns.Add(selectionIdColumn)

            '        Dim runnerNameColumn As New DataGridViewTextBoxColumn
            '        With runnerNameColumn
            '            .SortMode = DataGridViewColumnSortMode.NotSortable
            '            .Name = "runnerName"
            '            .DataPropertyName = "runnerName"
            '            .Width = 110
            '            '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '        End With
            '        .Columns.Add(runnerNameColumn)

            '        Dim marketNameColumn As New DataGridViewTextBoxColumn
            '        With marketNameColumn
            '            .SortMode = DataGridViewColumnSortMode.NotSortable
            '            .Name = "marketName"
            '            .DataPropertyName = "marketName"
            '            .Width = 120
            '        End With
            '        .Columns.Add(marketNameColumn)

            '        'Dim runnerStatusColumn As New DataGridViewTextBoxColumn 'runnerstatus function disabled
            '        'With runnerStatusColumn
            '        '    .SortMode = DataGridViewColumnSortMode.NotSortable
            '        '    .Name = "runnerStatus"
            '        '    '.Name = "marketName"
            '        '    .DataPropertyName = "runnerStatus"
            '        '    .Width = 150
            '        'End With
            '        '.Columns.Add(runnerStatusColumn)

            '        Dim backColumn As New DataGridViewTextBoxColumn
            '        With backColumn
            '            .SortMode = DataGridViewColumnSortMode.NotSortable
            '            .Name = "back"
            '            .DataPropertyName = "back"
            '            .DefaultCellStyle.BackColor = Color.LightSkyBlue
            '            .DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue
            '            .Width = 40
            '        End With
            '        .Columns.Add(backColumn)

            '        Dim layColumn As New DataGridViewTextBoxColumn
            '        With layColumn
            '            .SortMode = DataGridViewColumnSortMode.NotSortable
            '            .Name = "lay"
            '            .DataPropertyName = "lay"
            '            .DefaultCellStyle.BackColor = Color.Pink
            '            .DefaultCellStyle.SelectionBackColor = Color.Pink
            '            .Width = 40
            '        End With
            '        .Columns.Add(layColumn)
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
        competitionIds.Add("31") 'EPL
        competitionIds.Add("117") 'ESP
        competitionIds.Add("2005") 'Europa League
        competitionIds.Add("9404054") 'Dutch Eredivisie
        competitionIds.Add("59") 'Bundesliga 1
        competitionIds.Add("81") 'Serie A
        competitionIds.Add("7129730") 'The Championship
        competitionIds.Add("99") 'Primeira Liga
        competitionIds.Add("55") 'French Ligue One
        competitionIds.Add("89979") 'Belgian Jupiler League
        ''competitionIds.Add("5984496") 'IT Pro Liga
        ''competitionIds.Add("7129730") 'Champ
        ''competitionIds.Add("228") 'Champions League
        ''competitionIds.Add("61") 'Bundesliga 2
        ''competitionIds.Add("35") 'League 1
        ''competitionIds.Add("37") 'League 2
        'competitionIds.Add(5614746) '2018 FIFA World Cup
        ''competitionIds.Add(801976) 'Egyptian Premier
        competitionIds.Add("10765348") 'International Friendly
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
        marketTypeCodes.Add("MATCH_ODDS")
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

            If CheckBox1.CheckState = 1 Then

                Using writer As StreamWriter = File.AppendText("C:\Betfair\" & filename & ".json")
                    writer.WriteLine(Now & "*" & jsonResponse)
                End Using
            End If

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
        'CheckMarkets()
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
        limitOrder.persistenceType = "LAPSE"

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

        If e.ColumnIndex = 8 Then
            'If e.ColumnIndex = 5 Then
            Dim runnerForm As New RunnerForm(DataGridView1.Item("runnerName", e.RowIndex).Value & " - " & DataGridView1.Item("marketStartTime", e.RowIndex).Value & " " & DataGridView1.Item("Event", e.RowIndex).Value, DataGridView1.Item("marketId", e.RowIndex).Value, DataGridView1.Item("selectionId", e.RowIndex).Value)
            'runnerFormDictionary.Add(DataGridView1.Item("selectionId", e.RowIndex).Value, runnerForm)
        End If


        If e.ColumnIndex = 9 Then
            'If e.ColumnIndex = 5 Then
            Dim runnerForm2 As New RunnerForm2(DataGridView1.Item("runnerName", e.RowIndex).Value & " - " & DataGridView1.Item("marketStartTime", e.RowIndex).Value & " " & DataGridView1.Item("Event", e.RowIndex).Value, DataGridView1.Item("marketId", e.RowIndex).Value, DataGridView1.Item("selectionId", e.RowIndex).Value)

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
            'runnerFormDictionary(pair.Key).MonitorBets()
        Next


    End Sub

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

    'Private Sub getData()
    '    Format(Now, "hh:mm")
    '    ' Dim NowFormat As String
    '    'NowFormat = Now.GetDateTimeFormats() '.......declare now in same format as marketStartTime

    '    For Each row As DataGridViewRow In DataGridView1.Rows

    '        If Now = (row.Cells.Item("marketStartTime").Value) Then
    '            ListMarketBook()
    '            CheckMarkets()
    '        End If
    '    Next

    'End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click 'Refresh button = takes a snapshot, loads prices in DGV and stores JSON response in C:\Betfair etc
        ListMarketBook()
        CheckMarkets()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Start button starts and stops Timer1 and buildsKeyfiles if Save Data button checked
        'CheckTriggers()
        If Button1.Text = "Start" Then

            If CheckBox1.CheckState = 1 Then 'check whether "Save Data" is selected
                BuildKeyFiles()
                'BuildcouponFiles()
            End If

            Button1.Text = "stop"
            Timer1.Enabled = True  'loads prices (calls "listMarketBook") streams the JSON data and updates DGV1 at 5 sec intervals
            CheckBox1.Enabled = False 'disables "Save Data" to stop it being changed whilst JSON is being recorded

        Else

            Button1.Text = "Start"
            Timer1.Enabled = False 'stops streaming the data
            CheckBox1.Enabled = True 'enables Start button again


        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'CheckTriggers()
        'For Each row As DataGridViewRow In DataGridView1.Rows
        '    If row.Cells.Item("marketId").Value = "1.130484378" And row.Cells.Item("selectionId").Value = "1222344" Then
        '        'Print("Trigger")
        '        TextBox1.Text = "ZA back 1.24"
        '    Else
        '        TextBox1.Text = "no trigger"
        '    End If
        'Next
        'dataView.Filter = "inPlay = ES" & TextBox1.Text & "ES"
        'Dim filter = "inPlay = 'ES'" ' and back = '<3'"
        Dim filter = " back  <'10' and back >'8.3' and selectionId ='3' and runnerStatus = 'Half Time Score' and inPlay = 'ES'"
        'Dim FilteredRows As DataRow() = "inPlay = 'ES' and 'back=<3"
        ' Filter the rows using Select() method of DataTable
        Dim FilteredRows As DataRow() = dataSet.Tables("Runners").Select(filter)
        DataGridView1.DataSource = FilteredRows.CopyToDataTable()
        'For Each row As DataRow In FilteredRows
        '    ListBox1.Items.Add(String.Format("{0},   {1},{2},{3},{4},", row("marketStartTime"), row("Event"), row("runnerStatus"), row("runnerName"), "back 7.8 to 9.8"))
        'Next

    End Sub
    'Private Sub CheckTriggers()

    '    For Each row As DataGridViewRow In DataGridView1.Rows
    '        If "inPlay" = "ZA" And "runnerStatus" = "Correct Score" Then
    '            'Print("Trigger")
    '            TextBox1.Text = "ZA back Correct Score"
    '        End If
    '    Next
    'End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    'Protected Sub BuildcouponFiles()

    '    Dim market As String = ""

    '    For Each row As DataGridViewRow In DataGridView1.Rows

    '        Using writer As StreamWriter = File.AppendText("C:\Betfair\" & "coupon-" & Format(Date.Now, "yyyy-MM-dd") & ".csv")

    '            writer.WriteLine(row.Cells.Item("country").Value & "," & row.Cells.Item("Event").Value & row.Cells.Item("marketName").Value & "'" & row.Cells.Item("runnerName").Value)
    '        End Using

    '        'If Not row.Cells.Item("marketId").Value = market Then

    '        '    Using writer As StreamWriter = File.AppendText("C:\Betfair\" & "marketKeys-" & Format(Date.Now, "yyyy-MM-dd") & ".csv")

    '        '        'writer.WriteLine(row.Cells.Item("marketId").Value & "," & row.Cells.Item("marketStartTime").Value & " " & row.Cells.Item("course").Value)
    '        '        writer.WriteLine(row.Cells.Item("marketId").Value & "," & row.Cells.Item("marketStartTime").Value & "," & row.Cells.Item("Event").Value)
    '        '    End Using

    '        '    market = row.Cells.Item("marketId").Value

    '        'End If
    '    Next
    'End Sub


    'Public Sub buildbetList()

    '    Dim betList As New List(Of String)
    '    Dim Country As New List(Of String)
    '    'Dim marketCountries As New List(Of String)
    '    Dim runnerName As New List(Of String)
    '    'Dim marketTypeCodes As New List(Of String)
    '    Dim backPrice As Double

    '    For Each row As DataGridViewRow In DataGridView1.Rows

    '        If = row.Cells.Item("country").Value = "GB" And
    '              row.Cells.Item("runnerName").Value ="Over 4.5 Goals" And
    '            row.Cells.Item("back").Value ="6.8" Then
    '            TextBox1.Text = "EPL O4.5 Lay Max 6.9"
    'Dim runner As New ChartDetail
    '                    runner.runnerName = row.Cells.Item("runnerName").Value
    '                    runner.selectionId = row.Cells.Item("selectionId").Value
    '                    runner.ChartBot = False
    '                    runnerList.Add(runner)
    'End If
    '    Next
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    buildbetList()
    'End Sub
End Class


