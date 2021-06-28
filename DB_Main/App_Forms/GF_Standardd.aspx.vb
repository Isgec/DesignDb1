Partial Class GF_Standardd
  Inherits System.Web.UI.Page



  Private Sub ShowsdData()
    Dim Data As List(Of SIS.DB.standardd) = SIS.DB.standardd.GetVRDATA()

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
    td.Text = "Item Code"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "DOCUMENT ID"
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
    td.Text = "PDF FILE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "FILE NAME"
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
    td.Text = "WEIGHT"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "DRAWN BY"
    tr.Cells.Add(td)



    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "CHECKED BY"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "APPROVED BY"
    tr.Cells.Add(td)




    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DB.standardd In Data
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
      td.Text = tmp.t_item
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_docn
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_revn
      tr.Cells.Add(td)

      td = New TableCell

      td.Text = tmp.t_dsca
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_pdfn
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_dttl
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_cspa
      With td
        .Font.Bold = True
      End With
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_wght
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_drwn
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_chck
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_aprb

      tr.Cells.Add(td)




      tbl.Rows.Add(tr)


    Next
    '================
    sdDetails.Controls.Add(tbl)

  End Sub
  Private Sub GF_STANDARDD_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim Det As String = Request.QueryString("detail")
    Dim empID As String = Request.QueryString("empid")

    sdheading.Text = "ERPLN - Standard Document Master"
    ShowsdData()
  End Sub



End Class
