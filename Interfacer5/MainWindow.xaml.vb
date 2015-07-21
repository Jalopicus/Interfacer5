Imports Interfacer5.Application
Class MainWindow
    Private Sub Wind0w_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded
    End Sub
    Private Sub backButton_Click(sender As Object, e As RoutedEventArgs) Handles Back.Click
        If Product_LogViewSource.View.CurrentPosition > 0 Then
            Product_LogViewSource.View.MoveCurrentToPrevious()
        End If
    End Sub
    Private Sub nextButton_Click(sender As Object, e As RoutedEventArgs) Handles Forward.Click
        If Product_LogViewSource.View.CurrentPosition < CType(Product_LogViewSource.View, CollectionView).Count - 1 Then
            Product_LogViewSource.View.MoveCurrentToNext()
        End If
    End Sub
    Private Sub saveButton_Click(sender As Object, e As RoutedEventArgs) Handles Save.Click
        DossierProduct_LogTableAdapter.Update(Application.Dossier.Product_Log)
    End Sub
    Private Sub Health_Expanded(sender As Object, e As RoutedEventArgs) Handles Health.Expanded
        Physical.IsExpanded = False
        Environmental.IsExpanded = False
    End Sub
    Private Sub Physical_Expanded(sender As Object, e As RoutedEventArgs) Handles Physical.Expanded
        Health.IsExpanded = False
        Environmental.IsExpanded = False
    End Sub
    Private Sub Environmental_Expanded(sender As Object, e As RoutedEventArgs) Handles Environmental.Expanded
        Physical.IsExpanded = False
        Health.IsExpanded = False
    End Sub
    Private Sub toolBar_Loaded(sender As Object, e As RoutedEventArgs) Handles toolBar.Loaded
        Dim tb As ToolBar = CType(sender, ToolBar)
        Dim fe As FrameworkElement = tb.Template.FindName("OverflowGrid", toolBar)
        If Not IsNothing(fe) Then
            fe.Visibility = Visibility.Collapsed
        End If
    End Sub
End Class

