//---> Tile Terminology

// 1- Peek
// Second part of an animated tile
// 2- Block
// large number text
// 3- Image Collection
// like the people app


//---> Tile & Badge Template Smple

// Tile XML
<tile>
  <visual version="2">
    <binding template= "TileSquare150x150PeekImageAndText01">
      <image id="1" src="{image url}" alt="MyImage"/>
      <text id="1">One Sample Text</text>
      <text id="2">Two Sample Text</text>
      <text id="3">Three Sample Text</text>
      <text i="4">Four Sample Text</text>
    </binding>
    <binding>
    ....
    </binding>
  </visual>
</tile>

// Badge XML
<badge version="1" value="alert" />


//---> Tile Template Code

XmlDocument tileDoc = new XmlDocument();
tileDoc.LoadXml("<my tile XML/>");

TileNotification myNewTile = new TileNotification(tileDoc);

TileNotification myTileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
myTileUpdater.Update(myNewTile);


//--> if you wnat to update the tile using build-in templates

// is is the method that changes the image shown in the tile of the application when the user
// selectes a different item of the listview (ArtistsListView)
// xaml code is shown below
<ListView x:Name="ArtistsListView" Margin="25,0,0,0" HorizontalAlignment="Left" ItemsSource="{Binding Items
                SelectionChanged="ArtistsListView_SelectionChanged" >
....</ListView>

private void ArtistsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    var selectedArtist = ArtistsListView.SelectedItem as ArtistItem;
    XmlDocument tileXmlDoc = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Image);

    XmlNodeList xmlElementsList = tileXmlDoc.GetElementsByTagName("image");
    XmlElement xmlElement = xmlElementsList.Item(0) as XmlElement;
    xmlElement.SetAttribute("scr", selectedArtist.ArtworkPhoto);
    xmlElement.SetAttribute("alt", selectedArtist.ArtistName);
            
    TileNotification notification= new TileNotification(tileXmlDoc);
    TileUpdater updater = TileUpdateManager.CreateTileUpdaterForApplication();
    updater.Update(notification);
}
