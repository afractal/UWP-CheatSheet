// Application ca execute logic to navigate back to precending page
// Navigating back by using a button click event

private void btnGoBack_Click(object sender, RoutedEventArgs e)
{
    if(this.Frame.CanGoBack)
        this.Frame.GoBack();
}
