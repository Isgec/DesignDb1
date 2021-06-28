Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DD
  <DataObject()>
  Partial Public Class DisciplineDetail

    'PLM
    Public Property t_docn As String = ""
    Public Property t_revn As String = ""
    Public Property t_dsca As String = ""
    Public Property t_cprj As String = ""
    Public Property t_pcod As String = ""
    Public Property Project_Name As String = ""

    Public Property t_sars As String = ""
    Public Property t_natp As String = ""

    Public Property t_bpid As String = ""
    Public Property sname As String = ""
    'KJK 


    Public Property prjID As String = ""


    Public Property t_bsfd As String = ""
    Public Property t_acdt As String = ""
    Public Property t_rsfd As String = ""
    Public Property t_lrrd As String = ""
    Public Property t_dttl As String = ""
    Public Property t_resp As String = ""
    Public Property t_appb As String = ""
    Public Property t_chkb As String = ""
    Public Property t_drwb As String = ""
    Public Property t_stat As String = ""
    Public Property t_wfst As String = ""
    Public Property t_soft As String = ""

    Public Property ProjectID As String = ""

    Public Property element As String = ""

    Public Property t_dcrn As String = ""
    Public Property t_cspa As String = ""
    Public Property t_reqs As String = ""
    Public Property t_comp As String = ""
    Public Property t_crea As String = ""
    Public Property t_user As String = ""



    Public Property t_tran As String = ""
    Public Property t_type As String = ""
    Public Property t_logn As String = ""
    Public Property t_subj As String = ""
    Public Property t_apsu As String = ""
    Public Property t_issu As String = ""
    Public Property t_retn As String = ""
    Public Property t_isby As String = ""
    Public Property t_isdt As String = ""

    Public Property t_sarn As String = ""
    Public Property t_draw As String = ""
    Public Property t_prep As String = ""
    Public Property t_rper As String = ""
    Public Property t_apby As String = ""
    Public Property t_idat As String = ""
    Public Property t_cdat As String = ""
    Public Property Sageindays As String = ""

    Public Property t_rcno As String = ""
    Public Property t_item As String = ""
    Public Property IMechanical As String = ""
    Public Property IStructure As String = ""
    Public Property IPiping As String = ""
    Public Property IProcess As String = ""
    Public Property IC_I As String = ""
    Public Property IElectrical As String = ""
    Public Property IQuality As String = ""

    Public Property TT_CSPA As String = ""
    Public Property TT_ENGS As String = ""
    Public Property TT_TITTLE As String = ""
    Public Property TT_DEPT As String = ""

    Public Property Owner_Dept As String = ""
    Public Property t_dprj As String = ""

    Public Property DocumentID As String = ""
    Public Property SerialNo As String = ""
    Public Property Description As String = ""
    Public Property ResponsibleDept As String = ""
    Public Property PartUnderHold As String = ""
    Public Property RevisionAtHold As String = ""
    Public Property RevisionAtUnhold As String = ""
    Public Property reasonforHold As String = ""
    Public Property CreatedBy As String = ""
    Public Property CreatedOn As String = ""
    Public Property HoldStatus As String = ""

    Public Property Project As String = ""
    Public Property UID As String = ""
    Public Property Revision As String = ""

    Public Property Document_ID As String = ""

    Public Property Tittle As String = ""


    Public Property Owner_department As String = ""
    Public Property Actual_Release_Date As String = ""
    Public Property Ptype As String = ""
    Public Property ReceiptID As String = ""
    Public Property RStatus As String = ""
    Public Property ReceiptDate As String = ""
    Public Property SentDate As String = ""
    Public Property Rageindays As String = ""
    Public Property Rrev As String = ""
    Public Property RProject As String = ""
    Public Property ItemDescription As String = ""
    Public Property Mechanical As String = ""
    Public Property sStructure As String = ""
    Public Property Piping As String = ""
    Public Property Process As String = ""
    Public Property CandI As String = ""
    Public Property Electrical As String = ""
    Public Property Quality As String = ""
        'LLL


        Public Shared Function GetDPLMData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String) As List(Of DisciplineDetail)
      Dim userG As String = ""

      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Dim UserIDT As Integer = 0
      Try
        UserIDT = Convert.ToInt32(UserID)
      Catch ex As Exception

      End Try



      If DivisionID = "" Then Return Nothing
      If DisciplineID = "" Then Return Nothing
      If DisciplineID = "CI" Then DisciplineID = "C&I"
      If YearID = "" Then Return Nothing
      If MonthID = "" Then Return Nothing
      Dim mRet As New List(Of SIS.DD.DisciplineDetail)
      Select Case DivisionID
        Case "BOILER"
          DivisionID = "AFBC','BLR_SPR','CFBC','HRSG','OILGAS','TG','WHRB','IPAC"
        Case "SMD"
          DivisionID = "SPDR"
        Case "EPC"
          DivisionID = "EPC01"
        Case "APC"
          DivisionID = "ESP"


        Case "FGD"
          DivisionID = "SDFGD"

      End Select






      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString() & ";Connection Timeout=50000")
        Con.Open()




        Select Case det

          Case "ToRelease_CurrentM"
            Sql = " select t_pcod,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_docn,t_revn,t_dsca,convert(date, dateadd(n,330,t_bsfd))As t_bsfd, convert(date, dateadd(n,330,t_rsfd)) As t_rsfd,convert(date, dateadd(n,330,t_acdt)) As t_acdt,convert(date, dateadd(n,330,t_lrrd)) as t_lrrd from tdmisg140200 as rec where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(dateadd(n,330,t_bsfd)) in (" & YearID & ") and month(dateadd(n,330,t_bsfd)) in (" & MonthID & ") and t_orgn='ISG' and t_docn not like '%VEN%'"

          Case "DueforRelease_CurrentM_A"
            Sql = " select t_pcod,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_docn,t_revn,t_dsca,convert(date, dateadd(n,330,t_bsfd))As t_bsfd, convert(date, dateadd(n,330,t_rsfd)) As t_rsfd,convert(date, dateadd(n,330,t_acdt)) As t_acdt,convert(date, dateadd(n,330,t_lrrd)) as t_lrrd from tdmisg140200 as rec where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(dateadd(n,330,t_bsfd)) in (" & YearID & ") and month(dateadd(n,330,t_bsfd)) in (" & MonthID & ") and t_orgn='ISG' and t_docn not like '%VEN%' and t_acdt ='1970-01-01 00:00:00.000'"

          Case "DueforRelease_PreviousM_B"
            Sql = " select t_pcod,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_docn,t_revn,t_dsca,convert(date, dateadd(n,330,t_bsfd))As t_bsfd, convert(date, dateadd(n,330,t_rsfd)) As t_rsfd,convert(date, dateadd(n,330,t_acdt)) As t_acdt,convert(date, dateadd(n,330,t_lrrd)) as t_lrrd from tdmisg140200 as rec where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')  and t_acdt ='1970-01-01 00:00:00.000' and t_orgn='ISG' and (dateadd(n,330,t_bsfd)) <' " & YearID & "-" & MonthID & "-01 00:00:00.000' and t_docn not like '%VEN%'"

          Case "DueforRelease_BothM_C"

            If (MonthID = 12) Then
              Sql = " select t_pcod,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_docn,t_revn,t_dsca,convert(date, dateadd(n,330,t_bsfd))As t_bsfd, convert(date, dateadd(n,330,t_rsfd)) As t_rsfd,convert(date, dateadd(n,330,t_acdt)) As t_acdt,convert(date, dateadd(n,330,t_lrrd)) as t_lrrd from tdmisg140200 as rec where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and t_acdt ='1970-01-01 00:00:00.000' and t_orgn='ISG' and (dateadd(n,330,t_bsfd)) <' " & YearID + 1 & "-" & 1 & "-01 00:00:00.000' and t_docn not like '%VEN%'"
            Else
              Sql = " select t_pcod,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_docn,t_revn,t_dsca,convert(date, dateadd(n,330,t_bsfd))As t_bsfd, convert(date, dateadd(n,330,t_rsfd)) As t_rsfd,convert(date, dateadd(n,330,t_acdt)) As t_acdt,convert(date, dateadd(n,330,t_lrrd)) as t_lrrd from tdmisg140200 as rec where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and t_acdt ='1970-01-01 00:00:00.000' and t_orgn='ISG' and (dateadd(n,330,t_bsfd)) <' " & YearID & "-" & MonthID + 1 & "-01 00:00:00.000' and t_docn not like '%VEN%'"

            End If


          Case "AllDueTillToday_Release"
            Sql = "select t_pcod,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_docn,t_revn,t_dsca,convert(date, dateadd(n,330,t_bsfd))As t_bsfd, convert(date, dateadd(n,330,t_rsfd)) As t_rsfd,convert(date, dateadd(n,330,t_acdt)) As t_acdt,convert(date, dateadd(n,330,t_lrrd)) as t_lrrd From tdmisg140200 as rec Where  t_resp In ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) <= convert(date,getdate()) and t_docn not like '%VEN%' "

          Case "DueOnlyToday_Release"
            Sql = "Select t_pcod,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_docn,t_revn,t_dsca,convert(date, dateadd(n,330,t_bsfd))As t_bsfd, convert(date, dateadd(n,330,t_rsfd)) As t_rsfd,convert(date, dateadd(n,330,t_acdt)) As t_acdt,convert(date, dateadd(n,330,t_lrrd)) as t_lrrd From tdmisg140200 as rec Where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) = convert(date,getdate())  and t_docn not like '%VEN%'"

          Case "Ontime_Release_CurrentM"
            Sql = "		select t_pcod,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_docn,t_revn,t_dsca,convert(date, dateadd(n,330,t_bsfd))As t_bsfd, convert(date, dateadd(n,330,t_rsfd)) As t_rsfd,convert(date, dateadd(n,330,t_acdt)) As t_acdt,convert(date, dateadd(n,330,t_lrrd)) as t_lrrd		"
            Sql &= "		from tdmisg140200 as rec		 "
            Sql &= "		where		 "
            Sql &= "		t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(dateadd(n,330,t_bsfd)) in (" & YearID & ")and month(dateadd(n,330,t_bsfd)) in (" & MonthID & ") And t_acdt <>'1970-01-01 00:00:00.000' and t_docn not like '%VEN%'"

            Sql &= "  And 1 =   case when (dateadd(n,330,t_acdt)) <  dateadd(d,1,(dateadd(n,330,t_bsfd))) "
            Sql &= "	then 1 else 0 end "

          Case "Backlog_Release_CurrentM"
            Sql = "		select t_pcod,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_docn,t_revn,t_dsca,convert(date, dateadd(n,330,t_bsfd))As t_bsfd, convert(date, dateadd(n,330,t_rsfd)) As t_rsfd,convert(date, dateadd(n,330,t_acdt)) As t_acdt,convert(date, dateadd(n,330,t_lrrd)) as t_lrrd		"
            Sql &= "	from tdmisg140200 as rec		 "
            Sql &= "	where		 "
            Sql &= "	t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(dateadd(n,330,t_acdt)) in (" & YearID & ")and month(dateadd(n,330,t_acdt)) in (" & MonthID & ") and t_docn not like '%VEN%'"
            Sql &= "  and t_acdt <> convert(datetime,'01/01/1970',103)	and (dateadd(n,330,t_bsfd)) <=' " & YearID & "-" & MonthID & "-01 00:00:00.000'"
            Sql &= "  And 1 =   case when (dateadd(n,330,t_acdt)) < dateadd(d,1,(dateadd(n,330,t_bsfd)))  "
            Sql &= "	then 0 else 1 end  "
            Sql &= "	order by t_docn "


        End Select

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While (rd.Read)
            mRet.Add(New DisciplineDetail(rd))
          End While
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function GetDissueData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String) As List(Of DisciplineDetail)
      Dim userG As String = ""

      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Dim UserIDT As Integer = 0
      Try
        UserIDT = Convert.ToInt32(UserID)
      Catch ex As Exception

      End Try



      If DivisionID = "" Then Return Nothing
      If DisciplineID = "" Then Return Nothing
      If DisciplineID = "CI" Then DisciplineID = "C&I"
      If YearID = "" Then Return Nothing
      If MonthID = "" Then Return Nothing
      Dim mRet As New List(Of SIS.DD.DisciplineDetail)
      Select Case DivisionID
        Case "BOILER"
          DivisionID = "AFBC','BLR_SPR','CFBC','HRSG','OILGAS','TG','WHRB','IPAC"
        Case "SMD"
          DivisionID = "SPDR"
        Case "EPC"
          DivisionID = "EPC01"
        Case "APC"
          DivisionID = "ESP"


        Case "FGD"
          DivisionID = "SDFGD"

      End Select






      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString() & ";Connection Timeout=50000")
        Con.Open()




        Select Case det

          Case "Dueforissue_CurrentM_A"
            Sql = " Select aa.t_pcod,aa.t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=aa.t_cprj) as Project_Name,aa.t_docn,aa.t_revn,aa.t_dsca,convert(date, dateadd(n,330,aa.t_acdt)) As t_acdt from tdmisg140200 As aa where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(dateadd(n,330,aa.t_acdt)) in "
                        Sql &= "(" & YearID & ") and month(dateadd(n,330,aa.t_acdt)) in (" & MonthID & ") And aa.t_docn not in (select bb.t_docn from tdmisg132200 as bb "
                        Sql &= "inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran where year(dateadd(n,330,cc.t_isdt)) in (" & YearID & ") and  cc.t_stat in (5) and month(dateadd(n,330,cc.t_isdt)) in "
                        Sql &= "(" & MonthID & ")and bb.t_revn = aa.t_revn) order by aa.t_acdt desc"
                    Case "Dueforissue_previousM_B"
            Sql = " Select aa.t_pcod,aa.t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=aa.t_cprj) as Project_Name,aa.t_docn,aa.t_revn,aa.t_dsca,convert(date, dateadd(n,330,aa.t_acdt)) As t_acdt from tdmisg140200 As aa where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and aa.t_acdt >= dateadd(d,-30,getdate())"
                        Sql &= " And aa.t_docn not in (select bb.t_docn from tdmisg132200 as bb "
                        Sql &= " inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran where cc.t_stat in (5) And cc.t_isdt >= dateadd(d,-30,getdate())and bb.t_revn = aa.t_revn)  order by aa.t_acdt desc"

                    Case "Dueforissue_Total_C"
            Sql = " Select aa.t_pcod,aa.t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=aa.t_cprj) as Project_Name,aa.t_docn,aa.t_revn,aa.t_dsca,convert(date, dateadd(n,330,aa.t_acdt)) As t_acdt from tdmisg140200 As aa where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and aa.t_acdt >= dateadd(d,-60,getdate())"
                        Sql &= " And aa.t_docn  not in (select bb.t_docn from tdmisg132200 as bb "
                        Sql &= " inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran where cc.t_stat in (5) And cc.t_isdt >= dateadd(d,-60,getdate())and bb.t_revn = aa.t_revn)  order by aa.t_acdt desc"


                    Case "Dueforissue_Total_D"
                        Sql = " Select aa.t_pcod,aa.t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=aa.t_cprj) as Project_Name,aa.t_docn,aa.t_revn,aa.t_dsca,convert(date, dateadd(n,330,aa.t_acdt)) As t_acdt from tdmisg140200 As aa where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and aa.t_acdt >= dateadd(d,-100,getdate())"
                        Sql &= " And aa.t_docn  not in (select bb.t_docn from tdmisg132200 as bb "
                        Sql &= " inner join tdmisg131200 as cc on bb.t_tran=cc.t_tran where cc.t_stat in (5) And cc.t_isdt >= dateadd(d,-100,getdate())and bb.t_revn = aa.t_revn)  order by aa.t_acdt desc"


                End Select

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While (rd.Read)
            mRet.Add(New DisciplineDetail(rd))
          End While
        End Using
      End Using
      Return mRet
    End Function

    Public Shared Function GetDSARData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String) As List(Of DisciplineDetail)
      Dim userG As String = ""
      Dim PrjID As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Dim UserIDT As Integer = 0
      Try
        UserIDT = Convert.ToInt32(UserID)
      Catch ex As Exception

      End Try

      If DivisionID = "" Then Return Nothing
      If DisciplineID = "" Then Return Nothing
      If DisciplineID = "CI" Then DisciplineID = "C&I"
      If YearID = "" Then Return Nothing
      If MonthID = "" Then Return Nothing
      Dim mRet As New List(Of SIS.DD.DisciplineDetail)
      Select Case DivisionID
        Case "BOILER"
          'DivisionID = "AFBC','BLR_SPR','CFBC','HRSG','OILGAS','TG','WHRB','IPAC"
          PrjID = "CA', 'IP', 'JA', 'JB', 'JE', 'JG',  'BS', 'DS"
        Case "SMD"
          'DivisionID = "SPDR"
          PrjID = "JS', 'SE', 'SG', 'SS', 'XP"
        Case "EPC"
          'DivisionID = "EPC01"
          PrjID = "EC', 'EE', 'EF','EG', 'EM', 'ES', 'JP"
        Case "APC"
          ' DivisionID = "ESP"
          PrjID = "AG', 'AS"
        Case "FGD"
          'DivisionID = "SDFGD"
          PrjID = "FG', 'FS', 'PS"
      End Select

      Select Case DisciplineID

        Case "PRC"
          DisciplineID = "PROCESS','MECHANICAL/PROCE','PROCESS-STOKER"
        Case "MEC"
          DisciplineID = "MECHANICAL/PROCE','MECHANICAL','MECH-SUGAR"
        Case "STR"
          DisciplineID = "STRUCTURE"
        Case "PIP"
          DisciplineID = "PIPING"
        Case "ELE"
          DisciplineID = "ELECTRICAL"
        Case "C&I"
          DisciplineID = "C & I','C&I','INSTRUMENTATION"
        Case "CIV"
          DisciplineID = "CIVIL"
        Case "MHE"
          DisciplineID = "MHE"
        Case "PRJ"
          DisciplineID = "OTHERS','SERVICE"
        Case "WWS"
          DisciplineID = "WWS"

      End Select



      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString() & ";Connection Timeout=50000")
        Con.Open()




        Select Case det

          Case "SAR_TotalCount"


            Sql = "             Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"

            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "
            Sql &= "          from ttpisg074200 As rec LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort In ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "            Order by Sageindays Desc"

          Case "SAR_UnderCreation"

            Sql = "Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"

            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "
            Sql &= " from ttpisg074200 As rec LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort In ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =1 and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "             Order by Sageindays Desc"
          Case "SAR_UnderReview"
            Sql = "             Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =2 and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "            Order by Sageindays Desc"
          Case "SAR_UnderApproval"
            Sql = "           Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "


            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =3 and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "            Order by Sageindays Desc"
          Case "SAR_Pending"
            Sql = "           Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "

            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat in (2,3) and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "             Order by Sageindays Desc"
          Case "SAR_Approved"

            Sql = "           Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =4 and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "             Order by Sageindays Desc"

          Case "SAR_NotApplicable"

            Sql = "           Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =5 and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "             Order by Sageindays Desc"
          Case "SAR_TotalCountA"

            Sql = "           Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "')  "
            Sql &= "             Order by Sageindays Desc"
          Case "SAR_UnderCreationA"

            Sql = "           Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =1  "
            Sql &= "            Order by Sageindays Desc"
          Case "SAR_UnderReviewA"
            Sql = "           Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "

            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =2  "
            Sql &= "           Order by Sageindays Desc"
          Case "SAR_UnderApprovalA"

            Sql = "Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "
            Sql &= "        from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =3  "
            Sql &= "          Order by Sageindays Desc"
          Case "SAR_PendingA"

            Sql = "Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "
            Sql &= "        from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat in (2,3)  "
            Sql &= "        Order by Sageindays Desc"
          Case "SAR_ApprovedA"

            Sql = "Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "
            Sql &= "            from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =4  "

            Sql &= "             Order by Sageindays Desc"
          Case "SAR_NotApplicableA"

            Sql = "Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn,convert(nvarchar(10),dateadd(n,330,rec.t_idat),103) as t_cdat,convert(nvarchar(10),dateadd(n,330,rec.t_cdat),103) as t_idat,datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_cdat)),getdate()) as Sageindays, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"

            Sql &= "             (case t_sars "
            Sql &= "            When 1 Then 'Work Stopped' "
            Sql &= "           when 3 then 'Work can Proceed' "
            Sql &= "         End) As t_sars ,(select t_desc from ttpisg070200 where ttpisg070200.t_code=rec.t_natp) as t_natp,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_rper) as t_rper,(select t_nama from ttccom001200 where ttccom001200.t_emno=rec.t_apby) as t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =5  "
            Sql &= "            Order by Sageindays Desc"


        End Select

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While (rd.Read)
            mRet.Add(New DisciplineDetail(rd))
          End While
        End Using
      End Using
      Return mRet
    End Function

    Public Shared Function GetDELEMENTData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String) As List(Of DisciplineDetail)
      Dim PrjID As String = ""
      If DivisionID = "" Then Return Nothing
      If DisciplineID = "CI" Then DisciplineID = "C&I"
      Dim mRet As New List(Of SIS.DD.DisciplineDetail)
      Select Case DivisionID
        Case "BOILER"
          'DivisionID = "AFBC','BLR_SPR','CFBC','HRSG','OILGAS','TG','WHRB','IPAC"
          PrjID = "CA', 'IP', 'JA', 'JB', 'JE', 'JG', 'BS', 'DS"
        Case "SMD"
          'DivisionID = "SPDR"
          PrjID = "JS', 'SE', 'SG', 'SS', 'XP"
        Case "EPC"
          'DivisionID = "EPC01"
          PrjID = "EC', 'EE', 'EF','EG', 'EM', 'ES', 'JP"
        Case "APC"
          ' DivisionID = "ESP"
          PrjID = "AG', 'AS"

        Case "FGD"
          'DivisionID = "SDFGD"
          PrjID = "FG', 'FS', 'PS"
      End Select



      Select Case DisciplineID

        Case "PRC"
          DisciplineID = "PROCESS','MECHANICAL/PROCE','PROCESS-STOKER"
        Case "MEC"
          DisciplineID = "MECHANICAL/PROCE','MECHANICAL','MECH-SUGAR"
        Case "STR"
          DisciplineID = "STRUCTURE"
        Case "PIP"
          DisciplineID = "PIPING"
        Case "ELE"
          DisciplineID = "ELECTRICAL"
        Case "C&I"
          DisciplineID = "C & I','C&I','INSTRUMENTATION"
        Case "CIV"
          DisciplineID = "CIVIL"
        Case "MHE"
          DisciplineID = "MHE"
        Case "PRJ"
          DisciplineID = "OTHERS','SERVICE"
        Case "WWS"
          DisciplineID = "WWS"

      End Select



      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString() & ";Connection Timeout=50000")
        Con.Open()


        Select Case det

          Case "Total_Element"

            Sql = " Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,rec.t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,rec.t_cspa As TT_CSPA,( "
            Sql &= "         Case rec.t_engs "
            Sql &= "         When 1 Then 'Free' "
            Sql &= "         when 2 then 'Partial' "
            Sql &= "         when 3 then 'Complete' "
            Sql &= "         end "
            Sql &= "         ) as TT_ENGS,ttppdm090200.t_desc AS TT_TITTLE,(case ttppdm090200.t_sort "
            Sql &= "  when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= " when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= " when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= " WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= " when 'OTHERS' then 'OTHERS' "
            Sql &= " WHEN 'PROCESS' then 'PROCESS' "
            Sql &= " WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= " WHEN 'PIPING' THEN 'PIPING' "
            Sql &= " WHEN 'C & I' THEN 'C&I' "
            Sql &= " WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= " WHEN 'EPC' THEN 'EPC' "
            Sql &= " WHEN 'C&I' THEN 'C&I' "
            Sql &= " WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= " WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "  else 'OTHERS' "
            Sql &= "  end) AS TT_DEPT from ttpisg063200 as rec"
            Sql &= " LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort In ('" & DisciplineID & "') and substring(rec.t_cprj,1,2) in ('" & PrjID & "') and rec.t_appl=1 "

          Case "Element_Free"
            Sql = " Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,rec.t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,rec.t_cspa As TT_CSPA,( "
            Sql &= "         Case rec.t_engs "
            Sql &= "         When 1 Then 'Free' "
            Sql &= "         when 2 then 'Partial' "
            Sql &= "         when 3 then 'Complete' "
            Sql &= "         end "
            Sql &= "         ) as TT_ENGS,ttppdm090200.t_desc AS TT_TITTLE,(case ttppdm090200.t_sort "
            Sql &= "  when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= " when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= " when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= " WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= " when 'OTHERS' then 'OTHERS' "
            Sql &= " WHEN 'PROCESS' then 'PROCESS' "
            Sql &= " WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= " WHEN 'PIPING' THEN 'PIPING' "
            Sql &= " WHEN 'C & I' THEN 'C&I' "
            Sql &= " WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= " WHEN 'EPC' THEN 'EPC' "
            Sql &= " WHEN 'C&I' THEN 'C&I' "
            Sql &= " WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= " WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "  else 'OTHERS' "
            Sql &= "  end) AS TT_DEPT from ttpisg063200 as rec"
            Sql &= " LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') and substring(rec.t_cprj,1,2) in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=1 "

          Case "Element_Partial"
            Sql = " Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,rec.t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, rec.t_cspa As TT_CSPA,( "
            Sql &= "         Case rec.t_engs "
            Sql &= "         When 1 Then 'Free' "
            Sql &= "         when 2 then 'Partial' "
            Sql &= "         when 3 then 'Complete' "
            Sql &= "         end "
            Sql &= "         ) as TT_ENGS,ttppdm090200.t_desc AS TT_TITTLE,(case ttppdm090200.t_sort "
            Sql &= "  when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= " when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= " when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= " WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= " when 'OTHERS' then 'OTHERS' "
            Sql &= " WHEN 'PROCESS' then 'PROCESS' "
            Sql &= " WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= " WHEN 'PIPING' THEN 'PIPING' "
            Sql &= " WHEN 'C & I' THEN 'C&I' "
            Sql &= " WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= " WHEN 'EPC' THEN 'EPC' "
            Sql &= " WHEN 'C&I' THEN 'C&I' "
            Sql &= " WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= " WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "  else 'OTHERS' "
            Sql &= "  end) AS TT_DEPT from ttpisg063200 as rec"

            Sql &= " LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') and substring(rec.t_cprj,1,2) in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=2 "


          Case "Element_Completed"
            Sql = " Select (select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType, rec.t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, rec.t_cspa As TT_CSPA,( "
            Sql &= "         Case rec.t_engs "
            Sql &= "         When 1 Then 'Free' "
            Sql &= "         when 2 then 'Partial' "
            Sql &= "         when 3 then 'Complete' "
            Sql &= "         end "
            Sql &= "         ) as TT_ENGS,ttppdm090200.t_desc AS TT_TITTLE,(case ttppdm090200.t_sort "
            Sql &= "  when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= " when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= " when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= " WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= " when 'OTHERS' then 'OTHERS' "
            Sql &= " WHEN 'PROCESS' then 'PROCESS' "
            Sql &= " WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= " WHEN 'PIPING' THEN 'PIPING' "
            Sql &= " WHEN 'C & I' THEN 'C&I' "
            Sql &= " WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= " WHEN 'EPC' THEN 'EPC' "
            Sql &= " WHEN 'C&I' THEN 'C&I' "
            Sql &= " WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= " WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "  else 'OTHERS' "
            Sql &= "  end) AS TT_DEPT from ttpisg063200 as rec"
            Sql &= " LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa where ttppdm090200.t_sort in ('" & DisciplineID & "') and substring(rec.t_cprj,1,2) in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=3 "

        End Select

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While (rd.Read)
            mRet.Add(New DisciplineDetail(rd))
          End While
        End Using
      End Using
      Return mRet
    End Function

    Public Shared Function GetDIDMSPREData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String) As List(Of DisciplineDetail)
      Dim userG As String = ""
      Dim PrjID As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Dim UserIDT As Integer = 0
      Try
        UserIDT = Convert.ToInt32(UserID)
      Catch ex As Exception

      End Try

      If DivisionID = "" Then Return Nothing
      If DisciplineID = "" Then Return Nothing
      If DisciplineID = "CI" Then DisciplineID = "C&I"
      If YearID = "" Then Return Nothing
      If MonthID = "" Then Return Nothing
      Dim mRet As New List(Of SIS.DD.DisciplineDetail)
      Select Case DivisionID
        Case "BOILER"
          'DivisionID = "AFBC','BLR_SPR','CFBC','HRSG','OILGAS','TG','WHRB','IPAC"
          PrjID = "CA', 'IP', 'JA', 'JB', 'JE', 'JG',  'BS', 'DS"
        Case "SMD"
          'DivisionID = "SPDR"
          PrjID = "JS', 'SE', 'SG', 'SS', 'XP"
        Case "EPC"
          'DivisionID = "EPC01"
          PrjID = "EC', 'EE', 'EF','EG', 'EM', 'ES', 'JP"
        Case "APC"
          ' DivisionID = "ESP"
          PrjID = "AG', 'AS"
        Case "FGD"
          'DivisionID = "SDFGD"
          PrjID = "FG', 'FS', 'PS"
      End Select

      Select Case DisciplineID

        Case "PRC"
          DisciplineID = "PROCESS','MECHANICAL/PROCE','PROCESS-STOKER"
        Case "MEC"
          DisciplineID = "MECHANICAL/PROCE','MECHANICAL','MECH-SUGAR"
        Case "STR"
          DisciplineID = "STRUCTURE"
        Case "PIP"
          DisciplineID = "PIPING"
        Case "ELE"
          DisciplineID = "ELECTRICAL"
        Case "C&I"
          DisciplineID = "C & I','C&I','INSTRUMENTATION"
        Case "CIV"
          DisciplineID = "CIVIL"
        Case "MHE"
          DisciplineID = "MHE"
        Case "PRJ"
          DisciplineID = "OTHERS','SERVICE"
        Case "WWS"
          DisciplineID = "WWS"

      End Select



      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString() & ";Connection Timeout=50000")
        Con.Open()




        Select Case det

          Case "IDMSPre_Total_Count"



            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname,rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType, "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ") "
            Sql &= " order by Rageindays desc"


          Case "IDMSPre_Submitted"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname,rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=1"
            Sql &= " order by Rageindays desc"

          Case "IDMSPre_Document_linked"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname,rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=2"
            Sql &= " order by Rageindays desc"
          Case "IDMSPre_Under_Evaluation"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=3"
            Sql &= " order by Rageindays desc"
          Case "IDMSPre_Comments_Submitted"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=4"
            Sql &= " order by Rageindays desc"
          Case "IDMSPre_Technically_Cleared"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=5"
            Sql &= " order by Rageindays desc"
          Case "IDMSPre_Transmittal_Issued"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=6"
            Sql &= " order by Rageindays desc"
          Case "IDMSPre_Superceded"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=7"
            Sql &= " order by Rageindays desc"
          Case "IDMSPre_Closed"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus, (select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=8"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPre_Total_Count"



            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " order by Rageindays desc"


          Case "All_IDMSPre_Submitted"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " and rec.t_stat=1"
            Sql &= " order by Rageindays desc"

          Case "All_IDMSPre_Document_linked"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus, (select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " and rec.t_stat=2"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPre_Under_Evaluation"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " and rec.t_stat=3"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPre_Comments_Submitted"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= "   and rec.t_stat=4"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPre_Technically_Cleared"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus, (select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= "   and rec.t_stat=5"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPre_Transmittal_Issued"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,  "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= "   and rec.t_stat=6"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPre_Superceded"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus, (select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= "    and rec.t_stat=7"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPre_Closed"
            Sql = "Select rec.t_bpid as t_bpid, ISNULL((Select t_nama from ttccom100200  where t_bpid =rec.t_bpid),'-') as Sname, rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus, (select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= "  and rec.t_stat=8"
            Sql &= " order by Rageindays desc"

        End Select

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While (rd.Read)
            mRet.Add(New DisciplineDetail(rd))
          End While
        End Using
      End Using
      Return mRet
    End Function


    Public Shared Function GetDIDMSPOSTData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String) As List(Of DisciplineDetail)
      Dim userG As String = ""
      Dim PrjID As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Dim UserIDT As Integer = 0
      Try
        UserIDT = Convert.ToInt32(UserID)
      Catch ex As Exception

      End Try

      If DivisionID = "" Then Return Nothing
      If DisciplineID = "" Then Return Nothing
      If DisciplineID = "CI" Then DisciplineID = "C&I"
      If YearID = "" Then Return Nothing
      If MonthID = "" Then Return Nothing
      Dim mRet As New List(Of SIS.DD.DisciplineDetail)
      Select Case DivisionID
        Case "BOILER"
          'DivisionID = "AFBC','BLR_SPR','CFBC','HRSG','OILGAS','TG','WHRB','IPAC"
          PrjID = "CA', 'IP', 'JA', 'JB', 'JE', 'JG',  'BS', 'DS"
        Case "SMD"
          'DivisionID = "SPDR"
          PrjID = "JS', 'SE', 'SG', 'SS', 'XP"
        Case "EPC"
          'DivisionID = "EPC01"
          PrjID = "EC', 'EE', 'EF','EG', 'EM', 'ES', 'JP"
        Case "APC"
          ' DivisionID = "ESP"
          PrjID = "AG', 'AS"

        Case "FGD"
          'DivisionID = "SDFGD"
          PrjID = "FG', 'FS', 'PS"
      End Select

      Select Case DisciplineID

        Case "PRC"
          DisciplineID = "PROCESS','MECHANICAL/PROCE','PROCESS-STOKER"
        Case "MEC"
          DisciplineID = "MECHANICAL/PROCE','MECHANICAL','MECH-SUGAR"
        Case "STR"
          DisciplineID = "STRUCTURE"
        Case "PIP"
          DisciplineID = "PIPING"
        Case "ELE"
          DisciplineID = "ELECTRICAL"
        Case "C&I"
          DisciplineID = "C & I','C&I','INSTRUMENTATION"
        Case "CIV"
          DisciplineID = "CIVIL"
        Case "MHE"
          DisciplineID = "MHE"
        Case "PRJ"
          DisciplineID = "OTHERS','SERVICE"
        Case "WWS"
          DisciplineID = "WWS"

      End Select



      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString() & ";Connection Timeout=50000")
        Con.Open()




        Select Case det

          Case "IDMSPost_Total_Count"



            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ") "
            Sql &= " order by Rageindays desc"

          Case "IDMSPost_Submitted"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=1"
            Sql &= " order by Rageindays desc"

          Case "IDMSPost_Document_linked"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=2"
            Sql &= " order by Rageindays desc"
          Case "IDMSPost_Under_Evaluation"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=3"
            Sql &= " order by Rageindays desc"
          Case "IDMSPost_Comments_Submitted"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=4"
            Sql &= " order by Rageindays desc"
          Case "IDMSPost_Technically_Cleared"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=5"
            Sql &= " order by Rageindays desc"
          Case "IDMSPost_Transmittal_Issued"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=6"
            Sql &= " order by Rageindays desc"
          Case "IDMSPost_Superceded"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=7"
            Sql &= " order by Rageindays desc"
          Case "IDMSPost_Closed"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " And year(rec.t_date) in (" & YearID & ") And month(rec.t_date) in (" & MonthID & ")   and rec.t_stat=8"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPost_Total_Count"



            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " order by Rageindays desc"


          Case "All_IDMSPost_Submitted"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " and rec.t_stat=1"
            Sql &= " order by Rageindays desc"

          Case "All_IDMSPost_Document_linked"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " and rec.t_stat=2"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPost_Under_Evaluation"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= " and rec.t_stat=3"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPost_Comments_Submitted"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= "   and rec.t_stat=4"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPost_Technically_Cleared"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= "   and rec.t_stat=5"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPost_Transmittal_Issued"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= "   and rec.t_stat=6"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPost_Superceded"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= "    and rec.t_stat=7"
            Sql &= " order by Rageindays desc"
          Case "All_IDMSPost_Closed"
            Sql = "Select rec.t_rcno As ReceiptID,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType,  "
            Sql &= "  (Case rec.t_stat "
            Sql &= " when 1 then 'Submitted' "
            Sql &= " when 2 then 'Document linked' "
            Sql &= " when 3 then 'Under Evaluation' "
            Sql &= " when 4 then 'Comments Submitted' "
            Sql &= " when 5 then 'Technically Cleared' "
            Sql &= " when 6 then 'Transmittal Issued' "
            Sql &= " when 7 then 'Superceded' "
            Sql &= " when 8 then 'Closed' end)as RStatus, (select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
            Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
            Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
            Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
            Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
            Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
            Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
            Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
            Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
            Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
            Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

            Sql &= " From tdmisg134200 As rec "

            Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
            Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
            Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
            Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
            Sql &= "  and rec.t_stat=8"
            Sql &= " order by Rageindays desc"

        End Select

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While (rd.Read)
            mRet.Add(New DisciplineDetail(rd))
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
