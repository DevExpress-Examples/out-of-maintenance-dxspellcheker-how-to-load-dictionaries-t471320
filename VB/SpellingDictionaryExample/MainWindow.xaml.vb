#Region "#usings"
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.SpellChecker
Imports DevExpress.XtraSpellChecker
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Windows
' ...
#End Region ' #usings

Namespace SpellingDictionaryExample
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits DXWindow

        Private checker As SpellChecker

        Public Sub New()
            checker = New SpellChecker()
            DataContext = Me
            InitializeComponent()
            textEditToCheck.Text = "This help system provides a a comprehansive information on using the XtraSpellChecker prodact (http://help.devexpress.com/#WindowsForms/CustomDocument2635). " & ControlChars.CrLf & _
"It contains a detailed description of the product's API, and also provides examples with step-by-step instractions, screenshot images and source code (both, C# and Visual Basic)." & ControlChars.CrLf & _
ControlChars.CrLf & _
"El asistete realiza automáticamente las modificacines en los ficheros de configuración. Si desea realizar una instalción manual siga estas instruciones:"

            LoadOpenOfficeDictionaries()
            ' Set the default culture of the spell checker.
            'spellChecker1.Culture = new CultureInfo("en-US");
            'spellChecker1.Culture = new CultureInfo("es-ES");
            checker.Culture = CultureInfo.InvariantCulture

            ' Set as-you-type mode.
            checker.SpellCheckMode = SpellCheckMode.AsYouType

            SpellChecker = checker
        End Sub

        Public Property SpellChecker() As SpellChecker
            Get
                Return checker
            End Get
            Private Set(ByVal value As SpellChecker)
                checker = value
            End Set
        End Property

        Private Sub btnCheck_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Start checking the text within a text edit control.
            checker.Check(textEditToCheck)
        End Sub

        Private Sub LoadCustomDictionary()
'            #Region "#LoadCustomDictionary"
            Dim customDictionary As New SpellCheckerCustomDictionary()
            customDictionary.AlphabetPath = "Dictionaries\EnglishAlphabet.txt"
            customDictionary.DictionaryPath = "Dictionaries\CustomEnglish.dic"
            customDictionary.Culture = CultureInfo.InvariantCulture
            checker.Dictionaries.Add(customDictionary)
'            #End Region ' #LoadCustomDictionary
        End Sub

        Private Sub cmbDictionaryType_SelectedIndexChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            checker.SpellCheckMode = SpellCheckMode.OnDemand
            Select Case cmbDictionaryType.SelectedIndex
                Case 0
                    LoadISpellDictionaries()
                Case 1
                    LoadOpenOfficeDictionaries()
                Case 2
                    LoadHunspellDictionaries()
            End Select
            checker.SpellCheckMode = SpellCheckMode.AsYouType
        End Sub

        Private Sub LoadISpellDictionaries()
'            #Region "#LoadISpellDictionaries"
            checker.Dictionaries.Clear()

            Dim dict_en_US As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("american.xlg")
            Dim grammar_en_US As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("english.aff")
            Dim alphabet_en_US As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("nglishAlphabet.txt")

            Dim ispellDictionaryEnglish As New SpellCheckerISpellDictionary()
            ispellDictionaryEnglish.LoadFromStream(dict_en_US, grammar_en_US, alphabet_en_US)
            ispellDictionaryEnglish.Culture = New CultureInfo("en-US")
            checker.Dictionaries.Add(ispellDictionaryEnglish)
            '            #End Region ' #LoadISpellDictionaries

            Dim dict_es_ES As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("espanol.dic")
            Dim grammar_es_ES As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("espanol.aff")
            Dim alphabet_es_ES As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SpanishAlphabet.txt")

            Dim ispellDictionarySpanish As New SpellCheckerISpellDictionary()
            ispellDictionarySpanish.LoadFromStream(dict_es_ES, grammar_es_ES, alphabet_es_ES)
            ispellDictionarySpanish.Culture = New CultureInfo("es-ES")
            checker.Dictionaries.Add(ispellDictionarySpanish)

            LoadCustomDictionary()
        End Sub

        Private Sub LoadOpenOfficeDictionaries()
'            #Region "#LoadOpenOfficeDictionaries"
            checker.Dictionaries.Clear()
            Dim resources() As String = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames
            Dim dict_en_US As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("oo_en_US.dic")
            Dim grammar_en_US As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("oo_en_US.aff")
            Dim alphabet_en_US As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("EnglishAlphabet.txt")

            Dim openOfficeDictionaryEnglish As New SpellCheckerOpenOfficeDictionary()
            openOfficeDictionaryEnglish.LoadFromStream(dict_en_US, grammar_en_US, alphabet_en_US)
            openOfficeDictionaryEnglish.Culture = New CultureInfo("en-US")
             checker.Dictionaries.Add(openOfficeDictionaryEnglish)
            '            #End Region ' #LoadOpenOfficeDictionaries

            Dim dict_es_ES As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("es_ES.dic")
            Dim grammar_es_ES As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("es_ES.aff")
            Dim alphabet_es_ES As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SpanishAlphabet.txt")

            Dim openOfficeDictionarySpanish As New SpellCheckerOpenOfficeDictionary()
            openOfficeDictionarySpanish.LoadFromStream(dict_es_ES, grammar_es_ES, alphabet_es_ES)
            openOfficeDictionarySpanish.Culture = New CultureInfo("es-ES")
            checker.Dictionaries.Add(openOfficeDictionarySpanish)

            LoadCustomDictionary()
        End Sub

        Private Sub LoadHunspellDictionaries()
'            #Region "#LoadHunspellDictionaries"
            checker.Dictionaries.Clear()

            Dim dict_en_US As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("en_US.dic")
            Dim grammar_en_US As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("en_US.aff")

            Dim hunspellDictionaryEnglish As New HunspellDictionary()
            hunspellDictionaryEnglish.LoadFromStream(dict_en_US, grammar_en_US)
            hunspellDictionaryEnglish.Culture = New CultureInfo("en-US")
            checker.Dictionaries.Add(hunspellDictionaryEnglish)
            '            #End Region ' #LoadHunspellDictionaries

            Dim dict_es_ES As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("es_ANY.dic")
            Dim grammar_es_ES As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("es_ANY.aff")

            Dim openOfficeDictionarySpanish As New HunspellDictionary()
            openOfficeDictionarySpanish.LoadFromStream(dict_es_ES, grammar_es_ES)
            openOfficeDictionarySpanish.Culture = New CultureInfo("es-ES")
            checker.Dictionaries.Add(openOfficeDictionarySpanish)

            LoadCustomDictionary()
        End Sub
    End Class
End Namespace
