Partial Class GF_Transfer
  Inherits System.Web.UI.Page



  Private Sub ShowVRData()
    Dim Data As List(Of SIS.DB.transfer) = SIS.DB.transfer.GetVRDATA()

    If Data.Count = 0 Then Exit Sub
    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-light"
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
    td.Text = "DOCUMENT NUMBER"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "REV."
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
    td.Text = "TYPE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "SOURCE FILE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "UPLOADED TIME"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "BY USER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "FROM MACHINE"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "VAULT"
    tr.Cells.Add(td)



    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "STATE"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "WORKFLOW"
    tr.Cells.Add(td)



    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DB.transfer In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)


      td = New TableCell
      'Dim hl As New HyperLink
      'With hl
      '  .Text = tmp.t_docn
      '  .NavigateUrl =
      'End With
      With td
        .Font.Bold = True
      End With
      td.Text = tmp.t_docn
      tr.Cells.Add(td)

      td = New TableCell

      td.Text = tmp.t_revn
      tr.Cells.Add(td)

      td = New TableCell

      td.Text = tmp.t_dttl
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_type
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_sorc
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_sdat
      With td
        .Font.Bold = True
      End With
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_user & "-" & tmp.t_usern
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_mach
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_name
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_stat
      If td.Text = "Submitted" Then
        td.ForeColor = Drawing.Color.Green
        tr.BackColor = Drawing.Color.Yellow
        With td
          .Font.Bold = True
        End With
      End If

      If td.Text = "Drawing Released" Then
        'td.ForeColor = Drawing.Color.DarkGreen
        tr.BackColor = Drawing.Color.LightGreen
        With td
          .Font.Bold = True
        End With
      End If

      If td.Text = "Item Released" Then
        'td.ForeColor = Drawing.Color.DarkGreen
        tr.BackColor = Drawing.Color.GreenYellow
        With td
          .Font.Bold = True
        End With
      End If

      If td.Text = "Expired" Then
        'td.ForeColor = Drawing.Color.DarkGreen
        tr.BackColor = Drawing.Color.Orange
        With td
          .Font.Bold = True
        End With
      End If
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.t_wfst
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)


    Next
    '================

    v2bDetails.Controls.Add(tbl)

  End Sub
  Private Sub GF_TRANSFER_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim Det As String = Request.QueryString("detail")
    Dim empID As String = Request.QueryString("empid")

    v2bheading.Text = "Last 1000 Documents Transferred from Autodesk Vault to ERPLN"
    ShowVRData()
  End Sub



End Class
