Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DB
  <DataObject()>
  Partial Public Class engDoc
    Public Property ProjectID As String = ""
    Public Property DocID As String = ""
    Public Property Rev As String = ""
    Public Property UserID As String = ""
    Public Property Tittle As String = ""
    Public Property DStatus As String = ""
    Public Property DrawnBy As String = ""
    Public Property Reviewer As String = ""
    Public Property Approver As String = ""
    Public Property DWorkFlow As String = ""
    Public Property ReceiptID As String = ""
    Public Property ReceiptDate As String = ""
    Public Property SentDate As String = ""
    Public Property Rageindays As String = ""
    Public Property Owner_Dept As String = ""
    Public Property Relement As String = ""
    Public Property PType As String = ""
    Public Property Project_Name As String = ""
    Public Property PO_Number As String = ""
    Public Property PO_Status As String = ""
    Public Property PR_Status As String = ""

    Public Property Rrev As String = ""
    Public Property RProject As String = ""

    Public Property ItemDescription As String = ""
    Public Property RStatus As String = ""
    Public Property Mechanical As String = ""
    Public Property Structure_ As String = ""
    Public Property Piping As String = ""
    Public Property Process As String = ""
    Public Property CandI As String = ""
    Public Property Electrical As String = ""
    Public Property Quality As String = ""

    Public Property TID As String = ""
    Public Property TProject As String = ""
    Public Property TStatus As String = ""
    Public Property TType As String = ""

    Public Property DCRNumber As String = ""
    Public Property DDescription As String = ""
    Public Property Dproject As String = ""
    Public Property DElement As String = ""
    Public Property DCreatedBy As String = ""
    Public Property DApprover As String = ""
    Public Property DCRStatus As String = ""


    Public Property SAR_Project As String = ""
    Public Property SAR_Number As String = ""
    Public Property SAR_Element As String = ""
    Public Property SAR_Drawing As String = ""
    Public Property SAR_PreparedBy As String = ""
    Public Property SAR_Status As String = ""
    Public Property SAR_Reviewer As String = ""
    Public Property SAR_Approver As String = ""


    Public Property MH_EmployeeCode As String = ""
    Public Property MH_Date As String = ""
    Public Property MH_activity As String = ""
    Public Property MH_Project As String = ""
    Public Property MH_serialnumber As String = ""
    Public Property MH_Division As String = ""
    Public Property MH_Remark As String = ""
    Public Property MH_HoursEntered As String = ""
    Public Property MH_EngineeringGroup As String = ""





    Public Shared Function GetData(ByVal det As String, ByVal emp As String) As List(Of engDoc)
      Dim userG As String = ""

      Dim mRet As New List(Of SIS.DB.engDoc)
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Dim UserIDT As Integer = 0
      Try
        UserIDT = Convert.ToInt32(UserID)
      Catch ex As Exception

      End Try
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Select Case det

          Case "cpr"

            Sql = " select "
            Sql &= "(case t_wfst "
            Sql &= " when 1 then 'Under Design' "
            Sql &= " when 2 then 'Submitted' "
            Sql &= " when 3 then 'Under Review' "
            Sql &= " when 4 then 'Under Approval' "
            Sql &= " when 5 then 'Released' "
            Sql &= " when 6 then 'Withdrawn' "
            Sql &= " when 7 then 'Under Revision' "
            Sql &= " when 8 then 'Superceded' "
            Sql &= " when 9 then 'Under DCR' "
            Sql &= "  End) "
            Sql &= " as DWorkFlow,"
            Sql &= "(case t_stat "
            Sql &= " when 1 then 'Submitted'"
            Sql &= " when 2 then 'Item Released' "
            Sql &= " when 3 then 'Drawing Released' "
            Sql &= "  End) "
            Sql &= " as DStatus,t_docn as DocID, t_revn as Rev,t_dttl as Tittle,t_user as DrawnBy,t_rusr as Reviewer,t_ausr as Approver "
            Sql &= " From tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr in ('" & UserID & "','" & UserIDT & "') "

          Case "cpa"

            Sql = " select "
            Sql &= "(case t_wfst "
            Sql &= " when 1 then 'Under Design' "
            Sql &= " when 2 then 'Submitted' "
            Sql &= " when 3 then 'Under Review' "
            Sql &= " when 4 then 'Under Approval' "
            Sql &= " when 5 then 'Released' "
            Sql &= " when 6 then 'Withdrawn' "
            Sql &= " when 7 then 'Under Revision' "
            Sql &= " when 8 then 'Superceded' "
            Sql &= " when 9 then 'Under DCR' "
            Sql &= "  End) "
            Sql &= " as DWorkFlow,"
            Sql &= "(case t_stat "
            Sql &= " when 1 then 'Submitted'"
            Sql &= " when 2 then 'Item Released' "
            Sql &= " when 3 then 'Drawing Released' "
            Sql &= "  End) "
            Sql &= " as DStatus,t_docn as DocID, t_revn as Rev,t_dttl as Tittle,t_user as DrawnBy,t_rusr as Reviewer,t_ausr as Approver "
            Sql &= " From tdmisg001200 where t_stat =1 And t_wfst =4 And t_ausr In ('" & UserID & "','" & UserIDT & "') "

          Case "cpd"

            Sql = " select "
            Sql &= "(case t_wfst "
            Sql &= " when 1 then 'Under Design' "
            Sql &= " when 2 then 'Submitted' "
            Sql &= " when 3 then 'Under Review' "
            Sql &= " when 4 then 'Under Approval' "
            Sql &= " when 5 then 'Released' "
            Sql &= " when 6 then 'Withdrawn' "
            Sql &= " when 7 then 'Under Revision' "
            Sql &= " when 8 then 'Superceded' "
            Sql &= " when 9 then 'Under DCR' "
            Sql &= "  End) "
            Sql &= " as DWorkFlow,"
            Sql &= "(case t_stat "
            Sql &= " when 1 then 'Under Design' "
            Sql &= " when 2 then 'Submitted' "
            Sql &= " when 3 then 'Under Review' "
            Sql &= " when 4 then 'Under Approval' "
            Sql &= " when 5 then 'Released' "
            Sql &= " when 6 then 'Withdrawn' "
            Sql &= " when 7 then 'Under Revision' "
            Sql &= " when 8 then 'Superceded' "
            Sql &= " when 9 then 'Under DCR' "
            Sql &= "  End) "
            Sql &= " as DStatus,t_docn as DocID, t_revn as Rev,t_dttl as Tittle,t_user as DrawnBy,t_rusr as Reviewer,t_ausr as Approver "
            Sql &= " from  tdmisg001200  where t_stat =1 and t_wfst in(1,2) and t_user in ('" & UserID & "','" & UserIDT & "') "


          Case "cipre"

            'Sql = " Select rec.t_rcno As ReceiptID, convert(nvarchar(10),dateadd(n,330,rec.t_date),103) As ReceiptDate, convert(nvarchar(10),dateadd(n,330,rec.t_sdat),103) As SentDate, datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_sdat)),getdate()) as Rageindays, "
            'Sql &= " rec.t_revn as Rrev,rec.t_cprj as RProject,Left(LTrim(rec.t_item), 8) As Relement,(case ttppdm090200.t_sort  "
            'Sql &= "       when 'MECH-SUGAR' then 'MECHANICAL' "
            'Sql &= "        When 'ELECTRICAL' then 'ELECTRICAL' "
            'Sql &= "         when 'MECHANICAL' then 'MECHANICAL' "
            'Sql &= "        When 'PROCESS-STOKER' Then 'MECHANICAL' "
            'Sql &= "        when 'OTHERS' then 'OTHERS' "
            'Sql &= "        When 'PROCESS' then 'PROCESS' "
            'Sql &= "        WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            'Sql &= "        When 'PIPING' THEN 'PIPING' "
            'Sql &= "         WHEN 'C & I' THEN 'C&I' "
            'Sql &= "          When 'INSTRUMENTATION' THEN 'C&I' "
            'Sql &= "         WHEN 'EPC' THEN 'EPC' "
            'Sql &= "         When 'C&I' THEN 'C&I' "
            'Sql &= "          WHEN 'ELE' THEN 'ELECTRICAL' "
            'Sql &= "          When 'SERVICE' THEN 'OTHERS' "
            'Sql &= "          else 'OTHERS' "
            'Sql &= "          End) As Owner_Dept,ttcibd001200.t_dsca As ItemDescription, (Case rec.t_stat When 3 Then 'Under Evaluation' end)as RStatus, "
            'Sql &= " (case rec.t_sent_1  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Mechanical, "
            'Sql &= " (case rec.t_sent_2  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Structure_, "
            'Sql &= " (case rec.t_sent_3  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Piping, "
            'Sql &= " (case rec.t_sent_4  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Process, "
            'Sql &= " (case rec.t_sent_5  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as CandI, "
            'Sql &= " (case rec.t_sent_6  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Electrical, "
            'Sql &= " (case rec.t_sent_7 "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Quality"
            'Sql &= " from tdmisg134200 as rec"
            'Sql &= " Left Join ttcibd001200"
            'Sql &= " On ttcibd001200.t_item = rec.t_item"
            'Sql &= "   LEFT JOIN ttppdm090200"
            'Sql &= " on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "

            'Sql &= "  where rec.t_rcno like ('REC%') "
            'Sql &= "  and rec.t_stat =3"
            'Sql &= "  and 1 = case (select top 1 t_dept from tdmisg130200 where t_logn in ('" & UserID & "')) "
            'Sql &= "   when 'MEC' then case when rec.t_sent_1=1 then 1 else 0 end  "
            'Sql &= "   when 'STR' then case when rec.t_sent_2=1 then 1 else 0 end  "
            'Sql &= "   when 'PIP' then case when rec.t_sent_3=1 then 1 else 0 end "
            'Sql &= "   when 'PRC' then case when rec.t_sent_4=1 then 1 else 0 end "
            'Sql &= "   when 'C&I' then case when rec.t_sent_5=1 then 1 else 0 end "
            'Sql &= "   when 'ELE' then case when rec.t_sent_6=1 then 1 else 0 end "
            'Sql &= "   when 'QLY' then case when rec.t_sent_7=1 then 1 else 0 end "
            'Sql &= "   end"
            'Sql &= "   And rec.t_eunt= (select top 1 t_eunt from tdmisg130200 where t_logn in ('" & UserID & "')) "

            Sql = "  select *  "
            Sql &= "  from ( "
            Sql &= "  Select rec.t_rcno As ReceiptID, convert(nvarchar(10),dateadd(n,330,rec.t_date),103) As ReceiptDate, convert(nvarchar(10),dateadd(n,330,rec.t_sdat),103) As SentDate, datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_sdat)),getdate()) as Rageindays,  "
            Sql &= "              rec.t_revn as Rrev,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType, rec.t_cprj as RProject,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name ,Left(LTrim(rec.t_item), 8) As Relement,(case ttppdm090200.t_sort   "
            Sql &= "                    when 'MECH-SUGAR' then 'MECHANICAL'  "
            Sql &= "                     When 'ELECTRICAL' then 'ELECTRICAL'  "
            Sql &= "                      when 'MECHANICAL' then 'MECHANICAL'  "
            Sql &= "                     When 'PROCESS-STOKER' Then 'MECHANICAL'  "
            Sql &= "                     when 'OTHERS' then 'OTHERS'  "
            Sql &= "                     When 'PROCESS' then 'PROCESS'  "
            Sql &= "                     WHEN 'STRUCTURE' THEN 'STRUCTURE'  "
            Sql &= "                     When 'PIPING' THEN 'PIPING'  "
            Sql &= "                      WHEN 'C & I' THEN 'C&I'  "
            Sql &= "                       When 'INSTRUMENTATION' THEN 'C&I'  "
            Sql &= "                      WHEN 'EPC' THEN 'EPC'  "
            Sql &= "                      When 'C&I' THEN 'C&I'  "
            Sql &= "                       WHEN 'ELE' THEN 'ELECTRICAL'  "
            Sql &= "                       When 'SERVICE' THEN 'OTHERS'  "
            Sql &= "                       else 'OTHERS'  "
            Sql &= "                       End) As Owner_Dept,ttcibd001200.t_dsca As ItemDescription,rec.t_orno as PO_Number, (Case rec.t_stat When 3 Then 'Under Evaluation'  When 4 Then 'Comment Submitted' When 5 Then 'Technically Cleared'  end) as RStatus,  "
            Sql &= "              (case rec.t_sent_1   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Mechanical,  "
            Sql &= "              (case rec.t_sent_2   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Structure,  "
            Sql &= "              (case rec.t_sent_3   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Piping,  "
            Sql &= "              (case rec.t_sent_4   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Process,  "
            Sql &= "              (case rec.t_sent_5   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as CandI,  "
            Sql &= "              (case rec.t_sent_6   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Electrical,  "
            Sql &= "              (case rec.t_sent_7  "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Quality, "
            Sql &= "  (select top 1 ( case t_dept when 'MEC' then 'MECHANICAL' when 'PRC' then 'PROCESS' when 'STR' then 'STRUCTURE' when 'PIP' then 'PIPING' when 'ELE' then 'ELECTRICAL' when 'QLY' then 'QUALITY' when 'C&I' then 'C&I' end )  from tdmisg130200 where t_logn in ('" & UserID & "')) as UserDept "
            Sql &= "              from tdmisg134200 as rec "
            Sql &= "              Left Join ttcibd001200 "
            Sql &= "              On ttcibd001200.t_item = rec.t_item "
            Sql &= "                LEFT JOIN ttppdm090200 "
            Sql &= "              on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8)  "
            Sql &= "               where rec.t_rcno like ('REC%')  "
            Sql &= "               and rec.t_stat in (3)  "
            Sql &= "               and 1 = case (select top 1 t_dept from tdmisg130200 where t_logn in ('" & UserID & "'))  "
            Sql &= "                when 'MEC' then case when rec.t_sent_1=1 then 1 else 0 end   "
            Sql &= "                when 'STR' then case when rec.t_sent_2=1 then 1 else 0 end   "
            Sql &= "                when 'PIP' then case when rec.t_sent_3=1 then 1 else 0 end  "
            Sql &= "                when 'PRC' then case when rec.t_sent_4=1 then 1 else 0 end  "
            Sql &= "                when 'C&I' then case when rec.t_sent_5=1 then 1 else 0 end  "
            Sql &= "                when 'ELE' then case when rec.t_sent_6=1 then 1 else 0 end  "
            Sql &= "                when 'QLY' then case when rec.t_sent_7=1 then 1 else 0 end  "
            Sql &= "                end "
            Sql &= "                And rec.t_eunt= (select top 1 t_eunt from tdmisg130200 where t_logn in ('" & UserID & "'))  "
            Sql &= "  ) as tmp  "
            Sql &= "  where 1 = case when Owner_Dept <> UserDept  "
            Sql &= "                 then case UserDept  "
            Sql &= "          when 'MECHANICAL' then case when Mechanical='Pending' then 1 else 0 end  "
            Sql &= "          when 'PROCESS' then case when Process='Pending' then 1 else 0 end  "
            Sql &= "   when 'STRUCTURE' then case when Structure='Pending' then 1 else 0 end  "
            Sql &= "    when 'PIPING' then case when Piping='Pending' then 1 else 0 end  "
            Sql &= "     when 'C&I' then case when CandI='Pending' then 1 else 0 end  "
            Sql &= "      when 'ELECTRICAL' then case when Electrical='Pending' then 1 else 0 end  "
            Sql &= "  when 'QUALITY' then case when Quality='Pending' then 1 else 0 end  "
            Sql &= "          end  "
            Sql &= "     else 1 end "
            Sql &= "     order by Rageindays Desc"



          Case "cipoe"

            'Sql = " Select rec.t_rcno As ReceiptID, convert(nvarchar(10),dateadd(n,330,rec.t_date),103) As ReceiptDate, convert(nvarchar(10),dateadd(n,330,rec.t_sdat),103) As SentDate, datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_sdat)),getdate()) As Rageindays, "
            'Sql &= " rec.t_revn As Rrev,rec.t_cprj As RProject,Left(LTrim(rec.t_item), 8) As Relement,(Case ttppdm090200.t_sort  "
            'Sql &= "       When 'MECH-SUGAR' then 'MECHANICAL' "
            'Sql &= "        When 'ELECTRICAL' then 'ELECTRICAL' "
            'Sql &= "         when 'MECHANICAL' then 'MECHANICAL' "
            'Sql &= "        When 'PROCESS-STOKER' Then 'MECHANICAL' "
            'Sql &= "        when 'OTHERS' then 'OTHERS' "
            'Sql &= "        When 'PROCESS' then 'PROCESS' "
            'Sql &= "        WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            'Sql &= "        When 'PIPING' THEN 'PIPING' "
            'Sql &= "         WHEN 'C & I' THEN 'C&I' "
            'Sql &= "          When 'INSTRUMENTATION' THEN 'C&I' "
            'Sql &= "         WHEN 'EPC' THEN 'EPC' "
            'Sql &= "         When 'C&I' THEN 'C&I' "
            'Sql &= "          WHEN 'ELE' THEN 'ELECTRICAL' "
            'Sql &= "          When 'SERVICE' THEN 'OTHERS' "
            'Sql &= "          else 'OTHERS' "
            'Sql &= "          End) As Owner_Dept,ttcibd001200.t_dsca As ItemDescription, (Case rec.t_stat When 3 Then 'Under Evaluation' end)as RStatus, "
            'Sql &= " (case rec.t_sent_1  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Mechanical, "
            'Sql &= " (case rec.t_sent_2  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Structure_, "
            'Sql &= " (case rec.t_sent_3  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Piping, "
            'Sql &= " (case rec.t_sent_4  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Process, "
            'Sql &= " (case rec.t_sent_5  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as CandI, "
            'Sql &= " (case rec.t_sent_6  "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Electrical, "
            'Sql &= " (case rec.t_sent_7 "
            'Sql &= " when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) "
            'Sql &= " when 2 then '-'   "
            'Sql &= " end ) as Quality"
            'Sql &= " from tdmisg134200 as rec"
            'Sql &= " Left Join ttcibd001200"
            'Sql &= " On ttcibd001200.t_item = rec.t_item"
            'Sql &= "   LEFT JOIN ttppdm090200"
            'Sql &= " on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "

            'Sql &= "  where rec.t_rcno like ('REP%') "
            'Sql &= "  and rec.t_stat =3"
            'Sql &= "  and 1 = case (select top 1 t_dept from tdmisg130200 where t_logn in ('" & UserID & "')) "
            'Sql &= "   when 'MEC' then case when rec.t_sent_1=1 then 1 else 0 end  "
            'Sql &= "   when 'STR' then case when rec.t_sent_2=1 then 1 else 0 end  "
            'Sql &= "   when 'PIP' then case when rec.t_sent_3=1 then 1 else 0 end "
            'Sql &= "   when 'PRC' then case when rec.t_sent_4=1 then 1 else 0 end "
            'Sql &= "   when 'C&I' then case when rec.t_sent_5=1 then 1 else 0 end "
            'Sql &= "   when 'ELE' then case when rec.t_sent_6=1 then 1 else 0 end "
            'Sql &= "   when 'QLY' then case when rec.t_sent_7=1 then 1 else 0 end "
            'Sql &= "   end"
            'Sql &= "   And rec.t_eunt= (select top 1 t_eunt from tdmisg130200 where t_logn in ('" & UserID & "')) "

            Sql = "  select *  "
            Sql &= "  from ( "
            Sql &= "  Select rec.t_rcno As ReceiptID, convert(nvarchar(10),dateadd(n,330,rec.t_date),103) As ReceiptDate, convert(nvarchar(10),dateadd(n,330,rec.t_sdat),103) As SentDate, datediff(DD,dateadd(n,330,dateadd(n,330,rec.t_sdat)),getdate()) as Rageindays,  "
            Sql &= "              rec.t_revn as Rrev,(select TOP 1 t_pcod from tdmisg140200 where tdmisg140200.t_cprj=rec.t_cprj) as PType, rec.t_cprj as RProject,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name ,(select TOP 1 (case t_fire when 1 then 'Confirmed' when 2 then 'Not Confirmed'end) from ttdpur406200 where ttdpur406200.t_orno=rec.t_orno) as PR_Status,Left(LTrim(rec.t_item), 8) As Relement,(case tdmisg164200.t_ownr   "
            Sql &= "                    when '1' then 'MECHANICAL'  "
            Sql &= "                    WHEN '2' THEN 'STRUCTURE'  "
            Sql &= "                    When '3' THEN 'PIPING'  "
            Sql &= "                    When '4' then 'PROCESS'  "
            Sql &= "                    WHEN '5' THEN 'C & I'  "
            Sql &= "                    When '6' then 'ELECTRICAL'  "
            Sql &= "                    when '7' then 'QUALITY'  "
            Sql &= "                    when '8' then 'PROJECT'  "
            Sql &= "                       End) As Owner_Dept,ttcibd001200.t_dsca As ItemDescription,rec.t_orno as PO_Number,(select top 1 (case t_hdst when 5 then 'Created' when 10 then 'Approved' when 15 then 'Sent' when 20 then 'In Progess' when 25 then 'Closed' when 30 then 'Calcelled' when 35 then 'Modified' when 40 then 'Not Applicable' when 45 then 'Released'  end) from ttdpur400200 where ttdpur400200.t_orno =rec.t_orno) as PO_Status, (Case rec.t_stat When 3 Then 'Under Evaluation'  When 4 Then 'Comment Submitted' When 5 Then 'Technically Cleared'  end) as RStatus,  "
            Sql &= "              (case rec.t_sent_1   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Mechanical,  "
            Sql &= "              (case rec.t_sent_2   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Structure,  "
            Sql &= "              (case rec.t_sent_3   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Piping,  "
            Sql &= "              (case rec.t_sent_4   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Process,  "
            Sql &= "              (case rec.t_sent_5   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as CandI,  "
            Sql &= "              (case rec.t_sent_6   "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Electrical,  "
            Sql &= "              (case rec.t_sent_7  "
            Sql &= "              when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end)  "
            Sql &= "              when 2 then '-'    "
            Sql &= "              end ) as Quality, "
            Sql &= "  (select top 1 ( case t_dept when 'MEC' then 'MECHANICAL' when 'PRC' then 'PROCESS' when 'STR' then 'STRUCTURE' when 'PIP' then 'PIPING' when 'ELE' then 'ELECTRICAL' when 'QLY' then 'QUALITY' when 'C&I' then 'C&I' end )  from tdmisg130200 where t_logn in ('" & UserID & "')) as UserDept "
            Sql &= "              from tdmisg134200 as rec "
            Sql &= "              Left Join tdmisg164200  "
            Sql &= "              On tdmisg164200.t_item = rec.t_item "

            Sql &= "              Left Join ttcibd001200 "
            Sql &= "              On ttcibd001200.t_item = rec.t_item "
            Sql &= "                LEFT JOIN ttppdm090200 "
            Sql &= "              on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8)  "
            Sql &= "               where rec.t_rcno like ('REP%')  "
            Sql &= "               and rec.t_stat in (3,4,5)  "
            Sql &= "               and 1 = case (select top 1 t_dept from tdmisg130200 where t_logn in ('" & UserID & "'))  "
            Sql &= "                when 'MEC' then case when rec.t_sent_1=1 then 1 else 0 end   "
            Sql &= "                when 'STR' then case when rec.t_sent_2=1 then 1 else 0 end   "
            Sql &= "                when 'PIP' then case when rec.t_sent_3=1 then 1 else 0 end  "
            Sql &= "                when 'PRC' then case when rec.t_sent_4=1 then 1 else 0 end  "
            Sql &= "                when 'C&I' then case when rec.t_sent_5=1 then 1 else 0 end  "
            Sql &= "                when 'ELE' then case when rec.t_sent_6=1 then 1 else 0 end  "
            Sql &= "                when 'QLY' then case when rec.t_sent_7=1 then 1 else 0 end  "
            Sql &= "                end "
            Sql &= "                And rec.t_eunt= (select top 1 t_eunt from tdmisg130200 where t_logn in ('" & UserID & "'))  "
            Sql &= "  ) as tmp  "
            Sql &= "  where 1 = case when Owner_Dept <> UserDept  "
            Sql &= "                 then case UserDept  "
            Sql &= "          when 'MECHANICAL' then case when Mechanical='Pending' then 1 else 0 end  "
            Sql &= "          when 'PROCESS' then case when Process='Pending' then 1 else 0 end  "
            Sql &= "   when 'STRUCTURE' then case when Structure='Pending' then 1 else 0 end  "
            Sql &= "    when 'PIPING' then case when Piping='Pending' then 1 else 0 end  "
            Sql &= "     when 'C&I' then case when CandI='Pending' then 1 else 0 end  "
            Sql &= "      when 'ELECTRICAL' then case when Electrical='Pending' then 1 else 0 end  "
            Sql &= "  when 'QUALITY' then case when Quality='Pending' then 1 else 0 end  "
            Sql &= "          end  "
            Sql &= "     else 1 end "
            Sql &= "     order by Rageindays Desc"


          Case "cta"

            Sql = " select t_tran as TID,(case t_type"
            Sql &= " When 1 Then 'Customer Transmittal'"
            Sql &= " When 2 Then 'Internal Transmittal'"
            Sql &= " When 3 Then 'Site Transmittal'"
            Sql &= " When 4 Then 'Vendor Transmittal'"

            Sql &= " End"
            Sql &= " ) As TType,t_dprj As TProject,"
            Sql &= "(case t_stat"
            Sql &= " When 1 Then 'Returned'"
            Sql &= " When 2 Then 'Free'"
            Sql &= " When 3 Then 'Under Approval'"
            Sql &= " When 4 Then 'Under Issue'"
            Sql &= " When 5 Then 'Issued'"
            Sql &= " When 6 Then 'Partial Received'"
            Sql &= " When 7 Then 'Received'"
            Sql &= " When 8 Then 'Closed'"
            Sql &= " End"
            Sql &= " ) As TStatus"
            Sql &= "  from tdmisg131200 where t_type =2 And t_stat =3 And t_user In ('" & UserID & "','" & UserIDT & "') "


          Case "cti"

            Sql = " select t_tran as TID,(case t_type"
            Sql &= " When 1 Then 'Customer Transmittal'"
            Sql &= " When 2 Then 'Internal Transmittal'"
            Sql &= " When 3 Then 'Site Transmittal'"
            Sql &= " When 4 Then 'Vendor Transmittal'"

            Sql &= " End"
            Sql &= " ) As TType,t_dprj As TProject,"
            Sql &= "(case t_stat"
            Sql &= " When 1 Then 'Returned'"
            Sql &= " When 2 Then 'Free'"
            Sql &= " When 3 Then 'Under Approval'"
            Sql &= " When 4 Then 'Under Issue'"
            Sql &= " When 5 Then 'Issued'"
            Sql &= " When 6 Then 'Partial Received'"
            Sql &= " When 7 Then 'Received'"
            Sql &= " When 8 Then 'Closed'"
            Sql &= " End"
            Sql &= " ) As TStatus"
            Sql &= "  from tdmisg131200 where t_type =2 And t_stat =4 And (t_user In ('" & UserID & "','" & UserIDT & "')  and t_apsu in ('" & UserID & "','" & UserIDT & "'))"


          Case "cda"

            Sql &= " select t_dcrn as DCRNumber,t_dsca as DDescription,t_cprj as Dproject, "
            Sql &= " t_cspa as DElement, t_crea as DCreatedBy, t_user as DApprover, (case t_stat "
            Sql &= " when 2 then 'Under Approval' "
            Sql &= " end) as DCRStatus from tdmisg114200 where t_stat =2 and t_user In ('" & UserID & "','" & UserIDT & "')"


          Case "cdac"


            Sql &= " select t_dcrn as DCRNumber,t_dsca as DDescription,t_cprj as Dproject, "
            Sql &= " t_cspa as DElement, t_crea as DCreatedBy, t_user as DApprover, (case t_stat "
            Sql &= " when 2 then 'Under Approval' "
            Sql &= " end) as DCRStatus from tdmisg114200 where t_stat =2 and t_crea In ('" & UserID & "','" & UserIDT & "')"

          Case "csr"

            Sql &= " Select t_cprj as SAR_Project, t_sarn as SAR_Number,t_cspa as SAR_Element, t_draw as SAR_Drawing, (case t_stat  "
            Sql &= " when 2 then 'Under Review'  "
            Sql &= " end) as SAR_Status, t_prep as SAR_PreparedBy,t_rper as SAR_Reviewer,t_apby as SAR_Approver from ttpisg074200 where t_stat=2 and t_rper  In ('" & UserID & "','" & UserIDT & "')"


          Case "csa"

            Sql &= " Select t_cprj as SAR_Project, t_sarn as SAR_Number,t_cspa as SAR_Element, t_draw as SAR_Drawing, (case t_stat  "
            Sql &= " when 3 then 'Under Approval'  "
            Sql &= " end) as SAR_Status, t_prep as SAR_PreparedBy,t_rper as SAR_Reviewer,t_apby as SAR_Approver from ttpisg074200 where t_stat=3 and t_apby In ('" & UserID & "','" & UserIDT & "')"

          Case "cmh"

            Sql &= " Select ttiisg910200.t_emno As MH_EmployeeCode,ttiisg910200.t_tdat As MH_Date, ttiisg908200.t_desc As MH_activity, ttiisg910200.t_cprj As MH_Project, "
            Sql &= " ttiisg910200.t_srno As MH_serialnumber, (case ttiisg910200.t_comp "
            Sql &= " when '200' then 'BOILER' "
            Sql &= " when '210' then 'EPC' "
            Sql &= " when '220' then 'PC' "
            Sql &= " when '230' then 'SMD' "
            Sql &= " when '240' then 'APC' "
            Sql &= " when '250' then 'ISGEC Wet FGD Business' "
            Sql &= " When '290' then 'ISGEC R&D' "
            Sql &= " when '400' then 'ISGEC HO' "
            Sql &= " When '650' then 'Isgec Covema Ltd.' "
            Sql &= " end) as MH_Division, ttiisg910200.t_remk As MH_Remark, ttiisg910200.t_hhrs As MH_HoursEntered,"

            Sql &= "(CASE ttiisg910200.t_grcd"
            Sql &= " when 'ENGG001'	then ' BOILER - MECHANICAL GROUP ' "
            Sql &= " When 'ENGG002'	then ' Thermal & Process Group ' "
            Sql &= " when 'ENGG003'	then ' Design Automation + Standard ' "
            Sql &= " When 'ENGG004'	then ' PC Boiler Engineering ' "
            Sql &= " when 'ENGG005'	then ' Boiler Chennai Design centre ' "
            Sql &= " When 'ENGG006'	then ' Engg. Administration ' "
            Sql &= " when 'ENGG007'	then ' APCE-Design ' "
            Sql &= " When 'ENGG008'	then ' Boiler Proposal Chennai ' "
            Sql &= " when 'ENGG009'	then ' CFBC-Thermal and Process ' "
            Sql &= " When 'ENGG010'	then ' Project Engineering Function ' "
            Sql &= " When 'ENGG011'	then ' EPC ENGINEERING MECHANICAL ' "
            Sql &= " When 'ENGG012'	then ' EPC ENGINEERING ELECTRICAL ' "
            Sql &= " when 'ENGG013'	then ' EPC ENGINEERING PIPING ' "
            Sql &= " When 'ENGG014'	then ' EPC ENGINEERING C&I ' "
            Sql &= " when 'ENGG015'	then ' EPC ENGINEERING CIVIL ' "
            Sql &= " When 'ENGG020'	then ' FGD ENGINEERING ' "

            Sql &= " End) As MH_EngineeringGroup"
            Sql &= " From ttiisg910200"

            Sql &= " LEFT JOIN ttiisg908200"
            Sql &= " on ttiisg910200.t_acid =ttiisg908200.t_acid"
            Sql &= " Where DATEDIFF(day, ttiisg910200.t_tdat, getdate()) between 0 And 30 And ttiisg910200.t_emno In ('" & UserID & "','" & UserIDT & "')"
            Sql &= "order by ttiisg910200.t_tdat"
        End Select
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While (rd.Read)
            mRet.Add(New engDoc(rd))
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
