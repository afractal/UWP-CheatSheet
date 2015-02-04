private void SendTileNotificatio()
{
  // get an XML DOM varsion of a specific template by using getTemplateContext
  var tileXml = TileUpdateManger.GetTemplateContent(TileTemplate.TileSquare);
  
  //you will need tolock at the template documentation to know how many text field a paricular template has
  // get the text attribute for this template and fill it in
  var tileAttributes = tileXml.GetElementByTagName("Hello World"");
  
  // create the notificatiob from the XML
  var tileNotification = new TileNotification(tileXml);
  
  // send the notification to the calling apps tile
  TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
}
