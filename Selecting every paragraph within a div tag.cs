private async void Parsing(string website)
{
    try
    {
        HttpClient http = new HttpClient();
        var response = await http.GetByteArrayAsync(website);
        String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
        source = WebUtility.HtmlDecode(source);

        string str = "";

        var document = new HtmlDocument();
        document.LoadHtml(source);

        var div = document.GetElementbyId("main-content");
        var paragraphs = div.ChildNodes.Where(item => item.Name == "p");

        foreach (var item in paragraphs)
        {
            str += item.InnerText;
        }

        fullDescription.Text = str;

    }
    catch (Exception)
    {
        new MessageDialog("loxl l lfdllfòlefklserkfls").ShowAsync();
    }

}
