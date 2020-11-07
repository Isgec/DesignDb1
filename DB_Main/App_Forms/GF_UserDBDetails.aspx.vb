Partial Class GF_UserDBDetails
  Inherits System.Web.UI.Page

  Private Sub ShowPData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.engDoc) = SIS.DB.engDoc.GetData(x, y)

    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-light table-bordered"
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
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "DOCUMENT NUMBER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "REV"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "TITTLE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "STATUS   "
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "WORKFLOW"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)

    End With
    td.Text = "DESIGNER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "REVIEWER"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)

    End With
    td.Text = "APPROVER"
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
    For Each tmp As SIS.DB.engDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.DocID
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Rev
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Tittle
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.DStatus
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.DWorkFlow
      tr.Cells.Add(td)


      td = New TableCell

      td.Text = tmp.DrawnBy
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.Reviewer
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.Approver
      tr.Cells.Add(td)

      'td = New TableCell
      'Dim cmd As New Button
      'cmd.Text = "Click Me"
      'td.Controls.Add(cmd)
      'tr.Cells.Add(td)


      tbl.Rows.Add(tr)


    Next
    '================
    pnlDetails.Controls.Add(tbl)

  End Sub


  Private Sub ShowPREData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.engDoc) = SIS.DB.engDoc.GetData(x, y)

    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-light table-bordered"
      '  .CssClass = "table-danger table-bordered thead-primary"
    End With
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing

    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIPT"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "REV"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIVED ON"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PENDING (DAYS)"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PROJECT TYPE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PROJECT ID"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PROJECT NAME"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "ITEM DESCRIPTION"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIPT STATUS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "MECH."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "STR."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PIP."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PRC."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "C&I"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "ELE."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "QLTY."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "OWNER DEPT."
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
    Dim j As Integer = 0

    '================
    For Each tmp As SIS.DB.engDoc In Data




      Dim utmp As List(Of SIS.DB.UserRoleIDMS) = SIS.DB.UserRoleIDMS.GetUserRoleIDMS(y)
      For Each uptm As SIS.DB.UserRoleIDMS In utmp






        I += 1

        tr = New TableRow

        td = New TableCell
        td.Text = I
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.ReceiptID
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Rrev
        tr.Cells.Add(td)


        td = New TableCell
        td.Text = tmp.SentDate
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Rageindays
        With td
          .Font.Bold = True


        End With
        If tmp.Rageindays >= 30 Then
          td.ForeColor = Drawing.Color.Red

        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.PType
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.RProject
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Project_Name
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.ItemDescription
        tr.Cells.Add(td)


        td = New TableCell
        td.Text = tmp.RStatus
        tr.Cells.Add(td)



        td = New TableCell
        td.Text = tmp.Mechanical

        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True


          End With


        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Structure_

        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Piping
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With

        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Process
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If

        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.CandI
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Electrical
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Quality

        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)






        td = New TableCell
        td.Text = tmp.Owner_Dept
        If tmp.Owner_Dept.ToUpper = uptm.EDepartment.ToUpper Then
          td.ForeColor = Drawing.Color.DarkGreen
          tr.BackColor = Drawing.Color.Yellow
          With td
            .Font.Bold = True
          End With
        End If

        tr.Cells.Add(td)
      Next

      'td = New TableCell
      'Dim cmd As New Button
      'cmd.Text = "Click Me"
      'td.Controls.Add(cmd)
      'tr.Cells.Add(td)


      tbl.Rows.Add(tr)


    Next

    '================
    pnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowPOSTData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.engDoc) = SIS.DB.engDoc.GetData(x, y)

    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-light table-bordered"
      '  .CssClass = "table-danger table-bordered thead-primary"
    End With
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing

    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIPT"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "REV"
    tr.Cells.Add(td)



    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIVED ON"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PENDING (DAYS)"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PROJECT TYPE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PROJECT ID"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PROJECT NAME"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "ITEM DESCRIPTION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PO NUMBER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PO STATUS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PR STATUS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIPT STATUS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "MECH."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "STR."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)

    End With
    td.Text = "PIP."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PRC."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "C&I"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "ELE."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "QLTY."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "OWNER DEPT."
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
    Dim j As Integer = 0

    '================
    For Each tmp As SIS.DB.engDoc In Data




      Dim utmp As List(Of SIS.DB.UserRoleIDMS) = SIS.DB.UserRoleIDMS.GetUserRoleIDMS(y)
      For Each uptm As SIS.DB.UserRoleIDMS In utmp






        I += 1

        tr = New TableRow

        td = New TableCell
        td.Text = I
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.ReceiptID
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Rrev
        tr.Cells.Add(td)


        td = New TableCell
        td.Text = tmp.SentDate
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Rageindays
        With td
          .Font.Bold = True


        End With
        If tmp.Rageindays >= 30 Then
          td.ForeColor = Drawing.Color.Red

        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.PType
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.RProject
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Project_Name
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.ItemDescription
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.PO_Number
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.PO_Status
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.PR_Status
        tr.Cells.Add(td)


        td = New TableCell
        td.Text = tmp.RStatus
        td.Font.Bold = True
        tr.Cells.Add(td)



        td = New TableCell
        td.Text = tmp.Mechanical

        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True


          End With


        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Structure_

        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Piping
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With

        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Process
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If

        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.CandI
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Electrical
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Quality

        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)






        td = New TableCell
        td.Text = tmp.Owner_Dept
        If tmp.Owner_Dept.ToUpper = uptm.EDepartment.ToUpper Then
          td.ForeColor = Drawing.Color.DarkGreen
          tr.BackColor = Drawing.Color.Yellow
          With td
            .Font.Bold = True
          End With
        End If

        tr.Cells.Add(td)
      Next

      'td = New TableCell
      'Dim cmd As New Button
      'cmd.Text = "Click Me"
      'td.Controls.Add(cmd)
      'tr.Cells.Add(td)


      tbl.Rows.Add(tr)


    Next

    '================
    pnlDetails.Controls.Add(tbl)

  End Sub


  Private Sub ShowTData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.engDoc) = SIS.DB.engDoc.GetData(x, y)

    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-light table-bordered"
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
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "TRANSMITTAL ID"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "TRANSMITTAL TYPE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "PROJECT ID"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "TRANSMITTAL STATUS"
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
    For Each tmp As SIS.DB.engDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.TID
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.TType
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.TProject
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.TStatus
      tr.Cells.Add(td)



      'td = New TableCell
      'Dim cmd As New Button
      'cmd.Text = "Click Me"
      'td.Controls.Add(cmd) 
      'tr.Cells.Add(td)


      tbl.Rows.Add(tr)


    Next
    '================
    pnlDetails.Controls.Add(tbl)

  End Sub


  Private Sub ShowDData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.engDoc) = SIS.DB.engDoc.GetData(x, y)

    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-light table-bordered"
      '  .CssClass = "table-danger table-bordered thead-primary table-hover"
    End With
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing



    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO"
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "DCR NUMBER"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "DESCRIPTION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "PROJECT ID"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "ELEMENT"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "CREATED BY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "APPROVER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "STATUS"
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
    For Each tmp As SIS.DB.engDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.DCRNumber
      tr.Cells.Add(td)




      td = New TableCell
      td.Text = tmp.DDescription
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Dproject
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.DElement
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.DCreatedBy
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.DApprover
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.DCRStatus
      tr.Cells.Add(td)

      'td = New TableCell
      'Dim cmd As New Button
      'cmd.Text = "Click Me"
      'td.Controls.Add(cmd) 
      'tr.Cells.Add(td)


      tbl.Rows.Add(tr)


    Next
    '================
    pnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowSData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.engDoc) = SIS.DB.engDoc.GetData(x, y)

    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-light table-bordered"
      '  .CssClass = "table-danger table-bordered thead-primary table-hover"
    End With
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing



    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO"
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "PROJECT"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "SAR NUMBER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "ELEMENT"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "DRAWING"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "STATUS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "PREPARED BY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "REVIEWER"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "APPROVER"
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
    For Each tmp As SIS.DB.engDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)



      td = New TableCell
      td.Text = tmp.SAR_Project
      tr.Cells.Add(td)




      td = New TableCell
      td.Text = tmp.SAR_Number
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.SAR_Element
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.SAR_Drawing
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.SAR_Status
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.SAR_PreparedBy
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.SAR_Reviewer
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.SAR_Approver
      tr.Cells.Add(td)

      'td = New TableCell
      'Dim cmd As New Button
      'cmd.Text = "Click Me"
      'td.Controls.Add(cmd) 
      'tr.Cells.Add(td)


      tbl.Rows.Add(tr)


    Next
    '================
    pnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowMData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.engDoc) = SIS.DB.engDoc.GetData(x, y)

    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-danger"
      '  .CssClass = "table-danger table-bordered thead-primary table-hover"
    End With
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing



    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO"
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    tr.Cells.Add(td)




    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "EMPLOYEE CODE"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "DATE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "ACTIVITY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "PROJECT"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "ENTRY SERIAL NUMBER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "DIVISION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "REMARKS"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "HOURS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "ENGINEERING GROUP"
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
    For Each tmp As SIS.DB.engDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.MH_EmployeeCode
      tr.Cells.Add(td)




      td = New TableCell
      With td
        .Font.Bold = True
      End With

      td.Text = tmp.MH_Date
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.MH_activity & " "
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.MH_Project
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.MH_serialnumber
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.MH_Division
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.MH_Remark
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.MH_HoursEntered
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.MH_EngineeringGroup
      tr.Cells.Add(td)

      'td = New TableCell
      'Dim cmd As New Button
      'cmd.Text = "Click Me"
      'td.Controls.Add(cmd) 
      'tr.Cells.Add(td)


      tbl.Rows.Add(tr)


    Next
    '================
    pnlDetails.Controls.Add(tbl)

  End Sub


  Private Sub GF_UserDBDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim Det As String = Request.QueryString("detail")
    Dim empID As String = Request.QueryString("empid")
    If (Det = "cpd") Then
      PSheading.Text = "PENDING DWGS/DOCS IN RELEASE WORKFLOW :-DRAFTING"
      ShowPData(Det, empID)
    End If
    If (Det = "cpr") Then
      PSheading.Text = "PENDING DWGS/DOCS IN RELEASE WORKFLOW :-UNDER REVIEW"
      ShowPData(Det, empID)
    End If
    If (Det = "cpa") Then
      PSheading.Text = "PENDING DWGS/DOCS IN RELEASE WORKFLOW :-UNDER APPROVAL"
      ShowPData(Det, empID)
    End If
    If (Det = "cipre") Then
      PSheading.Text = "PRE ORDER RECEIPT PENDING FOR EVALUATION"
      ShowPREData(Det, empID)
    End If
    If (Det = "cipoe") Then
      PSheading.Text = "POST ORDER RECEIPT PENDING - FOR EVALUATION , COMMENTS SUBMITTED & TECHNICALLY CLEARED"
      ShowPOSTData(Det, empID)
    End If

    If (Det = "cta") Then
      PSheading.Text = "TRANSMITTAL LIST - PENDING FOR APPROVAL (CREATED BY ME)"
      ShowTData(Det, empID)
    End If

    If (Det = "cti") Then
      PSheading.Text = "TRANSMITTAL LIST - PENDING FOR ISSUE (CREATED BY ME/APPROVED BY ME)"
      ShowTData(Det, empID)
    End If


    If (Det = "cda") Then
      PSheading.Text = "DCR - PENDING FOR APPROVAL"
      ShowDData(Det, empID)
    End If


    If (Det = "cdac") Then
      PSheading.Text = "DCR - PENDING FOR APPROVAL - CREATED BY ME"
      ShowDData(Det, empID)
    End If

    If (Det = "csr") Then
      PSheading.Text = "SAR - PENDING FOR REVIEW"
      ShowSData(Det, empID)
      End If


    If (Det = "csa") Then
      PSheading.Text = "SAR - PENDING FOR APPROVAL"
      ShowSData(Det, empID)

    End If

    If (Det = "cmh") Then
      PSheading.Text = "MANHOUR ENTRY DATA FOR LAST 30 CALENDER DAYS"
      ShowMData(Det, empID)

    End If
  End Sub
End Class
