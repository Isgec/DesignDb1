<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_Transfer.aspx.vb" Inherits="GF_Transfer" title="Transfer" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="container-fluid">
  <div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;Autodesk Vault to ERPLN Document - Transfer Details"></asp:Label>
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


         <div id="vi" runat="server" visible="true">
       
 
       <div class="col-12 text-center">
  <img src="vault2baan.gif" width="320" height="180""/>
         </div>
  


        <div class="col-12 text-center">
          <div class="btn btn-warning btn-outline-dark" role="alert" id="V2B">
            <b>
              <asp:Label ID="v2bheading" runat="server"></asp:Label></b>
          </div>
        </div>
      <div class="row">
        
         
    
        <div class="col-sm-auto my-0 table-hover text-center">
          <div id="v2bDetails" runat="server">
          </div>
        </div>
     

      </div></div>


      </ContentTemplate>

           <Triggers>
           </Triggers>
      </asp:UpdatePanel>
</div>
</asp:Content>
