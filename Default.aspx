<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableViewState="false" %>

<%@ Register Src="~/ctl_Check.ascx" TagPrefix="uc1" TagName="ctl_Check" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Check File</title>
    
</head>
<body>
    <form id="form1" runat="server">
        <uc1:ctl_Check runat="server" id="ctl_Check" />
    </form>
</body>
</html>
