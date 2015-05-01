// use this converter for example when converting a Fill property of an Rectangle 
// and display it on a tooptip 
// for the above example the result is an hexdecimal value wrapped as an String

//--> BrushToStringConverter
class BrushToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return value is Brush ? 
                String.Format("{0}", ((SolidColorBrush)value).Color.ToString()) :
                String.Format("{0}", "lol");
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}


//--> BooleanToVisibilityConverter
class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return value is Visibility && (Visibility)value == Visibility.Visible;
    }
}


//--> TextToHtmlConverter
public sealed class TextToHtmlConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is string)
        {
            return HtmlUtilities.ConvertToText(value.ToString());
        }
        else
        {
            return value;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
