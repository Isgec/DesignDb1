Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DB
  <DataObject()>
  Partial Public Class standardd


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


    Public Shared Function GetVRDATA() As List(Of SIS.DB.standardd)



      Dim mRetd As New List(Of SIS.DB.standardd)



      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()



        'Sql = " select t_item,t_docn,t_revn,t_dsca,t_pdfn,t_dttl,t_cspa,t_wght,t_drwn,t_chck,t_aprb from tdmisg007200 order by t_docn"

        Sql = " Select aa.t_item,aa.t_docn,aa.t_revn,aa.t_dsca,aa.t_pdfn,aa.t_dttl,aa.t_cspa, "
        Sql &= " aa.t_wght, aa.t_drwn, aa.t_chck, aa.t_aprb,bb.t_csig From tdmisg007200 As aa "
        Sql &= " inner Join ttcibd001200 as bb on aa.t_item=bb.t_item "

        Sql &= " where bb.t_csig ='' order by aa.t_docn"


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 5000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            mRetd.Add(New standardd(rd))
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
