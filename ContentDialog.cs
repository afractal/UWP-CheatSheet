private asynv void ShowContentDialog()
{
    var dialog = new ContentDialog()
    {
        Title= "Download updates?",
        Content = "This update will clean teh slate fro Iron Man",
        PrimaryButtonText = "Yes, clean it",
        SecondaryButtonText = "No, Don't"
    };
    dialog.SecondaryButtonClick += dialog_SecondaryButtonClick;

    ContentDialogResult result = await dialog.ShowAsync();
    if(result == ContentDialogResult.Primary){ /*do some more Primary logic*/}  
    else if(result == ContentDialogResult.Secondary){ /* else do Secondary logic}
}

void dialog_SecondaryButtonClick()
{
    // you can also hook up to a button event handler
}
