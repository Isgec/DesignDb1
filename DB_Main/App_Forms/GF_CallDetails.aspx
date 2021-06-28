<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_CallDetails.aspx.vb" Inherits="GF_CallDetails" title="Technical Support Case Details" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="container-fluid">
  <div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;Technical Support Case Details - PENDING"></asp:Label>
</div>

<asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server">
  <ContentTemplate>
    <asp:UpdateProgress ID="UPGStaApprovalWFTypes" runat="server" AssociatedUpdatePanelID="UPNLtaApprovalWFTypes" DisplayAfter="100" >
      <ProgressTemplate>
        <span style="color: #ff0031">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
   
    
 
        
 <%--   <div class="col-1">
      
        <div class="mb-1 mt-1">
           <a class="btn btn-success" href="GF_UserDB.aspx"  role="button"><i class="fa fa-dashboard" style="font-size:20px"> </i></a>
        </div>--%>
       
     
      <%-- <div class="container text-center">
            <img src="DB.jpg" class="img-rounded" alt="Design DashBoard - Beta Version 1.0.0" width="414" height="98"/> 
             </div>--%>
    <br />
   
      
     <%-- <asp:Image ID="were" runat="server" ImageAlign="Left" width="700" height="500" ImageUrl="~/support.jpg" Visible="true"/>--%>
   <asp:Image ID="were" runat="server" ImageAlign="Left" width="400" height="300" ImageUrl="~/support.jpg" />
  <br/>
      <br/>
       
    <br/>
      <br/>
      <br/>
      <br/>

    <div class="col-12 text-center">
          <div class="btn btn-dark btn-outline-warning" role="alert" id="PSC">
            <b>
              <asp:Label ID="PSheading" runat="server"></asp:Label></b>
          </div>
        </div>




    <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">
    
        <div class="col-sm-auto my-0 table-hover">
          <div id="pnlDetails" runat="server">
          </div>
        </div>
     
  <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">
     
      <asp:LinkButton ID="btnexportexcel" runat="server" text=".xls" CssClass="btn btn-small btn-primary"><i class="fa fa-bars"></i></asp:LinkButton>
      <%-- <a asp  ID="btnexportexcel" runat="server" role="button"><i class="fa fa-dashboard" style="font-size:20px"> </i></a>--%>
      </ContentTemplate>

           <Triggers>
               <asp:PostBackTrigger ControlID="btnexportexcel" />
           </Triggers>
      </asp:UpdatePanel>
</div>
</asp:Content>
