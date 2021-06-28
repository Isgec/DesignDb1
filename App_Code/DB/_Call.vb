Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DB
  <DataObject()>
  Partial Public Class Calldetail


    Public Property userID As String = ""
        'hi
        Public Property CallID As String = ""
    Public Property CaseApplication As String = ""
    Public Property CallDescription As String = ""
    'Public Property UserID As String = ""
    Public Property Caseloggedby As String = ""
    Public Property LoggedOn As String = ""
    Public Property CaseAttendedBy As String = ""
    Public Property AttendedOn As String = ""
    Public Property SolutionProvided As String = ""
    Public Property CaseStatus As String = ""
    Public Property CasePriority As String = ""
    Public Property ClosedOn As String = ""
    Public Property SignedOffOn As String = ""














    Public Shared Function GetData(ByVal det As String, ByVal emp As String) As List(Of Calldetail)
      Dim userG As String = ""

      Dim mRet As New List(Of SIS.DB.Calldetail)
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Dim UserIDT As Integer = 0
      Try
        UserIDT = Convert.ToInt32(UserID)
      Catch ex As Exception

      End Try
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetPerkConnectionString())
        Con.Open()
                'Select Case det


                '  Case "cpd"


                'Sql = " Select [CallID],[Subtype],[CallDescription],[UserID],[Name],[LoggedOn],[Status],[Priority]"
                'Sql &= " From [IJTPerks].[dbo].[Ecal_Monitoring] where callid >28 order by callid desc"


                Sql = "Select [CallID] "
                Sql &= " ,[UserID],(select Employeename from HRM_Employees where HRM_Employees.cardno=rec.userid) as Caseloggedby "
        Sql &= " ,(select Description from Ecal_Subtypes where Ecal_Subtypes.SubTypeID=rec.SubTypeID) as CaseApplication "
        Sql &= " ,[CallDescription] "
        Sql &= " ,[LoggedOn] "
        Sql &= " ,(select Description from ECal_Priority where ECal_Priority.Priority=rec.Priority) as CasePriority "
        Sql &= " ,(select Employeename from HRM_Employees where HRM_Employees.cardno=rec.AttenderID) as CaseAttendedBy "
        Sql &= " ,[AttendedOn] "
        Sql &= " ,[AttenderDescription] as SolutionProvided "
        Sql &= " ,(select Description from ECal_Status where ECal_Status.CallStatusID=rec.CallStatusID) as CaseStatus "
        Sql &= " ,[ClosedOn] "
        Sql &= " ,[SignedOffOn] "

        Sql &= " From [IJTPerks].[dbo].[ECal_Register] as rec "
                Sql &= " Where CallID > 28 "
                Sql &= " And rec.CallStatusID Not in ('8','6','9')"
                Sql &= " Order By CallID desc "



        'End Select
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While (rd.Read)
            mRet.Add(New Calldetail(rd))
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
