Imports System.ComponentModel

Public Class SafetyDance
    ' Dim dossy As Dossier = FindResource("Dossier")
    Private Sub SafetyDance_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

    End Sub
    Private Sub Swindow_Closed(sender As Object, e As EventArgs) Handles Swindow.Closed
        Swindow = Nothing
    End Sub
    Private Sub Dancer_DownPreset(sender As Object, e As RoutedEventArgs)
        Dim snd As Dancer = sender
        Dim sndP = snd.GetBindingExpression(DataContextProperty).ResolvedSourcePropertyName
        '  Me.DataContext


    End Sub
    Private Sub Dancer_UpPreset(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
