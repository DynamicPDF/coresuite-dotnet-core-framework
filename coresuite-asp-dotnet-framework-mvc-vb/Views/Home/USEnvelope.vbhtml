@ModelType coresuite_asp_dotnet_framework_mvc_vb.Models.EnvelopeModel
@Code
    ViewData("Title") = "US Envelope"
    Layout = "~/Views/Shared/_DynamicPDFLayout.vbhtml"
End Code

<h2>Create US Envelope</h2>
<form action="CreateEnvelope" method="post">
    <table border=0>
        <tr><td colspan=2><b>From Address:</b></td></tr>
        <tr><td>Name:</td><td>@Html.TextBoxFor(Function(model) model.FromAddress.Name)</td></tr>
        <tr><td>Address:</td><td>@Html.TextBoxFor(Function(model) model.FromAddress.Address1)</td></tr>
        <tr><td>&nbsp;</td><td>@Html.TextBoxFor(Function(model) model.FromAddress.Address2)</td></tr>
        <tr><td>City:</td><td>@Html.TextBoxFor(Function(model) model.FromAddress.City)</td></tr>
        <tr><td>State:</td><td>@Html.TextBoxFor(Function(model) model.FromAddress.State)</td></tr>
        <tr><td>Zip:</td><td>@Html.TextBoxFor(Function(model) model.FromAddress.Zip)</td></tr>
        <tr><td colspan=2><b>To Address:</b></td></tr>
        <tr><td>Name:</td><td>@Html.TextBoxFor(Function(model) model.ToAddress.Name)</td></tr>
        <tr><td>Address:</td><td>@Html.TextBoxFor(Function(model) model.ToAddress.Address1)</td></tr>
        <tr><td>&nbsp;</td><td>@Html.TextBoxFor(Function(model) model.ToAddress.Address2)</td></tr>
        <tr><td>City:</td><td>@Html.TextBoxFor(Function(model) model.ToAddress.City)</td></tr>
        <tr><td>State:</td><td>@Html.TextBoxFor(Function(model) model.ToAddress.State)</td></tr>
        <tr><td>Zip:</td><td>@Html.TextBoxFor(Function(model) model.ToAddress.Zip)</td></tr>
        <tr><td colspan=2 align=center><input id="btnCreateEnvelope" type="submit" value="Create Envelope" /></td></tr>
    </table>
</form>