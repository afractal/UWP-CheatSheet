// Do it only if you are interested in performance not on designing

// Fire when item is realized 

<ListView ItemTemplate="{StaticResource SampleDataTemplate}"
    ContainerContentChanging="IncrementalUpdateHandler">

// Items can be rendered in phases
 // Phase Priorities
        // 1. Simple Shapes(Placeholder visuals)
        // 2. Key text (title)
        // 3. Other text (subtitle)
        // 4. Images
        
// performance tip 
// do not use visibility but use Opacity
private void IncrementalUpdateHandler(ListViewBase sender, ContainerContentChangingEventArgs args)
{
    args.Handled = true;

    if (args.Phase != 0)
    {
        throw new Exception("Not in phase 0.");
    }

    // First, show the items' placeholders.
    var templateRoot = (StackPanel)args.ItemContainer.ContentTemplateRoot;
    var titleTextBlock = (TextBlock)templateRoot.FindName("textTitle");
    var pubDateTextBlock = (TextBlock)templateRoot.FindName("textPubDate");

    // Make everything else invisible.
    titleTextBlock.Opacity = 0;
    pubDateTextBlock.Opacity = 0;

    // Show the items' titles in the next phase.
    args.RegisterUpdateCallback(ShowText);
}

private void ShowText(ListViewBase sender, ContainerContentChangingEventArgs args)
{
    if (args.Phase != 1)
    {
        throw new Exception("Not in phase 1.");
    }

    // Next, show the items' titles. Keep everything else invisible.
    var myItem = (FeedDataItem)args.Item;
    SelectorItem itemContainer = (SelectorItem)args.ItemContainer;
    var templateRoot = (StackPanel)itemContainer.ContentTemplateRoot;
    var titleTextBlock = (TextBlock)templateRoot.FindName("textTitle");

    titleTextBlock.Text = myItem.Title;
    titleTextBlock.Opacity = 1;

    // Show the items' subtitles in the next phase.
    args.RegisterUpdateCallback(ShowPubDate);
}

private void ShowPubDate(ListViewBase sender, ContainerContentChangingEventArgs args)
{
    if (args.Phase != 2)
    {
        throw new Exception("Not in phase 2.");
    }

    // Next, show the items' subtitles. Keep everything else invisible.
    var myItem = (FeedDataItem)args.Item;
    SelectorItem itemContainer = (SelectorItem)args.ItemContainer;

    var templateRoot = (StackPanel)itemContainer.ContentTemplateRoot;
    var pudDateText = (TextBlock)templateRoot.FindName("textPubDate");

    pudDateText.Text = myItem.PubDate.ToString();
    pudDateText.Opacity = 1;

    // Show the items' descriptions in the next phase.
    args.RegisterUpdateCallback(ShowImage);
}

private void ShowImage(ListViewBase sender, ContainerContentChangingEventArgs args)
{
    if (args.Phase != 3)
    {
        throw new Exception("Not in phase 3.");
    }

    // Finally, show the items' descriptions. 
    var myItem = (FeedDataItem)args.Item;
    SelectorItem itemContainer = (SelectorItem)args.ItemContainer;

    var templateRoot = (StackPanel)itemContainer.ContentTemplateRoot;
    var picture = (Image)templateRoot.FindName("picture");

    var bitImage = new BitmapImage();
    bitImage.UriSource = myItem.ImageLink;

    picture.Source = bitImage;
    picture.Opacity = 1;

    // Make the placeholder rectangle invisible.
}
.....
// Repeat another phase if you want to
