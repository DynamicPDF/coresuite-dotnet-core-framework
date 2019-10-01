Namespace Models

    Public Class EnvelopeModel

        Private fromAddress1 As Address = Nothing
        Private toAddress1 As Address = Nothing

        Public Property FromAddress As Address

            Get

                If fromAddress1 Is Nothing Then

                    fromAddress1 = New Address() With {.Address1 = "13071 Wainwright Road", .Address2 = "Suite 100", .City = "Columbia", .Name = "", .State = "MD", .Zip = "20777"}
                End If

                Return fromAddress1
            End Get

            Set(ByVal value As Address)

                fromAddress1 = value
            End Set

        End Property

        Public Property ToAddress As Address

            Get

                If toAddress1 Is Nothing Then

                    toAddress1 = New Address() With {.Address1 = "123 Main Street", .Address2 = "", .City = "Anywhere", .Name = "Any Company", .State = "MD", .Zip = "20815-4704"}
                End If
                Return fromAddress1
            End Get

            Set(ByVal value As Address)

                toAddress1 = value
            End Set
        End Property
    End Class
End Namespace
