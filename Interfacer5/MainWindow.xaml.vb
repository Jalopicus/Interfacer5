Class MainWindow
    Public Shared Dossier As Interfacer5.Dossier
    Public Shared Product_LogViewSource As System.Windows.Data.CollectionViewSource
    Public Shared DossierProduct_LogTableAdapter As New DossierTableAdapters.Product_LogTableAdapter
    Public Shared ClassifTableAdapter As DossierTableAdapters.ClassificationsTableAdapter
    Public Shared CompAdapter As DossierTableAdapters.ComponentsTableAdapter
    Public Shared Swindow As SafetyDance

    Public ReadOnly Property PIDD As Integer
        Get
            Return Product_LogViewSource.View.CurrentItem.PID
        End Get
    End Property

    Public Sub New()
        'This call Is required by the designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call.
        Dossier = CType(Me.FindResource("Dossier"), Interfacer5.Dossier)
        DossierProduct_LogTableAdapter.FillByBigDance(Dossier.Product_Log)
        ClassifTableAdapter = Me.FindResource("ClassifTableAdapter")
        CompAdapter = Me.FindResource("CompTableAdapter")
        CompAdapter.Fill(Dossier.Components)
        Product_LogViewSource = CType(Me.FindResource("Product_LogViewSource"), System.Windows.Data.CollectionViewSource)
        Product_LogViewSource.View.MoveCurrentToFirst()
    End Sub
    Private Sub OpenSwindow(sender As Object, e As RoutedEventArgs) Handles SdsProfile.Click
        Swindow = New SafetyDance With {.DataContext = Product_LogViewSource, .Owner = Me.Wind0w}
        Swindow.Show()
    End Sub
    Private Sub BackButton_Click(sender As Object, e As RoutedEventArgs) Handles Back.Click
        If Product_LogViewSource.View.CurrentPosition > 0 Then
            Product_LogViewSource.View.MoveCurrentToPrevious()
        End If
    End Sub
    Private Sub NextButton_Click(sender As Object, e As RoutedEventArgs) Handles Forward.Click
        If Product_LogViewSource.View.CurrentPosition < CType(Product_LogViewSource.View, CollectionView).Count - 1 Then
            Product_LogViewSource.View.MoveCurrentToNext()
        End If
    End Sub
    Public Sub SaveButton_Click(sender As Object, e As RoutedEventArgs) Handles Save.Click
        DossierProduct_LogTableAdapter.Update(Dossier.Product_Log)
    End Sub
    Private Sub PopulateSelections(sender As Object, e As RoutedEventArgs) Handles HealthLB.Loaded, PhysLB.Loaded, EnvLB.Loaded
        Dim LB As ListBox = sender
        Dim whatkind As String = Strings.Left(LB.Items(0).id.ToString, 1)
        Dim pidd As Integer = Product_LogViewSource.View.CurrentItem.Row.PID
        Dim pop = ClassifTableAdapter.GetClassifKeyys(pidd)
        Dim found = LB.Items.Cast(Of Object).Where(Function(x) pop.Contains(x.ID)).ToList
        LB.SelectedItems.Clear()
        For Each fnd In found
            LB.SelectedItems.Add(fnd)
        Next
    End Sub
    Private Sub SyncSelections(sender As Object, e As MouseButtonEventArgs)

    End Sub
    Private Sub EnvLB_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles HealthLB.SelectionChanged, PhysLB.SelectionChanged, EnvLB.SelectionChanged
        Dim pidd = Product_LogViewSource.View.CurrentItem.Row.PID
        For Each go In e.AddedItems
            ClassifTableAdapter.InsertPIDkeyy(pidd, go.ID)
        Next
        For Each git In e.RemovedItems
            ClassifTableAdapter.DeletePIDkeyy(pidd, git.ID)
        Next
    End Sub

End Class

