//--> Writing a complete file

// This methos will create a file from a string of text 
// All the file operations are asynchronous

private async void writeTextToLocalStorageFile(string filename, string text)
{
  // Sets the target folder
    StorageFolder fold= Windows.Storage.ApplicationData.Current.LocalFolder;
    
  //Sets action if file already exists
  Storage file= await fold.CreateFileAsync(filename,CreationCollisionOption.ReplaceExisting);
  await FileIO.WriteTextAsync(file, text);
}

//--> Reading a complete file

//  This method will read a file into a string

private async Task<string> readTextFromLocalStorage(string filename)
{
  var fold= Windows.Storage.ApplicationData.Current.LocalFolder;
  StorageFile file= await FileIO.GetTextAsync(filename);
  string result= await FileIO.ReadTextAsync(file);
  return result;
}
