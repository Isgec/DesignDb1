<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_Employee.aspx.vb" Inherits="GF_EmployeeDB" title="Employee Dashboard" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="container-fluid">
<div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;EMPLOYEE DASHBOARD"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server">
  <ContentTemplate>
    <asp:UpdateProgress ID="UPGStaApprovalWFTypes" runat="server" AssociatedUpdatePanelID="UPNLtaApprovalWFTypes" DisplayAfter="100" >
      <ProgressTemplate>
        <span style="color: #ff0031">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
     <%-- <div class="container text-center">
            <img src="DB.jpg" class="img-rounded" alt="Design DashBoard - Beta Version 1.0.0" width="414" height="98"/> 
             </div>--%>
      <asp:UpdatePanel ID="UPNLctPActivity" runat="server">
           <ContentTemplate>
      <div class="row">
      <div class="col-4">
        
         
            <div class="form-group">
              <div class="input-group">
               <%-- <span class=" btn btn-sm btn-dark" style="width: 78px; text-align: center; cursor: pointer" title="Enter Project ID:" onclick="openNav()"><b>Project:</b></span>--%>
                <a href="#empi" class="btn btn-light btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Employee ID</b></a>
  <div id="doci" class="collapse">
    Enter Eployee ID & Click to 'SHOW' button. This will allow system to Search and Show all available information .
    Click again 'Employee ID' button To Hide this Information.
  </div>
                <asp:TextBox ID="F_employeeID" CssClass="form-control" ClientIDMode="static" style="width: 10px; cursor: pointer" runat="Server"> </asp:TextBox>
                 
               
              </div>
            </div>
            <%-- <br />
           <asp:button ID="pd" runat="server" CssClass="btn btn-warning btn-lg" ToolTip="pd" Text="pd" Font-Bold="true"></asp:button>--%>
         
        
      </div>


        
 <div class="col-1">
           <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-warning ml-1" Text="SHOW" ToolTip="Click to Search information " Font-Bold="true" Font-Names="Comic Sans MS" />


 </div>
       <%--  <div class="col-2">
           <asp:Button ID="cmdSubmitV2B" runat="server" CssClass="btn btn-success ml-1" Text="Live - Vault To Baan Transfer" ToolTip="Click to See Recent 1000 Documents " Font-Bold="true" Font-Names="Comic Sans MS" />


 </div>
        <div class="col-2">
           <asp:Button ID="cmdsubmitsd" runat="server" CssClass="btn btn-info ml-1" Text="Standard Document Master" ToolTip="Click to all Standard Document Master " Font-Bold="true" Font-Names="Comic Sans MS" />


 </div>--%>
           </div>
           </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="cmdSubmit" />
          </Triggers>
          </asp:UpdatePanel>



              <div id="ei" runat="server" visible="false">
        <a href="#EMPLOYEEinformation" text-align: center; cursor: pointer" data-toggle="collapse">EMPLOYEE -Informations</a>
                <div id="EMPLOYEEinformation" class="collapse">
                           
                        <div class="col-sm-auto my-0 table-hover">
                            <div id="pnl_pDetails" runat="server" visible="true">
                            </div>
                        </div>
                    
                </div>
                <br/>
       
                   Name:  <asp:Label text="" id="Ename" runat="server" Visible="true"></asp:Label>
                  <br/>
                Role:  <asp:Label text="" id="Erole" runat="server" Visible="true"></asp:Label>
               <br/>
                 Group:  <asp:Label text="" id="Egroup" runat="server" Visible="true"></asp:Label>
        </div>
  
        <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">


             </ContentTemplate>
           <Triggers>
           </Triggers>
    </asp:UpdatePanel>
</div>
</div>
</asp:Content>