Imports System.Globalization
Imports System.Resources
Class Application

   
    Public Shared Df As ResourceManager = ResourceManager.CreateFileBasedResourceManager("Frame", ".\Frame.resources", Nothing)
    Public Sub New()
    End Sub

    Private Sub Application_LoadCompleted(sender As Object, e As NavigationEventArgs) Handles Me.LoadCompleted
        Dim fart As Integer
        fart = 3

    End Sub

    Private Sub CloseButton_Click(sender As Object, e As RoutedEventArgs)
        Dim wd As Window = sender

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
Public Class TextBoxEmptyConverter
    Implements IMultiValueConverter
    Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
        Return CBool(Len(values(0)) = 0)
    End Function
    Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class