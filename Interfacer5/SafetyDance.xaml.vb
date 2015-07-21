Public Class SafetyDance
    Private Sub SafetyDance_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

    End Sub

    Private Sub FA_SkinTextBox_GotFocus(sender As Object, e As RoutedEventArgs) Handles FA_SkinTextBox.GotFocus
        Dim df As New DocumentFrame
        Dim fart As String
        fart = df("Ingestion")
    End Sub
End Class
