Imports coresuite_asp_dotnet_framework_mvc_vb.Models
Imports System
Imports System.Collections.Generic
Imports System.Web.Mvc

Namespace coresuite_asp_dotnet_framework_mvc_vb.Controllers
    Public Class HomeController
        Inherits Controller

        ' GET Home
        Public Function Index() As ActionResult
            Return View()
        End Function
        Public Function Invoice() As ActionResult
            Return View()
        End Function

        Public Function MergerInvoice() As ActionResult
            Return View()
        End Function
        Public Function SelectPages() As ActionResult
            Return View()
        End Function

        Public Function AcroFormFill() As ActionResult
            Dim w9 As W9FormModel = New W9FormModel()
            Return View(w9)
        End Function

        Public Function USEnvelope() As ActionResult
            Dim envelope As EnvelopeModel = New EnvelopeModel()
            Return View(envelope)
        End Function
        Public Function FormFill() As ActionResult
            Dim w9 As W9FormModel = New W9FormModel()
            Return View(w9)
        End Function

        Public Function TextExtraction() As ActionResult
            Return View()
        End Function

        Public Function ExtractText() As ActionResult
            Return Content(CodeFiles.ExtractText.Run())
        End Function

        Public Function CreateInvoice(ByVal collection As FormCollection) As ActionResult
            Dim selected As List(Of String) = New List(Of String)()

            For Each key As String In collection.AllKeys
                If collection(key).StartsWith("true") Then selected.Add(key)
            Next

            Dim pdf As Byte() = CodeFiles.Invoice.Run(selected)
            Return File(pdf, "application/pdf")
        End Function

        Public Function CreateMergerInvoice(ByVal collection As FormCollection) As ActionResult
            Dim selected As List(Of String) = New List(Of String)()

            For Each key As String In collection.AllKeys
                If collection(key).StartsWith("true") Then selected.Add(key)
            Next

            Dim pdf As Byte() = CodeFiles.Invoice.RunMerger(selected)
            Return File(pdf, "application/pdf")
        End Function

        Public Function CreateEnvelope(ByVal envelope As EnvelopeModel) As ActionResult
            Dim pdf As Byte() = CodeFiles.USEnvelope.Run(envelope)
            Return File(pdf, "application/pdf")
        End Function

        Public Function AcroFormFillW9(ByVal w9FormData As W9FormModel) As ActionResult

            Dim pdf As Byte() = CodeFiles.AcroFormFillW9.Run(w9FormData)
            Return File(pdf, "application/pdf")
        End Function

        Public Function FormFillW9(ByVal w9FormData As W9FormModel) As ActionResult
            Dim pdf As Byte() = CodeFiles.AcroFormFillW9.RunFormFill(w9FormData)
            Return File(pdf, "application/pdf")
        End Function

        Public Function SelectPages1(ByVal collection As FormCollection) As ActionResult
            Dim selected As List(Of String) = New List(Of String)()
            For Each key As String In collection.AllKeys
                If collection(key).StartsWith("true") Then selected.Add(key)
            Next

            Dim pdf As Byte() = CodeFiles.SelectPages.Run(selected)
            Return File(pdf, "application/pdf")
        End Function
    End Class
End Namespace