Imports System.IO
Imports System.Text.RegularExpressions
Imports Microsoft.Extensions.Configuration

Public Class Util
    Friend Shared DynamicPDFConfiguration As IConfiguration

    Shared Sub New()
        Dim builder = New ConfigurationBuilder()
        builder.SetBasePath(Directory.GetCurrentDirectory())
        builder.AddJsonFile("appsettings.json", False, True)
        DynamicPDFConfiguration = builder.Build()
    End Sub

    ' This is a helper function to get a full path to a file in the Resources folder.
    Friend Shared Function GetResourcePath(ByVal inputFileName As String) As String

        Dim exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        Dim appPathMatcher As Regex = New Regex("(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)")
        Dim appRoot = appPathMatcher.Match(exePath).Value
        Return System.IO.Path.Combine(appRoot, "Resources", inputFileName)

    End Function
End Class