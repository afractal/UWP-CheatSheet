//--> Implementing the INotifyPropertyChanged (The Non-Optimal Way)

public class ItemViewModel : INotifyPropertyChanged 
{
  private string _manufacturer;
  private string _model;
  private string _color;
  private int _year;
  
  public string manufacturer
  {
    get { return _manufacturer;}  
    set {
      _manufacturer = value;
      OnPropertyChanged("manufacturer");  }
  }  
  public string model
  {
    get { return _model; }
    set {
      _model = value;
      OnPropertyChanged("model");  }
  }  
  public string color
  {
    get { return _color; }
    set {
      _color = value;
      OnPropertyChanged("color");  }
  }  
  public int year
  {
    get { return _year;  } 
    set {
      _year = value;
      OnPropertyChanged("color");
      //or just OnPropertyChanged()
  }  
  // Property Change Logic
  public event PropertyChangedEventHandler PropertyChanged;  
  private void OnPropertyChanged([CallerMemberName]string propertyName = null)
  {      
    // you can also use PropertyChanged?.Invoke(this, new PropertyChangedEventArg(propertyName)));
    var handler = PropertyChanged;  
    if (handler != null)       
      PropertyChanged(this, new  PropertyChangedEventArgs(propertyName));  
  }
  
// class ends here  
} 


//--> Implementing the INotifyPropertyChanged (The Optimal Way)

public class ItemViewModel : BindableBase
{
  public string model
  //private string manufacturer;
  //private string color;
  //private int year;

  public string Model
  {
    get { return model; }
    set { SetProperty(ref model, value); }
  }
  
// class ends here  
}

// creating an abstract class called BindableBase is a good way to introduce MVVM pattern
[DataContract]
public abstract class BindableBase : INotifyPropertyChanged
{
  // A unique feature of anonymous methods is that you can omit the parameter declaration
  // entirely - even if the delegate expects them. This can be useful in declaring events
  // with a default empty handler.
  public event PropertyChangedEventHandler PropertyChanged = delegate { };

  protected virtual void OnPropertyChanged([CallerMemberName]string caller = null)
  {
    // you can also use PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    var handler = PropertyChanged;
    if (handler != null)
      handler(this, new PropertyChangedEventArgs(caller) );
  }

  protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
  {
    // you use the Object.Equals because you dont know the Type of T(maybe no .Equals() method)
    // if (EqualityComparer<T>.Default.Equals(storage, value)) return false;
    // this avoids boxing so use this
    if (Object.Equals(storage, value)) return false;
    storage = value;
    this.OnPropertyChanged(propertyName);
    return true;
  }
  
// class ends here  
}
