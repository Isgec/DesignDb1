Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DB
    <DataObject()>
    Partial Public Class DBDocumentDB
        Public Property DocumentID As String = ""
        Public Property Document_Rev As String = ""
        Public Property Tittle_001 As String = ""
        Public Property Drawing_File_Name_001 As String = ""
        Public Property Drawing_State_001 As String = ""
        Public Property Workflow_Status_001 As String = ""
        Public Property Responsible_001 As String = ""
        Public Property Document_Date_001 As String = ""
        Public Property Drawing_Weight_001 As String = ""

        Public Property Sumofitems_Weight_002 As String = ""
        Public Property Drawing_Scale_001 As String = ""
        Public Property Sheet_Size_001 As String = ""
        Public Property Element_001 As String = ""
        Public Property Drawn_By_001 As String = ""
        Public Property Checked_By_001 As String = ""
        Public Property Approved_By_001 As String = ""
        Public Property Document_Type As String = ""
        Public Property Division As String = ""
        Public Property Submitted_Time As String = ""
        Public Property User_Name As String = ""
        Public Property Review_By As String = ""
        Public Property EApproved_BY As String = ""
        Public Property ISGEC_DATA_Source As String = ""
        Public Property doc_releasedate As String = ""
        Public Property For_Erection As String = ""
        Public Property For_Information As String = ""
        Public Property For_Production As String = ""
        Public Property For_Approval As String = ""
        Public Property SoftwareUsed As String = ""
        Public Property MachineName As String = ""
        Public Property ProjectID As String = ""
        Public Property Client As String = ""
        Public Property Consultant As String = ""
        Public Property Year As String = ""
        Public Property IWT As String = ""
        Public Property Project_Service As String = ""
        Public Property IndentNumber As String = ""
        Public Property IndentDate As String = ""
        Public Property IndentRequester As String = ""
        Public Property IndentRequestername As String = ""
        Public Property PONumber As String = ""
        Public Property PODate As String = ""
        Public Property POsupplier As String = ""
        Public Property POsuppliername As String = ""
        Public Property POBuyer As String = ""
        Public Property POBuyername As String = ""
        Public Property Transmittalid As String = ""

        Public Property SUBMITTEDBY_Name As String = ""
        Public Property REVIEWEDBY_NAME As String = ""
        Public Property APPROVEDBY_NAME As String = ""
        Public Property Element_desc As String = ""
        Public Property Vaultstatus As String = ""
        'Public Property t_docn As String = ""
        'Public Property t_revn As String = ""
        'Public Property t_srno As String = ""
        'Public Property t_item As String = ""
        'Public Property t_dsca As String = ""
        'Public Property t_citg As String = ""
        'Public Property t_qnty As String = ""
        'Public Property t_wght As String = ""
        'Public Property t_itmt As String = ""
        'Public Property t_txta As String = ""
        'Public Property t_txtb As String = ""
        'Public Property t_cuni As String = ""
        'Public Property t_oitm As String = ""
        'Public Property t_elem As String = ""
        'Public Property t_Refcntd As String = ""
        'Public Property t_Refcntu As String = ""
        'Public Property t_sitm As String = ""


        Public Shared Function GetDocumentDB(ByVal DocumentID As String, ByVal RevisionNo As String) As DBDocumentDB
            If DocumentID = "" Then Return Nothing
            Dim mRet As New DBDocumentDB

            mRet.DocumentID = DocumentID
            mRet.Document_Rev = RevisionNo




            Dim Sql As String = ""
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
                Con.Open()
                If RevisionNo = "" Then



                    Sql = " select t_dttl"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn)from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Tittle_001 = Cmd.ExecuteScalar
                    End Using


                    Sql = " select t_revn"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Document_Rev = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_dsca"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Drawing_File_Name_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (case t_stat when 1 then 'Submitted' when 2 then 'Item Released' when 3 then 'Drawing Released' when 4 then 'Expired' end)		as 	Drawing_State"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Drawing_State_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (case t_wfst when 1 then 'Under Design' when 2 then 'Submitted' when 3 then 'Under Review' when 4 then 'Under Approval' when 5 then 'Released'"
                    Sql &= " when 6 then 'Withdrawn' when 7 then 'Under Revision' when 8 then 'Superceded' when 9 then 'under DCR'  end)"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Workflow_Status_001 = Cmd.ExecuteScalar
                    End Using



                    Sql = " select t_type"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Document_Type = Cmd.ExecuteScalar
                    End Using



                    Sql = " select t_resp"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Responsible_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_date"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Document_Date_001 = Cmd.ExecuteScalar
                    End Using


                    Sql = " select t_wght"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Drawing_Weight_001 = Cmd.ExecuteScalar
                    End Using


                    Sql = " Select ISNULL(sum(t_wght),'0') From tdmisg002200 where t_docn In ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "
                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Sumofitems_Weight_002 = Cmd.ExecuteScalar
                    End Using


                    Sql = " select t_scal"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Drawing_Scale_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_size"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Sheet_Size_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_cspa"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Element_001 = Cmd.ExecuteScalar
                    End Using


                    Sql = "  SELECT (select t_desc from ttppdm090200 where aa.t_cspa=ttppdm090200.t_cspa)  From tdmisg001200 as aa where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Element_desc = Cmd.ExecuteScalar
                    End Using







                    Sql = " select t_drwb"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Drawn_By_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_chkb"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Checked_By_001 = Cmd.ExecuteScalar
                    End Using



                    Sql = " select t_appb"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Approved_By_001 = Cmd.ExecuteScalar
                    End Using




                    Sql = " select t_sdat"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Submitted_Time = Cmd.ExecuteScalar
                    End Using


                    Sql = " select t_user"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.User_Name = Cmd.ExecuteScalar
                    End Using



          Sql = " SELECT ISNULL((select t_nama from ttccom001200 where t_loco=tdmisg001200.t_user),'-') as SUBMITTEDBY_Name  From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

          Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.SUBMITTEDBY_Name = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_rusr From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Review_By = Cmd.ExecuteScalar
                    End Using

          Sql = " SELECT ISNULL((select t_nama from ttccom001200 where t_emno=tdmisg001200.t_rusr),'-') as REVIEWEDBY_NAME From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

          Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.REVIEWEDBY_NAME = Cmd.ExecuteScalar
                    End Using



                    Sql = " select t_ausr From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.EApproved_BY = Cmd.ExecuteScalar
                    End Using

          Sql = " SELECT ISNULL((select t_nama from ttccom001200 where t_emno=tdmisg001200.t_ausr),'-') as APPROVEDBY_NAME  From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

          Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.APPROVEDBY_NAME = Cmd.ExecuteScalar
                    End Using






                    Sql = " select t_sorc"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.ISGEC_DATA_Source = Cmd.ExecuteScalar
                    End Using

                    Sql = " SELECT (convert(date, dateadd(n,330,t_drdt))) From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "


                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.doc_releasedate = Cmd.ExecuteScalar
                    End Using


                    Sql = " select t_grup"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Division = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (case t_erec when 1 then 'Yes' when 2 then 'No' end)"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.For_Erection = Cmd.ExecuteScalar
                    End Using


                    Sql = " select (case t_info when 1 then 'Yes' when 2 then 'No' end)"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.For_Information = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (case t_prod when 1 then 'Yes' when 2 then 'No' end)"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.For_Production = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (case t_appr when 1 then 'Yes' when 2 then 'No' end)"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.For_Approval = Cmd.ExecuteScalar
                    End Using


                    Sql = " select t_soft"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.SoftwareUsed = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_mach"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.MachineName = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_cprj"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.ProjectID = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_clnt"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Client = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_cnsl"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Consultant = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_year"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Year = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_iwtn"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.IWT = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (t_ser1 + ' ' + t_ser2)	as 	Project_Service"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Project_Service = Cmd.ExecuteScalar
                    End Using

                    Sql = "  Select distinct t_rqno from ttdisg003200 "
                    Sql &= " where t_docn in ('" & DocumentID & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.IndentNumber = Cmd.ExecuteScalar
                    End Using



                    Sql = "  Select t_rdat from ttdpur200200  "
                    Sql &= " where t_rqno in ('" & mRet.IndentNumber & "')"

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.IndentDate = Cmd.ExecuteScalar
                    End Using

                    Sql = "  Select t_remn from ttdpur200200  "
                    Sql &= " where t_rqno in ('" & mRet.IndentNumber & "')"

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.IndentRequester = Cmd.ExecuteScalar
                    End Using

                    Sql = "  Select (select t_nama from ttccom001200 where t_emno=ttdpur200200.t_remn) from ttdpur200200  where t_rqno in ('" & mRet.IndentNumber & "')"


                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.IndentRequestername = Cmd.ExecuteScalar
                    End Using

                    Sql = "  Select distinct t_orno from ttdisg002200 "
                    Sql &= " where t_docn in ('" & DocumentID & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.PONumber = Cmd.ExecuteScalar
                    End Using



                    Sql = "  Select t_odat from ttdpur400200  "
                    Sql &= " where t_orno in ('" & mRet.PONumber & "')"

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.PODate = Cmd.ExecuteScalar
                    End Using

                    Sql = "  Select t_sfbp from ttdpur400200  "
                    Sql &= " where t_orno in ('" & mRet.PONumber & "')"

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.POsupplier = Cmd.ExecuteScalar
                    End Using

                    Sql = "  Select t_nama from ttccom100200  "
                    Sql &= " where t_bpid in ('" & mRet.POsupplier & "')"

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.POsuppliername = Cmd.ExecuteScalar
                    End Using


                    Sql = "  Select t_ccon from ttdpur400200  "
                    Sql &= " where t_orno in ('" & mRet.PONumber & "')"

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.POBuyer = Cmd.ExecuteScalar
                    End Using




                    Sql = "  Select (select t_nama from ttccom001200 where t_emno=ttdpur400200.t_ccon) from ttdpur400200  where t_orno in ('" & mRet.PONumber & "')"

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.POBuyername = Cmd.ExecuteScalar
                    End Using



                    Sql = "  select t_tran from tdmisg132200  "
                    Sql &= " where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg132200 where t_docn in ('" & DocumentID & "')) "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Transmittalid = Cmd.ExecuteScalar
                    End Using
                Else

                    Sql = " select t_dttl"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Tittle_001 = Cmd.ExecuteScalar
                    End Using


                    Sql = " select t_revn"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Document_Rev = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_dsca"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Drawing_File_Name_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (case t_stat when 1 then 'Submitted' when 2 then 'Item Released' when 3 then 'Drawing Released' when 4 then 'Expired' end)		as 	Drawing_State"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Drawing_State_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (case t_wfst when 1 then 'Under Design' when 2 then 'Submitted' when 3 then 'Under Review' when 4 then 'Under Approval' when 5 then 'Released'"
                    Sql &= " when 6 then 'Withdrawn' when 7 then 'Under Revision' when 8 then 'Superceded' when 9 then 'under DCR'  end)"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Workflow_Status_001 = Cmd.ExecuteScalar
                    End Using



                    Sql = " select t_type"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Document_Type = Cmd.ExecuteScalar
                    End Using



                    Sql = " select t_resp"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Responsible_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_date"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Document_Date_001 = Cmd.ExecuteScalar
                    End Using


                    Sql = " select t_wght"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Drawing_Weight_001 = Cmd.ExecuteScalar
                    End Using


                    Sql = " Select ISNULL(sum(t_wght),'0') From tdmisg002200 where t_docn In ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "
                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Sumofitems_Weight_002 = Cmd.ExecuteScalar
                    End Using


                    Sql = " select t_scal"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Drawing_Scale_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_size"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Sheet_Size_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_cspa From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Element_001 = Cmd.ExecuteScalar
                    End Using



                    Sql = "  SELECT (select t_desc from ttppdm090200 where aa.t_cspa=ttppdm090200.t_cspa)  From tdmisg001200 as aa where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Element_desc = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_drwb"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Drawn_By_001 = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_chkb"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Checked_By_001 = Cmd.ExecuteScalar
                    End Using



                    Sql = " select t_appb"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Approved_By_001 = Cmd.ExecuteScalar
                    End Using



                    Sql = " select t_sdat"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Submitted_Time = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_user"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.User_Name = Cmd.ExecuteScalar
                    End Using

                    Sql = " SELECT ISNULL((select t_nama from ttccom001200 where t_emno=tdmisg001200.t_user),'-')  From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.SUBMITTEDBY_Name = Cmd.ExecuteScalar
                    End Using





                    Sql = " select t_rusr"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Review_By = Cmd.ExecuteScalar
                    End Using


                    Sql = " SELECT ISNULL((select t_nama from ttccom001200 where t_emno=tdmisg001200.t_rusr),'-') From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.REVIEWEDBY_NAME = Cmd.ExecuteScalar
                    End Using



                    Sql = " select t_ausr"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.EApproved_BY = Cmd.ExecuteScalar
                    End Using

                    Sql = " SELECT ISNULL((select t_nama from ttccom001200 where t_emno=tdmisg001200.t_ausr),'-')  From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.APPROVEDBY_NAME = Cmd.ExecuteScalar
                    End Using



                    Sql = " select t_sorc"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.ISGEC_DATA_Source = Cmd.ExecuteScalar
                    End Using



                    Sql = " SELECT (convert(date, dateadd(n,330,t_drdt))) From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "


                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.doc_releasedate = Cmd.ExecuteScalar
                    End Using


                    Sql = " select t_grup"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Division = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (case t_erec when 1 then 'Yes' when 2 then 'No' end)"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.For_Erection = Cmd.ExecuteScalar
                    End Using


                    Sql = " select (case t_info when 1 then 'Yes' when 2 then 'No' end)"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.For_Information = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (case t_prod when 1 then 'Yes' when 2 then 'No' end)"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.For_Production = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (case t_appr when 1 then 'Yes' when 2 then 'No' end)"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.For_Approval = Cmd.ExecuteScalar
                    End Using


                    Sql = " select t_soft"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.SoftwareUsed = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_mach"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.MachineName = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_cprj"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.ProjectID = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_clnt"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Client = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_cnsl"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Consultant = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_year"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Year = Cmd.ExecuteScalar
                    End Using

                    Sql = " select t_iwtn"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.IWT = Cmd.ExecuteScalar
                    End Using

                    Sql = " select (t_ser1 + ' ' + t_ser2)	as 	Project_Service"
                    Sql &= " From tdmisg001200 where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Project_Service = Cmd.ExecuteScalar
                    End Using

                    'Sql = "  Select distinct t_rqno from ttdisg003200 "
                    'Sql &= " where t_docn in ('" & DocumentID & "') "

                    'Using Cmd As SqlCommand = Con.CreateCommand()
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = Sql
                    '    mRet.IndentNumber = Cmd.ExecuteScalar
                    'End Using



                    'Sql = "  Select t_rdat from ttdpur200200  "
                    'Sql &= " where t_rqno in ('" & mRet.IndentNumber & "')"

                    'Using Cmd As SqlCommand = Con.CreateCommand()
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = Sql
                    '    mRet.IndentDate = Cmd.ExecuteScalar
                    'End Using

                    'Sql = "  Select t_remn from ttdpur200200  "
                    'Sql &= " where t_rqno in ('" & mRet.IndentNumber & "')"

                    'Using Cmd As SqlCommand = Con.CreateCommand()
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = Sql
                    '    mRet.IndentRequester = Cmd.ExecuteScalar
                    'End Using

                    'Sql = "  Select (select t_nama from ttccom001200 where t_emno=ttdpur200200.t_remn) from ttdpur200200  where t_rqno in ('" & mRet.IndentNumber & "')"


                    'Using Cmd As SqlCommand = Con.CreateCommand()
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = Sql
                    '    mRet.IndentRequestername = Cmd.ExecuteScalar
                    'End Using

                    'Sql = "  Select distinct t_orno from ttdisg002200 "
                    'Sql &= " where t_docn in ('" & DocumentID & "') "

                    'Using Cmd As SqlCommand = Con.CreateCommand()
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = Sql
                    '    mRet.PONumber = Cmd.ExecuteScalar
                    'End Using

                    'Sql = "  Select t_odat from ttdpur400200  "
                    'Sql &= " where t_orno in ('" & mRet.PONumber & "')"

                    'Using Cmd As SqlCommand = Con.CreateCommand()
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = Sql
                    '    mRet.PODate = Cmd.ExecuteScalar
                    'End Using

                    'Sql = "  Select t_sfbp from ttdpur400200  "
                    'Sql &= " where t_orno in ('" & mRet.PONumber & "')"

                    'Using Cmd As SqlCommand = Con.CreateCommand()
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = Sql
                    '    mRet.POsupplier = Cmd.ExecuteScalar
                    'End Using

                    'Sql = "  Select t_nama from ttccom100200  "
                    'Sql &= " where t_bpid in ('" & mRet.POsupplier & "')"

                    'Using Cmd As SqlCommand = Con.CreateCommand()
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = Sql
                    '    mRet.POsuppliername = Cmd.ExecuteScalar
                    'End Using


                    'Sql = "  Select t_ccon from ttdpur400200  "
                    'Sql &= " where t_orno in ('" & mRet.PONumber & "')"

                    'Using Cmd As SqlCommand = Con.CreateCommand()
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = Sql
                    '    mRet.POBuyer = Cmd.ExecuteScalar
                    'End Using

                    'Sql = "  Select (select t_nama from ttccom001200 where t_emno=ttdpur400200.t_ccon) from ttdpur400200  where t_orno in ('" & mRet.PONumber & "')"

                    'Using Cmd As SqlCommand = Con.CreateCommand()
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = Sql
                    '    mRet.POBuyername = Cmd.ExecuteScalar
                    'End Using


                    Sql = "  select t_tran from tdmisg132200  "
                    Sql &= " where t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "

                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Transmittalid = Cmd.ExecuteScalar
                    End Using
                End If

            End Using


            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetVaultConnectionString())
                    Con.Open()


                    Sql = " Select  "

                    Sql &= " fi.LifeCycleStateName                                                                                 "
                        Sql &= "                       From dbo.FileIteration AS fi                                                     "
                        Sql &= " INNER Join dbo.FileResource AS fr ON fr.ResourceId = fi.ResourceId                                    "
                        Sql &= " INNER Join dbo.Iteration AS i ON fi.FileIterationId = i.IterationID                                    "
                        Sql &= " INNER Join dbo.Entity AS e ON i.IterationID = e.EntityId                                              "
                        Sql &= " INNER Join dbo.v_User AS uf ON uf.UserGroupID = e.CreateUserID                                         "
                        Sql &= " INNER Join dbo.Master AS m ON m.MasterID = i.MasterID                                                 "
                        Sql &= " INNER Join dbo.FileMaster AS fm ON fm.FileMasterID = m.MasterID                                        "
                        Sql &= " INNER Join dbo.FileIteration AS fit ON fit.FileIterationId = m.TipIterationID                         "
                        Sql &= " Left OUTER JOIN dbo.ContentSourceIndexStatus AS csis ON csis.EntityId = fit.ResourceId                 "
                        Sql &= " Left OUTER JOIN dbo.Revision AS r ON i.RevisionId = r.RevisionId                                      "
                        Sql &= " Left OUTER JOIN dbo.LifeCycleState AS lcs ON r.LifeCycleStateId = lcs.LifeCycleStateId                 "
                        Sql &= "                                                                                                       "
                    Sql &= " where FI.filename Like ('" & DocumentID & "%') AND I.IterationNumber=(     "
                    Sql &= " SELECT                                                                                                "
                        Sql &= "                                                                                                        "
                        Sql &= " MAX(i.IterationNumber)                                                                                "
                        Sql &= "                                                                                                        "
                        Sql &= "                       From dbo.FileIteration AS fi                                                    "
                        Sql &= " INNER Join dbo.FileResource AS fr ON fr.ResourceId = fi.ResourceId                                     "
                        Sql &= " INNER Join dbo.Iteration AS i ON fi.FileIterationId = i.IterationID                                   "
                        Sql &= " INNER Join dbo.Entity AS e ON i.IterationID = e.EntityId                                               "
                        Sql &= " INNER Join dbo.v_User AS uf ON uf.UserGroupID = e.CreateUserID                                        "
                        Sql &= " INNER Join dbo.Master AS m ON m.MasterID = i.MasterID                                                  "
                        Sql &= " INNER Join dbo.FileMaster AS fm ON fm.FileMasterID = m.MasterID                                       "
                        Sql &= " INNER Join dbo.FileIteration AS fit ON fit.FileIterationId = m.TipIterationID                          "
                        Sql &= " Left OUTER JOIN dbo.ContentSourceIndexStatus AS csis ON csis.EntityId = fit.ResourceId                "
                        Sql &= " Left OUTER JOIN dbo.Revision AS r ON i.RevisionId = r.RevisionId                                       "
                        Sql &= " Left OUTER JOIN dbo.LifeCycleState AS lcs ON r.LifeCycleStateId = lcs.LifeCycleStateId                "
                        Sql &= "                                                                                                        "
                    Sql &= " where FI.filename Like ('" & DocumentID & "%')                                                   "
                    Sql &= " )                                                                                                      "






                    Using Cmd As SqlCommand = Con.CreateCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql
                        mRet.Vaultstatus = Cmd.ExecuteScalar
                    End Using
                End Using

            Return mRet
        End Function
        Public Sub New(ByVal Reader As SqlDataReader)
            Try
                For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                    If pi.MemberType = Reflection.MemberTypes.Property Then
                        Try
                            Dim Found As Boolean = False
                            For I As Integer = 0 To Reader.FieldCount - 1
                                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                                    Found = True
                                    Exit For
                                End If
                            Next
                            If Found Then
                                If Convert.IsDBNull(Reader(pi.Name)) Then
                                    Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                                        Case "decimal"
                                            CallByName(Me, pi.Name, CallType.Let, "0.00")
                                        Case "bit"
                                            CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                                        Case Else
                                            CallByName(Me, pi.Name, CallType.Let, String.Empty)
                                    End Select
                                Else
                                    CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Public Sub New()
        End Sub
    End Class
  Public Class BOM_Information
    Public Property DocumentID As String = ""
    Public Property t_docn As String = ""
    Public Property t_revn As String = ""
    Public Property Document_rev As String = ""
    Public Property t_srno As String = ""
    Public Property t_item As String = ""
    Public Property t_dsca As String = ""
    Public Property t_citg As String = ""
    Public Property t_qnty As String = ""
    Public Property t_wght As String = ""
    Public Property t_itmt As String = ""
    Public Property t_cuni As String = ""
    Public Property t_oitm As String = ""
    Public Property t_elem As String = ""





    Public Shared Function GetBOMDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.BOM_Information)


      If DocumentID = "" Then Return Nothing
      Dim mRetd As New List(Of SIS.DB.BOM_Information)



      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        If RevisionNo = "" Then

          Sql = " Select [t_docn],[t_revn],[t_srno],[t_item],[t_dsca],[t_citg],[t_qnty],[t_wght],[t_itmt],[t_cuni],[t_oitm],[t_elem] "
          Sql &= "       From tdmisg002200 "
          Sql &= "  where   t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "
        Else
          Sql = " Select [t_docn],[t_revn],[t_srno],[t_item],[t_dsca],[t_citg],[t_qnty],[t_wght],[t_itmt],[t_cuni],[t_oitm],[t_elem] "
          Sql &= "       From  tdmisg002200 "
          Sql &= "  where   t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "
        End If

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 5000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            mRetd.Add(New BOM_Information(rd))
          End While
        End Using
      End Using

      Return mRetd
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
  Public Class Pa_Information
    Public Property DocumentNumber As String = ""
    Public Property Revision As String = ""
    Public Property SrNo As String = ""
    Public Property Item As String = ""
    Public Property PartItemSNo As String = ""
    Public Property PartNumber As String = ""
    Public Property PartDescription As String = ""
    Public Property Weight As String = ""
    Public Property Quantity As String = ""
    Public Property Specification As String = ""
    Public Property Size As String = ""
    Public Property Remark As String = ""
    Public Property MOCCode As String = ""

    Public Shared Function GetPADATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.Pa_Information)


      If DocumentID = "" Then Return Nothing
      Dim mRetd As New List(Of SIS.DB.Pa_Information)



      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        If RevisionNo = "" Then


          Sql = "Select DocumentNumber, Revision, SrNo, Item, PartItemSNo, PartNumber, PartDescription, Weight, Quantity, Specification, Size, Remark, MOCCode  FROM [inforerpdb].[dbo].[LN_PartItems]"
          Sql &= "  where   DocumentNumber in ('" & DocumentID & "') And Revision = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "
        Else
          Sql = "Select DocumentNumber, Revision, SrNo, Item, PartItemSNo, PartNumber, PartDescription, Weight, Quantity, Specification, Size, Remark, MOCCode  FROM [inforerpdb].[dbo].[LN_PartItems]"
          Sql &= "  where   DocumentNumber in ('" & DocumentID & "') And Revision = ('" & RevisionNo & "') "
        End If

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 5000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            mRetd.Add(New Pa_Information(rd))
          End While
        End Using
      End Using

      Return mRetd
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
  Public Class REF_Information
        Public Property t_drgt As String = ""
        Public Property t_dcfn As String = ""

        Public Shared Function GetREFDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.REF_Information)


            If DocumentID = "" Then Return Nothing
            Dim mRetd As New List(Of SIS.DB.REF_Information)



            Dim Sql As String = ""
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
                Con.Open()
                If RevisionNo = "" Then

                    Sql = " select t_drgt,t_dcfn from tdmisg003200 where t_docn in ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "


                Else
                    Sql = " select t_drgt,t_dcfn from tdmisg003200 "

                    Sql &= "  where   t_docn in ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "
                End If

                Using Cmd As SqlCommand = Con.CreateCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Cmd.CommandTimeout = 5000
                    Dim rd As SqlDataReader = Cmd.ExecuteReader
                    While rd.Read
                        mRetd.Add(New REF_Information(rd))
                    End While
                End Using
            End Using

            Return mRetd
        End Function
        Public Sub New(ByVal Reader As SqlDataReader)
            Try
                For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                    If pi.MemberType = Reflection.MemberTypes.Property Then
                        Try
                            Dim Found As Boolean = False
                            For I As Integer = 0 To Reader.FieldCount - 1
                                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                                    Found = True
                                    Exit For
                                End If
                            Next
                            If Found Then
                                If Convert.IsDBNull(Reader(pi.Name)) Then
                                    Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                                        Case "decimal"
                                            CallByName(Me, pi.Name, CallType.Let, "0.00")
                                        Case "bit"
                                            CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                                        Case Else
                                            CallByName(Me, pi.Name, CallType.Let, String.Empty)
                                    End Select
                                Else
                                    CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Public Sub New()
        End Sub
    End Class
  Public Class I_Information


    Public Property t_rqno As String = ""
    Public Property t_rdat As String = ""
    Public Property t_remn As String = ""
    Public Property indentor_name As String = ""


    Public Shared Function GetIDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.I_Information)


      If DocumentID = "" Then Return Nothing
      Dim mRetd As New List(Of SIS.DB.I_Information)



      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        If RevisionNo = "" Then

          'Sql = " Select t_rqno,t_rdat,t_remn,(Select t_nama from ttccom001200 where t_emno=ttdpur200200.t_remn) As  "
          'Sql &= " indentor_name From ttdpur200200 Where t_rqno in (Select  t_rqno from ttdisg003200 where t_docn in "
          'Sql &= " (select t_drgt from tdmisg003200 where t_docn In ('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')))) "


          Sql = "                  Select  t_rqno,t_rdat,t_remn,(Select t_nama from ttccom001200 where t_emno=ttdpur200200.t_remn) As   indentor_name From ttdpur200200  Where t_rqno In "

          Sql &= "(select distinct t_rqno from ttdisg003200 where t_docn in "

          Sql &= " (Select t_drgt from tdmisg003200 where t_docn=('" & DocumentID & "') and t_revn =(select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "'))) Or "
          Sql &= "(t_docn=('" & DocumentID & "')  and t_revi=(select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')))) "








        Else
          'Sql = " Select t_rqno,t_rdat,t_remn,(Select t_nama from ttccom001200 where t_emno=ttdpur200200.t_remn) As  "
          'Sql &= " indentor_name From ttdpur200200 Where t_rqno in (Select  t_rqno from ttdisg003200 where t_docn in "
          'Sql &= " (select t_drgt from tdmisg003200 where t_docn In ('" & DocumentID & "') And t_revn = ('" & RevisionNo & "')))) "
          Sql = "                  Select t_rqno,t_rdat,t_remn,(Select t_nama from ttccom001200 where t_emno=ttdpur200200.t_remn) As   indentor_name From ttdpur200200  Where t_rqno In "

          Sql &= "(select distinct t_rqno from ttdisg003200 where t_docn in "

          Sql &= " (Select t_drgt from tdmisg003200 where t_docn=('" & DocumentID & "') and t_revn =('" & RevisionNo & "')) Or "
          Sql &= "(t_docn=('" & DocumentID & "')  and t_revi=('" & RevisionNo & "'))) "



        End If

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 5000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            mRetd.Add(New I_Information(rd))
          End While
        End Using
      End Using

      Return mRetd
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class

  Public Class VR_Information


    Public Property t_docn As String = ""
    Public Property t_revn As String = ""
    Public Property t_dttl As String = ""
    Public Property t_sorc As String = ""
    Public Property t_sdat As String = ""
    Public Property t_user As String = ""
    Public Property t_usern As String = ""
    Public Property t_type As String = ""
    Public Property t_mach As String = ""
    Public Property t_name As String = ""
    Public Property t_wfst As String = ""
    Public Property t_stat As String = ""


    Public Shared Function GetVRDATA() As List(Of SIS.DB.VR_Information)



      Dim mRetd As New List(Of SIS.DB.VR_Information)



      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()



        Sql = " select top(1000) t_docn,t_revn,t_dttl,t_sorc,t_sdat,ISNULL((select t_nama from ttccom001200 where t_loco=tdmisg001200.t_user),'-') as t_usern, t_user, t_mach,t_type,t_name,(case t_wfst when 1 then 'Under Design' when 2 then 'Submitted' when 3 then 'Under Review' when 4 then 'Under Approval' when 5 then 'Released'"
        Sql &= " when 6 then 'Withdrawn' when 7 then 'Under Revision' when 8 then 'Superceded' when 9 then 'under DCR'  end) as t_wfst,(case t_stat when 1 then 'Submitted' when 2 then 'Item Released' when 3 then 'Drawing Released' when 4 then 'Expired' end)		as 	t_Stat from tdmisg001200 ORDER BY t_sdat DESC"


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 5000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            mRetd.Add(New VR_Information(rd))
          End While
        End Using
      End Using

      Return mRetd
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class

  Public Class SD_Information


    Public Property t_item As String = ""
    Public Property t_docn As String = ""
    Public Property t_revn As String = ""
    Public Property t_dsca As String = ""
    Public Property t_pdfn As String = ""
    Public Property t_dttl As String = ""
    Public Property t_cspa As String = ""
    Public Property t_wght As String = ""
    Public Property t_drwn As String = ""
    Public Property t_chck As String = ""
    Public Property t_aprb As String = ""


    Public Shared Function GetSDDATA() As List(Of SIS.DB.SD_Information)



      Dim mRetd As New List(Of SIS.DB.SD_Information)



      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()



        Sql = " select t_item,t_docn,t_revn,t_dsca,t_pdfn,t_dttl,t_cspa,t_wght,t_drwn,t_chck,t_aprb from tdmisg007200 order by t_docn"

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 5000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            mRetd.Add(New SD_Information(rd))
          End While
        End Using
      End Using

      Return mRetd
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
  Public Class PO_Information


        Public Property t_orno As String = ""
        Public Property t_odat As String = ""
        Public Property supplierID As String = ""
        Public Property Supplier_name As String = ""
        Public Property t_ccon As String = ""
        Public Property buyer As String = ""

        Public Shared Function GetPODATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.PO_Information)


            If DocumentID = "" Then Return Nothing
            Dim mRetd As New List(Of SIS.DB.PO_Information)



            Dim Sql As String = ""
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
                Con.Open()
                If RevisionNo = "" Then

                    'Sql = " Select t_orno,t_odat,t_sfbp As supplierID,(Select t_nama from ttccom100200 where t_bpid=ttdpur400200.t_sfbp) As Supplier_name,t_ccon, "
                    'Sql &= " (select t_nama from ttccom001200 where t_emno=ttdpur400200.t_ccon) As buyer From ttdpur400200 Where t_orno In   (Select  t_orno from ttdisg002200 where t_docn In "
                    'Sql &= "(select t_drgt from tdmisg003200 where t_docn =('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) ))"
                    Sql = "   Select  t_orno,t_odat,t_sfbp As supplierID,(Select t_nama from ttccom100200 where t_bpid=ttdpur400200.t_sfbp) As Supplier_name,t_ccon, "
                    Sql &= "(select t_nama from ttccom001200 where t_emno=ttdpur400200.t_ccon) As buyer From ttdpur400200   Where t_orno In  "

                    Sql & = "(select distinct t_orno from ttdisg002200 where t_docn in "

                    Sql &= "(Select t_drgt from tdmisg003200 where t_docn=('" & DocumentID & "') and t_revn =(select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')))  or "

                    Sql &= "(t_docn = ('" & DocumentID & "')  and t_revi=(select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')))) "


                Else
                    'Sql = " Select t_orno,t_odat,t_sfbp As supplierID,(Select t_nama from ttccom100200 where t_bpid=ttdpur400200.t_sfbp) As Supplier_name,t_ccon, "
                    'Sql &= " (select t_nama from ttccom001200 where t_emno=ttdpur400200.t_ccon) As buyer From ttdpur400200 Where t_orno In   (Select  t_orno from ttdisg002200 where t_docn In "
                    'Sql &= "(select t_drgt from tdmisg003200 where t_docn =('" & DocumentID & "') And t_revn = ('" & RevisionNo & "'))) )"
                    Sql = "   Select  t_orno,t_odat,t_sfbp As supplierID,(Select t_nama from ttccom100200 where t_bpid=ttdpur400200.t_sfbp) As Supplier_name,t_ccon, "
                    Sql &= "(select t_nama from ttccom001200 where t_emno=ttdpur400200.t_ccon) As buyer From ttdpur400200   Where t_orno In  "

                    Sql &= "(select distinct t_orno from ttdisg002200 where t_docn in "

                    Sql &= "(Select t_drgt from tdmisg003200 where t_docn=('" & DocumentID & "') and t_revn =('" & RevisionNo & "'))  or "

                    Sql &= "(t_docn = ('" & DocumentID & "')  and t_revi=('" & RevisionNo & "'))) "

                End If

                Using Cmd As SqlCommand = Con.CreateCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Cmd.CommandTimeout = 5000
                    Dim rd As SqlDataReader = Cmd.ExecuteReader
                    While rd.Read
                        mRetd.Add(New PO_Information(rd))
                    End While
                End Using
            End Using

            Return mRetd
        End Function
        Public Sub New(ByVal Reader As SqlDataReader)
            Try
                For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                    If pi.MemberType = Reflection.MemberTypes.Property Then
                        Try
                            Dim Found As Boolean = False
                            For I As Integer = 0 To Reader.FieldCount - 1
                                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                                    Found = True
                                    Exit For
                                End If
                            Next
                            If Found Then
                                If Convert.IsDBNull(Reader(pi.Name)) Then
                                    Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                                        Case "decimal"
                                            CallByName(Me, pi.Name, CallType.Let, "0.00")
                                        Case "bit"
                                            CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                                        Case Else
                                            CallByName(Me, pi.Name, CallType.Let, String.Empty)
                                    End Select
                                Else
                                    CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Public Sub New()
        End Sub
    End Class

    Public Class PRE_Information
        Public Property ReceiptID As String = ""
        Public Property Rrev As String = ""
        Public Property ReceiptDate As String = ""
        Public Property SentDate As String = ""
        Public Property Rageindays As String = ""
        Public Property RProject As String = ""
        Public Property Relement As String = ""
        Public Property Owner_Dept As String = ""
        Public Property ItemDescription As String = ""
        Public Property Receipt_State As String = ""
        Public Property Mechanical As String = ""
        Public Property Structure_1 As String = ""
        Public Property Piping As String = ""
        Public Property Process As String = ""
        Public Property CandI As String = ""
        Public Property Electrical As String = ""
        Public Property Quality As String = ""
        Public Property t_bpid As String = ""
        Public Property Sname As String = ""
        Public Property t_user As String = ""
        Public Property ename As String = ""
        Public Property t_rqno As String = ""
        Public Property t_item As String = ""





        Public Shared Function GetPREDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.PRE_Information)


            If DocumentID = "" Then Return Nothing
            Dim mRetd As New List(Of SIS.DB.PRE_Information)



            Dim Sql As String = ""
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
                Con.Open()



                'Sql = " Select ReceiptID, ReceiptREvision, CreatedOn, (Case statusID      When 1	Then 'Created'  when 2	then 'Tech.Spec.Released'   when 3	then 'Enquiry In Progress' when 4	then 'All Offer Received'  when 5	then 'Commercial offer Finalized'     when 6	then 'Acrchived' "
                'Sql &= " End) As statusID FROM [IJTPerks].[dbo].[POW_Offers]   where tsid = (Select top 1 tsid from [IJTPerks].[dbo].[POW_TSIndentDocuments] where DocumentID=('" & DocumentID & "')) "

                Sql &= "                Select rec.t_rcno As ReceiptID, rec.t_revn As Rrev, convert(nvarchar(10),dateadd(n,330,rec.t_date),103) As ReceiptDate, convert(nvarchar(10),dateadd(n,330,rec.t_sdat),103) As SentDate, datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_sdat)),getdate()) As Rageindays,rec.t_cprj As RProject, "
                Sql &= "Left(LTrim(rec.t_item), 8) As Relement,(Case ttppdm090200.t_sort When 'MECH-SUGAR' then 'MECHANICAL' When 'ELECTRICAL' then 'ELECTRICAL' when 'MECHANICAL' then 'MECHANICAL'  When 'PROCESS-STOKER' Then 'MECHANICAL' when 'OTHERS' then 'OTHERS' When  "
                Sql &= "  'PROCESS' then 'PROCESS' WHEN 'STRUCTURE' THEN 'STRUCTURE' When 'PIPING' THEN 'PIPING' WHEN 'C & I' THEN 'C&I' When 'INSTRUMENTATION' THEN 'C&I' WHEN 'EPC' THEN 'EPC' When 'C&I' THEN 'C&I' WHEN 'ELE' THEN 'ELECTRICAL' When 'SERVICE' THEN 'OTHERS' else 'OTHERS' End) As Owner_Dept,rec.t_item,  "
                Sql &= "  ttcibd001200.t_dsca As ItemDescription, (Case rec.t_stat  When 1 Then 'Submitted'  when 2 then 'Document linked'  when 3 then 'Under Evaluation'  when 4 then  "
                Sql &= "'Comments Submitted'  when 5 then 'Technically Cleared'  when 6   then 'Transmittal Issued'  when 7 then 'Superceded'  when 8 then 'Closed' end)  as Receipt_State,(case rec.t_sent_1 when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1) when '1970-01-01 00:00:00.000'  "
                Sql &= "  then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end) when 2 then '-' end ) as Mechanical, (case rec.t_sent_2 when 1 then (case (select t_sudt from tdmisg136200 as rep where "
                Sql &= "   rec.t_rcno = rep.t_rcno And rec.t_revn = rep.t_revn And rep.t_engi = 2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'  "
                Sql &= "   End ) As Structure_1, (Case rec.t_sent_3 When 1 Then (Case (Select t_sudt from tdmisg136200 As rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 "
                Sql &= "    as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3)end) when 2 then '-' end ) as Piping, (case rec.t_sent_4 when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4) when '1970-01-01 00:00:00.000' "
                Sql &= "	 then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-' end ) as Process,(case rec.t_sent_5 when 1 then (case (select t_sudt from tdmisg136200 as rep where  "
                Sql &= "	 rec.t_rcno = rep.t_rcno And rec.t_revn = rep.t_revn And rep.t_engi = 5) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end)when 2 then '-' "
                Sql &= "	  End ) As CandI, (Case rec.t_sent_6 When 1 Then (Case (Select t_sudt from tdmisg136200 As rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 "
                Sql &= "	   as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6)end) when 2 then '-' end ) as Electrical, (case rec.t_sent_7 when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7) when "
                Sql &= "	    '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-' end ) as Quality, "
                Sql &= "		rec.t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname,     rec.t_user,ISNULL((select t_nama from ttccom001200 where t_loco=rec.t_user),'-') as ename, rec.t_rqno "
                Sql &= "         From tdmisg134200 As rec "


                Sql &= "        Left Join ttcibd001200 On ttcibd001200.t_item = rec.t_item LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8)  "
                Sql &= "		   Where t_rqno = (Select top 1 t_rqno from ttdisg003200 where t_docn=('" & DocumentID & "')) and rec.t_rcno like 'REC%' "



                Using Cmd As SqlCommand = Con.CreateCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Cmd.CommandTimeout = 5000
                    Dim rd As SqlDataReader = Cmd.ExecuteReader
                    While rd.Read
                        mRetd.Add(New PRE_Information(rd))
                    End While
                End Using
            End Using

            Return mRetd
        End Function
        Public Sub New(ByVal Reader As SqlDataReader)
            Try
                For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                    If pi.MemberType = Reflection.MemberTypes.Property Then
                        Try
                            Dim Found As Boolean = False
                            For I As Integer = 0 To Reader.FieldCount - 1
                                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                                    Found = True
                                    Exit For
                                End If
                            Next
                            If Found Then
                                If Convert.IsDBNull(Reader(pi.Name)) Then
                                    Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                                        Case "decimal"
                                            CallByName(Me, pi.Name, CallType.Let, "0.00")
                                        Case "bit"
                                            CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                                        Case Else
                                            CallByName(Me, pi.Name, CallType.Let, String.Empty)
                                    End Select
                                Else
                                    CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Public Sub New()
        End Sub
    End Class

    Public Class POST_Information
        Public Property ReceiptID As String = ""
        Public Property Rrev As String = ""
        Public Property ReceiptDate As String = ""
        Public Property SentDate As String = ""
        Public Property Rageindays As String = ""
        Public Property RProject As String = ""
        Public Property Relement As String = ""
        Public Property Owner_Dept As String = ""
        Public Property ItemDescription As String = ""
        Public Property Receipt_State As String = ""
        Public Property Mechanical As String = ""
        Public Property Structure_1 As String = ""
        Public Property Piping As String = ""
        Public Property Process As String = ""
        Public Property CandI As String = ""
        Public Property Electrical As String = ""
        Public Property Quality As String = ""
        Public Property t_bpid As String = ""
        Public Property Sname As String = ""
        Public Property t_user As String = ""
        Public Property ename As String = ""
        Public Property t_orno As String = ""
        Public Property t_item As String = ""

        Public Property t_appr As String = ""
        Public Property cname As String = ""
        Public Property t_adat As String = ""
        Public Property trno As String = ""








        Public Shared Function GetPOSTDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.POST_Information)


            If DocumentID = "" Then Return Nothing
            Dim mRetd As New List(Of SIS.DB.POST_Information)



            Dim Sql As String = ""
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
                Con.Open()



                'Sql = " Select ReceiptID, ReceiptREvision, CreatedOn, (Case statusID      When 1	Then 'Created'  when 2	then 'Tech.Spec.Released'   when 3	then 'Enquiry In Progress' when 4	then 'All Offer Received'  when 5	then 'Commercial offer Finalized'     when 6	then 'Acrchived' "
                'Sql &= " End) As statusID FROM [IJTPerks].[dbo].[POW_Offers]   where tsid = (Select top 1 tsid from [IJTPerks].[dbo].[POW_TSIndentDocuments] where DocumentID=('" & DocumentID & "')) "

                Sql &= "                Select rec.t_rcno As ReceiptID, rec.t_revn As Rrev, convert(nvarchar(10),dateadd(n,330,rec.t_date),103) As ReceiptDate, convert(nvarchar(10),dateadd(n,330,rec.t_sdat),103) As SentDate, datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_sdat)),getdate()) As Rageindays,rec.t_cprj As RProject, "
                Sql &= "Left(LTrim(rec.t_item), 8) As Relement,(Case ttppdm090200.t_sort When 'MECH-SUGAR' then 'MECHANICAL' When 'ELECTRICAL' then 'ELECTRICAL' when 'MECHANICAL' then 'MECHANICAL'  When 'PROCESS-STOKER' Then 'MECHANICAL' when 'OTHERS' then 'OTHERS' When  "
                Sql &= "  'PROCESS' then 'PROCESS' WHEN 'STRUCTURE' THEN 'STRUCTURE' When 'PIPING' THEN 'PIPING' WHEN 'C & I' THEN 'C&I' When 'INSTRUMENTATION' THEN 'C&I' WHEN 'EPC' THEN 'EPC' When 'C&I' THEN 'C&I' WHEN 'ELE' THEN 'ELECTRICAL' When 'SERVICE' THEN 'OTHERS' else 'OTHERS' End) As Owner_Dept,rec.t_item,  "
                Sql &= "  ttcibd001200.t_dsca As ItemDescription, (Case rec.t_stat  When 1 Then 'Submitted'  when 2 then 'Document linked'  when 3 then 'Under Evaluation'  when 4 then  "
                Sql &= "'Comments Submitted'  when 5 then 'Technically Cleared'  when 6   then 'Transmittal Issued'  when 7 then 'Superceded'  when 8 then 'Closed' end)  as Receipt_State,(case rec.t_sent_1 when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1) when '1970-01-01 00:00:00.000'  "
                Sql &= "  then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end) when 2 then '-' end ) as Mechanical, (case rec.t_sent_2 when 1 then (case (select t_sudt from tdmisg136200 as rep where "
                Sql &= "   rec.t_rcno = rep.t_rcno And rec.t_revn = rep.t_revn And rep.t_engi = 2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'  "
                Sql &= "   End ) As Structure_1, (Case rec.t_sent_3 When 1 Then (Case (Select t_sudt from tdmisg136200 As rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 "
                Sql &= "    as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3)end) when 2 then '-' end ) as Piping, (case rec.t_sent_4 when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4) when '1970-01-01 00:00:00.000' "
                Sql &= "	 then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-' end ) as Process,(case rec.t_sent_5 when 1 then (case (select t_sudt from tdmisg136200 as rep where  "
                Sql &= "	 rec.t_rcno = rep.t_rcno And rec.t_revn = rep.t_revn And rep.t_engi = 5) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end)when 2 then '-' "
                Sql &= "	  End ) As CandI, (Case rec.t_sent_6 When 1 Then (Case (Select t_sudt from tdmisg136200 As rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 "
                Sql &= "	   as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6)end) when 2 then '-' end ) as Electrical, (case rec.t_sent_7 when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7) when "
                Sql &= "	    '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-' end ) as Quality, "
                Sql &= "		rec.t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname,     rec.t_user,ISNULL((select t_nama from ttccom001200 where t_loco=rec.t_user),'-') as ename, rec.t_orno, rec.t_appr,ISNULL((select t_nama from ttccom001200 where t_loco=rec.t_appr),'-') as cname,rec.t_adat,rec.t_trno "
                Sql &= "         From tdmisg134200 As rec "


                Sql &= "        Left Join ttcibd001200 On ttcibd001200.t_item = rec.t_item LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8)  "
                Sql &= "		   Where t_orno = (Select top 1 t_orno from ttdisg002200 where t_docn=('" & DocumentID & "')) and rec.t_rcno like 'REP%' "



                Using Cmd As SqlCommand = Con.CreateCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Cmd.CommandTimeout = 5000
                    Dim rd As SqlDataReader = Cmd.ExecuteReader
                    While rd.Read
                        mRetd.Add(New POST_Information(rd))
                    End While
                End Using
            End Using

            Return mRetd
        End Function
        Public Sub New(ByVal Reader As SqlDataReader)
            Try
                For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                    If pi.MemberType = Reflection.MemberTypes.Property Then
                        Try
                            Dim Found As Boolean = False
                            For I As Integer = 0 To Reader.FieldCount - 1
                                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                                    Found = True
                                    Exit For
                                End If
                            Next
                            If Found Then
                                If Convert.IsDBNull(Reader(pi.Name)) Then
                                    Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                                        Case "decimal"
                                            CallByName(Me, pi.Name, CallType.Let, "0.00")
                                        Case "bit"
                                            CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                                        Case Else
                                            CallByName(Me, pi.Name, CallType.Let, String.Empty)
                                    End Select
                                Else
                                    CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Public Sub New()
        End Sub
    End Class

    Public Class POSTD_Information
        Public Property t_rcno As String = ""
        Public Property t_revn As String = ""
        Public Property t_srno As String = ""
        Public Property t_docn As String = ""
        Public Property t_revi As String = ""
        Public Property t_dsca As String = ""
        Public Property t_idoc As String = ""
        Public Property t_irev As String = ""
        Public Property t_date As String = ""
        Public Property t_remk As String = ""








        Public Shared Function GetPOSTDDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.POSTD_Information)


            If DocumentID = "" Then Return Nothing
            Dim mRetd As New List(Of SIS.DB.POSTD_Information)



            Dim Sql As String = ""
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
                Con.Open()




                Sql = " Select t_rcno, t_revn, t_srno, t_docn, t_revi, t_dsca, t_idoc, t_irev, t_date, t_remk From tdmisg135200 where t_rcno = "
                Sql &= "   (Select top 1 t_rcno from  tdmisg134200 where t_orno =(Select top 1 t_orno from ttdisg002200 where t_docn= ('" & DocumentID & "'))) "


                Using Cmd As SqlCommand = Con.CreateCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Cmd.CommandTimeout = 5000
                    Dim rd As SqlDataReader = Cmd.ExecuteReader
                    While rd.Read
                        mRetd.Add(New POSTD_Information(rd))
                    End While
                End Using
            End Using

            Return mRetd
        End Function
        Public Sub New(ByVal Reader As SqlDataReader)
            Try
                For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                    If pi.MemberType = Reflection.MemberTypes.Property Then
                        Try
                            Dim Found As Boolean = False
                            For I As Integer = 0 To Reader.FieldCount - 1
                                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                                    Found = True
                                    Exit For
                                End If
                            Next
                            If Found Then
                                If Convert.IsDBNull(Reader(pi.Name)) Then
                                    Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                                        Case "decimal"
                                            CallByName(Me, pi.Name, CallType.Let, "0.00")
                                        Case "bit"
                                            CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                                        Case Else
                                            CallByName(Me, pi.Name, CallType.Let, String.Empty)
                                    End Select
                                Else
                                    CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Public Sub New()
        End Sub
    End Class

    'Public Class POST_Information
    '    Public Property ReceiptID As String = ""
    '    Public Property ReceiptREvision As String = ""
    '    Public Property t_cprj As String = ""
    '    Public Property LOTItem As String = ""
    '    Public Property Itemdescription As String = ""
    '    Public Property Receipt_State As String = ""
    '    Public Property ReceiptDate As String = ""
    '    Public Property SentDate As String = ""
    '    Public Property t_bpid As String = ""
    '    Public Property t_user As String = ""
    '    Public Property t_orno As String = ""
    '    Public Property Sname As String = ""
    '    Public Property ename As String = ""





    '    Public Shared Function GetPOSTDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.POST_Information)


    '        If DocumentID = "" Then Return Nothing
    '        Dim mRetd As New List(Of SIS.DB.POST_Information)



    '        Dim Sql As String = ""
    '        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
    '            Con.Open()



    '            'Sql = " Select ReceiptID, ReceiptREvision, CreatedOn, (Case statusID      When 1	Then 'Created'  when 2	then 'Tech.Spec.Released'   when 3	then 'Enquiry In Progress' when 4	then 'All Offer Received'  when 5	then 'Commercial offer Finalized'     when 6	then 'Acrchived' "
    '            'Sql &= " End) As statusID FROM [IJTPerks].[dbo].[POW_Offers]   where tsid = (Select top 1 tsid from [IJTPerks].[dbo].[POW_TSIndentDocuments] where DocumentID=('" & DocumentID & "')) "

    '            Sql = "Select  rec.t_rcno As ReceiptID,rec.t_revn As ReceiptREvision,rec.t_cprj,rec.t_item As LOTItem,ttcibd001200.t_dsca As ItemDescription, (Case rec.t_stat  When 1 Then 'Submitted'  when 2 then 'Document linked'  when 3 then 'Under Evaluation'  when 4 then 'Comments Submitted'  when 5 then 'Technically Cleared'  when 6 "
    '            Sql &= "  then 'Transmittal Issued'  when 7 then 'Superceded'  when 8 then 'Closed' end)  as Receipt_State,  Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate,  Convert(nvarchar(10),  "
    '            Sql &= "   DateAdd(n, 330, rec.t_sdat), 103) As SentDate, rec.t_bpid,ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, "
    '            Sql &= "    rec.t_user,ISNULL((select t_nama from ttccom001200 where t_emno=rec.t_user),'-') as ename, rec.t_orno From tdmisg134200 As rec  "
    '            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8)  Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item  "

    '            Sql &= " Where  rec.t_orno =(Select top 1 t_orno from ttdisg002200 where t_docn =('" & DocumentID & "')) and rec.t_rcno like 'REP%' "

    '            Using Cmd As SqlCommand = Con.CreateCommand()
    '                Cmd.CommandType = CommandType.Text
    '                Cmd.CommandText = Sql
    '                Cmd.CommandTimeout = 5000
    '                Dim rd As SqlDataReader = Cmd.ExecuteReader
    '                While rd.Read
    '                    mRetd.Add(New POST_Information(rd))
    '                End While
    '            End Using
    '        End Using

    '        Return mRetd
    '    End Function
    '    Public Sub New(ByVal Reader As SqlDataReader)
    '        Try
    '            For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
    '                If pi.MemberType = Reflection.MemberTypes.Property Then
    '                    Try
    '                        Dim Found As Boolean = False
    '                        For I As Integer = 0 To Reader.FieldCount - 1
    '                            If Reader.GetName(I).ToLower = pi.Name.ToLower Then
    '                                Found = True
    '                                Exit For
    '                            End If
    '                        Next
    '                        If Found Then
    '                            If Convert.IsDBNull(Reader(pi.Name)) Then
    '                                Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
    '                                    Case "decimal"
    '                                        CallByName(Me, pi.Name, CallType.Let, "0.00")
    '                                    Case "bit"
    '                                        CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
    '                                    Case Else
    '                                        CallByName(Me, pi.Name, CallType.Let, String.Empty)
    '                                End Select
    '                            Else
    '                                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
    '                            End If
    '                        End If
    '                    Catch ex As Exception
    '                    End Try
    '                End If
    '            Next
    '        Catch ex As Exception
    '        End Try
    '    End Sub
    '    Public Sub New()
    '    End Sub
    'End Class


    'Public Class PRED_Information


    '    Public Property Receipt_State As String = ""
    '    Public Property ReceiptDate As String = ""
    '    Public Property SentDate As String = ""
    '    Public Property t_item As String = ""
    '    Public Property ItemDescription As String = ""
    '    Public Property t_rqno As String = ""
    '    Public Shared Function GetPREDDATA(ByVal ReceiptID As String, ByVal ReceiptREvision As String) As SIS.DB.PRED_Information


    '        If ReceiptID = "" Then Return Nothing
    '        Dim mRetd As SIS.DB.PRED_Information = Nothing



    '        Dim Sql As String = ""
    '        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
    '            Con.Open()

    '            Sql = " Select (Case rec.t_stat  When 1 Then 'Submitted'  when 2 then 'Document linked'  when 3 then 'Under Evaluation'  when 4 then 'Comments Submitted'  when 5 then 'Technically Cleared'  when 6 "
    '            Sql &= " then 'Transmittal Issued'  when 7 then 'Superceded'  when 8 then 'Closed' end)  as Receipt_State,  Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate,  Convert(nvarchar(10), "
    '            Sql &= " DateAdd(n, 330, rec.t_sdat), 103) As SentDate, rec.t_item, "
    '            Sql &= " ttcibd001200.t_dsca As ItemDescription,t_rqno From tdmisg134200 As rec  "
    '            Sql &= "   Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8)  Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item  Where rec.t_rcno = '" & ReceiptID & "' and rec.t_revn='" & ReceiptREvision & "'"




    '            Using Cmd As SqlCommand = Con.CreateCommand()
    '                Cmd.CommandType = CommandType.Text
    '                Cmd.CommandText = Sql
    '                Cmd.CommandTimeout = 5000
    '                Dim rd As SqlDataReader = Cmd.ExecuteReader
    '                While rd.Read
    '                    mRetd = New PRED_Information(rd)
    '                End While
    '            End Using
    '        End Using

    '        Return mRetd
    '    End Function
    '    Public Sub New(ByVal Reader As SqlDataReader)
    '        Try
    '            For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
    '                If pi.MemberType = Reflection.MemberTypes.Property Then
    '                    Try
    '                        Dim Found As Boolean = False
    '                        For I As Integer = 0 To Reader.FieldCount - 1
    '                            If Reader.GetName(I).ToLower = pi.Name.ToLower Then
    '                                Found = True
    '                                Exit For
    '                            End If
    '                        Next
    '                        If Found Then
    '                            If Convert.IsDBNull(Reader(pi.Name)) Then
    '                                Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
    '                                    Case "decimal"
    '                                        CallByName(Me, pi.Name, CallType.Let, "0.00")
    '                                    Case "bit"
    '                                        CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
    '                                    Case Else
    '                                        CallByName(Me, pi.Name, CallType.Let, String.Empty)
    '                                End Select
    '                            Else
    '                                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
    '                            End If
    '                        End If
    '                    Catch ex As Exception
    '                    End Try
    '                End If
    '            Next
    '        Catch ex As Exception
    '        End Try
    '    End Sub
    '    Public Sub New()
    '    End Sub
    'End Class
    Public Class Transmittal_Information
        Public Property t_tran As String = ""
        Public Property t_docn As String = ""
        Public Property t_revn As String = ""
        Public Property t_type As String = ""
        Public Property t_subj As String = ""
        Public Property creator As String = ""
        Public Property Approver As String = ""
        Public Property issuedate As String = ""
        Public Property creator_remarks As String = ""
        Public Property approver_remarks As String = ""
        Public Property issuer_remarks As String = ""
        Public Property t_stat As String = ""
        Public Property t_isdt As String = ""

        Public Property issuedvia As String = ""


        Public Shared Function GetTRANSDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.Transmittal_Information)


            If DocumentID = "" Then Return Nothing
            Dim mRetd As New DBDocumentDB

            mRetd.DocumentID = DocumentID


            Dim mRet As New List(Of SIS.DB.Transmittal_Information)
            Dim Sql As String = ""
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
                Con.Open()
                If RevisionNo = "" Then
                    Sql = " select aa.t_tran,aa.t_docn,aa.t_revn, (case bb.t_type"
                    Sql &= "       when 1 then 'Customer' "
                    Sql &= "       when 2 then 'Internal' "
                    Sql &= "       when 3 then 'Site' "
                    Sql &= "       when 4 then 'Vendor' "
                    Sql &= "       end) as t_type,bb.t_subj,(select t_nama from ttccom001200 where bb.t_user=ttccom001200.t_loco) as creator,(select t_nama from ttccom001200 where bb.t_apsu=ttccom001200.t_loco) as Approver,(case bb.t_stat "
                    Sql &= "   when 1 then 'Returned' "
                    Sql &= "       when 2 then 'Free' "
                    Sql &= "       when 3 then 'Under Approval' "
                    Sql &= "       when 4 then 'Under Isuue' "
                    Sql &= "   when 5 then 'Issued' "
                    Sql &= "       when 6 then 'Partial Received' "
                    Sql &= "       when 7 then 'Received' "
                    Sql &= "       when 8 then 'Closed' "
                    Sql &= "          end) as t_stat, (Case bb.t_issu   when 001 then  'Hard copy by Hand' When 002 Then 'Hard copy by Courier' when 003 then 'e mail' When 004 Then 'Uploaded in ftp server' when 005 then 'Uploaded in client or consultant portal' "
                    Sql &= "          When 006 Then 'Vault'  when 007 then 'Open KM (DMS)' End) As issuedvia, convert(date, dateadd(n,330,bb.t_isdt))As issuedate,aa.t_remk as creator_remarks,bb.t_irmk as approver_remarks,bb.t_rekm as issuer_remarks from tdmisg132200 as aa  "
                    Sql &= " inner join tdmisg131200 as bb "
                    Sql &= " on aa.t_tran=bb.t_tran"
                    Sql &= " where aa.t_docn=('" & DocumentID & "') And t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "
                    Sql &= " order by aa.t_docn, aa.t_revn"
                Else
                    Sql = " select aa.t_tran,aa.t_docn,aa.t_revn, (case bb.t_type"
                    Sql &= "       when 1 then 'Customer' "
                    Sql &= "       when 2 then 'Internal' "
                    Sql &= "       when 3 then 'Site' "
                    Sql &= "       when 4 then 'Vendor' "
                    Sql &= "       end) as t_type,bb.t_subj,(select t_nama from ttccom001200 where bb.t_user=ttccom001200.t_loco) as creator,(select t_nama from ttccom001200 where bb.t_apsu=ttccom001200.t_loco) as Approver,(case bb.t_stat "
                    Sql &= "   when 1 then 'Returned' "
                    Sql &= "       when 2 then 'Free' "
                    Sql &= "       when 3 then 'Under Approval' "
                    Sql &= "       when 4 then 'Under Isuue' "
                    Sql &= "   when 5 then 'Issued' "
                    Sql &= "       when 6 then 'Partial Received' "
                    Sql &= "       when 7 then 'Received' "
                    Sql &= "       when 8 then 'Closed' "
                    Sql &= "          end) as t_stat, (Case bb.t_issu   when 001 then  'Hard copy by Hand' When 002 Then 'Hard copy by Courier' when 003 then 'e mail' When 004 Then 'Uploaded in ftp server' when 005 then 'Uploaded in client or consultant portal' "
                    Sql &= "          When 006 Then 'Vault'  when 007 then 'Open KM (DMS)' End) As issuedvia, convert(date, dateadd(n,330,bb.t_isdt))As issuedate,aa.t_remk as creator_remarks,bb.t_irmk as approver_remarks,bb.t_rekm as issuer_remarks from tdmisg132200 as aa  "
                    Sql &= " inner join tdmisg131200 as bb "
                    Sql &= " on aa.t_tran=bb.t_tran"
                    Sql &= " where aa.t_docn=('" & DocumentID & "') And t_revn = ('" & RevisionNo & "') "
                    Sql &= " order by aa.t_docn, aa.t_revn"

                End If

                Using Cmd As SqlCommand = Con.CreateCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Dim rd As SqlDataReader = Cmd.ExecuteReader
                    While rd.Read
                        mRet.Add(New SIS.DB.Transmittal_Information(rd))
                    End While
                End Using
            End Using

            Return mRet
        End Function
        Public Sub New(ByVal Reader As SqlDataReader)
            Try
                For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                    If pi.MemberType = Reflection.MemberTypes.Property Then
                        Try
                            Dim Found As Boolean = False
                            For I As Integer = 0 To Reader.FieldCount - 1
                                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                                    Found = True
                                    Exit For
                                End If
                            Next
                            If Found Then
                                If Convert.IsDBNull(Reader(pi.Name)) Then
                                    Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                                        Case "decimal"
                                            CallByName(Me, pi.Name, CallType.Let, "0.00")
                                        Case "bit"
                                            CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                                        Case Else
                                            CallByName(Me, pi.Name, CallType.Let, String.Empty)
                                    End Select
                                Else
                                    CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Public Sub New()
        End Sub
    End Class

    Public Class DCR_Information
        Public Property t_dcrn As String = ""
        Public Property t_dsca As String = ""
        Public Property t_cspa As String = ""
        Public Property t_stat As String = ""
        Public Property t_reqs As String = ""
        Public Property t_comp As String = ""
        Public Property t_docd As String = ""
        Public Property t_revn As String = ""
        Public Property t_nama As String = ""
        Public Property t_crea As String = ""
        Public Property t_emno As String = ""
        Public Property t_catg As String = ""
        Public Property User_remarks As String = ""
        Public Property Approver_remarks As String = ""
        Public Property t_appt As String = ""
        Public Property creator As String = ""
        Public Property approver As String = ""
        Public Property element As String = ""



        Public Shared Function GetDCRDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.DCR_Information)


            If DocumentID = "" Then Return Nothing
            Dim mRetd As New DBDocumentDB

            mRetd.DocumentID = DocumentID


            Dim mRet As New List(Of SIS.DB.DCR_Information)
            Dim Sql As String = ""
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
                Con.Open()
                If RevisionNo = "" Then

                    Sql = "  select rec.t_dcrn,rec.t_dsca,rec.t_cspa as element,(case rec.t_stat                                 "
                    Sql &= "  when 1 then 'Under Creation'                                                                        "
                    Sql &= "   when 2 then 'Under Approve'                                                                        "
                    Sql &= "  when 3 then 'Approved'                                                                              "
                    Sql &= "  end) as t_stat, (case rec.t_reqs                                                                    "
                    Sql &= "  when 001 then 'Work Stopped'                                                                        "
                    Sql &= "  when 002 then 'Work can proceed'                                                                    "
                    Sql &= "  when 003 then 'Work will stop'                                                                      "
                    Sql &= "  end) as t_reqs,(case rec.t_comp                                                                     "
                    Sql &= "  when 001 then 'Work Stopped'                                                                        "
                    Sql &= "  when 002 then 'Manufacturing Yet to start'                                                          "
                    Sql &= "  when 003 then 'Under manufacturing'                                                                 "
                    Sql &= "  when 004    then 'Ready for dispatch'                                                               "
                    Sql &= "  when 005 then 'Material Recieved at site'                                                           "
                    Sql &= "  when 006 then 'Erection completed'                                                                  "
                    Sql &= "  when 007 then 'Boiler commisioned and in operation'                                                 "
                    Sql &= "  when 008 then 'In design stage'                                                                     "
                    Sql &= "  when 009 then 'Budget available in element 50060100'                                                "
                    Sql &= "  when 010 then 'under progress'                                                                      "
                    Sql &= "  when 011 then 'not applicable'                                                                      "
                    Sql &= "  when 012 then 'Budget avilable in element'                                                          "
                    Sql &= "  end) as t_comp,recd.t_docd,recd.t_revn,                                                             "
                    Sql &= " (select t_nama from ttccom001200 where rec.t_crea=ttccom001200.t_loco) as creator,                   "
                    Sql &= "  		 (select t_nama from ttccom001200 where rec.t_user=ttccom001200.t_loco) as approver,          "
                    Sql &= " 			                                                                                          "
                    Sql &= "                                                                                                      "
                    Sql &= "  (case recd.t_catg                                                                                   "
                    Sql &= "                                                                                                      "
                    Sql &= " when 001 then 'As Built'                                                                             "
                    Sql &= " when 002 then 'Revised as per PO Annexure'                                                           "
                    Sql &= " when 003 then 'Client or consultant comments incorporation'                                          "
                    Sql &= " when 004 then 'Structure input changes due to mechanical'                                            "
                    Sql &= " when 005 then 'Structure input changes due to piping'                                                "
                    Sql &= " when 006 then 'Change due to structure size changes'                                                 "
                    Sql &= " when 007 then 'Design or drawing error'                                                              "
                    Sql &= " when 008 then 'Manufacturing requirement'                                                            "
                    Sql &= " when 009 then 'Hold removal'                                                                         "
                    Sql &= " when 010 then 'Vendor design changes'                                                                "
                    Sql &= " when 011 then 'Drawing Improvement'                                                                  "
                    Sql &= " when 012 then 'Design/Drawing Mistakes'                                                              "
                    Sql &= " when 013 then 'Inter Group Input change'                                                             "
                    Sql &= " when 014 then 'Customer / Client / Supplier Input Change'                                            "
                    Sql &= " when 015 then '3D COMMENTS'                                                                          "
                    Sql &= " when 016 then 'Alternate Material change'                                                            "
                    Sql &= " when 017 then 'Design change'                                                                        "
                    Sql &= " when 018 then 'input change'                                                                         "
                    Sql &= " when 019 then 'Erection requirement'                                                                 "
                    Sql &= " when 020 then 'Iso document updated'                                                                 "
                    Sql &= " when 021 then 'Project requirement'                                                                  "
                    Sql &= " when 022 then 'Comments updated by vendor'                                                           "
                    Sql &= " when 023 then 'Matl. group requirment as per market availability' end) as t_catg,                    "
                    Sql &= "                                                                                                      "
                    Sql &= "                                                                                                      "
                    Sql &= "                                                                                                      "
                    Sql &= "                                                                                                      "
                    Sql &= "  recd.t_remk as User_remarks , rec.t_remk as Approver_remarks,rec.t_appt                                                                 "
                    Sql &= "             From tdmisg114200 as rec                                                                 "
                    Sql &= "                                                                                                      "
                    Sql &= "  inner join tdmisg115200 as recd                                                                     "
                    Sql &= "        on rec.t_dcrn=recd.t_dcrn                                                                     "

                    Sql &= " Where recd.t_docd=('" & DocumentID & "') And recd.t_revn = (select max(t_revn) from tdmisg001200 where t_docn in ('" & DocumentID & "')) "

                Else
                    Sql = "  select rec.t_dcrn,rec.t_dsca,rec.t_cspa as element,(case rec.t_stat                                 "
                    Sql &= "  when 1 then 'Under Creation'                                                                        "
                    Sql &= "   when 2 then 'Under Approve'                                                                        "
                    Sql &= "  when 3 then 'Approved'                                                                              "
                    Sql &= "  end) as t_stat, (case rec.t_reqs                                                                    "
                    Sql &= "  when 001 then 'Work Stopped'                                                                        "
                    Sql &= "  when 002 then 'Work can proceed'                                                                    "
                    Sql &= "  when 003 then 'Work will stop'                                                                      "
                    Sql &= "  end) as t_reqs,(case rec.t_comp                                                                     "
                    Sql &= "  when 001 then 'Work Stopped'                                                                        "
                    Sql &= "  when 002 then 'Manufacturing Yet to start'                                                          "
                    Sql &= "  when 003 then 'Under manufacturing'                                                                 "
                    Sql &= "  when 004    then 'Ready for dispatch'                                                               "
                    Sql &= "  when 005 then 'Material Recieved at site'                                                           "
                    Sql &= "  when 006 then 'Erection completed'                                                                  "
                    Sql &= "  when 007 then 'Boiler commisioned and in operation'                                                 "
                    Sql &= "  when 008 then 'In design stage'                                                                     "
                    Sql &= "  when 009 then 'Budget available in element 50060100'                                                "
                    Sql &= "  when 010 then 'under progress'                                                                      "
                    Sql &= "  when 011 then 'not applicable'                                                                      "
                    Sql &= "  when 012 then 'Budget avilable in element'                                                          "
                    Sql &= "  end) as t_comp,recd.t_docd,recd.t_revn,                                                             "
                    Sql &= " (select t_nama from ttccom001200 where rec.t_crea=ttccom001200.t_loco) as creator,                   "
                    Sql &= "  		 (select t_nama from ttccom001200 where rec.t_user=ttccom001200.t_loco) as approver,          "
                    Sql &= " 			                                                                                          "
                    Sql &= "                                                                                                      "
                    Sql &= "  (case recd.t_catg                                                                                   "
                    Sql &= "                                                                                                      "
                    Sql &= " when 001 then 'As Built'                                                                             "
                    Sql &= " when 002 then 'Revised as per PO Annexure'                                                           "
                    Sql &= " when 003 then 'Client or consultant comments incorporation'                                          "
                    Sql &= " when 004 then 'Structure input changes due to mechanical'                                            "
                    Sql &= " when 005 then 'Structure input changes due to piping'                                                "
                    Sql &= " when 006 then 'Change due to structure size changes'                                                 "
                    Sql &= " when 007 then 'Design or drawing error'                                                              "
                    Sql &= " when 008 then 'Manufacturing requirement'                                                            "
                    Sql &= " when 009 then 'Hold removal'                                                                         "
                    Sql &= " when 010 then 'Vendor design changes'                                                                "
                    Sql &= " when 011 then 'Drawing Improvement'                                                                  "
                    Sql &= " when 012 then 'Design/Drawing Mistakes'                                                              "
                    Sql &= " when 013 then 'Inter Group Input change'                                                             "
                    Sql &= " when 014 then 'Customer / Client / Supplier Input Change'                                            "
                    Sql &= " when 015 then '3D COMMENTS'                                                                          "
                    Sql &= " when 016 then 'Alternate Material change'                                                            "
                    Sql &= " when 017 then 'Design change'                                                                        "
                    Sql &= " when 018 then 'input change'                                                                         "
                    Sql &= " when 019 then 'Erection requirement'                                                                 "
                    Sql &= " when 020 then 'Iso document updated'                                                                 "
                    Sql &= " when 021 then 'Project requirement'                                                                  "
                    Sql &= " when 022 then 'Comments updated by vendor'                                                           "
                    Sql &= " when 023 then 'Matl. group requirment as per market availability' end) as t_catg,                    "
                    Sql &= "                                                                                                      "
                    Sql &= "  recd.t_remk as User_remarks , rec.t_remk as Approver_remarks, rec.t_appt                            "
                    Sql &= "             From tdmisg114200 as rec                                                                 "
                    Sql &= "                                                                                                      "
                    Sql &= "  inner join tdmisg115200 as recd                                                                     "
                    Sql &= "        on rec.t_dcrn=recd.t_dcrn                                                                     "
                    Sql &= " Where recd.t_docd=('" & DocumentID & "') And recd.t_revn = ('" & RevisionNo & "') "


                End If

                Using Cmd As SqlCommand = Con.CreateCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Dim rd As SqlDataReader = Cmd.ExecuteReader
                    While rd.Read
                        mRet.Add(New SIS.DB.DCR_Information(rd))
                    End While
                End Using
            End Using

            Return mRet
        End Function
        Public Sub New(ByVal Reader As SqlDataReader)
            Try
                For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                    If pi.MemberType = Reflection.MemberTypes.Property Then
                        Try
                            Dim Found As Boolean = False
                            For I As Integer = 0 To Reader.FieldCount - 1
                                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                                    Found = True
                                    Exit For
                                End If
                            Next
                            If Found Then
                                If Convert.IsDBNull(Reader(pi.Name)) Then
                                    Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                                        Case "decimal"
                                            CallByName(Me, pi.Name, CallType.Let, "0.00")
                                        Case "bit"
                                            CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                                        Case Else
                                            CallByName(Me, pi.Name, CallType.Let, String.Empty)
                                    End Select
                                Else
                                    CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Public Sub New()
        End Sub
    End Class

    Public Class SAR_Information
        Public Property t_dcrn As String = ""
        Public Property t_cprj As String = ""
        Public Property t_sarn As String = ""
        Public Property t_stat As String = ""
        Public Property t_idat As String = ""
        Public Property t_cdat As String = ""
        Public Property t_draw As String = ""
        Public Property t_natp As String = ""
        Public Property t_sars As String = ""
        Public Property t_prep As String = ""
        Public Property t_rper As String = ""
        Public Property t_apby As String = ""



        Public Shared Function GetSARDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.SAR_Information)


            If DocumentID = "" Then Return Nothing
            Dim mRetd As New DBDocumentDB

            mRetd.DocumentID = DocumentID


            Dim mRet As New List(Of SIS.DB.SAR_Information)
            Dim Sql As String = ""
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
                Con.Open()


                Sql = "  Select rec.t_cprj,rec.t_sarn,(Case rec.t_stat When 1 Then 'Created' when 2 then 'Under Review' When 3 Then 'Under Approval' when 4 then 'Approved' When 5 Then 'Not Applicable' End) As t_stat, "
                Sql &= " (select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) As t_rper,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) As t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) As t_idat,rec.t_draw,"
                    Sql &= " (select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) As t_natp,(Case rec.t_sars When 1 Then 'Work Stopped' when 3 then 'Work can Proceed' End) As t_sars, rec.t_prep, "
                    Sql &= " (select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby "
                Sql &= " From ttpisg074200 As rec LEFT Join ttppdm090200 On ttppdm090200.t_cspa = rec.t_cspa Where t_draw Like ('%" & DocumentID & "%') and  DATALENGTH(t_cprj) > 0 "


                Using Cmd As SqlCommand = Con.CreateCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Dim rd As SqlDataReader = Cmd.ExecuteReader
                    While rd.Read
                        mRet.Add(New SIS.DB.SAR_Information(rd))
                    End While
                End Using
            End Using

            Return mRet
        End Function
        Public Sub New(ByVal Reader As SqlDataReader)
            Try
                For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                    If pi.MemberType = Reflection.MemberTypes.Property Then
                        Try
                            Dim Found As Boolean = False
                            For I As Integer = 0 To Reader.FieldCount - 1
                                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                                    Found = True
                                    Exit For
                                End If
                            Next
                            If Found Then
                                If Convert.IsDBNull(Reader(pi.Name)) Then
                                    Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                                        Case "Decimal"
                                            CallByName(Me, pi.Name, CallType.Let, "0.00")
                                        Case "bit"
                                            CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                                        Case Else
                                            CallByName(Me, pi.Name, CallType.Let, String.Empty)
                                    End Select
                                Else
                                    CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Public Sub New()
        End Sub
    End Class


    Public Class PMDL_Information

        Public Property t_pcod As String = ""
        Public Property t_cprj As String = ""
        Public Property t_docn As String = ""
        Public Property t_revn As String = ""
        Public Property t_dhrs As String = ""
        Public Property t_chrs As String = ""
        Public Property t_ehrs As String = ""
        Public Property t_lmhr As String = ""
        Public Property t_bssd As String = ""
        Public Property t_bsfd As String = ""
        Public Property t_rsfd As String = ""
        Public Property t_acdt As String = ""
        Public Property t_genm As String = ""
        Public Property t_dwgs As String = ""


        Public Shared Function GetPMDLDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.PMDL_Information)


            If DocumentID = "" Then Return Nothing
            Dim mRetd As New DBDocumentDB

            mRetd.DocumentID = DocumentID


            Dim mRet As New List(Of SIS.DB.PMDL_Information)
            Dim Sql As String = ""
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
                Con.Open()
                If RevisionNo = "" Then
                    Sql = " Select  "
                    Sql &= "t_pcod, t_cprj, t_docn, t_revn, t_dhrs, t_chrs, t_ehrs, t_lmhr, t_bssd, t_bsfd, t_rsfd, t_acdt, t_genm, (Case t_dwgs          "
                    Sql &= "When 1 Then 'Standard'                                                                                                                    "
                    Sql &= " when 2 then 'Customized'                                                                                                                  "
                    Sql &= "End)As t_dwgs from tdmisg140200                                                                                                           "
                    Sql &= "where t_docn = ('" & DocumentID & "')    "

                Else
                    Sql = " select  "
                    Sql &= "t_pcod, t_cprj, t_docn, t_revn, t_dhrs, t_chrs, t_ehrs, t_lmhr, t_bssd, t_bsfd, t_rsfd, t_acdt, t_genm, (case t_dwgs          "
                    Sql &= "when 1 then 'Standard'                                                                                                                    "
                    Sql &= " when 2 then 'Customized'                                                                                                                  "
                    Sql &= "End)As t_dwgs from tdmisg140200                                                                                                           "
                    Sql &= "where t_docn = ('" & DocumentID & "') "


                End If

                Using Cmd As SqlCommand = Con.CreateCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Dim rd As SqlDataReader = Cmd.ExecuteReader
                    While rd.Read
                        mRet.Add(New SIS.DB.PMDL_Information(rd))
                    End While
                End Using
            End Using

            Return mRet
        End Function
        Public Sub New(ByVal Reader As SqlDataReader)
            Try
                For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                    If pi.MemberType = Reflection.MemberTypes.Property Then
                        Try
                            Dim Found As Boolean = False
                            For I As Integer = 0 To Reader.FieldCount - 1
                                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                                    Found = True
                                    Exit For
                                End If
                            Next
                            If Found Then
                                If Convert.IsDBNull(Reader(pi.Name)) Then
                                    Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                                        Case "decimal"
                                            CallByName(Me, pi.Name, CallType.Let, "0.00")
                                        Case "bit"
                                            CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                                        Case Else
                                            CallByName(Me, pi.Name, CallType.Let, String.Empty)
                                    End Select
                                Else
                                    CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Public Sub New()
        End Sub
    End Class

    Public Class MANHOUR_Information



        Public Property t_empname As String = ""
        Public Property t_emno As String = ""
        Public Property t_grcd As String = ""
        Public Property t_cdoc As String = ""
        Public Property t_dsrv As String = ""
        Public Property t_tdat As String = ""
        Public Property t_hhrs As String = ""
        Public Property t_acid As String = ""
        Public Property t_remk As String = ""
        Public Property t_edat As String = ""




        Public Shared Function GetMANHOURDATA(ByVal DocumentID As String, ByVal RevisionNo As String) As List(Of SIS.DB.MANHOUR_Information)


            If DocumentID = "" Then Return Nothing
            Dim mRetd As New DBDocumentDB

            mRetd.DocumentID = DocumentID


            Dim mRet As New List(Of SIS.DB.MANHOUR_Information)
            Dim Sql As String = ""
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
                Con.Open()
                Sql &= " Select (select t_nama from ttccom001200 where t_emno=aa.t_emno) as t_empname,aa.t_emno, (select t_desc from ttiisg911200 where t_grcd=aa.t_grcd) as t_grcd,t_cdoc,t_dsrv,t_tdat, "
                Sql &= "  t_hhrs, (select t_desc from ttiisg908200 where t_acid=aa.t_acid) as t_acid,t_remk,t_edat from ttiisg910200 as aa                                                                   "

                Sql &= " where t_cdoc = ('" & DocumentID & "')                                                                                                                                              "
                Sql &= " order by t_tdat asc"



                Using Cmd As SqlCommand = Con.CreateCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql
                    Dim rd As SqlDataReader = Cmd.ExecuteReader
                    While rd.Read
                        mRet.Add(New SIS.DB.MANHOUR_Information(rd))
                    End While
                End Using
            End Using

            Return mRet
        End Function
        Public Sub New(ByVal Reader As SqlDataReader)
            Try
                For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                    If pi.MemberType = Reflection.MemberTypes.Property Then
                        Try
                            Dim Found As Boolean = False
                            For I As Integer = 0 To Reader.FieldCount - 1
                                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                                    Found = True
                                    Exit For
                                End If
                            Next
                            If Found Then
                                If Convert.IsDBNull(Reader(pi.Name)) Then
                                    Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                                        Case "decimal"
                                            CallByName(Me, pi.Name, CallType.Let, "0.00")
                                        Case "bit"
                                            CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                                        Case Else
                                            CallByName(Me, pi.Name, CallType.Let, String.Empty)
                                    End Select
                                Else
                                    CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Public Sub New()
        End Sub
    End Class


End Namespace
