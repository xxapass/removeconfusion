Imports System.Net
Imports System.Text
    Imports System.IO
    Imports Newtonsoft.Json

    Module AccountsAPI

        Public ssoid As String

        Private Function SendAccReq(ByVal jsonString As String)

            Dim request As WebRequest = WebRequest.Create("https://api.betfair.com/exchange/account/json-rpc/v1/")

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(jsonString)
        'Try
        request.Method = "POST"
            request.ContentType = "application/json"
            request.ContentLength = byteArray.Length
            request.Headers.Add("X-Application: DVxEQHLHgSQC27rz")
            request.Headers.Add("X-Authentication: " & ssoid)

            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)

            Dim response As WebResponse = request.GetResponse()
            dataStream = response.GetResponseStream()

            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()


            'Catch ex As WebException 'Exception
            '    'Form1.Print("SendSportsReq Error: " & ex.Message)
            'End Try

            Return responseFromServer

    End Function

        'Classes for getAccountBalance Response 
        Public Class AccountBalanceResponse
            Public jsonrpc As String
            Public result As AccountBalanceResult
        End Class

        Public Class AccountBalanceResult
            Public availableToBetBalance As Double
            Public exposure As Double
            Public retainedCommission As Double
            Public exposureLimit As Double
            Public discountRate As Double
            Public pointsBalance As Integer
        End Class

        Function DeserializeAccountBalanceResponse(ByVal response As String)
            Return JsonConvert.DeserializeObject(Of AccountBalanceResponse())(SendAccReq(response))
        End Function

    Public Sub KeepAlive()

        Dim request As HttpWebRequest = WebRequest.Create("https://identitysso.betfair.com/api/keepAlive")
        Dim response As HttpWebResponse = Nothing
        Dim strResponse As String = ""

        Try
            request.Accept = "application/json"
            request.Method = "POST"
            request.Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1,utf-8")
            request.Headers.Add("X-Authentication: " & ssoid)
            request.Headers.Add("X-Application: DVxEQHLHgSQC27rz")

            Using wr As System.Net.HttpWebResponse = request.GetResponse()
                Using sr As New _
                      System.IO.StreamReader(wr.GetResponseStream())
                    strResponse = sr.ReadToEnd().ToString
                    sr.Close()
                End Using
                wr.Close()
            End Using

        Catch ex As Exception
            'Form1.TextBox1.Text = ("KeepAlive Error " & ex.Message)
        End Try

    End Sub
End Module
