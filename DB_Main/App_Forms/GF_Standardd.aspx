<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_Standardd.aspx.vb" Inherits="GF_Standardd" title="Standard" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="container-fluid">
  <div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;Standard Document Master Details"></asp:Label>
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


           <div id="sd" runat="server" visible="true">
        <div class="col-12 text-center">
          <div class="btn btn-warning btn-outline-dark" role="alert" id="sdm">
            <b>
              <asp:Label ID="sdheading" runat="server"></asp:Label></b>
          </div>
        </div>
      <div class="row">
        
         
    
        <div class="col-sm-auto my-0 table-hover text-center">
          <div id="sdDetails" runat="server">
          </div>
        </div>
     

      </div></div>


      </ContentTemplate>

           <Triggers>
           </Triggers>
      </asp:UpdatePanel>
</div>
</asp:Content>
