
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <link rel="stylesheet" href="~/Content/DynamicPDF.css" type="text/css" />
    <title>@ViewBag.Title</title>
    @*<title>_DynamicPDFLayout</title>*@
</head>
<body>
    <div>
        <div id="banner">
            <img src="~/Images/DynamicPDF_top.gif" align="right"><img src="~/Images/ceTeSoftware_top.gif">
            <div id="header"> &nbsp;</div>
            <h1><i>Dynamic</i><b>PDF</b> CoreSuite v10.x for .NET Examples</h1>
        </div>
        <div id="content">
            @RenderBody()
        </div>
    </div>
</body>
</html>
