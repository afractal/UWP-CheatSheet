// Navigations between pages by using a ListView item event

/// <summary>
/// Shows the details of an item clicked on in the <see cref="ItemPage"/>
/// </summary>

private void itemListView_ItemClick(object sender, ItemClickEventArgs e)
{
    // Navigate to the appropriate destination page, configuring the new page
    // by passing required information as a navigation paramenter
    var itemId= ((MyListViewItem)e.ClickedItem).UniqueId;
    Frame.Navigate(typeof(MyDetailPage), itemId);
    if (!Frame.Navigate(typeof(ItemPage), itemId))
    {
        throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
    }
}

// the most generic version is by using it with an botton click event 
// here we navigate to a new page called SecondPage by clicking the botton
// for good visual effects make sure you use Page Transitions (everybody loves eye candy)

private void Button_Click(object sender, RoutedEventArgs e)
{
    Frame.Navigate(typeof(SecondPage) );
}
