Imports System.Data

Partial Class Dossier

End Class

Namespace DossierTableAdapters
    Partial Public Class BrandingTableAdapter
        Private ReadOnly _comboProp As New List(Of SuppCode)
        Private Sub SnagProperties()
            Using dt As DataTable = Me.GetCombo
                For Each rw In dt.Rows
                    _comboProp.Add(New SuppCode(rw("CID"), rw("Supplier")))
                Next
            End Using
        End Sub
        Public ReadOnly Property ComboProp As IEnumerable
            Get
                If _comboProp.Count = 0 Then
                    SnagProperties()
                End If
                Dim ien As IEnumerable(Of SuppCode) = _comboProp
                Return ien
            End Get
        End Property

        Private Class SuppCode
            Private ReadOnly _cid As Integer
            Private ReadOnly _supp As String
            Sub New(cid As Integer, supp As String)
                _cid = cid
                _supp = supp
            End Sub
            Public ReadOnly Property CID As Integer
                Get
                    Return _cid
                End Get
            End Property
            Public ReadOnly Property Supplier As String
                Get
                    Return _supp
                End Get
            End Property
        End Class




    End Class
End Namespace
