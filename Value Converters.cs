// use this converter for example when converting a Fill property of an Rectangle 
// and display it on a tooptip 
// for the above example the result is an hexdecimal value wrapped as an String

class BrushToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return value is Brush ? String.Format("{0}", ((SolidColorBrush)value).Color.ToString()) : String.Format("{0}", "lol");
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
