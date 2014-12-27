//--> Using a Serializer

// This code serializes a collection of customers
using(Stream stream= await notesFolder.OpenStreamForWriteAsync(filename, CreationCollisionOption.OpenIfExists))
{
  DataContractJsonSerializer serializer= new DataContractJsonSerializer(typeof(Customers));

  serializer.WriteObject(stream, customers);
}

//-->Deserializing the data

using(Stream stream= await notesFolder.OPenStreamForReadAsync(filename))
{
  DataConstractJsonSerializer serializer= bew DataConstractJsonSerializer(typeof(Customers));

  Customers result= serializer.ReadObject(stream) as Customers;
}
// This read process is the reverse of the writing one 
// Note that we have to cast the result of ReadObject(Stream) to the required type





