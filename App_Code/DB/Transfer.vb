Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DB
  <DataObject()>
  Partial Public Class transfer


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


    Public Shared Function GetVRDATA() As List(Of SIS.DB.transfer)



      Dim mRetd As New List(Of SIS.DB.transfer)



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
            mRetd.Add(New transfer(rd))
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
End Namespace
