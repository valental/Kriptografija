using System.Text.RegularExpressions;

namespace KerckhoffsPrincipleHelper.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Public Properties
        private string codedText1 = string.Empty;
        public string CodedText1
        {
            get => codedText1;
            set
            {
                codedText1 = CleanString(value);
                Properties.Settings.Default.CodedText1 = codedText1;
                Properties.Settings.Default.Save();
                OnPropertyChanged("CodedText1");
            }
        }

        private string codedText2 = string.Empty;
        public string CodedText2
        {
            get => codedText2;
            set
            {
                codedText2 = CleanString(value);
                Properties.Settings.Default.CodedText2 = codedText2;
                Properties.Settings.Default.Save();
                OnPropertyChanged("CodedText2");
            }
        }

        private string openText1 = string.Empty;
        public string OpenText1
        {
            get => openText1;
            set
            {
                openText1 = CleanString(value);
                Properties.Settings.Default.OpenText1 = openText1;
                Properties.Settings.Default.Save();
                OnPropertyChanged("OpenText1");
            }
        }

        private string openText2 = string.Empty;
        public string OpenText2
        {
            get => openText2;
            set
            {
                openText2 = CleanString(value);
                Properties.Settings.Default.OpenText2 = openText2;
                Properties.Settings.Default.Save();
                OnPropertyChanged("OpenText2");
            }
        }

        private bool isFirstEditable = true;
        public bool IsFirstEditable
        {
            get => isFirstEditable;
            set
            {
                isFirstEditable = value;
                if (isFirstEditable)
                {
                    IsSecondEditable = false;
                    OpenText1 = Decoder.GetOpenText(CodedText2, CodedText1, OpenText2);
                }
                OnPropertyChanged("IsFirstEditable");
            }
        }

        private bool isSecondEditable = false;
        public bool IsSecondEditable
        {
            get => isSecondEditable;
            set
            {
                isSecondEditable = value;
                if (isSecondEditable)
                {
                    IsFirstEditable = false;
                    OpenText2 = Decoder.GetOpenText(CodedText1, CodedText2, OpenText1);
                }
                OnPropertyChanged("IsSecondEditable");
            }
        }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            CodedText1 = Properties.Settings.Default.CodedText1 ?? CodedText1;
            CodedText2 = Properties.Settings.Default.CodedText2 ?? CodedText2;
            OpenText1 = Properties.Settings.Default.OpenText1 ?? OpenText1;
            OpenText2= Properties.Settings.Default.OpenText2 ?? OpenText2;
        }
        #endregion

        #region Methods
        private string CleanString(string value)
        {
            return Regex.Replace(value.ToUpper(), @"[^A-Z]", "");
        }
        #endregion
    }
}
