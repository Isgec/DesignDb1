<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_Discipline.aspx.vb" Inherits="GF_Discipline" Title="Discipline DashBoard" %>

<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" runat="Server">

 
    <div class="caption">
      <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;Discipline DashBoard"></asp:Label>
    </div>
  
    <div class="pagedata">
      <asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server">
        <ContentTemplate>

          <asp:UpdateProgress ID="UPGStaApprovalWFTypes" runat="server" AssociatedUpdatePanelID="UPNLtaApprovalWFTypes" DisplayAfter="100">
            <ProgressTemplate>
              <span style="color: #ff0031">Loading...</span>
            </ProgressTemplate>
          </asp:UpdateProgress>
         
           <%-- <script src="Script1.js"></script>--%>
         <div class="container-fluid">
      <div id="carouselExampleIndicators1" class="carousel slide" data-ride="carousel">
  <ol class="carousel-indicators">
    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="5"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="6"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="7"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="8"></li>
  </ol>
  <div class="carousel-inner">
    <div class="carousel-item active">
     
       <hr style="color: forestgreen; background-color: darkgreen; width: 100%; height: 1px">  
    </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: blue; width: 100%; height: 1px">
       </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: red; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: orange; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: yellow; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: magenta; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
     <hr style="color: forestgreen; background-color: darkslategray; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
     <hr style="color: forestgreen; background-color: blue; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: lightgreen; width: 100%; height: 1px">
    </div>

  </div>
  <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>   
          <%-- Query Buttons--%>
          <div class="row">

            <div class="col-auto">
               <div class="input-group">

                  <a href="#ID_Division" class="btn btn-secondary" style="width: 90px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Division</b></a>
                  <div id="ID_Division" class="collapse">
                    Select Division for which Information need to fetched for Dashboard.
    Click again 'Division' button To Hide this Information.
                  </div>
                  <asp:DropDownList ID="F_DivisionID" ClientIDMode="static" runat="Server" class="btn btn-light btn-outline-dark">
                    <asp:ListItem Value="">BOILER</asp:ListItem>
                    <asp:ListItem>EPC</asp:ListItem>
                    <asp:ListItem>SMD</asp:ListItem>
                    <asp:ListItem>APC</asp:ListItem>
                    <asp:ListItem>FGD</asp:ListItem>

                  </asp:DropDownList>
                </div>
             
            </div>

            <div class="col-auto">

             

                <div class="input-group">

                  <a href="#ID_Discipline" class="btn btn-secondary" style="width: 100px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Discipline</b></a>
                  <div id="ID_Discipline" class="collapse">
                    Select Department for which Information need to fetched for Dashboard.
    Click again 'Department' button To Hide this Information.
                  </div>
                  <asp:DropDownList ID="F_DisciplineID" class="btn btn-light btn-outline-dark" ClientIDMode="static" runat="Server">
                    <asp:ListItem Value="">MECHANICAL</asp:ListItem>
                    <asp:ListItem>PROCESS</asp:ListItem>
                    <asp:ListItem>STRUCTURE</asp:ListItem>
                    <asp:ListItem>PIPING</asp:ListItem>
                    <asp:ListItem>ELECTRICAL</asp:ListItem>
                    <asp:ListItem>INSTRUMENTATION</asp:ListItem>
                    <asp:ListItem>CIVIL</asp:ListItem>
                    <asp:ListItem>MATERIAL HANDLING</asp:ListItem>
                    <asp:ListItem>PROJECT</asp:ListItem>
                    <asp:ListItem>WWS</asp:ListItem>


                  </asp:DropDownList>
                </div>
             
            </div>

               <div class="col-auto">

            

                <div class="input-group">

                  <a href="#ID_Month" class="btn btn-secondary" style="width: 80px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Month</b></a>
                  <div id="ID_Month" class="collapse">
                    Select Department for which Information need to fetched for Dashboard.
    Click again 'Department' button To Hide this Information.
                  </div>
                  <asp:DropDownList ID="F_MonthID" class="btn btn-light btn-outline-dark" runat="server">
                    <asp:ListItem>JANUARY</asp:ListItem>
                    <asp:ListItem>FEBRUARY</asp:ListItem>
                    <asp:ListItem>MARCH</asp:ListItem>
                    <asp:ListItem>APRIL</asp:ListItem>
                    <asp:ListItem>MAY</asp:ListItem>
                    <asp:ListItem>JUNE</asp:ListItem>
                    <asp:ListItem>JULY</asp:ListItem>
                    <asp:ListItem>AUGUST</asp:ListItem>
                    <asp:ListItem>SEPTEMBER</asp:ListItem>
                    <asp:ListItem>OCTOBER</asp:ListItem>
                    <asp:ListItem>NOVEMBER</asp:ListItem>
                    <asp:ListItem>DECEMBER</asp:ListItem>
                  </asp:DropDownList>
                </div>
          
            </div>

            <div class="col-auto">

            

                <div class="input-group">

                  <a href="#ID_Year" class="btn btn-secondary" style="width: 80px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Year</b></a>
                  <div id="ID_Year" class="collapse">
                    Select Department for which Information need to fetched for Dashboard.
    Click again 'Department' button To Hide this Information.
                  </div>
                  <asp:DropDownList ID="F_YearID" class="btn btn-light btn-outline-dark" ClientIDMode="static" runat="Server">
                    <asp:ListItem Value="">2021</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>


                  </asp:DropDownList>
                </div>
              
            </div>

          <div class="col-auto">
    <asp:Button ID="cmdSubmit" runat="server" class="btn btn-light btn-outline-dark" Font-Bold="true" Text="Generate DashBoard" ToolTip="Click to Generate DashBoard" Style="width: 210px; text-align: center; cursor: pointer" />
            </div>

          </div>

         
   <%-- <div class="row mt-2">
            <div class="col-9">
            </div>
            <div class="col-3 text-left">

              <asp:Button ID="cmdSubmit" runat="server" class="btn btn-light btn-outline-dark" Font-Bold="true" Text="Generate DashBoard" ToolTip="Click to Generate DashBoard" Style="width: 210px; text-align: center; cursor: pointer" />
            </div>
          </div>--%>
       
          <%-- Query Buttons--%>
     <div id="carouselExampleIndicators2" class="carousel slide" data-ride="carousel">
  <ol class="carousel-indicators">
    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="5"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="6"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="7"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="8"></li>
  </ol>
  <div class="carousel-inner">
    <div class="carousel-item active">
     
       <hr style="color: forestgreen; background-color: darkgreen; width: 100%; height: 1px">  
    </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: blue; width: 100%; height: 1px">
       </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: red; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: orange; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: yellow; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: magenta; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
     <hr style="color: forestgreen; background-color: darkslategray; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
     <hr style="color: forestgreen; background-color: blue; width: 100%; height: 1px">
    </div>
    <div class="carousel-item">
      <hr style="color: forestgreen; background-color: lightgreen; width: 100%; height: 1px">
    </div>

  </div>
  <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>   
      </div>
   
         
              
          
      
           <%-- PMDL TABLE--%>

        <div>

          <div class="container-fluid" id="DPMDLTABLE" runat="server" visible="false">
             
       <%--  <hr style="color: forestgreen; background-color: darkgreen; width: 100%; height: 1px">--%> 
            <center> <h6><font face="comic Sans MS">Drawing and Document Progress Status As per PMDL (Baseline Finish Date)</font></h6></center>

     <div class="border border-secondary btn-outline-light">
            <div class="container-fluid" id="DPMDLTABLE1" runat="server" visible="true">
              
             
                <div class=" text-center">

                  <div class="row">
                    <div class="col-3">
                      <div class="text-secondary">
                        <h6><b></b></h6>
                      </div>
                    </div>

                    <div class="col-9">
                      <div class="row">

                         <div class="col">
                          <div class="text-dark">
                           <font face="Comic Sans MS"><b>To Release in Current Month </b></font>
                          </div>
                        </div>

                        <div class="col">
                          <div class="text-warning">
                           <font face="Comic Sans MS"><b>Total Due for Release Current Month = A </b></font>
                          </div>
                        </div>
                        <div class="col">
                          <div class="text-danger">
                             <font face="Comic Sans MS"><b>Backlog for Release (Previous months) = B </b></font>
                          </div>
                        </div>
                        <div class="col">
                          <div class="text-danger">

                            <font face="Comic Sans MS"><b> Due For Release  C = (A + B)</b></font>
                          </div>
                        </div>
                        <div class="col">
                          <div class="text-danger">
                           <font face="Comic Sans MS"><b> Due Till Today For Release</b></font>
                          </div>
                        </div>

                        <div class="col">
                          <div class="text-warning">
                          <font face="Comic Sans MS"><b>Due for Today Only To Release</b></font>
                          </div>
                        </div>

                        <div class="col">
                          <div class="text-success">
                         <font face="Comic Sans MS">Ontime Released in/before This Month</font>
                          </div>
                        </div>

                        <div class="col">
                          <div class="text-info">
                            <font face="Comic Sans MS">Backlog Released in This Month</font
                          </div>
                        </div>
                      </div>
                    </div>

                  </div>

                </div>

                <div class="mb-1">
                  <div class="row">
                    <div class="col-3">
                      <asp:Button ID="Btn_Discipline" runat="server" CssClass="btn btn-dark btn-sm btn-block text-center font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-9">
                      <div class="row">

                        <div class="col">
                          <asp:Button ID="btn_ToRelease_CurrentM" runat="server" CssClass="btn-sm btn-block font-weight-bold" ToolTip="To Release in Current Month " Text="" Font-Bold="true"></asp:Button>
                        </div>

                        <div class="col">
                          <asp:Button ID="btn_DueforRelease_CurrentM_A" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total Due for Release Current Month -A" Text="" Font-Bold="true"></asp:Button>
                        </div>
                        <div class="col">
                          <asp:Button ID="btn_DueforRelease_PreviousM_B" runat="server" CssClass="btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Total Due for Release Previous Month -B" Text="" Font-Bold="true"></asp:Button>
                        </div>
                        <div class="col">
                          <asp:Button ID="btn_DueforRelease_BothM_C" runat="server" CssClass="btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Total Due For Release - C = A + B" Text="" Font-Bold="true"></asp:Button>
                        </div>

                        <div class="col">
                          <asp:Button ID="btn_AllDueTillToday_Release" runat="server" CssClass="btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="All Due Till Today For Release" Text="" Font-Bold="true"></asp:Button>

                        </div>

                        <div class="col">
                          <asp:Button ID="btn_DueOnlyToday_Release" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Due for Today Only To Release" Text="" Font-Bold="true"></asp:Button>
                        </div>
                        <div class="col">
                          <asp:Button ID="btn_Ontime_Release_CurrentM" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Ontime Released in This Month" Text="" Font-Bold="true"></asp:Button>
                        </div>
                        <div class="col">
                          <asp:Button ID="btn_Backlog_Release_CurrentM" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Backlog Released in This Month" Text="" Font-Bold="true"></asp:Button>
                        </div>

                      </div>
                    </div>

                  </div>
                </div>
        </div>
              </div>
            </div>
          </div>
         
            <div class="container-fluid" id="prod1" runat="server" visible="false">
             
       <%--  <hr style="color: forestgreen; background-color: darkgreen; width: 100%; height: 1px">--%> 
            <center> <h6><font face="comic Sans MS">Release vs Issue Comparision</font></h6></center>

     <div class="border border-secondary btn-outline-light">
            <div class="container-fluid" id="prod2" runat="server" visible="true">
              
             
                <div class=" text-center">

                  <div class="row">
                    <div class="col-3">
                      <div class="text-secondary">
                        <h6><b></b></h6>
                      </div>
                    </div>

                    <div class="col-9">
                      <div class="row">

                         <div class="col">
                          <div class="text-dark">
                           <font face="Comic Sans MS"><b>Document Released but not issued in Current Month </b></font>
                          </div>
                        </div>

                        <div class="col">
                          <div class="text-warning">
                           <font face="Comic Sans MS"><b>Document Released but not issued in last 30 Days </b></font>
                          </div>
                        </div>
                        <div class="col">
                          <div class="text-danger">
                             <font face="Comic Sans MS"><b>Document Released but not issued in last 60 Days </b></font>
                          </div>
                        </div>

                           <div class="col">
                          <div class="text-danger">
                             <font face="Comic Sans MS"><b>Document Released but not issued in last 100 Days </b></font>
                          </div>
                        </div>
                        
                      </div>
                    </div>

                  </div>

                </div>

                <div class="mb-1">
                  <div class="row">
                    <div class="col-3">
                      <asp:Button ID="BtnDisciplineprod" runat="server" CssClass="btn btn-dark btn-sm btn-block text-center font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-9">
                      <div class="row">

                        <div class="col">
                          <asp:Button ID="btn_Dueforissue_CurrentM_A" runat="server" CssClass="btn-sm btn-block font-weight-bold" ToolTip="Document Released but not issued in Current Month" Text="" Font-Bold="true"></asp:Button>
                        </div>

                        <div class="col">
                          <asp:Button ID="btn_Dueforissue_previousM_B" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Document Released but not issued in last 30 Days" Text="" Font-Bold="true"></asp:Button>
                        </div>

                        <div class="col">
                          <asp:Button ID="btn_Dueforissue_Total_C" runat="server" CssClass="btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Document Released but not issued in last 60 Days" Text="" Font-Bold="true"></asp:Button>
                        </div>
                        
                          <div class="col">
                          <asp:Button ID="btn_Dueforissue_Total_D" runat="server" CssClass="btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Document Released but not issued in last 100 Days" Text="" Font-Bold="true"></asp:Button>
                        </div>

                      </div>
                    </div>

                  </div>
                </div>
        </div>
              </div>
            </div>

         
        
          
        <%--  <hr>--%>
          <%-- SAR TABLE--%>



          <div class="container-fluid mt-1" id="DSARTABLE" runat="server" visible="false">
            <center> <h6><font face="Comic Sans MS">SAR Progress Status</font></h6></center>
            <div class="border border-secondary btn-outline-light">
             <div class="container-fluid mb-1" id="DSARTABLE1" runat="server" visible="true">
               <div class=" text-center">
                <div class="row">

                  <div class="col-3">
                    <div class="text-secondary">
                      <b></b>
                    </div>
                  </div>



                  <div class="col-9">
                    <div class="row">
                      <div class="col">
                        <div class="text-dark">
                          <font face="Comic Sans MS"><b>Total SAR Count</b></font>
                        </div>
                      </div>

                      <div class="col">
                        <div class="text-info">
                          <font face="Comic Sans MS">Under Creation</font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-warning">
                          <font face="Comic Sans MS"><b>Under Review</b></font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-warning">
                          <font face="Comic Sans MS"><b>Under Approval</b></font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-danger">
                          <font face="Comic Sans MS"><b>Pending</b></font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-success">
                          <font face="Comic Sans MS">Approved</font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-secondary">
                          <font face="Comic Sans MS">Not Applicable</font>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

             
             
                <div class="row">
                  <div class="col-3">
                    <asp:Button ID="Btn_Discipline1" runat="server" CssClass="btn btn-dark btn-sm btn-block text-center font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>

                  </div>
                  <div class="col-9">
                    <div class="row">
                      <div class="col">
                        <asp:Button ID="btn_SAR_TotalCount" runat="server" CssClass="btn-sm btn-block font-weight-bold" ToolTip="Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_UnderCreation" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_UnderReview" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_UnderApproval" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_Pending" runat="server" CssClass="btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="SAR - Pending" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_NotApplicable" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                      </div>


                    </div>
                  </div>

                </div>

                <div class="row mt-1">
                  <div class="col-3">
                    <asp:Button ID="Btn_Discipline2" runat="server" CssClass="btn btn-dark btn-sm btn-block text-center font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>

                  </div>
                  <div class="col-9">
                    <div class="row">
                      <div class="col">
                        <asp:Button ID="btn_SAR_TotalCountA" runat="server" CssClass="btn-sm btn-block font-weight-bold" ToolTip="Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_UnderCreationA" runat="server" CssClass="btn btn-sm btn-outline-info btn-block font-weight-bold" ToolTip="SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_UnderReviewA" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_UnderApprovalA" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_PendingA" runat="server" CssClass="btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="SAR - Pending" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_ApprovedA" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                      </div>
                      <div class="col">
                        <asp:Button ID="btn_SAR_NotApplicableA" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                      </div>


                    </div>
                  </div>

                </div>
 </div>
              </div>
            </div>
           </div>
      
     

          <%-- ELEMENT TABLE--%>
          
          <div class=" container-fluid" id="DELEMENTTABLE" runat="server" visible="false">
           <center>  <h6><font face="Comic Sans MS">Active Element Progress</font></h6></center>
            
               <div class="border border-secondary btn-outline-light">
            <div class=" container-fluid" id="DELEMENTTABLE1" runat="server" visible="true">
           
                    <div class="row">

                    <div class="col-3">
                      <div class="text-secondary">
                     <b></b>
                      </div>
                    </div>



                    <div class="col-5">
                      <div class="row">
                        <div class="col-6">
                          <div class="text-dark">
                            <center> <font face="Comic Sans MS"><b>Total Active Element Count</b></font></center>
                          </div>
                        </div>

                        <div class="col-6">
                          <div class="text-warning">
                             <center> <font face="Comic Sans MS"><b>Free</b></font></center>
                          </div>
                        </div>
                      </div>
                    </div>

                    <div class="col-4">
                      <div class="row">

                        <div class="col-6">
                          <div class="text-warning">
                            <center>  <font face="Comic Sans MS"><b>Partial</b></font></center>
                          </div>
                        </div>
                        <div class="col-6">
                          <div class="text-success">
                            <center> <font face="Comic Sans MS">Completed</font></center>
                          </div>
                        </div>

                      </div>
                    </div>
                  </div>
                              
                    <div class="row">
                      <div class="col-3">
                        <h6><span class="btn btn-dark btn-sm btn-block text-center font-weight-bold"><font face="Comic Sans MS">Total </font></span></h6>
                      </div>
                      <div class="col-5">
                        <div class="row">
                          <div class="col-6">
                            <asp:Button ID="btn_Total_Element" runat="server" CssClass="btn-sm btn-block font-weight-bold" ToolTip="Total - Total Active Element Count" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col-6">
                            <asp:Button ID="btn_Element_Free" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                          </div>
                        </div>
                      </div>
                      <div class="col-4">
                        <div class="row">

                          <div class="col-6">
                            <asp:Button ID="btn_Element_Partial" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col-6">
                            <asp:Button ID="btn_Element_Completed" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Total - Active Element - Completed" Text="" Font-Bold="true"></asp:Button>
                          </div>

                        </div>
                      </div>
                    </div>
                 
              </div>
            </div>
          <%--   <hr style="color: forestgreen; background-color: darkgreen; width: 100%; height: 1px">--%>
          </div>
           
       <%--   <hr>--%>

             <%--<%--  PreOrder Receipt--%>
         <div class="container-fluid mt-1" id="DIDMSPRETABLE" runat="server" visible="false">
            <center> <h6><font face="Comic Sans MS">IDMS Pre Order Receipt Progress Status</font></h6></center>
            <div class="border border-secondary btn-outline-light">
             <div class="container-fluid mb-1" id="DIDMSPRETABLE1" runat="server" visible="true">
               <div class=" text-center">
                <div class="row">

                  <div class="col-3">
                    <div class="text-secondary">
                      <b></b>
                    </div>
                  </div>



                  <div class="col-9">
                    <div class="row">
                      <div class="col">
                        <div class="text-dark">
                          <font face="Comic Sans MS"><b>Total Receipt Count</b></font>
                        </div>
                      </div>

                      <div class="col">
                        <div class="text-info">
                          <font face="Comic Sans MS">Submitted</font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-warning">
                          <font face="Comic Sans MS">Document Linked</font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-danger">
                          <font face="Comic Sans MS"><b>Under Evaluation</b></font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-warning">
                          <font face="Comic Sans MS"><b>Comments Submitted</b></font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-success">
                          <font face="Comic Sans MS">Technically Cleared</font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-secondary">
                          <font face="Comic Sans MS">Transmittal Issued</font>
                        </div>
                      </div>
                       <div class="col">
                        <div class="text-secondary">
                          <font face="Comic Sans MS">Superceded</font>
                        </div>
                      </div>
                       <div class="col">
                        <div class="text-secondary">
                          <font face="Comic Sans MS">Closed</font>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

             
             
                <div class="row">
                  <div class="col-3">
                    <asp:Button ID="Btn_Discipline3" runat="server" CssClass="btn btn-dark btn-sm btn-block text-center font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>

                  </div>
                  <div class="col-9">
                   <div class="row">
                      <div class="col">
                      <asp:Button ID="btn_IDMSPre_Total_Count" runat="server" CssClass="btn-sm btn-block font-weight-bold" ToolTip="Pre Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPre_Submitted" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Pre Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPre_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Pre Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPre_Under_Evaluation" runat="server" CssClass="btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Pre Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPre_Comments_Submitted" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Pre Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPre_Technically_Cleared" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Pre Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPre_Transmittal_Issued" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Pre Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPre_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Pre Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPre_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Pre Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>


                    </div>
                  </div>

                </div>

                <div class="row mt-1">
                  <div class="col-3">
                    <asp:Button ID="Btn_Discipline4" runat="server" CssClass="btn btn-dark btn-sm btn-block text-center font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>

                  </div>
                  <div class="col-9">
                     <div class="row">
                      <div class="col">
                      <asp:Button ID="btn_All_IDMSPre_Total_Count" runat="server" CssClass="btn-sm btn-block font-weight-bold" ToolTip="All - Pre Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPre_Submitted" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="All - Pre Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPre_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="All - Pre Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPre_Under_Evaluation" runat="server" CssClass="btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="All - Pre Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPre_Comments_Submitted" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="All - Pre Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPre_Technically_Cleared" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="All - Pre Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPre_Transmittal_Issued" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="All - Pre Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPre_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="All - Pre Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPre_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="All - Pre Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>


                    </div>
                  </div>

                </div>
 </div>
              </div>
            </div>
           </div>
          
         <div class="container-fluid mt-1" id="DIDMSPOSTTABLE" runat="server" visible="false">
            <center> <h6><font face="Comic Sans MS">IDMS Post Order Receipt Progress Status</font></h6></center>
            <div class="border border-secondary btn-outline-light">
             <div class="container-fluid mb-1" id="DIDMSPOSTTABLE1" runat="server" visible="true">
               <div class=" text-center">
                <div class="row">

                  <div class="col-3">
                    <div class="text-secondary">
                      <b></b>
                    </div>
                  </div>



                  <div class="col-9">
                    <div class="row">
                      <div class="col">
                        <div class="text-dark">
                          <font face="Comic Sans MS"><b>Total Receipt Count</b></font>
                        </div>
                      </div>

                      <div class="col">
                        <div class="text-info">
                          <font face="Comic Sans MS">Submitted</font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-warning">
                          <font face="Comic Sans MS">Document Linked</font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-danger">
                          <font face="Comic Sans MS"><b>Under Evaluation</b></font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-warning">
                          <font face="Comic Sans MS"><b>Comments Submitted</b></font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-primary">
                          <font face="Comic Sans MS"><b>Technically Cleared</b></font>
                        </div>
                      </div>
                      <div class="col">
                        <div class="text-success">
                          <font face="Comic Sans MS">Transmittal Issued</font>
                        </div>
                      </div>
                       <div class="col">
                        <div class="text-secondary">
                          <font face="Comic Sans MS">Superceded</font>
                        </div>
                      </div>
                       <div class="col">
                        <div class="text-secondary">
                          <font face="Comic Sans MS">Closed</font>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

             
             
                <div class="row">
                  <div class="col-3">
                    <asp:Button ID="Btn_Discipline5" runat="server" CssClass="btn btn-dark btn-sm btn-block text-center font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>

                  </div>
                  <div class="col-9">
                   <div class="row">
                      <div class="col">
                      <asp:Button ID="btn_IDMSPost_Total_Count" runat="server" CssClass="btn-sm btn-block font-weight-bold" ToolTip="Post Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPost_Submitted" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Post Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPost_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Post Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPost_Under_Evaluation" runat="server" CssClass="btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Post Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPost_Comments_Submitted" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Post Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPost_Technically_Cleared" runat="server" CssClass="btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Post Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPost_Transmittal_Issued" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Post Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPost_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Post Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_IDMSPost_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Post Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>


                    </div>
                  </div>

                </div>

                <div class="row mt-1">
                  <div class="col-3">
                    <asp:Button ID="Btn_Discipline6" runat="server" CssClass="btn btn-dark btn-sm btn-block text-center font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>

                  </div>
                  <div class="col-9">
                     <div class="row">
                      <div class="col">
                      <asp:Button ID="btn_All_IDMSPost_Total_Count" runat="server" CssClass="btn-sm btn-block font-weight-bold" ToolTip="All - Post Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPost_Submitted" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="All - Post Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPost_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="All - Post Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPost_Under_Evaluation" runat="server" CssClass="btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="All - Post Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPost_Comments_Submitted" runat="server" CssClass="btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="All - Post Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPost_Technically_Cleared" runat="server" CssClass="btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="All - Post Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPost_Transmittal_Issued" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="All - Post Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPost_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="All - Post Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col">
                      <asp:Button ID="btn_All_IDMSPost_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="All - Post Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>


                    </div>
                  </div>

                </div>
 </div>
              </div>
            </div>
           </div>
        
           <%--   <hr>--%>
                
        </ContentTemplate>
        <Triggers>
          <asp:PostBackTrigger ControlID="cmdSubmit" />
        </Triggers>
      </asp:UpdatePanel>
    </div>
      
</asp:Content>
