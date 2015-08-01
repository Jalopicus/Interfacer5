Public Class Fielder
    Public Property Cntnt As String
        Get
            Return GetValue(CntntProperty)
        End Get

        Set(ByVal value As String)
            SetValue(CntntProperty, value)
        End Set
    End Property

    Public Shared ReadOnly CntntProperty As DependencyProperty =
                           DependencyProperty.Register("Cntnt",
                           GetType(String), GetType(Fielder),
                           New PropertyMetadata(Nothing))

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
