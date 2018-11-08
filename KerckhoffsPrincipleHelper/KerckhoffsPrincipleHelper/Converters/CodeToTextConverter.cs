using System;
using System.Globalization;
using System.Windows.Data;

namespace KerckhoffsPrincipleHelper.Converters
{
    public class CodeToTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string codedText1 = (string)values[0];
            string codedText2 = (string)values[1];
            string openText1 = (string)values[2];

            return Decoder.GetOpenText(codedText1, codedText2, openText1);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
