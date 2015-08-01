'This is the controller or the viewmodel or some crazy 
'shit that doesn't matter. This does work.
Imports System.Data
Imports System.Collections.ObjectModel
Partial Class Dossier


End Class
Namespace DossierTableAdapters
    ''' <summary>
    ''' Mammal toxicity table
    ''' </summary>
    Partial Public Class Acute_ToxicityTableAdapter
    End Class
    ''' <summary>
    ''' Fish toxicity table
    ''' </summary>
    Partial Public Class Aquatic_ToxicityTableAdapter
    End Class
    ''' <summary>
    ''' SDS Details with fields that are candidate for preset
    ''' </summary>
    Partial Public Class Safety_DanceTableAdapter
        'who fucking knows
    End Class
    'DEFAULTS IS THE FUCKING PRESET BANK NOT THE FUCKING LEXICON
    Partial Public Class DefaultsTableAdapter
        Private _presetNames
        Sub fart()
            Using dt As Dossier.DefaultsDataTable = GetData()
                For Each rw In dt.Rows
                    _presetNames.Add(rw.item("Preset"))
                Next
            End Using
        End Sub
        Public ReadOnly Property PresetNames As Collection(Of String)
            Get
                Return _presetNames
            End Get
        End Property


    End Class

    ''' <summary>
    '''     Presets for individual fields
    ''' </summary>
    Partial Public Class Safety_LexiconTableAdapter
        ''' <summary>
        ''' Returns a single preset string
        ''' </summary>
        ''' <param name="who">Name of the parameter</param>
        ''' <param name="which">Index of preset</param>
        ''' <returns></returns>
        Public Function RetPreset(who As String, which As Integer) As String
            Dim Cntnts As New ColContents(who)
            Dim ret As String = ""
            Dim retnum As Integer = which
            Select Case which
                Case which > Cntnts.CountOf - 1
                    retnum = 0
                Case which < 0
                    retnum = Cntnts.CountOf - 1
                Case Else
                    ret = "Something has gone terribly wrong."
            End Select
            If ret = "" Then
                ret = Cntnts.ValOf(retnum)
            End If
            Return ret
        End Function
        ''' <summary>
        ''' Extracts single column from the datatable and removes blanks
        ''' </summary>
        Partial Public Class ColContents
            Inherits Safety_LexiconTableAdapter
            Private _values As New List(Of String)
            Sub New(who As String)
                Using dt = GetData()
                    For Each rw In dt.Rows
                        _values.Add(rw.item(who))
                    Next
                End Using
                _values.Remove("")
            End Sub
            ''' <summary>
            ''' Number of valid presets
            ''' </summary>
            ''' <returns></returns>
            Public ReadOnly Property CountOf
                Get
                    Return _values.Count
                End Get
            End Property
            ''' <summary>
            ''' Value of specified index
            ''' </summary>
            ''' <param name="which">Index to return</param>
            ''' <returns></returns>
            Public ReadOnly Property ValOf(which As Integer)
                Get
                    Return _values(which)
                End Get
            End Property
        End Class
    End Class
    ''' <summary>
    ''' Tier 1 of the UN prescribed hazard language
    ''' </summary>
    Partial Class Hazard_LexiconTableAdapter
        Private ReadOnly _health As New Collection(Of HazCode)
        Private ReadOnly _phys As New Collection(Of HazCode)
        Private ReadOnly _environ As New Collection(Of HazCode)
        Private ReadOnly _okGo As Boolean = SnagProperties()
        ''' <summary>
        ''' Fills the listboxes of classifs
        ''' </summary>
        ''' <returns></returns>
        Function SnagProperties() As Boolean
            Using dt As Dossier.Hazard_LexiconDataTable = Me.GetData
                For Each rw In dt.Rows
                    Select Case rw.typecrypt
                        Case 1, 9
                            _phys.Add(New HazCode(rw("ID"), rw("Haz_listbox"), rw("Hazard_statement")))
                        Case 2
                            _health.Add(New HazCode(rw("ID"), rw("Haz_listbox"), rw("Hazard_statement")))
                        Case 4
                            _environ.Add(New HazCode(rw("ID"), rw("Haz_listbox"), rw("Hazard_statement")))
                        Case Else
                            Throw New ArgumentException("Something has gone terribly wrong.")
                    End Select
                Next
            End Using
            Return True
        End Function
        Public ReadOnly Property HealthLBL As Collection(Of HazCode)
            Get
                If _health.Count = 0 Then
                    SnagProperties()
                End If
                Return _health
            End Get
        End Property
        Public ReadOnly Property PhysLBL As Collection(Of HazCode)
            Get
                If _phys.Count = 0 Then
                    SnagProperties()
                End If
                Return _phys
            End Get
        End Property
        Public ReadOnly Property EnvironLBL As Collection(Of HazCode)
            Get
                If _environ.Count = 0 Then
                    SnagProperties()
                End If
                Return _environ
            End Get
        End Property
        Class HazCode
            Private ReadOnly _id As Integer
            Private ReadOnly _disp As String
            Private ReadOnly _tooltip As String
            Sub New(id As Integer, disp As String, tip As String)
                _id = id
                _disp = disp
                _tooltip = tip
            End Sub
            Public ReadOnly Property ID As Integer
                Get
                    Return _id
                End Get
            End Property
            Public ReadOnly Property DisplayValue As String
                Get
                    Return _disp
                End Get
            End Property
            Public ReadOnly Property ToolTip As String
                Get
                    Return _tooltip
                End Get
            End Property
        End Class
    End Class
    ''' <summary>
    ''' Returns details of property branding
    ''' </summary>
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
    ''' <summary>
    ''' Bridge of main dataset and classification splay
    ''' </summary>
    Partial Public Class ClassificationsTableAdapter
        Public Sub okGo(ByVal pid As Integer, ByVal keyy As Integer)
            Using dt As DataTable = Me.GetByPIDkeyy(pid, keyy)
                For Each dr In dt.Rows
                    dt.Rows.Remove(dr)
                Next
            End Using
        End Sub
        Public ReadOnly Property GetClassifKeyys(pid As Integer)
            Get
                Using dt = Me.GetByPID(pid)
                    GetClassifKeyys = dt.Select(Function(x) CStr(x.Keyy)).ToList
                End Using
            End Get
        End Property
    End Class
    ''' <summary>
    ''' Bank of components and component-specific properties
    ''' </summary>
    Partial Public Class ComponentsTableAdapter
        Public ReadOnly Property CompPool As IEnumerable
            Get
                Dim ien As IEnumerable(Of String)
                Using dt As DataTable = GetData()
                    ien = dt.AsEnumerable().[Select](Function(x) x.Field(Of String)("Substance")).Distinct.ToList
                    Return ien
                End Using
                Return ien
            End Get
        End Property
    End Class

End Namespace
