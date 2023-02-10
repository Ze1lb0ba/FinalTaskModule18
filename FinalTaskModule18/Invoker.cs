class Invoker
{
    IComand comand;

    public Invoker() { }

    public void SetComand(IComand com)
    {
        comand = com;
    }

    public void IfDownLoadInput()
    {
        comand.DownLoadVideo();
    }

    public void IfDescriptionInput()
    {
        comand.ShowDescription();
    }
}
