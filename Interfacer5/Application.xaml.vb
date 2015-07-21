Imports System.Globalization
Class Application
    Public Shared Dossier As Interfacer5.Dossier
    Public Shared Product_LogViewSource As System.Windows.Data.CollectionViewSource
    Public Shared DossierProduct_LogTableAdapter As Interfacer5.DossierTableAdapters.Product_LogTableAdapter
    Public Shared DossierBrandingTableAdapter As Interfacer5.DossierTableAdapters.BrandingTableAdapter
    Public Sub New()

    End Sub

    Private Sub Application_LoadCompleted(sender As Object, e As NavigationEventArgs) Handles Me.LoadCompleted
        Dossier = CType(Me.FindResource("Dossier"), Interfacer5.Dossier)
        Product_LogViewSource = CType(Me.FindResource("Product_LogViewSource"), System.Windows.Data.CollectionViewSource)
        DossierProduct_LogTableAdapter = New Interfacer5.DossierTableAdapters.Product_LogTableAdapter()
        'DossierProduct_LogTableAdapter.Fill(Dossier.Product_Log)
        DossierProduct_LogTableAdapter.FillByBigDance(Dossier.Product_Log)
        DossierBrandingTableAdapter = New Interfacer5.DossierTableAdapters.BrandingTableAdapter
        ' DossierBrandingTableAdapter.Fill(Dossier.Branding)
        Product_LogViewSource.View.MoveCurrentToFirst()
    End Sub
    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

End Class
Public Class MultiplyConverter
    Implements IMultiValueConverter
    Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
        Dim result As Double = 1.0
        For i As Integer = 0 To values.Length - 1
            If TypeOf values(i) Is Double Then
                result *= CDbl(values(i))
            End If
        Next
        Return result
    End Function

    Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class