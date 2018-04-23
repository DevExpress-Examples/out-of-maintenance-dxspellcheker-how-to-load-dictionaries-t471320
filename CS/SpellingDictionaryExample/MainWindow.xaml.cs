#region #usings
using DevExpress.Xpf.Core;
using DevExpress.Xpf.SpellChecker;
using DevExpress.XtraSpellChecker;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;
// ...
#endregion #usings

namespace SpellingDictionaryExample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow {
        SpellChecker checker;

        public MainWindow() {
            checker = new SpellChecker();
            DataContext = this;
            InitializeComponent();
            textEditToCheck.Text = @"This help system provides a a comprehansive information on using the XtraSpellChecker prodact (http://help.devexpress.com/#WindowsForms/CustomDocument2635). 
It contains a detailed description of the product's API, and also provides examples with step-by-step instractions, screenshot images and source code (both, C# and Visual Basic).

El asistete realiza automáticamente las modificacines en los ficheros de configuración. Si desea realizar una instalción manual siga estas instruciones:";

            LoadOpenOfficeDictionaries();
            // Set the default culture of the spell checker.
            //spellChecker1.Culture = new CultureInfo("en-US");
            //spellChecker1.Culture = new CultureInfo("es-ES");
            checker.Culture = CultureInfo.InvariantCulture;

            // Set as-you-type mode.
            checker.SpellCheckMode = SpellCheckMode.AsYouType;

            SpellChecker = checker;
        }

        public SpellChecker SpellChecker
        {
            get { return checker; }
            private set { checker = value; }
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e) {
            // Start checking the text within a text edit control.
            checker.Check(textEditToCheck);
        }

        private void LoadCustomDictionary() {
            #region #LoadCustomDictionary
            SpellCheckerCustomDictionary customDictionary = new SpellCheckerCustomDictionary();
            customDictionary.AlphabetPath = @"Dictionaries\EnglishAlphabet.txt";
            customDictionary.DictionaryPath = @"Dictionaries\CustomEnglish.dic";
            customDictionary.Culture = CultureInfo.InvariantCulture;
            checker.Dictionaries.Add(customDictionary);
            #endregion #LoadCustomDictionary
        }

        private void cmbDictionaryType_SelectedIndexChanged(object sender, RoutedEventArgs e) {
            checker.SpellCheckMode = SpellCheckMode.OnDemand;
            switch (cmbDictionaryType.SelectedIndex) {
                case 0:
                    LoadISpellDictionaries();
                    break;
                case 1:
                    LoadOpenOfficeDictionaries();
                    break;
                case 2:
                    LoadHunspellDictionaries();
                    break;
            }
            checker.SpellCheckMode = SpellCheckMode.AsYouType;
        }

        private void LoadISpellDictionaries() {
            #region #LoadISpellDictionaries
            checker.Dictionaries.Clear();

            Stream dict_en_US = Assembly.GetExecutingAssembly().
    GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.ISpell.en_US.american.xlg");
            Stream grammar_en_US = Assembly.GetExecutingAssembly().
                GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.ISpell.en_US.english.aff");
            Stream alphabet_en_US = Assembly.GetExecutingAssembly().
    GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.EnglishAlphabet.txt");

            SpellCheckerISpellDictionary ispellDictionaryEnglish = new SpellCheckerISpellDictionary();
            ispellDictionaryEnglish.LoadFromStream(dict_en_US, grammar_en_US, alphabet_en_US);
            ispellDictionaryEnglish.Culture = new CultureInfo("en-US");
            checker.Dictionaries.Add(ispellDictionaryEnglish);
            #endregion #LoadISpellDictionaries

            Stream dict_es_ES = Assembly.GetExecutingAssembly().
GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.ISpell.es_ES.espanol.dic");
            Stream grammar_es_ES = Assembly.GetExecutingAssembly().
                GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.ISpell.es_ES.espanol.aff");
            Stream alphabet_es_ES = Assembly.GetExecutingAssembly().
    GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.SpanishAlphabet.txt");

            SpellCheckerISpellDictionary ispellDictionarySpanish = new SpellCheckerISpellDictionary();
            ispellDictionarySpanish.LoadFromStream(dict_es_ES, grammar_es_ES, alphabet_es_ES);
            ispellDictionarySpanish.Culture = new CultureInfo("es-ES");
            checker.Dictionaries.Add(ispellDictionarySpanish);

            LoadCustomDictionary();
        }

        private void LoadOpenOfficeDictionaries() {
            #region #LoadOpenOfficeDictionaries
            checker.Dictionaries.Clear();

            Stream dict_en_US = Assembly.GetExecutingAssembly().
    GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.OpenOffice.en_US.en_US.dic");
            Stream grammar_en_US = Assembly.GetExecutingAssembly().
                GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.OpenOffice.en_US.en_US.aff");
            Stream alphabet_en_US = Assembly.GetExecutingAssembly().
    GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.EnglishAlphabet.txt");

            SpellCheckerOpenOfficeDictionary openOfficeDictionaryEnglish = new SpellCheckerOpenOfficeDictionary();
            openOfficeDictionaryEnglish.LoadFromStream(dict_en_US, grammar_en_US, alphabet_en_US);
            openOfficeDictionaryEnglish.Culture = new CultureInfo("en-US");
             checker.Dictionaries.Add(openOfficeDictionaryEnglish);
            #endregion #LoadOpenOfficeDictionaries

            Stream dict_es_ES = Assembly.GetExecutingAssembly().
GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.OpenOffice.es_ES.es_ES.dic");
            Stream grammar_es_ES = Assembly.GetExecutingAssembly().
                GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.OpenOffice.es_ES.es_ES.aff");
            Stream alphabet_es_ES = Assembly.GetExecutingAssembly().
    GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.SpanishAlphabet.txt");

            SpellCheckerOpenOfficeDictionary openOfficeDictionarySpanish = new SpellCheckerOpenOfficeDictionary();
            openOfficeDictionarySpanish.LoadFromStream(dict_es_ES, grammar_es_ES, alphabet_es_ES);
            openOfficeDictionarySpanish.Culture = new CultureInfo("es-ES");
            checker.Dictionaries.Add(openOfficeDictionarySpanish);

            LoadCustomDictionary();
        }

        private void LoadHunspellDictionaries() {
            #region #LoadHunspellDictionaries
            checker.Dictionaries.Clear();

            Stream dict_en_US = Assembly.GetExecutingAssembly().
    GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.Hunspell.en_US.en_US.dic");
            Stream grammar_en_US = Assembly.GetExecutingAssembly().
                GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.Hunspell.en_US.en_US.aff");

            HunspellDictionary hunspellDictionaryEnglish = new HunspellDictionary();
            hunspellDictionaryEnglish.LoadFromStream(dict_en_US, grammar_en_US);
            hunspellDictionaryEnglish.Culture = new CultureInfo("en-US");
            checker.Dictionaries.Add(hunspellDictionaryEnglish);
            #endregion #LoadHunspellDictionaries

            Stream dict_es_ES = Assembly.GetExecutingAssembly().
GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.Hunspell.es_ES.es_ANY.dic");
            Stream grammar_es_ES = Assembly.GetExecutingAssembly().
                GetManifestResourceStream("SpellingDictionaryExample.Dictionaries.Hunspell.es_ES.es_ANY.aff");

            HunspellDictionary openOfficeDictionarySpanish = new HunspellDictionary();
            openOfficeDictionarySpanish.LoadFromStream(dict_es_ES, grammar_es_ES);
            openOfficeDictionarySpanish.Culture = new CultureInfo("es-ES");
            checker.Dictionaries.Add(openOfficeDictionarySpanish);

            LoadCustomDictionary();
        }
    }
}
