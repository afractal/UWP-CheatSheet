// The Rss feed in Xml
<?xml version="1.0"?>

<rss version="2.0">
  <channel>
    <title>Roux Academy 2012 Art Conference</title>
    <description>Featured Artists</description>
    <link>http://www.rouxacademy.org</link>
    <item>
      <title>Barot Bellingham</title>
      <link>Barot_Bellingham.jpg</link>
      <description>Barot has just finished his final year at The Royal Academy of Painting and Sculpture, 
      where he excelled in glass etching paintings and portraiture. 
      Hailed as one of the most diverse artists of his generation, 
      Barot is equally as skilled with watercolors as he is with oils.
      </description>
    </item>
    <item>
      <title>Jonathan G. Ferrar II</title>
      <link>Jonathan_Ferrar.jpg</link>
      <description>Labeled as The Artist to Watch in 2012 by the London Review,
      Johnathan has already sold one of the highest priced 
      commissions paid to an art student, ever on record. 
      The piece, entitled Gratitude Resort, a work in oil and mixed media, was sold for $750,000.
      </description>
    </item>
..... etc

// For the above feed we need to create three classes ArtistiItem, ArtistData and ArtistDataSource

class ArtistItem
{
    public string ArtistName { get; set; }
    public string ArtistPhoto { get; set; }
    public string ArtworkPhoto { get; set; }
    public string Biography { get; set; }
}

class ArtistData
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
    private List<ArtistItem> _artistList = new List<ArtistItem>();
    public List<ArtistItem> Items
    {
        get { return _artistList; }
        set { _artistList = value; }
    }
}

class ArtistDataSource
{
    private string BaseURIString = "http://datafeeds.rouxacademy.com/rss/";
    private ArtistData _artistData;
    public ArtistData Data
    {
        get { return _artistData; }
        set { _artistData = value; }
    }
    
    public async Task<ArtistData> GetFeedAsync()
    {
        string feedURIString = BaseURIString + "artists.xml";
        Uri feedUri = new Uri(feedURIString);
        _artistData = new ArtistData();
        try
        {
            var client = new SyndicationClient();
            var feed = await client.RetrieveFeedAsync(feedUri);
            _artistData.Title = feed.Title.Text;
            _artistData.Subtitle = feed.Subtitle.Text;
            foreach (var item in feed.Items)
            {
                ArtistItem _artistItem = new ArtistItem();
                _artistItem.ArtistName = item.Title.Text;
                _artistItem.Biography = item.Summary.Text;
                _artistItem.ArtistPhoto = BaseURIString
                    + "images/artistsSmall/" + item.Links[0].NodeValue;
                _artistItem.ArtworkPhoto = BaseURIString
                    + "images/artwoksSmall/" + item.Links[0].NodeValue;
                _artistData.Items.Add(_artistItem);
            }
        }
        catch(Exception ex)
        {
            Debug.WriteLine("error eccured:" + ex.Message);
        }
        return _artistData;
    }
}// class ends here


// after we created those classes our job is almost done
// write this method in the MainPage.xaml.cs

private async void RetrieveData()
{
    ArtistDataSource _dataSource = new ArtistDataSource();
    await _dataSource.GetFeedAsync();
    this.DataContext = _dataSource.Data;
}
