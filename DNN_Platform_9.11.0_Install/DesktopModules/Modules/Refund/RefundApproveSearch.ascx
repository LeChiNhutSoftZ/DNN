<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RefundApproveSearch.ascx.cs" Inherits="Modules.Refund.RefundApproveSearch" %>

<asp:UpdatePanel ID="updatePanel"
    runat="server">
    <ContentTemplate>
        <div class="form-horizontal">
            <div class="form-group">
                <div class="col-sm-3 control-label">
                    <label>Tab</label>
                </div>
                <div class="col-sm-5">
                    <asp:DropDownList 
                        ID="ddlTab" 
                        runat="server" 
                        AutoPostBack="true" 
                        OnSelectedIndexChanged="LoadTabModule" 
                        EmptyMessage="Please select a Tab Page" >
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2"></div>
           </div>
            <div class="form-group">
                <div class="col-sm-3 control-label">
                    <label>Module</label>
                </div>
                <div class="col-sm-5">
                    <asp:DropDownList 
                        ID="ddlModule" 
                        runat="server" 
                        AutoPostBack="True" 
                        OnSelectedIndexChanged="LoadModuleDefinition" 
                        EmptyMessage="Please select a Module" >
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="form-group">
                <div class="col-sm-3 control-label">
                    <label>Definition</label>
                </div>
                <div class="col-sm-5">
                    <asp:DropDownList
                        ID="ddlDefinition"
                        runat="server">

                    </asp:DropDownList>
                </div>
            </div> 

           <div class="form-group">
                <div class="col-sm-3 control-label"></div>
                <div class="col-sm-9">
                   <asp:Button Cssclass="btn btn-primary"
                        ID="btnAddd"
                        OnClick="AddModule"
                        runat="server"
                       Text="Thêm Mới"/>
                </div>
            </div>

         <%--  <div class="form-group">
                <asp:PlaceHolder ID="phMessage"
                    runat="server" />
            </div>
            <div class="form-group">
                <div class="col-sm-12 table-responsive">
                    <asp:GridView
                        AutoGenerateColumns="false"
                        AllowFilteringByColumn="False"
                        AllowSorting="False"
                        ID="gridData"
                        PageSize="10"
                        runat="server"
                        Visible="false">
                        <MasterTableView>
                            <Columns>
                                <dnn:DnnGridBoundColumn DataField="ModuleOrder"
                                    HeaderText="ModuleOrder">
                                    <HeaderStyle Width="10%" />
                                </dnn:DnnGridBoundColumn>
                                <dnn:DnnGridBoundColumn DataField="ModuleName"
                                    HeaderText="ModuleName">
                                    <HeaderStyle Width="30%" />
                                </dnn:DnnGridBoundColumn>
                                <dnn:DnnGridBoundColumn DataField="Content"
                                    HeaderText="Content">
                                    <HeaderStyle Width="30%" />
                                </dnn:DnnGridBoundColumn>
                                <dnn:DnnGridBoundColumn DataField="ControlSrc"
                                    HeaderText="ControlSrc">
                                    <HeaderStyle Width="30%" />
                                </dnn:DnnGridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </asp:GridView>
                </div>
            </div>--%>
            
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
