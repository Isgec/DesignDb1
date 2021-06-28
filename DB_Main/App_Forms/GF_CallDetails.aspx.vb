Partial Class GF_CallDetails
  Inherits System.Web.UI.Page

    Private Sub ShowCallData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.Calldetail) = SIS.DB.Calldetail.GetData(x, y)

    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
            .CssClass = "table-warning table-bordered"
            '  .CssClass = "table-danger table-bordered thead-primary table-hover"
        End With
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing

    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "CASE ID"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "LOGGED BY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "APPLICATION "
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "DESCRIPTION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "LOGGED ON"
    tr.Cells.Add(td)



    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "PRIORITY"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "STATUS"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "ATTENDED BY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "ATTENDED ON"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "SOLUTION PROVIDED"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "CLOSED ON"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
      .Font.Name = "corbel"
    End With
    td.Text = "SIGNEDOFF ON"
    tr.Cells.Add(td)




    'td = New TableCell
    'With td
    '  .Font.Bold = True
    '  .Font.Size = FontUnit.Point(14)
    'End With
    'td.Text = "Option"
    'tr.Cells.Add(td)

    tbl.Rows.Add(tr)

        Dim I As Integer = 0

        '================
        For Each tmp As SIS.DB.Calldetail In Data

      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.CallID

      If tmp.CallID < 29 Then

        With td

          .Font.Name = "corbel"
          .Font.Size = 9

        End With
        tr.Font.Strikeout = True
      End If
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.UserID & "-" & tmp.Caseloggedby
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.CaseApplication
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.CallDescription
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      tr.Cells.Add(td)



      td = New TableCell

      td.Text = tmp.LoggedOn
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      tr.Cells.Add(td)



      td = New TableCell
      td.Text = tmp.CasePriority
      If td.Text = "Critical" Then
        With td
          .Font.Bold = True
          .Font.Name = "corbel"
          .Font.Size = 10
        End With

        'tr.Font.Bold = True
      End If
      tr.Cells.Add(td)

      td = New TableCell

      td.Text = tmp.CaseStatus
      If td.Text = "Closed" Then
        With td

          .Font.Name = "corbel"
          .Font.Size = 9
        End With
        tr.BackColor = Drawing.Color.LightGreen
      End If
      If td.Text = "Assigned" Then
        With td

          .Font.Name = "corbel"
          .Font.Size = 9
        End With
        tr.BackColor = Drawing.Color.LightYellow
      End If
      If td.Text = "Submitted" Then
        With td

          .Font.Name = "corbel"
          .Font.Size = 9
        End With
        tr.BackColor = Drawing.Color.Yellow
      End If

      If td.Text = "Resolved" Then
        With td

          .Font.Name = "corbel"
          .Font.Size = 9
        End With
        tr.BackColor = Drawing.Color.LawnGreen
      End If

      If td.Text = "FREE" Then
        With td

          .Font.Name = "corbel"
          .Font.Size = 9
        End With
        tr.BackColor = Drawing.Color.Red
      End If


      If td.Text = "Under Observation" Then
        With td

          .Font.Name = "corbel"
          .Font.Size = 9
        End With
        tr.BackColor = Drawing.Color.LightPink
      End If

      If td.Text = "SignedOff" Then
        With td

          .Font.Name = "corbel"
          .Font.Size = 9
        End With
        tr.BackColor = Drawing.Color.GreenYellow
      End If

      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.CaseAttendedBy
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.AttendedOn
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.SolutionProvided
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      tr.Cells.Add(td)




      td = New TableCell
      td.Text = tmp.ClosedOn
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.SignedOffOn
      With td

        .Font.Name = "corbel"
        .Font.Size = 9
      End With
      tr.Cells.Add(td)
      'td = New TableCell
      'Dim cmd As New Button
      'cmd.Text = "Click Me"
      'td.Controls.Add(cmd)
      'tr.Cells.Add(td)


      tbl.Rows.Add(tr)


    Next
        '================
        If Not isexcel Then

            pnlDetails.Controls.Add(tbl)
        Else
            ExportToExcel(tbl)
        End If




    End Sub
    Protected Sub ExportToExcel(tbl As Table)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=Master_Technical_Support_Case_Details.xls")

        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New IO.StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim I As Integer = 0
            For Each row As TableRow In tbl.Rows
                I += 1


                'row.BackColor = Drawing.Color.White
                For Each cell As TableCell In row.Cells
                    If I = 1 Then
                        row.BorderWidth = 3
                        ' cell.BorderWidth = 2
                    End If


                    If I Mod 2 = 0 Then
                        'cell.BackColor = System.Drawing.Color.SkyBlue
                    Else
                        'cell.BackColor = System.Drawing.Color.LightGreen
                    End If
                    'cell.CssClass = "textmode"
                Next
            Next
            tbl.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()
        End Using
    End Sub


    Private Sub GF_UserDBDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Det As String = Request.QueryString("detail")
        Dim empID As String = Request.QueryString("empid")
        'If (Det = "cpd") Then
        '    PSheading.Text = "PENDING DWGS/DOCS IN RELEASE WORKFLOW :-DRAFTING"
        '    ShowCallData(Det, empID)
        'End If
        PSheading.Text = "ENGINEERING TECHNICAL SUPPORT CASES DETAILS - PENDING"
        ShowCallData(Det, empID)
        were.Visible = True
    End Sub

    Private Sub btnexportexcel_Click(sender As Object, e As EventArgs) Handles btnexportexcel.Click
        Dim Det As String = Request.QueryString("detail")
        Dim empID As String = Request.QueryString("empid")
        isexcel = True
        ShowCallData(Det, empID)
    End Sub

    Dim isexcel As Boolean = False


End Class
