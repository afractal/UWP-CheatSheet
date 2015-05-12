/// <summary>
/// Used to display messages to the user
/// </summary>
/// <param name="strMessage"></param>
/// <param name="type"></param>

public void NotifyUser(string strMessage, NotifyType type)
{
    switch (type)
    {
        case NotifyType.StatusMessage:
            StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Green);
            break;
        case NotifyType.ErrorMessage:
            StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Red);
            break;
    }
    StatusBlock.Text = strMessage;
    // Collapse the StatusBlock if it has no text to conserve real estate.
    StatusBorder.Visibility = (StatusBlock.Text != String.Empty) ? Visibility.Visible : Visibility.Collapsed;
}
    
        
public enum NotifyType
{
    StatusMessage,
    ErrorMessage
};
