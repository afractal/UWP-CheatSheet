// the value converter is used to convert from a source(bool) to a target(Visibility) and vice versa

// use this converter for example when converting a Fill property of an Rectangle 
// and display it on a tooptip 
// for the above example the result is an hexdecimal value wrapped as an String

//--> BrushToStringConverter
public sealed class BrushToStringConverter : IValueConverter
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
public sealed class BooleanToVisibilityConverter : IValueConverter
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


// Custom class implements the IValueConverter interface.
// DateToStringConverter
public class DateToStringConverter : IValueConverter
{
    // Define the Convert method to change a DateTime object to 
    // a month string.
    public object Convert(object value, Type targetType, 
        object parameter, string language)
    {
        // value is the data from the source object.
        DateTime thisdate = (DateTime)value;
        int monthnum = thisdate.Month;
        string month;
        switch (monthnum)
        {
            case 1:
                month = "January";
                break;
            case 2:
                month = "February";
                break;
            default:
                month = "Month not found";
                break;
        }
        // Return the value to pass to the target.
        return month;

    }

    // ConvertBack is not implemented for a OneWay binding.
    public object ConvertBack(object value, Type targetType, 
        object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
