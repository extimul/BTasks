namespace Task9;

public class TaskClass
{
    public delegate void MessageHandler(string message);

    public void Task1()
    {
        MessageHandler messageHandler = delegate(string message)
        {
            Console.WriteLine(message);
        };
        
        messageHandler.Invoke("HelloWorld!");
    }

    public void Task2()
    {
        ShowMessage("HelloWorld", delegate(string message)
        {
            Console.WriteLine(message);
        });
    }

    private void ShowMessage(string message, MessageHandler messageHandler)
    {
        messageHandler.Invoke(message);
    }
}