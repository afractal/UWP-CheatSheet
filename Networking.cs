//---> Background transfers

//Download File Example
//1 of 2

async void DownloadFile(Uri sourceUri, string destFilename)
{
  cts = new CancellationTokenSource();
  StorageFile destinationFile = await KnownFolders.Pictures.CreateFileAsync(
                    destFilename, CreationCollisionOption.GenerateUniqueName);
  BackgroundDownloader downloader = new BackgroundDownloader();
  DownloadOperation download = downloader.CreateDownload(sourceUri, destinationFile);

  try
  {
    Progress<DownloadOperation> progressCallBack = new Progress<DownloadOperation>(DownloadProgress);
    // Start the download and attach a progress handler.
    await download.StartAsync().AsTask(cts.Token, progressCallback);
  }
  catch(TaskCanceledException){ // User cancelled the transfer}
  catch(Exception ex) { }
}

//2 of 2

private void CancelAll_Click(object senderm RoutedEventArgs e)
{
  cts.Cancel();
  cts.Dispose();
  cts = new CancellationTokenSource(); // Re-create the cancellationTokenSource for future downloads.
}

private void DownloadProgress(DownloadOperation download)
{
  double percent = 100;
  if(download.Progress.TotalBytesToReceive >0)
     percent = download.Progress.BytesReceived * 100 / download.Progress.TotalBytesToReceive;
  if(download.Progress.HasRestarted)
  { /* Download restarded /};
  if(download.Progress.HasResponseChanged) // We're received new response headers from the server.
     Debug.WriteLine(" - Response updated; Header count:" + download.GetResponseInformation().Headers.Count);
}


//---> Http Client

// Simple example: Get a string

try
{
  // Create the HttpClient
  HttpClient httpClient = new HttpClient;

  // Optionally, define HTTP headers
  httpClient.DefaultRequesteHeaders.Accept.TryParseAdd("application/json");

  // Make the call
  string responseText = await httpClient.GetStringAsync(
         new Uri("http://services.Odata.org/Northwind/Northwind.svc/Supplies"));
}
catch(Exception ex)
{
  // ...
}


//---> Get full response

try
{
  var client = new HttpClient(9;
  var uri = new Uri("http://example.com/customers/1");
  var response = await client.GetAsync(uri);

  // code and results
  var statusCode = response.StatusCode;
  // EnsureSuccesStatusCode throws exception if not HTTP 200
  response.EnsureSuccessStatusCode();
  var responseText = await response.Content.ReadAsStringAsync();
}
catch(Exception ex)
{
  // ...
}

// HttpClient 
// If you want response codes, headers and other information, use GetAsync instead of GetStringAsync


//---> Reading response headers

try
{
  var client = new HttpClient();
  var uri = new Uri("http://example.com/customers/1");
  var response = await client.GetAsync(uri);
 
  // display headers
  foreach (var header in response.Headers)
  {
    HeadersText.Text += header.Key + "=" + header.Value + "\n";
  }
  
  ResultsText.Text = await response.Content.ReadAsStringAsync();
}
catch(Exception ex)
{ }


//---> Writing request headers

var client = new HttpClient();
// set some headers
var headers = client.DefaultRequestHeaders;
headers.Referer = new Uri("http://contoso.com");
var ok = headers.UserAgent.TryParseAdd("teestprogram/1.0");

// make the request
var response = await client.GetAync(uri);
// get response content length
var length = response.Content.Headers.ContentLength.Value;
byte[] buffer = new byte[length];

// Headers
// Strongly typed headers make setting and getting values simple and safe.
// Use the TryParseAdd method to receive a bool on failure rather than an exception


// Using HttpBaseProtocolFilter

//For compression, credentials etc

HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
// When AutomaticDecompression is true(the default), the Accept-Encoding header is added
// to the headers and set to allow gzip and compress
filter.AutomaticDecompression = true;

PasswordCredential creds = new PasswordCredential("JumpStart", userNAme, password);
filter.ServerCredential = creds;
filter.ProxyCredential = creds;


// Create the HttpClient
HttpClient httpClient = new HttpClient(filter);

// Make the call
string responseText = await httpClient.getStringAsync(uri);
// ...

