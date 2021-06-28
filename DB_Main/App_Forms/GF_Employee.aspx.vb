Partial Class GF_EmployeeDB
  Inherits System.Web.UI.Page
  Public Property EmployeeID As String
    Get
      If ViewState("EmployeeID") IsNot Nothing Then
        Return ViewState("EmployeeID")
      End If
      Return ""
    End Get
    Set(value As String)

      ViewState.Add("EmployeeID", value)
    End Set
  End Property


  Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
    ' vi.Visible = False
    ' sd.Visible = False
    Dim EmployeeID As String = ""

    EmployeeID = F_employeeID.Text.ToUpper()
    F_employeeID.Text = EmployeeID


    If EmployeeID = "" Then Exit Sub
    If EmployeeID.Length < 3 Then Exit Sub
    If EmployeeID.Length > 5 Then Exit Sub
    Dim x As SIS.DB.DBEmployeeDB = SIS.DB.DBEmployeeDB.GetEmployeeDB(EmployeeID)
    'Dim y As SIS.DB.PRE_Information = SIS.DB.PRE_Information.GetPREDATA(DocumentID, RevisionNO)
    'If RevisionNO <> "00" Or RevisionNO <> "01" Or RevisionNO <> "02" Then Exit Sub
    EName.Text = x.Employee_Name
    Erole.Text = x.Employee_Role
    Egroup.Text = x.Employee_Group
    'Project
    If x.EmployeeID = "" Then
      ei.Visible = False

    Else
      ei.Visible = True


    End If
  End Sub



End Class