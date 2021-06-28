Partial Class GF_DocumentDB
    Inherits System.Web.UI.Page
    Public Property DocumentID As String
        Get
            If ViewState("DocumentID") IsNot Nothing Then
                Return ViewState("DocumentID")
            End If
            Return ""
        End Get
        Set(value As String)

            ViewState.Add("DocumentID", value)
        End Set
    End Property


    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
    ' vi.Visible = False
    ' sd.Visible = False
    Dim DocumentID As String = ""
        Dim RevisionNO As String = ""
        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID

        If F_t_revn.Text.Length > 2 Then Exit Sub

        If F_t_revn.Text = "0" Then F_t_revn.Text = "00"
        If F_t_revn.Text = "1" Then F_t_revn.Text = "01"
        If F_t_revn.Text = "2" Then F_t_revn.Text = "02"
        If F_t_revn.Text = "3" Then F_t_revn.Text = "03"
        If F_t_revn.Text = "4" Then F_t_revn.Text = "04"
        If F_t_revn.Text = "5" Then F_t_revn.Text = "05"
        If F_t_revn.Text = "6" Then F_t_revn.Text = "06"
        If F_t_revn.Text = "7" Then F_t_revn.Text = "07"
        If F_t_revn.Text = "8" Then F_t_revn.Text = "08"
        If F_t_revn.Text = "9" Then F_t_revn.Text = "09"




        RevisionNO = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
        If DocumentID.Length < 24 Then Exit Sub
        If DocumentID.Length > 25 Then Exit Sub
        Dim x As SIS.DB.DBDocumentDB = SIS.DB.DBDocumentDB.GetDocumentDB(DocumentID, RevisionNO)
        Dim Det As String = F_t_docn.Text
        Dim empID As String = F_t_revn.Text
        'Dim y As SIS.DB.PRE_Information = SIS.DB.PRE_Information.GetPREDATA(DocumentID, RevisionNO)
        'If RevisionNO <> "00" Or RevisionNO <> "01" Or RevisionNO <> "02" Then Exit Sub

        'Project
        If x.ProjectID = "" Then
            notfound.Visible = True
            notfound_text.Visible = True
            V2B.Visible = True
            found.Visible = False

            poi.Visible = False

            mi.Visible = False
            pi.Visible = False
            ii.Visible = False
            ti.Visible = False
            di.Visible = False
            si.Visible = False
            reci.Visible = False
            repi.Visible = False
            repd.Visible = False
      bom.Visible = False
      partbom.Visible = False
      ref.Visible = False
            dwg.Visible = False
            'ShowV2BData(Det, empID)
        Else
            notfound.Visible = False
            found.Visible = True
            V2B.Visible = True
            revision_text.Visible = True
        F_t_revn.Visible = True


        DivProjectID.Visible = True
        DivProjectID1.Visible = True
        btn_ProjectID.Text = x.ProjectID
        btn_ProjectID.Font.Size = 10
        btn_ProjectID.Font.Name = "Comic Sans MS"
        btn_ProjectID.Font.Bold = True

            V2BUserID.Text = x.V2buserid
            'Year
            DivProjectYear.Visible = True
        DivProjectYear1.Visible = True
        btn_ProjectYear.Text = x.Year
        btn_ProjectYear.Font.Size = 10
        btn_ProjectYear.Font.Bold = True
        btn_ProjectYear.Font.Name = "Comic Sans MS"
        'Client
        DivProjectClient.Visible = True
        DivProjectClient1.Visible = True
        btn_ProjectClient.Text = x.Client
        btn_ProjectClient.Font.Size = 10
        btn_ProjectClient.Font.Bold = True
        btn_ProjectClient.Font.Name = "Comic Sans MS"


        'IWT
        DivProjectIWT.Visible = True
        DivProjectIWT1.Visible = True
        btn_ProjectIWT.Text = x.IWT
        btn_ProjectIWT.Font.Size = 10
        btn_ProjectIWT.Font.Bold = True
        btn_ProjectIWT.Font.Name = "Comic Sans MS"

        'Service
        DivProject_Service.Visible = True
        DivProject_Service1.Visible = True
        Btn_Project_Service.Text = x.Project_Service
        Btn_Project_Service.Font.Size = 10
        Btn_Project_Service.Font.Bold = True
        Btn_Project_Service.Font.Name = "Comic Sans MS"
        'Consultant
        DivProjectConsultant.Visible = True
        DivProjectConsultant1.Visible = True
        btn_ProjectConsultant.Text = x.Consultant
        btn_ProjectConsultant.Font.Size = 10
        btn_ProjectConsultant.Font.Bold = True
        btn_ProjectConsultant.Font.Name = "Comic Sans MS"
        'Description
        DivDescription2.Visible = True
        DivDescription1.Visible = True
        btn_documentname.Font.Size = 10
        btn_documentname.Font.Bold = True
        btn_documentname.Font.Name = "Comic Sans MS"


        'Revision
        DivRevision1.Visible = True
        DivRevision2.Visible = True
        btn_documentrev.Font.Size = 10
        btn_documentrev.Font.Bold = True
        btn_documentrev.Font.Name = "Comic Sans MS"

        'Submitted Time
        DivSubmittedTime1.Visible = True
        DivSubmittedTime2.Visible = True
        btn_documentSubmittedTime.Font.Size = 10
        btn_documentSubmittedTime.Font.Bold = True
        btn_documentSubmittedTime.Font.Name = "Comic Sans MS"

        'Username
        DivEUserName1.Visible = True
        DivEUserName2.Visible = True
        btn_EUserName.Font.Size = 10
        btn_EUserName.Font.Bold = True
        btn_EUserName.Font.Name = "Comic Sans MS"
        'Reviewer
        DivEReviewedBy1.Visible = True
        DivEReviewedBy2.Visible = True
        btn_EReviewedBy.Font.Size = 10
        btn_EReviewedBy.Font.Bold = True
        btn_EReviewedBy.Font.Name = "Comic Sans MS"




        'Approver
        DivEApprovedBy1.Visible = True
        DivEApprovedBy2.Visible = True
        Btn_EApprovedBy.Font.Size = 10
        Btn_EApprovedBy.Font.Bold = True
        Btn_EApprovedBy.Font.Name = "Comic Sans MS"


        'ISGEC Data Source
        DivISGECDataSource1.Visible = True
        DivISGECDataSource2.Visible = True
        Btn_IsgecDataSource.Font.Size = 10
        Btn_IsgecDataSource.Font.Bold = True
        Btn_IsgecDataSource.Font.Name = "Comic Sans MS"
        VaultStatus.Visible = True
        If x.Vaultstatus = "" Then
            VaultStatus.Visible = False
        Else
            VaultStatus.Visible = True

            If (x.Vaultstatus = "Released") Then
                VaultStatus.ImageUrl = "~/Images/locked-s.jpg"
            End If
            If (x.Vaultstatus = "Submitted") Then
                VaultStatus.ImageUrl = "~/Images/locked-s.jpg"

            End If
            If (x.Vaultstatus = "Work In Progress") Then
                VaultStatus.ImageUrl = "~/Images/Unlocked-s.jpg"

            End If
        End If
        'document release date
        Divdocreleasedate1.Visible = True
        Divdocreleasedate2.Visible = True
        Btn_docreleasedate.Font.Size = 10
        Btn_docreleasedate.Font.Bold = True
        Btn_docreleasedate.Font.Name = "Comic Sans MS"


        'Status
        DivStatus.Visible = True
        DivStatus1.Visible = True
        btn_documentStatus.Font.Size = 10
        btn_documentStatus.Font.Bold = True
        btn_documentStatus.Font.Name = "Comic Sans MS"


        'Workflow
        DivWorkflow.Visible = True
        DivWorkflow1.Visible = True
        btn_documentWorkflow.Font.Size = 10
        btn_documentWorkflow.Font.Bold = True
        btn_documentWorkflow.Font.Name = "Comic Sans MS"

        'DOC Type
        DivDocumenttype.Visible = True
        DivDocumenttype1.Visible = True
        btn_documentType.Font.Size = 10
        btn_documentType.Font.Bold = True
        btn_documentType.Font.Name = "Comic Sans MS"

        'Division
        DivDivision.Visible = True
        DivDivision1.Visible = True
        btn_documentDivision.Font.Size = 10
        btn_documentDivision.Font.Bold = True
        btn_documentDivision.Font.Name = "Comic Sans MS"

        'Responsible Department
        DivResponsible.Visible = True
        DivResponsible1.Visible = True
        btn_documentResponsible.Font.Size = 10
        btn_documentResponsible.Font.Bold = True
        btn_documentResponsible.Font.Name = "Comic Sans MS"


        'Date
        DivDate.Visible = True
        DivDate1.Visible = True
        btn_documentDate.Font.Size = 10
        btn_documentDate.Font.Bold = True
        btn_documentDate.Font.Name = "Comic Sans MS"


        'Weight
        Divweight.Visible = True
        Divweight1.Visible = True
        btn_documentWeight.Font.Size = 10
        btn_documentWeight.Font.Bold = True
        btn_documentWeight.Font.Name = "Comic Sans MS"

        'Scale
        Divscale.Visible = True
        Divscale1.Visible = True
        btn_documentScale.Font.Size = 9
        btn_documentScale.Font.Bold = True
        btn_documentScale.Font.Name = "Comic Sans MS"

        'SheetSize
        Divsize.Visible = True
        Divsize1.Visible = True
        btn_documentSize.Font.Size = 10
        btn_documentSize.Font.Bold = True
        btn_documentSize.Font.Name = "Comic Sans MS"


        'Element
        DivElement.Visible = True
        DivElement1.Visible = True
        btn_documentElement.Font.Size = 10
        btn_documentElement.Font.Bold = True
        btn_documentElement.Font.Name = "Comic Sans MS"


        'DrawnBy
        DivDrawnBy.Visible = True
        DivDrawnBy1.Visible = True
        btn_documentDrawnby.Font.Size = 10
        btn_documentDrawnby.Font.Bold = True
        btn_documentDrawnby.Font.Name = "Comic Sans MS"


        'CheckedBy
        DivCheckedBy.Visible = True
        DivCheckedBy1.Visible = True
        btn_documentCheckedBy.Font.Size = 10
        btn_documentCheckedBy.Font.Bold = True
        btn_documentCheckedBy.Font.Name = "Comic Sans MS"

        'ApprovedBy
        DivApprovedBy.Visible = True
        DivApprovedBy1.Visible = True
        btn_documentApprovedBy.Font.Size = 10
        btn_documentApprovedBy.Font.Bold = True
        btn_documentApprovedBy.Font.Name = "Comic Sans MS"

        'Software Used
        DivSoftwareused.Visible = True
        DivSoftwareused1.Visible = True
        Btn_Softwareused.Font.Size = 10
        Btn_Softwareused.Font.Bold = True
        Btn_Softwareused.Font.Name = "Comic Sans MS"

        'ErectionBy
        DivErection.Visible = True
        DivErection1.Visible = True
        Btn_Erection.Font.Size = 10
        Btn_Erection.Font.Bold = True
        Btn_Erection.Font.Name = "Comic Sans MS"

        'Inforation
        Divinformation.Visible = True
        Divinformation1.Visible = True
        Btn_Information.Font.Size = 10
        Btn_Information.Font.Bold = True
        Btn_Information.Font.Name = "Comic Sans MS"

        'Production
        DivProduction.Visible = True
        DivProduction1.Visible = True
        Btn_Production.Font.Size = 10
        Btn_Production.Font.Bold = True
        Btn_Production.Font.Name = "Comic Sans MS"


        'Approval
        DivApproval.Visible = True
        DivApproval1.Visible = True
        Btn_Approval.Font.Size = 10
        Btn_Approval.Font.Bold = True
        Btn_Approval.Font.Name = "Comic Sans MS"


        'MachineName
        DivMachineName.Visible = True
        DivMachineName1.Visible = True
        Btn_MachineName.Font.Size = 10
        Btn_MachineName.Font.Bold = True
        Btn_MachineName.Font.Name = "Comic Sans MS"


        'FileName
        DivFilename.Visible = True
        DivFilename1.Visible = True
        btn_documentfilename.Font.Size = 10
        btn_documentfilename.Font.Bold = True
        btn_documentfilename.Font.Name = "Comic Sans MS"


            'Transmittal
            'DivTransmittalid.Visible = True
            'DivTransmittalid1.Visible = True

            'btn_transmittalid.Font.Size = 10
            'btn_transmittalid.Font.Bold = True
            'btn_transmittalid.Font.Name = "Comic Sans MS"

            'DivTransmittalType.Visible = True
            'DivTransmittalType1.Visible = True
            'btn_TransmittalType.Font.Size = 10
            'btn_transmittalid.Font.Bold = True
            'btn_transmittalid.Font.Name = "Comic Sans MS"

            'DivIndentNumber.Visible = True
            'DivindentDate.Visible = True
            'DivIndentRequester.Visible = True
            'DivPONumber.Visible = True
            'DivPODate.Visible = True

            'DivPOSupplier.Visible = True
            'DivPOSuppliername.Visible = False
            'DivPOBuyer.Visible = True
            'di.Visible = True
            'pi.Visible = True
            poi.Visible = True 'PO
            ' pmdli.Visible = False

            mi.Visible = True
            V2B.Visible = True
            pi.Visible = True

            ii.Visible = True 'Indent
            ti.Visible = True
        di.Visible = True
        si.Visible = True
        reci.Visible = True
        repi.Visible = True
        repd.Visible = True
        bom.Visible = True
            bom.Font.Size = 8.5
            'bom.Font.Bold = True
            bom.Text = "ERPLN Items"
            bom.Font.Name = "corbel"
      bom.ForeColor = Drawing.Color.BlueViolet
      partbom.Visible = True
      partbom.Font.Size = 8.5
      'bom.Font.Bold = True
      partbom.Text = "ERPLN Parts"
      partbom.Font.Name = "corbel"
      partbom.ForeColor = Drawing.Color.BlueViolet
      ref.Visible = True
            ref.Font.Size = 8.5
            'ref.Font.Bold = True
            ref.Text = "Reference Drawings"
            ref.Font.Name = "corbel"
            ref.ForeColor = Drawing.Color.BlueViolet

        dwg.Visible = True
            dwg.Font.Size = 8.5
            ' dwg.Font.Bold = True
            dwg.Text = "DRAWING Information"
            dwg.Font.Name = "corbel"
            dwg.ForeColor = Drawing.Color.BlueViolet


        btn_documentname.Text = x.Tittle_001
      btn_documentname.Font.Size = 14
      'btn_documentname.ForeColor = Drawing.Color.CadetBlue
      btn_documentname.ForeColor = Drawing.Color.BlueViolet
      'btn_documentname.Font.Name = "corbel"
      btn_documentrev.Text = x.Document_Rev
      btn_documentrev.Font.Size = 14
      btn_documentrev.ForeColor = Drawing.Color.BlueViolet
      'btn_documentrev.Font.Name = "corbel"
      btn_documentfilename.Text = x.Drawing_File_Name_001
        btn_documentStatus.Text = x.Drawing_State_001
        btn_documentWorkflow.Text = x.Workflow_Status_001
        btn_documentResponsible.Text = x.Responsible_001
        btn_documentDate.Text = x.Document_Date_001
        If (x.Sumofitems_Weight_002 = "0") Then
            btn_documentWeight.Text = x.Drawing_Weight_001
        Else
            btn_documentWeight.Text = x.Drawing_Weight_001 & " (Actual sum of item's weight =" & x.Sumofitems_Weight_002 & ")"
        End If
        If x.Drawing_Weight_001 = x.Sumofitems_Weight_002 Then btn_documentWeight.ForeColor = Drawing.Color.Green Else btn_documentWeight.ForeColor = Drawing.Color.Red
        btn_documentWeight.Font.Size = 11
        btn_documentScale.Text = x.Drawing_Scale_001
        btn_documentScale.Font.Size = 11
        btn_documentSize.Text = x.Sheet_Size_001
        btn_documentSize.Font.Size = 11
        btn_documentElement.Text = x.Element_001 & " - " & x.Element_desc
        btn_documentElement.Font.Size = 11
        btn_documentDrawnby.Text = x.Drawn_By_001
        btn_documentCheckedBy.Text = x.Checked_By_001
        btn_documentApprovedBy.Text = x.Approved_By_001
        btn_documentType.Text = x.Document_Type
        btn_documentDivision.Text = x.Division
        btn_documentSubmittedTime.Text = x.Submitted_Time
        'btn_documentSubmittedTime.Font.Size = 10
        btn_EUserName.Text = x.User_Name & " - " & x.SUBMITTEDBY_Name
        'btn_EUserName.Font.Size = 10
        btn_EReviewedBy.Text = x.Review_By & " - " & x.REVIEWEDBY_NAME
        'btn_EReviewedBy.Font.Size = 10
        Btn_EApprovedBy.Text = x.EApproved_BY & " - " & x.APPROVEDBY_NAME
        'Btn_EApprovedBy.Font.Size = 10
        Btn_IsgecDataSource.Text = x.ISGEC_DATA_Source

        If (x.doc_releasedate = "01/01/1970") Then x.doc_releasedate = "-"
        End If

        Btn_docreleasedate.Text = x.doc_releasedate
        'Btn_IsgecDataSource.Font.Size = 10
        Btn_Erection.Text = x.For_Erection
        Btn_Information.Text = x.For_Information
        Btn_Production.Text = x.For_Production
        Btn_Approval.Text = x.For_Approval
        Btn_Softwareused.Text = x.SoftwareUsed
        Btn_MachineName.Text = x.MachineName
        'btn_IndentNumber.Text = x.IndentNumber
        'btn_IndentDate.Text = x.IndentDate
        'btn_IndentRequester.Text = x.IndentRequester & " - " & x.IndentRequestername
        'btn_PONumber.Text = x.PONumber
        'btn_PODate.Text = x.PODate
        'btn_POSupplier.Text = x.POsupplier & " - " & x.POsuppliername
        'btn_POSuppliername.Visible = False
        'btn_POSuppliername.Text = x.POsuppliername
        'btn_POBuyer.Text = x.POBuyer & " - " & x.POBuyername

        'btn_transmittalid.Text = x.Transmittalid


        ShowPData(Det, empID)
            ShowMData(Det, empID)
            ShowV2BData(Det, empID)
            ShowBData(Det, empID)
      ShowPaData(Det, empID)
      ShowrData(Det, empID)
        ShowTData(Det, empID)
        ShowDData(Det, empID)
        ShowSData(Det, empID)
        ShowPreData(Det, empID)
        ShowPostData(Det, empID)
            ShowPostdData(Det, empID)
            ShowIData(Det, empID)
            ShowPOData(Det, empID)

        'ShowPredData(Det, empID)

    End Sub

    Public Sub ShowBData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.BOM_Information) = SIS.DB.BOM_Information.GetBOMDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
        If Data.Count = 0 Then Exit Sub




        Dim tbl As New Table
        With tbl
            .GridLines = GridLines.Both
            .BorderWidth = 2
            .CellSpacing = 2
            .Width = Unit.Percentage(100)
            .CssClass = "table-warning"
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
        td.Text = "DOCUMENT ID"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "REVISION"
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
        td.Text = "ITEM"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "ITEM DESCRIPTION"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "ITEM GROUP"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "QUANTITY"
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
        td.Text = "ITEM TYPE"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "UNIT"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "OITM"
        tr.Cells.Add(td)





        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.BOM_Information In Data
            I += 1
            tr = New TableRow

      td = New TableCell
      With td
        .Font.Bold = True
      End With
      td.Text = tmp.t_srno
            tr.Cells.Add(td)


      td = New TableCell
      With td
        .Font.Bold = True
      End With
      td.Text = tmp.t_docn
            tr.Cells.Add(td)




            td = New TableCell
            With td
                .Font.Bold = True
            End With

            td.Text = tmp.t_revn
            tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
      End With
      td.Text = tmp.t_elem
            tr.Cells.Add(td)



            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_item
            tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
      End With
      td.Text = tmp.t_dsca
            tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
      End With
      td.Text = tmp.t_citg
            tr.Cells.Add(td)


      td = New TableCell
      With td
        .Font.Bold = True
      End With
      td.Text = tmp.t_qnty
            tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
      End With

      td.Text = tmp.t_wght
            tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
      End With
      td.Text = tmp.t_itmt
            tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
      End With
      td.Text = tmp.t_cuni
            tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
      End With
      td.Text = tmp.t_oitm
            tr.Cells.Add(td)



            tbl.Rows.Add(tr)


        Next
        '================
        pnl_Details.Controls.Add(tbl)

    End Sub
  Public Sub ShowPaData(ByVal DocumentID As String, ByVal RevisionNo As String)
    Dim Data As List(Of SIS.DB.Pa_Information) = SIS.DB.Pa_Information.GetPADATA(DocumentID, RevisionNo)

    DocumentID = F_t_docn.Text.ToUpper()
    F_t_docn.Text = DocumentID
    RevisionNo = F_t_revn.Text


    If DocumentID = "" Then Exit Sub
    If Data.Count = 0 Then Exit Sub




    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-warning"
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
      .Font.Size = FontUnit.Point(9)
    End With
    tr.Cells.Add(td)



    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)

    End With
    td.Text = "DOCUMENT ID"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "REVISION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "SRNO"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "ITEM"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PARTITEMSNO"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PARTNUMBER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PART DESCRIPTION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "WEIGHT"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "QUANTITY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "SPECIFICATION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "SIZE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "REMARKS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "MOCCODE"
    tr.Cells.Add(td)



    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DB.PA_Information In Data
      I += 1
      tr = New TableRow

      td = New TableCell

      td.Text = I
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.DocumentNumber
      tr.Cells.Add(td)




      td = New TableCell
      With td
        .Font.Bold = True
      End With

      td.Text = tmp.Revision
      tr.Cells.Add(td)

      td = New TableCell

      td.Text = tmp.SrNo
      td.ForeColor = Drawing.Color.Blue
      tr.Cells.Add(td)



      td = New TableCell
      With td
        .Font.Bold = True
        td.ForeColor = Drawing.Color.Blue
      End With
      td.Text = tmp.Item

      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.PartItemSNo
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.PartNumber

      td.ForeColor = Drawing.Color.Blue
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.PartDescription
      td.ForeColor = Drawing.Color.Blue
      tr.Cells.Add(td)

      td = New TableCell

      td.Text = tmp.Weight
      td.ForeColor = Drawing.Color.Blue
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Quantity
      td.ForeColor = Drawing.Color.Blue
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Specification
      td.ForeColor = Drawing.Color.Blue
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Size
      td.ForeColor = Drawing.Color.Blue
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.Remark
      td.ForeColor = Drawing.Color.Blue
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.MOCCode
      td.ForeColor = Drawing.Color.Blue
      tr.Cells.Add(td)


      tbl.Rows.Add(tr)


    Next
    '================
    pnl_Details.Controls.Add(tbl)

  End Sub
  Private Sub ShowrData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.REF_Information) = SIS.DB.REF_Information.GetREFDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
        If Data.Count = 0 Then Exit Sub
        Dim tbl As New Table
        With tbl
            .GridLines = GridLines.Both
            .BorderWidth = 2
            .CellSpacing = 2
            .Width = Unit.Percentage(100)
            .CssClass = "table-info"
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
        td.Text = "DOCUMENT ID"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "TITTLE"
        tr.Cells.Add(td)







        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.REF_Information In Data
            I += 1
            tr = New TableRow

            td = New TableCell
            td.Text = I
            tr.Cells.Add(td)


            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_drgt
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.t_dcfn
            tr.Cells.Add(td)








            tbl.Rows.Add(tr)


        Next
        '================
        pnl_rDetails.Controls.Add(tbl)

    End Sub

    Private Sub ShowPOData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.PO_Information) = SIS.DB.PO_Information.GetPODATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
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
        td.Text = "PO NUMBER"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "PO DATE"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "SUPPLIER ID"
        tr.Cells.Add(td)



        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "BUYER"
        tr.Cells.Add(td)






        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.PO_Information In Data
            I += 1
            tr = New TableRow

            td = New TableCell
            td.Text = I
            tr.Cells.Add(td)


            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_orno
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.t_odat
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.supplierID & " - " & tmp.Supplier_name
            tr.Cells.Add(td)


            td = New TableCell

            td.Text = tmp.t_ccon & " - " & tmp.buyer
            tr.Cells.Add(td)


            tbl.Rows.Add(tr)


        Next
        '================
        pnl_PODetails.Controls.Add(tbl)

    End Sub

    Private Sub ShowIData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.I_Information) = SIS.DB.I_Information.GetIDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
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
        td.Text = "INDENT NUMBER"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "INDENT DATE"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "INDENT REQUESTED BY"
        tr.Cells.Add(td)





        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.I_Information In Data
            I += 1
            tr = New TableRow

            td = New TableCell
            td.Text = I
            tr.Cells.Add(td)


            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_rqno
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.t_rdat
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.t_remn & " - " & tmp.indentor_name
            tr.Cells.Add(td)



            tbl.Rows.Add(tr)


        Next
        '================
        pnl_iDetails.Controls.Add(tbl)

    End Sub
  'Private Sub ShowVRData()
  '  Dim Data As List(Of SIS.DB.VR_Information) = SIS.DB.VR_Information.GetVRDATA()

  '  If Data.Count = 0 Then Exit Sub
  '  Dim tbl As New Table
  '  With tbl
  '    .GridLines = GridLines.Both
  '    .BorderWidth = 2
  '    .CellSpacing = 2
  '    .Width = Unit.Percentage(100)
  '    .CssClass = "table-light"
  '    '  .CssClass = "table-danger table-bordered thead-primary table-hover"
  '  End With
  '  Dim tr As TableRow = Nothing
  '  Dim td As TableCell = Nothing



  '  'Header
  '  tr = New TableRow

  '  td = New TableCell
  '  td.Text = "S.NO"
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  tr.Cells.Add(td)



  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "DOCUMENT NUMBER"
  '  tr.Cells.Add(td)


  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "REV."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "TITTLE"
  '  tr.Cells.Add(td)


  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "TYPE"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "SOURCE FILE"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "UPLOADED TIME"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "BY USER"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "FROM MACHINE"
  '  tr.Cells.Add(td)


  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "VAULT"
  '  tr.Cells.Add(td)



  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "STATE"
  '  tr.Cells.Add(td)


  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "WORKFLOW"
  '  tr.Cells.Add(td)



  '  tbl.Rows.Add(tr)

  '  Dim I As Integer = 0
  '  '================
  '  For Each tmp As SIS.DB.VR_Information In Data
  '    I += 1
  '    tr = New TableRow

  '    td = New TableCell
  '    td.Text = I
  '    tr.Cells.Add(td)


  '    td = New TableCell
  '    'Dim hl As New HyperLink
  '    'With hl
  '    '  .Text = tmp.t_docn
  '    '  .NavigateUrl =
  '    'End With
  '    With td
  '      .Font.Bold = True
  '    End With
  '    td.Text = tmp.t_docn
  '    tr.Cells.Add(td)

  '    td = New TableCell

  '    td.Text = tmp.t_revn
  '    tr.Cells.Add(td)

  '    td = New TableCell

  '    td.Text = tmp.t_dttl
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_type
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_sorc
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_sdat
  '    With td
  '      .Font.Bold = True
  '    End With
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_user & "-" & tmp.t_usern
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_mach
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_name
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_stat
  '    If td.Text = "Submitted" Then
  '      td.ForeColor = Drawing.Color.Green
  '      tr.BackColor = Drawing.Color.Yellow
  '      With td
  '        .Font.Bold = True
  '      End With
  '    End If

  '    If td.Text = "Drawing Released" Then
  '      'td.ForeColor = Drawing.Color.DarkGreen
  '      tr.BackColor = Drawing.Color.LightGreen
  '      With td
  '        .Font.Bold = True
  '      End With
  '    End If

  '    If td.Text = "Item Released" Then
  '      'td.ForeColor = Drawing.Color.DarkGreen
  '      tr.BackColor = Drawing.Color.GreenYellow
  '      With td
  '        .Font.Bold = True
  '      End With
  '    End If

  '    If td.Text = "Expired" Then
  '      'td.ForeColor = Drawing.Color.DarkGreen
  '      tr.BackColor = Drawing.Color.Orange
  '      With td
  '        .Font.Bold = True
  '      End With
  '    End If
  '    tr.Cells.Add(td)


  '    td = New TableCell
  '    td.Text = tmp.t_wfst
  '    tr.Cells.Add(td)

  '    tbl.Rows.Add(tr)


  '  Next
  '  '================
  '  'v2bDetails.Controls.Add(tbl)

  'End Sub
  'Private Sub ShowsdData()
  '  Dim Data As List(Of SIS.DB.SD_Information) = SIS.DB.SD_Information.GetSDDATA()

  '  If Data.Count = 0 Then Exit Sub
  '  Dim tbl As New Table
  '  With tbl
  '    .GridLines = GridLines.Both
  '    .BorderWidth = 2
  '    .CellSpacing = 2
  '    .Width = Unit.Percentage(100)
  '    .CssClass = "table-light"
  '    '  .CssClass = "table-danger table-bordered thead-primary table-hover"
  '  End With
  '  Dim tr As TableRow = Nothing
  '  Dim td As TableCell = Nothing



  '  'Header
  '  tr = New TableRow

  '  td = New TableCell
  '  td.Text = "S.NO"
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  tr.Cells.Add(td)



  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "Item Code"
  '  tr.Cells.Add(td)


  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "DOCUMENT ID"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "REV."
  '  tr.Cells.Add(td)


  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "TITTLE"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "PDF FILE"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "FILE NAME"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "ELEMENT"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "WEIGHT"
  '  tr.Cells.Add(td)


  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "DRAWN BY"
  '  tr.Cells.Add(td)



  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "CHECKED BY"
  '  tr.Cells.Add(td)


  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(10)
  '  End With
  '  td.Text = "APPROVED BY"
  '  tr.Cells.Add(td)




  '  tbl.Rows.Add(tr)

  '  Dim I As Integer = 0
  '  '================
  '  For Each tmp As SIS.DB.SD_Information In Data
  '    I += 1
  '    tr = New TableRow

  '    td = New TableCell
  '    td.Text = I
  '    tr.Cells.Add(td)


  '    td = New TableCell
  '    'Dim hl As New HyperLink
  '    'With hl
  '    '  .Text = tmp.t_docn
  '    '  .NavigateUrl =
  '    'End With
  '    With td
  '      .Font.Bold = True
  '    End With
  '    td.Text = tmp.t_item
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_docn
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_revn
  '    tr.Cells.Add(td)

  '    td = New TableCell

  '    td.Text = tmp.t_dsca
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_pdfn
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_dttl
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_cspa
  '    With td
  '      .Font.Bold = True
  '    End With
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_wght
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_drwn
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_chck
  '    tr.Cells.Add(td)

  '    td = New TableCell
  '    td.Text = tmp.t_aprb

  '    tr.Cells.Add(td)




  '    tbl.Rows.Add(tr)


  '  Next
  '  '================
  '  sdDetails.Controls.Add(tbl)

  'End Sub

  Private Sub ShowPreData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.PRE_Information) = SIS.DB.PRE_Information.GetPREDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
        If Data.Count = 0 Then Exit Sub
        Dim tbl As New Table
        With tbl
            .GridLines = GridLines.Both
            .BorderWidth = 2
            .CellSpacing = 2
            .Width = Unit.Percentage(100)
            .CssClass = "table-info"
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
        td.Text = "RECEIPT ID"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "RECEIPT REV"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "RECEIPT DATE"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "SENT DATE"
        tr.Cells.Add(td)

        'td = New TableCell
        'With td
        '    .Font.Bold = True
        '    .Font.Size = FontUnit.Point(10)
        'End With
        'td.Text = "R Age in days"
        'tr.Cells.Add(td)


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
        td.Text = "OWNER's DEPT"
        tr.Cells.Add(td)



        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "ITEM"
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
        td.Text = "Mechanical"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "Structure"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "Piping"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "Process"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "C&I"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "Electrical"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "Quality"
        tr.Cells.Add(td)








        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "VENDOR"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "USER"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "INDENT NO."
        tr.Cells.Add(td)

        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.PRE_Information In Data
            I += 1
            tr = New TableRow

            td = New TableCell
            td.Text = I
            tr.Cells.Add(td)


            If tmp.ReceiptID = "" Then Exit Sub
            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.ReceiptID
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Rrev
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.ReceiptDate
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.SentDate
            tr.Cells.Add(td)


            'td = New TableCell
            'With td
            '    .Font.Bold = True
            'End With
            'td.Text = tmp.Rageindays
            'tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.RProject
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Relement
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Owner_Dept
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_item & " - " & tmp.ItemDescription
            tr.Cells.Add(td)



            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Receipt_State
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Mechanical
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Structure_1
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Piping
            tr.Cells.Add(td)


            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Process
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.CandI
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Electrical
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Quality
            tr.Cells.Add(td)


            'Dim Dataa As SIS.DB.PRED_Information = SIS.DB.PRED_Information.GetPREDDATA(tmp.ReceiptID, tmp.ReceiptREvision)

            'td = New TableCell

            'td.Text = tmp.Itemdescription
            'tr.Cells.Add(td)



            td = New TableCell
            td.Text = tmp.t_bpid & " - " & tmp.Sname
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_user & " - " & tmp.ename
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_rqno
            tr.Cells.Add(td)

            tbl.Rows.Add(tr)


        Next
        '================
        pnl_PREDetails.Controls.Add(tbl)

    End Sub

    Private Sub ShowPostData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.POST_Information) = SIS.DB.POST_Information.GetPOSTDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
        If Data.Count = 0 Then Exit Sub
        Dim tbl As New Table
        With tbl
            .GridLines = GridLines.Both
            .BorderWidth = 2
            .CellSpacing = 2
            .Width = Unit.Percentage(100)
            .CssClass = "table-info"
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
        td.Text = "RECEIPT ID"
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
        td.Text = "RECEIPT DATE"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "SENT DATE"
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
        td.Text = "OWNER's DEPT"
        tr.Cells.Add(td)



        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "ITEM"
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
        td.Text = "Mechanical"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "Structure"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "Piping"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "Process"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "C&I"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "Electrical"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "Quality"
        tr.Cells.Add(td)








        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "VENDOR"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "CREATOR"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "CLOSED BY"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "CLOSED ON"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "PO NO."
        tr.Cells.Add(td)

        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.POST_Information In Data
            I += 1
            tr = New TableRow

            td = New TableCell
            td.Text = I
            tr.Cells.Add(td)


            If tmp.ReceiptID = "" Then Exit Sub
            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.ReceiptID
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Rrev
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.ReceiptDate
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.SentDate
            tr.Cells.Add(td)




            td = New TableCell
            td.Text = tmp.RProject
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.Relement
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Owner_Dept
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.t_item & " - " & tmp.ItemDescription
            tr.Cells.Add(td)



            td = New TableCell

            td.Text = tmp.Receipt_State
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.Mechanical
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.Structure_1
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.Piping
            tr.Cells.Add(td)


            td = New TableCell

            td.Text = tmp.Process
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.CandI
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.Electrical
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.Quality
            tr.Cells.Add(td)


            'Dim Dataa As SIS.DB.PRED_Information = SIS.DB.PRED_Information.GetPREDDATA(tmp.ReceiptID, tmp.ReceiptREvision)

            'td = New TableCell

            'td.Text = tmp.Itemdescription
            'tr.Cells.Add(td)



            td = New TableCell
            td.Text = tmp.t_bpid & " - " & tmp.Sname
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_user & " - " & tmp.ename
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_appr & " - " & tmp.cname
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_adat
            tr.Cells.Add(td)



            td = New TableCell
            td.Text = tmp.t_orno
            tr.Cells.Add(td)

            tbl.Rows.Add(tr)


        Next
        '================
        pnl_POSTDetails.Controls.Add(tbl)

    End Sub

    Private Sub ShowPostdData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.POSTD_Information) = SIS.DB.POSTD_Information.GetPOSTDDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
        If Data.Count = 0 Then Exit Sub
        Dim tbl As New Table
        With tbl
            .GridLines = GridLines.Both
            .BorderWidth = 2
            .CellSpacing = 2
            .Width = Unit.Percentage(100)
            .CssClass = "table-info"
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
        td.Text = "RECEIPT ID"
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
        td.Text = "SERIAL NO."
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
        td.Text = "REVISION"
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
        td.Text = "ISGEC DOCUMENT NUMBER"
        tr.Cells.Add(td)



        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "ISGEC REVISION"
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
        td.Text = "REMARKS"
        tr.Cells.Add(td)



        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.POSTD_Information In Data
            I += 1
            tr = New TableRow

            td = New TableCell
            td.Text = I
            tr.Cells.Add(td)

            If tmp.t_rcno = "" Then Exit Sub
            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_rcno
            tr.Cells.Add(td)

            If tmp.t_rcno = "" Then Exit Sub
            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_revn
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_srno
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_docn
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_revi
            tr.Cells.Add(td)


            td = New TableCell
            td.Text = tmp.t_dsca
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_idoc
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_irev
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.t_date
            tr.Cells.Add(td)

            td = New TableCell

            td.Text = tmp.t_remk
            tr.Cells.Add(td)

            'Dim Dataa As SIS.DB.PRED_Information = SIS.DB.PRED_Information.GetPREDDATA(tmp.ReceiptID, tmp.ReceiptREvision)

            'td = New TableCell

            'td.Text = tmp.Itemdescription
            'tr.Cells.Add(td)


            tbl.Rows.Add(tr)


        Next
        '================
        pnl_POSTDDetails.Controls.Add(tbl)

    End Sub

    'Private Sub ShowPostData(ByVal DocumentID As String, ByVal RevisionNo As String)
    '    Dim Data As List(Of SIS.DB.POST_Information) = SIS.DB.POST_Information.GetPOSTDATA(DocumentID, RevisionNo)

    '    DocumentID = F_t_docn.Text.ToUpper()
    '    F_t_docn.Text = DocumentID
    '    RevisionNo = F_t_revn.Text


    '    If DocumentID = "" Then Exit Sub
    '    If Data.Count = 0 Then Exit Sub
    '    Dim tbl As New Table
    '    With tbl
    '        .GridLines = GridLines.Both
    '        .BorderWidth = 2
    '        .CellSpacing = 2
    '        .Width = Unit.Percentage(100)
    '        .CssClass = "table-info"
    '        '  .CssClass = "table-danger table-bordered thead-primary table-hover"
    '    End With
    '    Dim tr As TableRow = Nothing
    '    Dim td As TableCell = Nothing



    '    'Header
    '    tr = New TableRow

    '    td = New TableCell
    '    td.Text = "S.NO"
    '    With td
    '        .Font.Bold = True
    '        .Font.Size = FontUnit.Point(10)
    '    End With
    '    tr.Cells.Add(td)



    '    td = New TableCell
    '    With td
    '        .Font.Bold = True
    '        .Font.Size = FontUnit.Point(10)
    '    End With
    '    td.Text = "RECEIPT ID"
    '    tr.Cells.Add(td)

    '    td = New TableCell
    '    With td
    '        .Font.Bold = True
    '        .Font.Size = FontUnit.Point(10)
    '    End With
    '    td.Text = "RECEIPT REV"
    '    tr.Cells.Add(td)

    '    td = New TableCell
    '    With td
    '        .Font.Bold = True
    '        .Font.Size = FontUnit.Point(10)
    '    End With
    '    td.Text = "PROJECT ID"
    '    tr.Cells.Add(td)

    '    td = New TableCell
    '    With td
    '        .Font.Bold = True
    '        .Font.Size = FontUnit.Point(10)
    '    End With
    '    td.Text = "ITEM"
    '    tr.Cells.Add(td)



    '    td = New TableCell
    '    With td
    '        .Font.Bold = True
    '        .Font.Size = FontUnit.Point(10)
    '    End With
    '    td.Text = "STATUS"
    '    tr.Cells.Add(td)

    '    td = New TableCell
    '    With td
    '        .Font.Bold = True
    '        .Font.Size = FontUnit.Point(10)
    '    End With
    '    td.Text = "RECEIPT DATE"
    '    tr.Cells.Add(td)

    '    td = New TableCell
    '    With td
    '        .Font.Bold = True
    '        .Font.Size = FontUnit.Point(10)
    '    End With
    '    td.Text = "SENT DATE"
    '    tr.Cells.Add(td)

    '    td = New TableCell
    '    With td
    '        .Font.Bold = True
    '        .Font.Size = FontUnit.Point(10)
    '    End With
    '    td.Text = "VENDOR"
    '    tr.Cells.Add(td)

    '    td = New TableCell
    '    With td
    '        .Font.Bold = True
    '        .Font.Size = FontUnit.Point(10)
    '    End With
    '    td.Text = "USER"
    '    tr.Cells.Add(td)

    '    td = New TableCell
    '    With td
    '        .Font.Bold = True
    '        .Font.Size = FontUnit.Point(10)
    '    End With
    '    td.Text = "PO NO."
    '    tr.Cells.Add(td)

    '    tbl.Rows.Add(tr)

    '    Dim I As Integer = 0
    '    '================
    '    For Each tmp As SIS.DB.Post_Information In Data
    '        I += 1
    '        tr = New TableRow

    '        td = New TableCell
    '        td.Text = I
    '        tr.Cells.Add(td)


    '        If tmp.ReceiptID = "" Then Exit Sub
    '        td = New TableCell
    '        With td
    '            .Font.Bold = True
    '        End With
    '        td.Text = tmp.ReceiptID
    '        tr.Cells.Add(td)

    '        td = New TableCell
    '        With td
    '            .Font.Bold = True
    '        End With
    '        td.Text = tmp.ReceiptREvision
    '        tr.Cells.Add(td)

    '        td = New TableCell
    '        With td
    '            .Font.Bold = True
    '        End With
    '        td.Text = tmp.t_cprj
    '        tr.Cells.Add(td)

    '        td = New TableCell
    '        With td
    '            .Font.Bold = True
    '        End With
    '        td.Text = tmp.LOTItem & "  -  " & tmp.Itemdescription
    '        tr.Cells.Add(td)

    '        'Dim Dataa As SIS.DB.PRED_Information = SIS.DB.PRED_Information.GetPREDDATA(tmp.ReceiptID, tmp.ReceiptREvision)

    '        'td = New TableCell

    '        'td.Text = tmp.Itemdescription
    '        'tr.Cells.Add(td)


    '        td = New TableCell
    '        td.Text = tmp.Receipt_State
    '        tr.Cells.Add(td)


    '        td = New TableCell
    '        td.Text = tmp.ReceiptDate
    '        tr.Cells.Add(td)


    '        td = New TableCell
    '        td.Text = tmp.SentDate
    '        tr.Cells.Add(td)

    '        td = New TableCell
    '        td.Text = tmp.t_bpid & " - " & tmp.Sname
    '        tr.Cells.Add(td)

    '        td = New TableCell
    '        td.Text = tmp.t_user & " - " & tmp.ename
    '        tr.Cells.Add(td)

    '        td = New TableCell
    '        td.Text = tmp.t_orno
    '        tr.Cells.Add(td)

    '        tbl.Rows.Add(tr)


    '    Next
    '    '================
    '    pnl_POSTDetails.Controls.Add(tbl)

    'End Sub
    Private Sub ShowTData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.Transmittal_Information) = SIS.DB.Transmittal_Information.GetTRANSDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
        If Data.Count = 0 Then Exit Sub
        Dim tbl As New Table
        With tbl
            .GridLines = GridLines.Both
            .BorderWidth = 2
            .CellSpacing = 2
            .Width = Unit.Percentage(100)
            .CssClass = "table-success"
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
        td.Text = "TRANS ID"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "DOC ID"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "REVISION"
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
        td.Text = "SUBJECT"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "CREATOR"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "CREATOR REMARKS"
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
        td.Text = "APPROVER REMARKS"
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
        td.Text = "ISSUE DATE"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "ISSUED VIA"
        tr.Cells.Add(td)



        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "ISSUER REMARKS"
        tr.Cells.Add(td)



        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.Transmittal_Information In Data
            I += 1
            tr = New TableRow

            td = New TableCell
            td.Text = I
            tr.Cells.Add(td)


            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_tran
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_docn
            tr.Cells.Add(td)




            td = New TableCell
            With td
                .Font.Bold = True
            End With

            td.Text = tmp.t_revn
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_type
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_subj
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.creator
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.creator_remarks
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.Approver
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.approver_remarks
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_stat
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.issuedate
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.issuedvia
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.issuer_remarks
            tr.Cells.Add(td)


            'td = New TableCell
            'td.Text = tmp.t_isdt
            'tr.Cells.Add(td)



            tbl.Rows.Add(tr)


        Next
        '================
        pnl_TDetails.Controls.Add(tbl)

    End Sub

    Private Sub ShowDData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.DCR_Information) = SIS.DB.DCR_Information.GetDCRDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
        If Data.Count = 0 Then Exit Sub
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
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "DCR ID"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "DOC ID"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "REVISION"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "DCR DESCRIPTION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(10)
    End With
    td.Text = "DCR STATE"
    tr.Cells.Add(td)


    td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "SUBJECT"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "REQUEST PRIORITY"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "COMPONENT STATUS"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "CREATOR"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "CREATOR REMARKS"
        tr.Cells.Add(td)




        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "DCR CATEGORY"
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
        td.Text = "APPROVER REMARKS"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "APPROVED DATE"
        tr.Cells.Add(td)





        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.DCR_Information In Data
            I += 1
            tr = New TableRow




            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_dcrn
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_docd
            tr.Cells.Add(td)




            td = New TableCell
            With td
                .Font.Bold = True
            End With

            td.Text = tmp.t_revn
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_dsca
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_stat
      tr.Cells.Add(td)

      td = New TableCell
            td.Text = tmp.element
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_reqs
            tr.Cells.Add(td)


            td = New TableCell
            td.Text = tmp.t_comp
            tr.Cells.Add(td)


            td = New TableCell
            td.Text = tmp.creator
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.User_remarks
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_catg
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.approver
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.Approver_remarks
            tr.Cells.Add(td)








            td = New TableCell
            td.Text = tmp.t_appt
            tr.Cells.Add(td)

            tbl.Rows.Add(tr)


        Next
        '================
        pnl_DDetails.Controls.Add(tbl)

    End Sub

    Private Sub ShowPData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.PMDL_Information) = SIS.DB.PMDL_Information.GetPMDLDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
        If Data.Count = 0 Then Exit Sub
        Dim tbl As New Table
        With tbl
            .GridLines = GridLines.Both
            .BorderWidth = 2
            .CellSpacing = 2
            .Width = Unit.Percentage(100)
            .CssClass = "table-primary"
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
        td.Text = "TYPE"
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
        td.Text = "DOC ID"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "REVISION"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "DRAFTING HOURS"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "CHECKER HOURS"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "ENGINEER HOURS"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "LEAD MANAGER HOURS"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "BASELINE START DATE"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "BASELINE FINISH DATE"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "REVISED FINISH DATE"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "ACTUAL RELEASE DATE"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "GENERATION METHOD"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "DRAWING TYPE"
        tr.Cells.Add(td)




        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.PMDL_Information In Data
            I += 1
            tr = New TableRow

            td = New TableCell
            td.Text = I
            tr.Cells.Add(td)


            td = New TableCell
            td.Text = tmp.t_pcod
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_cprj
            tr.Cells.Add(td)




            td = New TableCell
            With td
                .Font.Bold = True
            End With

            td.Text = tmp.t_docn
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_revn
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_dhrs
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_chrs
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_ehrs
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_lmhr
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_bssd
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_bsfd
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_rsfd
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_acdt
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_genm
            tr.Cells.Add(td)


            td = New TableCell
            td.Text = tmp.t_dwgs
            tr.Cells.Add(td)



            tbl.Rows.Add(tr)


        Next
        '================
        pnl_pDetails.Controls.Add(tbl)

    End Sub

    Private Sub ShowMData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.MANHOUR_Information) = SIS.DB.MANHOUR_Information.GetMANHOURDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
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
        td.Text = "EMPLOYEE NAME"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "GROUP"
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
        td.Text = "REVISION NO"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "WORKED ON"
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
        td.Text = "ACTIVITY"
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
        td.Text = "ENTRY ON DATE"
        tr.Cells.Add(td)






        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.MANHOUR_Information In Data
            I += 1
            tr = New TableRow

            td = New TableCell
            td.Text = I
            tr.Cells.Add(td)


            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_emno & " - " & tmp.t_empname
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_grcd
            tr.Cells.Add(td)




            td = New TableCell
            With td
                .Font.Bold = True
            End With

            td.Text = tmp.t_cdoc
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_dsrv
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_tdat
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_hhrs
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_acid
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_remk
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_edat
            tr.Cells.Add(td)





            tbl.Rows.Add(tr)


        Next
        '================
        pnl_MDetails.Controls.Add(tbl)

    End Sub

    <System.Web.Services.WebMethod()>
    <System.Web.Script.Services.ScriptMethod()>
    Private Sub ShowV2BData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.V2B_Information) = SIS.DB.V2B_Information.GetV2BDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
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
        td.Text = "SRNO"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "PROCESS NAME"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "LOG DETAILS"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "JOB CREATED BY"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "HOSTNAME"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "CREATED ON"
        tr.Cells.Add(td)

        'td = New TableCell
        'With td
        '    .Font.Bold = True
        '    .Font.Size = FontUnit.Point(10)
        'End With
        'td.Text = "STEP DESCRIPTION"
        'tr.Cells.Add(td)





        tbl.Rows.Add(tr)

        Dim I As Integer = 0
        '================
        For Each tmp As SIS.DB.V2B_Information In Data
            I += 1
            tr = New TableRow

            td = New TableCell
            td.Text = I
            tr.Cells.Add(td)


            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.Srno
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.Processname
            If td.Text.IndexOf("BomXPort-F:\Temp\Test1") > -1 Then

                td.Text = "BOM Export - Processor 1"
                tr.BackColor = Drawing.Color.LightYellow
                'With td
                '    .Font.Bold = True
                'End With


            End If

            If td.Text.IndexOf("BomXPort-F:\Temp\Test2") > -1 Then
                td.Text = "BOM Export - Processor 2"
                tr.BackColor = Drawing.Color.LightYellow
                'With td
                '    .Font.Bold = True
                'End With


            End If



            If td.Text.IndexOf("VaultToBaaN") > -1 Then
                td.Text = "VaultToBaaN - XML Validator"
                tr.BackColor = Drawing.Color.Red
                'With td
                '    .Font.Bold = True
                'End With


            End If



            tr.Cells.Add(td)




            td = New TableCell
            With td
                .Font.Bold = True
            End With

            td.Text = tmp.StepError

            If td.Text.IndexOf("Imported") > -1 Then

                tr.BackColor = Drawing.Color.Green
                With td
                    .Font.Bold = True

                End With


            End If

            If td.Text.IndexOf("Document Closed") > -1 Then

                tr.BackColor = Drawing.Color.LightYellow
                With td
                    .Font.Bold = True

                End With
                td.Text = "Completed :- Document Closed."

            End If



            If td.Text.IndexOf("Error") > -1 Then
                tr.BackColor = Drawing.Color.Red
                With td
                    .Font.Bold = True

                End With


            End If
            If td.Text.IndexOf(".xml :") > -1 Then
                tr.BackColor = Drawing.Color.Orange
                With td
                    .Font.Bold = True

                End With
                td.Text = "Reason:- " & tmp.StepError

            End If



            If td.Text.IndexOf("Processing") > -1 Then
                tr.BackColor = Drawing.Color.LightYellow
                With td
                    .Font.Bold = True

                End With
                td.Text = "Started :- Processing For drawing file."


            End If

            If td.Text.IndexOf("Importing") > -1 Then
                tr.BackColor = Drawing.Color.Yellow
                With td
                    .Font.Bold = True

                End With


            End If



            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.Job_CreatedBy
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.Job_UserID
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.CreatedOn
            tr.Cells.Add(td)

            'td = New TableCell
            'td.Text = tmp.StepDescription
            'tr.Cells.Add(td)







            tbl.Rows.Add(tr)


        Next
        '================
        pnl_v2bdetails.Controls.Add(tbl)

    End Sub
    Private Sub ShowSData(ByVal DocumentID As String, ByVal RevisionNo As String)
        Dim Data As List(Of SIS.DB.SAR_Information) = SIS.DB.SAR_Information.GetSARDATA(DocumentID, RevisionNo)

        DocumentID = F_t_docn.Text.ToUpper()
        F_t_docn.Text = DocumentID
        RevisionNo = F_t_revn.Text


        If DocumentID = "" Then Exit Sub
        If Data.Count = 0 Then Exit Sub
        Dim tbl As New Table
        With tbl
            .GridLines = GridLines.Both
            .BorderWidth = 2
            .CellSpacing = 2
            .Width = Unit.Percentage(100)
            .CssClass = "table-secondary"
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
        td.Text = "Project ID"
        tr.Cells.Add(td)


        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "SAR NO."
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
        td.Text = "CREATION DATE"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "ISSUE DATE"
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
        td.Text = "NATURE OF THE PROBLEM"
        tr.Cells.Add(td)

        td = New TableCell
        With td
            .Font.Bold = True
            .Font.Size = FontUnit.Point(10)
        End With
        td.Text = "SAR SEVERITY"
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
        td.Text = "REVIEWED BY"
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
        For Each tmp As SIS.DB.SAR_Information In Data
            I += 1
            tr = New TableRow

            td = New TableCell
            td.Text = I
            tr.Cells.Add(td)


            td = New TableCell
            td.Text = tmp.t_cprj
            tr.Cells.Add(td)

            td = New TableCell
            With td
                .Font.Bold = True
            End With
            td.Text = tmp.t_sarn
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_stat
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_cdat
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_idat
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_draw
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_natp
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_sars
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_prep
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_rper
            tr.Cells.Add(td)

            td = New TableCell
            td.Text = tmp.t_apby
            tr.Cells.Add(td)


            tbl.Rows.Add(tr)


        Next
        '================
        pnl_SDetails.Controls.Add(tbl)

    End Sub

  'Private Sub cmdSubmitV2B_Click(sender As Object, e As EventArgs) Handles cmdSubmitV2B.Click
  '  ' sd.Visible = False
  '  'vi.Visible = True
  '  poi.Visible = False
  '  found.Visible = False
  '  mi.Visible = False
  '  pi.Visible = False
  '  ii.Visible = False
  '  ti.Visible = False
  '  di.Visible = False
  '  si.Visible = False
  '  reci.Visible = False
  '  repi.Visible = False
  '  repd.Visible = False
  '  bom.Visible = False
  '  partbom.Visible = False
  '  ref.Visible = False
  '  dwg.Visible = False
  '  'v2bheading.Text = "Last 1000 Documents Transferred from Autodesk Vault to ERPLN"
  '  'ShowVRData()
  'End Sub

  'Private Sub cmdsubmitsd_Click(sender As Object, e As EventArgs) Handles cmdsubmitsd.Click
  '  'sd.Visible = True
  '  'vi.Visible = False
  '  poi.Visible = False
  '  found.Visible = False
  '  mi.Visible = False
  '  pi.Visible = False
  '  ii.Visible = False
  '  ti.Visible = False
  '  di.Visible = False
  '  si.Visible = False
  '  reci.Visible = False
  '  repi.Visible = False
  '  repd.Visible = False
  '  bom.Visible = False
  '  partbom.Visible = False
  '  ref.Visible = False
  '  dwg.Visible = False
  '  sdheading.Text = "Standard Document Master"
  '  ShowsdData()
  'End Sub
End Class