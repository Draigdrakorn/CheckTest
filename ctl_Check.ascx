<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_Check.ascx.cs" Inherits="Controls_ctl_Check" %>
<div>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script src="Scripts/json2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=btnAdd.ClientID%>').click(function (){
                $.ajax({
                    type: 'post',
                    contentType: "application/json;charset=utf-8",
                    data: JSON2.stringify({fileName: $('#<%=txtFileName.ClientID%>').val(),
                        check: CheckIt()}),
                    url: 'CheckService.asmx/NewMethod',
                    dataType: JSON,
                    success: function()
                    {
                        alert('done');
                    },
                    error: function(err)
                    {
                        alert('wrong');
                    }
                })
                function CheckIt() {
                    if ($('#<%= chkChecked.ClientID %>').is(':checked')) {
                        return 'true';
                    }
                    else 
                    {
                        return 'false';
                    }
                }
            })
        })

        $(document).ready(function () {
                    
            $.ajax({
                type: 'post',
                contentType: "application/json;charset=utf-8",
                url: 'CheckService.asmx/GetAll',
                dataType: 'json',
                async: true,
                success: function(data)
                {

                    var obj = jQuery.parseJSON(data.d);
                    var table = '<table>';
                    table += '<tr><th>File Name</th> <th>Checked</th></tr>'
                    $.each(obj, function (index, element) {
                        table += '<tr><td>' + element.FileName + '</td>';
                        table += '<td>' + element.Checked + '</td></tr>';
                        //table += '<td><span class="' + 'check' + '">edit</span></td></tr>';


                        //for(var i=0; i< obj.length;i++)
                        //{
                        //    $("#gdvCheckList").append("<tr><td>" + obj[i].CheckID + "</td><td>" + obj[i].FileName + "</td><td>" + obj[i].Country + "</td></tr>");
                        //}
                    });
                    table += '</table>';

                    $('#dispElements').html(table);

                        
                },
                error: function(err){
                    alert("error");
            }
                
            })
        })

                
    </script>    
        <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
            <div id="divForm" runat="server" visible="true">
                <table style="width:100%" border="0">
                    <tr>
                        <td>File Name</td>
                        <td>
                            <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Checked</td>
                        <td>
                            <asp:CheckBox ID="chkChecked" runat="server" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        
            <div id="dispElements">CheckID</div>

            

            <div id="divList" runat="server" visible="false">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
                <asp:GridView ID="gdvCheckList" runat="server" 
                    AutoGenerateColumns="False" 
                    OnRowDataBound="gdvCheckList_RowDataBound" 
                    OnRowCommand="gdvCheckList_RowCommand" 
                    OnRowDeleting="gdvCheckList_RowDeleting" 
                    OnRowEditing="gdvCheckList_RowEditing" 
                    OnRowUpdating="gdvCheckList_RowUpdating" EmptyDataText="No Records Found" >
                    <Columns>

                        <asp:TemplateField HeaderText="Check ID">
                            <ItemTemplate>
                              
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="File Name">
                            <ItemTemplate>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Checked">
                            <ItemTemplate>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="imgEdit" Text="Edit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("CheckID")%>'
                                    CommandName="Edit" CssClass="icon-edit" ToolTip="Edit Check" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="sfEdit" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="imgDelete" runat="server" Text="Delete" CausesValidation="False" CommandArgument='<%# Eval("CheckID")%>'
                                    CommandName="Delete" CssClass="icon-delete" ToolTip="Delete Check" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="sfDelete" />
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>