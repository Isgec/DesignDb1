Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DB
  <DataObject()>
  Partial Public Class DBEmployeeDB
    Public Property EmployeeID As String = ""

    Public Property Employee_Name As String = ""
    Public Property Employee_Role As String = ""
    Public Property Employee_Group As String = ""



    Public Shared Function GetEmployeeDB(ByVal EmployeeID As String) As DBEmployeeDB
      If EmployeeID = "" Then Return Nothing
      Dim mRet As New DBEmployeeDB

      mRet.EmployeeID = EmployeeID
      Dim EmployeeIDs As Integer = 0
      EmployeeIDs = Convert.ToInt32(EmployeeID)
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()



        Sql = " select t_nama from ttccom001200 where t_loco in ('" & EmployeeID & "','" & EmployeeIDs & "') "

        Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
          mRet.Employee_Name = Cmd.ExecuteScalar
        End Using

        Sql = " select t_nama from ttccom001200 where t_loco in ('" & EmployeeID & "','" & EmployeeIDs & "') "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Employee_Role = Cmd.ExecuteScalar
        End Using

        Sql = " select t_nama from ttccom001200 where t_loco in ('" & EmployeeID & "','" & EmployeeIDs & "') "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Employee_Group = Cmd.ExecuteScalar
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
