//---> Write code to work with your Mobile Service

private async System.Threading.Tasks.Task InsertToDoItem()
{
  IMobileServiceTable<TodoItem> TodoTable = App.TaskMasterDemoClient.GetTable<TodoItem>();
  
  TodoItem t = new TodoItem();
  t.Title = titleTextBox.Text;
  t.Description = descriptionTextBox.Text;
  t.DueDate = dueDatePicker.Date.ToString(9;
  t.AssignedTo = assignesToTextBox.Text;

  try
  {
    await TodoTable.InsertAsync(t);
  }   
  catch(Exception)
  { // TODO: Insert error handling code}
}

