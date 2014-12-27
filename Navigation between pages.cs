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
