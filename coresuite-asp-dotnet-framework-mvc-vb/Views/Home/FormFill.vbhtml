@ModelType coresuite_asp_dotnet_framework_mvc_vb.Models.W9FormModel
@Code
    ViewData("Title") = "FormFill"
    Layout = "~/Views/Shared/_DynamicPDFLayout.vbhtml"
End Code

<h2>Form Fill Example</h2>

<form id="FormFill" action="FormFillW9" method="post">
    <h3>2014 W-9 Form Fill</h3>
    <table border=0>
        <tr><td>Name:</td><td>@Html.TextBoxFor(Function(model) model.Name)</td></tr>
        <tr><td>Business Name:</td><td>@Html.TextBoxFor(Function(model) model.BusinessName)</td></tr>
        <tr>
            <td>Business Type:</td>
            <td>
                @Code
                    For Each value In System.Enum.GetValues(GetType(coresuite_asp_dotnet_framework_mvc_vb.Models.BusinessType))
                        @Html.RadioButtonFor(Function(modal) modal.BusinessType, value)
                        @Html.Label(value.ToString())
                End code
                <br />
                @Code
                    Next
                End code
                <table style="border:0">
                    <tr>
                        <td style="width:50%;border:0">
                            Other:
                        </td>
                        <td style="border:0">
                            @Html.TextBoxFor(Function(model) model.OtherBusinessType)
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50%;border:0">
                            Enter the tax classification:
                        </td>
                        <td style="border:0">
                            @Html.TextBoxFor(Function(model) model.TaxClassification)
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr><td>Address (number, street, and apt. or suite no.):</td><td>@Html.TextBoxFor(Function(model) model.Address)</td></tr>
        <tr><td>City, state and ZIP code:</td><td>@Html.TextBoxFor(Function(model) model.CityState)</td></tr>
        <tr><td>Requester's name and address (optional):</td><td>@Html.TextBoxFor(Function(model) model.RequestersNameAndAddress)</td></tr>
        <tr><td>List account number(s) here (optional):</td><td>@Html.TextBoxFor(Function(model) model.AccountNumbers)</td></tr>
        <tr><td>Social security number:</td><td>@Html.TextBoxFor(Function(model) model.SSN)</td></tr>
        <tr><td colspan=2 align=center><b>Or</b></td></tr>
        <tr><td>Employer identification number:</td><td>@Html.TextBoxFor(Function(model) model.EmployersID)</td></tr>
        <tr><td colspan=2 align=center><input id="btnAcroFill" type="submit" value="Create W9" /></td></tr>
    </table>
</form>