<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_DocumentDB.aspx.vb" Inherits="GF_DocumentDB" title="Document Dashboard" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="container-fluid">
<div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;DOCUMENT DASHBOARD"></asp:Label>
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
                <a href="#doci" class="btn btn-light btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Document ID</b></a>
  <div id="doci" class="collapse">
    Enter Document ID & Click to 'SHOW' button. This will allow system to Search and Show all available information in BAAN ERPLN.
    Click again 'Document ID' button To Hide this Information.
  </div>
                <asp:TextBox ID="F_t_docn" CssClass="form-control" ClientIDMode="static" style="width: 10px; cursor: pointer" runat="Server"> </asp:TextBox>
                 
               
              </div>
            </div>
            <%-- <br />
           <asp:button ID="pd" runat="server" CssClass="btn btn-warning btn-lg" ToolTip="pd" Text="pd" Font-Bold="true"></asp:button>--%>
         
        
      </div>


          <div class="col-2" id="revision_text" runat="server" visible="false">
               <div class="form-group">
              <div class="input-group">
               <%-- <span class=" btn btn-sm btn-dark" style="width: 78px; text-align: center; cursor: pointer" title="Enter Project ID:" onclick="openNav()"><b>Project:</b></span>--%>
                <a href="#revi" class="btn btn-light btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Revison No.</b></a>
  <div id="revi" class="collapse">
    -
  </div>
                <asp:TextBox ID="F_t_revn" CssClass="form-control" ClientIDMode="static" style="width: 5px; cursor: pointer" runat="Server" Text="" Visible="false"> </asp:TextBox>
              
              </div>
            </div>

          </div>
 <div class="col-1">
           <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-warning ml-1" Text="SHOW" ToolTip="Click to Search Document " Font-Bold="true" Font-Names="Comic Sans MS" />


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

         <asp:Label ID="V2BUserID" Text="" runat="server" ToolTip="User ID" Visible="true"></asp:Label>
      
      <div id="V2B" runat="server" visible="false">
        <a href="#V2Binformation" text-align: center; cursor: pointer" data-toggle="collapse">Vault To Baan Transfer Logs</a>
                <div id="V2Binformation" class="collapse">
                           
                        <div class="col-sm-auto my-0 table-hover">
                            <div id="pnl_v2bdetails" runat="server" visible="true">
                            </div>
                        </div>
                    
                </div>
        </div>
      

              <div id="pi" runat="server" visible="false">
        <a href="#PMDLinformation" text-align: center; cursor: pointer" data-toggle="collapse">PMDL -Informations</a>
                <div id="PMDLinformation" class="collapse">
                           
                        <div class="col-sm-auto my-0 table-hover">
                            <div id="pnl_pDetails" runat="server" visible="true">
                            </div>
                        </div>
                    
                </div>
        </div>




                 <div id="mi" runat="server" visible="false">
        <a href="#MANHOURinformation" text-align: center; cursor: pointer" data-toggle="collapse">MANHOUR -Informations</a>
                <div id="MANHOURinformation" class="collapse">
                           
                        <div class="col-sm-auto my-0 table-hover">
                            <div id="pnl_MDetails" runat="server" visible="true">
                            </div>
                        </div>
                    
                </div>
        </div>

       <div class="row">
           <div class="col-1">
            <asp:label ID="dwg" Text="" runat="server" Visible="false"> </asp:label>
           </div>
           <div class="col-11">
             <hr />
           </div>
             </div>

      <div id="notfound" runat="server" visible="false">
           <asp:label ID="notfound_text" Text="" runat="server" Visible="false"> </asp:label>
      
           <div id="carouselExampleIndicators9" class="carousel slide" data-ride="carousel">
  <ol class="carousel-indicators">
    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
      <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>
  </ol>
  <div class="carousel-inner">
    <div class="carousel-item active btn-white">
     <div class="row">
         <div class ="col-1"> </div>
          <div class ="col-11"> 
Mentioned Document/Revision not found in ERPLN. Please check carefully
          </div>

     </div>
      
    </div>
    <div class="carousel-item btn-white">
   <div class="row">
         <div class ="col-1"> </div>
          <div class ="col-11"> 
Mentioned Document/Revision not found in ERPLN. Please check carefully
          </div>

     </div>
       </div>
    <div class="carousel-item btn-white">
 <div class="row">
         <div class ="col-1"> </div>
          <div class ="col-11"> 
Mentioned Document/Revision not found in ERPLN. Please check carefully
          </div>

     </div>
    </div>
    <div class="carousel-item btn-white">
   <div class="row">
         <div class ="col-1"> </div>
          <div class ="col-11"> 
Mentioned Document/Revision not found in ERPLN. Please check carefully
          </div>

     </div>
    </div>
  <div class="carousel-item btn-white">
     
     <div class="row">
         <div class ="col-1"> </div>
          <div class ="col-11"> 
Mentioned Document/Revision not found in ERPLN. Please check carefully
          </div>

     </div>
    </div>

  </div>
  <a class="carousel-control-prev" href="#carouselExampleIndicators9" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleIndicators9" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>   

      </div>

     <%-- <asp:Label ID="V2BUserID" Text="" runat="server" ToolTip="User ID" Visible="true"></asp:Label>--%>



   <div id="found" runat ="server" visible="false" text="">
      <div class="row">
          <div class="col-1" id="DivProjectID" runat="server" visible="false">
             
              <asp:Label ID="label_projectID" Text="Project ID :" runat="server"> </asp:Label>
               
          </div>
              <div class="col-5" id="DivProjectID1" runat="server" visible="false">
                  
              <asp:Label ID="btn_ProjectID" Text="" runat="server" ToolTip="Project ID"></asp:Label>
          </div>
          <div class="col-1" id="DivProjectYear" runat="server" visible="false">
              <asp:Label ID="label_Year" Text="Year :" runat="server"> </asp:Label></div>
              <div class="col-5" id="DivProjectYear1" runat="server" visible="false">
              <asp:Label ID="btn_ProjectYear" Text="" runat="server" ToolTip="Year"></asp:Label>
          </div></div>
      <div class="row">
          <div class="col-1" id="DivProjectClient" runat="server" visible="false">
              <asp:Label ID="label_Client" Text="Client :" runat="server" ToolTip="Client"> </asp:Label>
          </div>
               <div class="col-5" id="DivProjectClient1" runat="server" visible="false">
              <asp:Label ID="btn_ProjectClient" Text="" runat="server" ToolTip="Client"></asp:Label>
          </div>
          <div class="col-1" id="DivProjectIWT" runat="server" visible="false">
              <asp:Label ID="label_IWT" Text="IWT :" runat="server"> </asp:Label></div>
           <div class="col-5" id="DivProjectIWT1" runat="server" visible="false">
              <asp:Label ID="btn_ProjectIWT" Text="" runat="server" Font-Bold="true" ToolTip="IWT"></asp:Label>
          </div>
      </div>
      <div class="row">
          <div class="col-1" id="DivProject_Service" runat="server" visible="false">
             <asp:Label ID="label_Service" Text="Service:" runat="server"> </asp:Label>
              </div>
              <div class="col-5" id="DivProject_Service1" runat="server" visible="false">
              <asp:Label ID="Btn_Project_Service" Text="" runat="server" Font-Bold="true" ToolTip="Service" ></asp:Label>
          </div>
          <div class="col-1" id="DivProjectConsultant" runat="server" visible="false">
                <asp:Label ID="label_Consultant" Text="Consultant:" runat="server"> </asp:Label></div>
           <div class="col-5" id="DivProjectConsultant1" runat="server" visible="false">
              <asp:Label ID="btn_ProjectConsultant" Text="" runat="server" Font-Bold="true" ToolTip="Consultant"></asp:Label>
          </div>
      </div>
       
           <div class="row">
           <div class="col-1">
            
           </div>
           <div class="col-11">
             <hr />
           </div>
             </div>
      <div class="row">
          <div class="col-1" id="DivDescription1" runat="server" visible="false">
              <asp:Label ID="label_Tittle" Text="Tittle:" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="DivDescription2" runat="server" visible="false">
              <asp:Label ID="btn_documentname" Text="" runat="server" ToolTip="Document's Description" ></asp:Label>
          </div>

          <div class="col-1" id="DivRevision1" runat="server" visible="false">
              <asp:Label ID="label_Revision" Text="Revision:" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="DivRevision2" runat="server" visible="false">
              <asp:Label ID="btn_documentrev" Text="" runat="server" ToolTip="Document's Current Revision"></asp:Label>
          </div>
        <hr />
      </div>
       
      <div class="row">
          <div class="col-1" id="DivSubmittedTime1" runat="server" visible="false">
              <asp:Label ID="label_Submitted" Text="Submitted On:" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="DivSubmittedTime2" runat="server" visible="false">
              <asp:Label ID="btn_documentSubmittedTime" Text="" runat="server" ToolTip="Document Submission Date/Time in ERPLN "></asp:Label>
          </div>
          <div class="col-1" id="DivEUserName1" runat="server" visible="false">
              <asp:Label ID="label_Username" Text="User Name:" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="DivEUserName2" runat="server" visible="false">
              <asp:Label ID="btn_EUserName" runat="server" Text="" ToolTip="ERPLN User Name"></asp:Label>
          </div>
      </div>
      <div class="row">
         <div class="col-1" id="Divdocreleasedate1" runat="server" visible="false">
                         <asp:Label ID="label_docreleasedate" Text="Release Date :" runat="server"> </asp:Label>
                              </div>

         <div class="col-5" id="Divdocreleasedate2" runat="server" visible="false">
          <asp:label ID="Btn_docreleasedate" Text="" runat="server"  ToolTip="Document Release Date"></asp:label>
        </div>
          <div class="col-1" id="DivEReviewedBy1" runat="server" visible="false">
              <asp:Label ID="label_Reviewer" Text="Reviewer:" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="DivEReviewedBy2" runat="server" visible="false">
              <asp:Label ID="btn_EReviewedBy" Text="" runat="server" ToolTip="ERPLN Reviewed By"></asp:Label>
          </div>
      </div>
      <div class="row">
          <div class="col-1" id="DivISGECDataSource1" runat="server" visible="false">
          <asp:Label ID="label_DataSource" Text="Data Source :" runat="server"> </asp:Label>
             </div>

         <div class="col-5" id="DivISGECDataSource2" runat="server" visible="false">
          <asp:label ID="Btn_IsgecDataSource" Text="" runat="server"  ToolTip="Document Datasource"></asp:label>
        </div>
           <div class="col-1" id="DivEApprovedBy1" runat="server" visible="false">
              <asp:Label ID="label_Approver" Text="Approver :" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="DivEApprovedBy2" runat="server" visible="false">
              <asp:Label ID="Btn_EApprovedBy" Text="" runat="server" ToolTip="ERPLN- Approved By"></asp:Label>
          </div>

          

                         




             </div>



      <div class="row">
     <div class="col-1" id="DivStatus" runat="server" visible="false">
        
         <asp:Label ID="label_Status" Text="Status :" runat="server"> </asp:Label>
             </div>
          <div class="col-5" id="DivStatus1" runat="server" visible="false">
         <asp:Label ID="btn_documentStatus" CssClass="btn-warning" Text="" runat="server"  ToolTip="Document's Status"/>
        
       
        </div>
       
  
     <div class="col-1" id="DivWorkflow" runat="server" visible="false">
          
          <asp:Label ID="label_WorkFlow" Text="Workflow :" runat="server"> </asp:Label> 
              </div>
         
          <div class="col-5" id="DivWorkflow1" runat="server" visible="false">
         
         <asp:Label ID="btn_documentWorkflow" CssClass="btn-warning" Text="" runat="server"   ToolTip="Document's Workflow"></asp:Label>
         
     
        </div>   
          </div>
      <div class="row">

         <div class="col-1" id="DivDocumenttype" runat="server" visible="false">
         
        <asp:Label ID="label_DocumentType" Text="Document Type :" runat="server"> </asp:Label>  
            </div>
             <div class="col-5" id="DivDocumenttype1" runat="server" visible="false">
            <asp:Label ID="btn_documentType" Text="" runat="server"  ToolTip="Document Type"></asp:Label>
  
         
        </div>
           

         <div class="col-1" id="DivDivision" runat="server" visible="false">
         
           <asp:Label ID="label_Division" Text="Division :" runat="server"> </asp:Label>   
               </div>
                 <div class="col-5" id="DivDivision1" runat="server" visible="false">
                <asp:label ID="btn_documentDivision" Text="" runat="server"  ToolTip="Division"></asp:label>
  
        </div>
            </div>
      <div class="row">
          <div class="col-1" id="DivResponsible" runat="server" visible="false">
              <asp:Label ID="label_Responsible" Text="Responsible:" runat="server"> </asp:Label>  
          </div>
          <div class="col-5" id="DivResponsible1" runat="server" visible="false">
              <asp:Label ID="btn_documentResponsible" Text="" runat="server"  ToolTip="Document's Responsible Department"></asp:Label>
          </div>
          <div class="col-1" id="DivDate" runat="server" visible="false">
              <asp:Label ID="label_Date" Text="Date:" runat="server"> </asp:Label> 
          </div>
          <div class="col-5" id="DivDate1" runat="server" visible="false">
              <asp:Label ID="btn_documentDate" Text="" runat="server"  ToolTip="Document's Date"></asp:Label>
          </div>
      </div>
      <div class="row">
        <div class="col-1" id="Divweight" runat="server" visible="false">
           <asp:Label ID="label_Weight" Text="Weight:" runat="server"> </asp:Label>  
               </div>
             <div class="col-5" id="Divweight1" runat="server" visible="false">
            <asp:Label ID="btn_documentWeight" Text="" runat="server"  ToolTip="Document's Weight"></asp:Label>
         </div>
       
          
         <div class="col-1" id="Divscale" runat="server" visible="false">
         
            <asp:Label ID="label_Scale" Text="Scale:" runat="server"> </asp:Label>  

         </div>
                <div class="col-5" id="Divscale1" runat="server" visible="false">
               <asp:Label ID="btn_documentScale" Text="" runat="server"  ToolTip="Document's Scale"></asp:Label>
  
           </div>
       
           </div>
      <div class="row">
          <div class="col-1" id="Divsize" runat="server" visible="false">
              <asp:Label ID="label_Size" Text="Size:" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="Divsize1" runat="server" visible="false">
              <asp:Label ID="btn_documentSize" Text="" runat="server"  ToolTip="Document's Size"></asp:Label>
          </div>
          <div class="col-1" id="DivElement" runat="server" visible="false">
              <asp:Label ID="label_Element" Text="Element:" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="DivElement1" runat="server" visible="false">
              <asp:Label ID="btn_documentElement" Text="" runat="server"  ToolTip="Document's Element"></asp:Label>
          </div>
      </div>
      <div class="row">
          <div class="col-1" id="DivDrawnBy" runat="server" visible="false">
              <asp:Label ID="label_Drawn" Text="Drawn:" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="DivDrawnBy1" runat="server" visible="false">
              <asp:Label ID="btn_documentDrawnby" Text="" runat="server"  ToolTip="Drawn By"></asp:Label>
          </div>
          <div class="col-1" id="DivCheckedBy" runat="server" visible="false">
              <asp:Label ID="label_Checked" Text="Checked:" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="DivCheckedBy1" runat="server" visible="false">
              <asp:Label ID="btn_documentCheckedBy" Text="" runat="server"  ToolTip="Checked By"></asp:Label>
          </div>
      </div>
      <div class="row">
          <div class="col-1" id="DivApprovedBy" runat="server" visible="false">
              <asp:Label ID="label_Approved" Text="Approved:" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="DivApprovedBy1" runat="server" visible="false">
              <asp:Label ID="btn_documentApprovedBy" Text="" runat="server"  ToolTip="Approved By"></asp:Label>
          </div>
          <div class="col-1" id="DivSoftwareused" runat="server" visible="false">
              <asp:Label ID="label_SoftwareUsed" Text="Software Used:" runat="server"> </asp:Label>
          </div>
          <div class="col-5" id="DivSoftwareused1" runat="server" visible="false">
              <asp:Label ID="Btn_Softwareused" Text="" runat="server"  ToolTip="Software Used"></asp:Label>
          </div>
      </div>
      <div class="row">
     <div class="col-1" id="DivErection" runat="server" visible="false">
        
           <asp:Label ID="label_Erection" Text="For Erection:" runat="server"> </asp:Label>

     </div>
           <div class="col-5" id="DivErection1" runat="server" visible="false">
          <asp:Label ID="Btn_Erection" Text="" runat="server"  ToolTip="For Erection"></asp:Label>
         
       
        </div>
       
     
     <div class="col-1" id="Divinformation" runat="server" visible="false">
          
           <asp:Label ID="label_Infomation" Text="For Infomation:" runat="server"> </asp:Label> 
         </div>
             <div class="col-5" id="Divinformation1" runat="server" visible="false">
            <asp:Label ID="Btn_Information" Text="" runat="server"   ToolTip="For Information"></asp:Label>
         
     
        </div>   
         </div>
      <div class="row">
          <div class="col-1" id="DivProduction" runat="server" visible="false">
              <asp:Label ID="label_Production" Text="For Production:" runat="server"> </asp:Label> 
          </div>
          <div class="col-5" id="DivProduction1" runat="server" visible="false">
              <asp:Label ID="Btn_Production" Text="" runat="server"  ToolTip="For Production"></asp:Label>
          </div>
          <div class="col-1" id="DivApproval" runat="server" visible="false">
              <asp:Label ID="label_Approval" Text="For Approval:" runat="server"> </asp:Label> 
          </div>
          <div class="col-5" id="DivApproval1" runat="server" visible="false">
              <asp:Label ID="Btn_Approval" Text="" runat="server"  ToolTip="For Approval"></asp:Label>
          </div>
      </div>
      <div class="row">
         <div class="col-1" id="DivMachineName" runat="server" visible="false">
         
            <asp:Label ID="label_MachineName" Text="Machine Name:" runat="server"> </asp:Label> 
             
         </div>
                  <div class="col-5" id="DivMachineName1" runat="server" visible="false">
                <asp:Label ID="Btn_MachineName" Text="" runat="server"  ToolTip="Machine Name"></asp:Label>
  
         
        </div>
    
                 <div class="col-1" id="DivFilename" runat="server" visible="false">
      
          <asp:Label ID="label_FileName" Text="File Name:" runat="server"> </asp:Label>  
           
                    </div>
                  <div class="col-5" id="DivFilename1" runat="server" visible="false">
                
        <asp:Label ID="btn_documentfilename" CssClass="btn-success" Text="" runat="server"  ToolTip="Document's File Name"></asp:Label>
   <asp:Image ID="VaultStatus" runat="server" ToolTip="Status in Vault" ImageUrl="~/Images/locked-s.jpg" Visible="false" />
         </div>
        </div>
          
                                 <div class="row">
           <div class="col-1">
            <asp:label ID="bom" Text="" runat="server" Visible="false"> </asp:label>
           </div>
           <div class="col-11">
             <hr />
           </div>
             </div>
         <div class="col-sm-auto my-0 table-hover">
          <div id="pnl_Details" runat="server" visible="true">
          </div>
        </div>
   <div class="row">
           <div class="col-1">
            <asp:label ID="partbom" Text="" runat="server" Visible="false"> </asp:label>
           </div>
           <div class="col-11">
             <hr />
           </div>
             </div>
         <div class="col-sm-auto my-0 table-hover">
          <div id="pnl_paDetails" runat="server" visible="true">
          </div>
        </div>

       <div class="row">
           <div class="col-1">
            <asp:label ID="ref" Text="" runat="server" Visible="false"> </asp:label>
           </div>
           <div class="col-11">
             <hr />
           </div>
             </div>

      </div>


         <div class="col-sm-auto my-0 table-hover">
          <div id="pnl_rDetails" runat="server" visible="true">
          </div>
        </div>

        <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">
    
      <div id="ti" runat="server" visible="false">
        <a href="#Transmittalinformation" text-align: center; cursor: pointer" data-toggle="collapse">Transmittal -Informations</a>
                <div id="Transmittalinformation" class="collapse">
                           
                        <div class="col-sm-auto my-0 table-hover">
                            <div id="pnl_TDetails" runat="server" visible="true">
                            </div>
                        </div>
                    
                </div>
        </div>

    

<%--      <div id="ii" runat="server" visible="false">
        <a href="#Indentinformation" text-align: center; cursor: pointer" data-toggle="collapse">Indent -Informations</a>
  <div id="Indentinformation" class="collapse">
      <div class="row">
         <div class="col-3" id="DivIndentNumber" runat="server" visible="false">
            Indent Number: </b><asp:label ID="btn_IndentNumber" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's indent Number" BorderStyle="Ridge"></asp:label>
             </div>
         <div class="col-4" id="DivindentDate" runat="server" visible="false">
            Indent Date: <asp:label ID="btn_IndentDate" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Indent's Date" BorderStyle="Ridge"></asp:label>
             </div>
        <div class="col-5" id="DivIndentRequester" runat="server" visible="false">
          Indent Requested By: <asp:label ID="btn_IndentRequester" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Indenter" BorderStyle="Ridge"></asp:label>
             </div>
                </div>
           </div>
    </div>--%>
         

<div id="ii" runat="server" visible="false">
        <a href="#Indentinformation" text-align: center; cursor: pointer" data-toggle="collapse">Indent -Informations</a>
  <div id="Indentinformation" class="collapse">
     
         
          <div class="col-sm-auto my-0 table-hover">
          <div id="pnl_iDetails" runat="server" visible="true">
          </div>
        </div>


                </div>
           </div>
              <div id="reci" runat="server" visible="false">
        <a href="#preorderinformation" text-align: center; cursor: pointer" data-toggle="collapse">Pre Order Receipt -Informations</a>
  <div id="preorderinformation" class="collapse">
     
         
          <div class="col-sm-auto my-0 table-hover">
          <div id="pnl_PREDetails" runat="server" visible="true">
          </div>
        </div>


                </div>
           </div>

    
    
               <%--  <div id="recid" runat="server" visible="false">
        <a href="#preorderdinformation" text-align: center; cursor: pointer" data-toggle="collapse">Pre Order Receipt Detail -Informations</a>
  <div id="preorderdinformation" class="collapse">
     
         
          <div class="col-sm-auto my-0 table-hover">
          <div id="pnl_PREDDetails" runat="server" visible="true">
          </div>
        </div>


                </div>
           </div>--%>

<%--      <div id="poi" runat="server" visible="false">
     <a href="#POinformation" text-align: center; cursor: pointer" data-toggle="collapse">PO -Informations</a>
  <div id="POinformation" class="collapse">
      <div class="row">
         <div class="col-2" id="DivPONumber" runat="server" visible="false">
            PO Number: </b><asp:label ID="btn_PONumber" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="PONumber" BorderStyle="Ridge"></asp:label>
             </div>
         <div class="col-2" id="DivPODate" runat="server" visible="false">
            Date: <asp:label ID="btn_PODate" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="PO Date" BorderStyle="Ridge"></asp:label>
        </div>
        <div class="col-3" id="DivPOSupplier" runat="server" visible="false">
          Supplier: <asp:label ID="btn_POSupplier" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Supplier" BorderStyle="Ridge"></asp:label>
   </div>
        <div class="col-3" id="DivPOSuppliername" runat="server" visible="false">
          Name: <asp:label ID="btn_POSuppliername" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Supplier" BorderStyle="Ridge"></asp:label>
         </div>
        <div class="col-2" id="DivPOBuyer" runat="server" visible="false">
          Buyer: <asp:label ID="btn_POBuyer" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Buyer" BorderStyle="Ridge"></asp:label>
         </div>
             </div>
           </div>
    </div>--%>
       <div id="poi" runat="server" visible="false">
     <a href="#POinformation" text-align: center; cursor: pointer" data-toggle="collapse">PO -Informations</a>
  <div id="POinformation" class="collapse">
     
         
          <div class="col-sm-auto my-0 table-hover">
          <div id="pnl_PODetails" runat="server" visible="true">
          </div>
        </div>


                </div>
           </div>


          <div id="repi" runat="server" visible="false">
        <a href="#postorderinformation" text-align: center; cursor: pointer" data-toggle="collapse">Post Order Receipt -Informations</a>
  <div id="postorderinformation" class="collapse">
     
         
          <div class="col-sm-auto my-0 table-hover">
          <div id="pnl_POSTDetails" runat="server" visible="true">
          </div>
        </div>


                </div>
           </div>

                <div id="repd" runat="server" visible="false">
        <a href="#postorderdinformation" text-align: center; cursor: pointer" data-toggle="collapse">Post Order Receipt Documents -Informations</a>
  <div id="postorderdinformation" class="collapse">
     
         
          <div class="col-sm-auto my-0 table-hover">
          <div id="pnl_POSTDDetails" runat="server" visible="true">
          </div>
        </div>


                </div>
           </div>


        <div id="di" runat="server" visible="false">
        <a href="#DCRinformation" text-align: center; cursor: pointer" data-toggle="collapse">DCR -Informations</a>
      <div id="DCRinformation" class="collapse">
                     
                  <div class="col-sm-auto my-0 table-hover">
          <div id="pnl_DDetails" runat="server" visible="true">
          </div>
        </div>
    
   </div>
              </div>
        <div id="si" runat="server" visible="false">
        <a href="#SARinformation" text-align: center; cursor: pointer" data-toggle="collapse">SAR -Informations</a>
      <div id="SARinformation" class="collapse">
                     
                  <div class="col-sm-auto my-0 table-hover">
          <div id="pnl_SDetails" runat="server" visible="true">
          </div>
        </div>
    
   </div>
              </div>

      <%--<div id="potable" runat="server" visible="true">
        <div class="col-auto">
          <div class="col-auto">
            <h6>
              <div class="badge badge-info">
              PO Item Details</h6>
          </div>
          <div class="col-sm-auto" id="POT" runat="server" clientidmode="static">
          </div>
        </div>
        </div>--%>
   <%--   <div id="pmdli" runat="server" visible="false">
    <a href="#PMDLinformation" text-align: center; cursor: pointer" data-toggle="collapse">PMDL -Informations</a>
  <div id="PMDLinformation" class="collapse">
  
    
      <div class="row mt-1">
      
   
        <div class="col-3">
         <div class="container" id="DivPMDLProjectType" runat="server" visible="false">
         
            Project Type: </b><asp:Button ID="btn_PMDLProjectType" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Project Type"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-3">
         <div class="container" id="DivPMDLProjectId" runat="server" visible="false">
         
            ProjectId: <asp:Button ID="btn_PMDLProjectId" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Project Id"></asp:Button>
  
         
        </div>
             </div>
           
            <div class="col-3">
           
        <div class="container" id="DivPMDLUID" runat="server" visible="false">
         
          UID: <asp:Button ID="btn_PMDLUID" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="UID"></asp:Button>
  
         </div>
       
             </div>
         <div class="col-3">
           
        <div class="container" id="DivPMDLDocumentRevision" runat="server" visible="false">
         
          Revision Number: <asp:Button ID="btnPMDLDocumentRevision" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Revision Number"></asp:Button>
  
         </div>
       
             </div>
            
             
           </div>
     <div class="row mt-1">
      
   
        <div class="col-3">
         <div class="container" id="DivPMDLBSFD" runat="server" visible="false">
         
            Project Type: </b><asp:Button ID="btn_" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Project Type"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-3">
         <div class="container" id="Div2" runat="server" visible="false">
         
            ProjectId: <asp:Button ID="Button2" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Project Id"></asp:Button>
  
         
        </div>
             </div>
           
            <div class="col-3">
           
        <div class="container" id="Div3" runat="server" visible="false">
         
          UID: <asp:Button ID="Button3" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="UID"></asp:Button>
  
         </div>
       
             </div>
         <div class="col-3">
           
        <div class="container" id="Div4" runat="server" visible="false">
         
          Revision Number: <asp:Button ID="Button4" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Revision Number"></asp:Button>
  
         </div>
       
             </div>
            
             
           </div>
    </div>
     <hr/>
</div>--%>
    <%-- <div id="vi" runat="server" visible="false">
       
 
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
     

      </div></div>--%>




    <%--    <div id="sd" runat="server" visible="false">
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
     

      </div></div>--%>
        <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">


             </ContentTemplate>
           <Triggers>
           </Triggers>
    </asp:UpdatePanel>
</div>
</div>
    <%--<script>
        function aaa() {
           
        }
    </script>--%>
</asp:Content>