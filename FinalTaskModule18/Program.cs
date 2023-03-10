using AngleSharp.Html.Dom;
using System.Xml.Linq;
using YoutubeExplode.Converter;

internal class Program
{
    private static void Main(string[] args)
    {
        UserData userData = new UserData();
        Setting setting = new Setting();

        userData.userURLs = EnterDataByUser.URLSet();
        userData.UserSelect = EnterDataByUser.UserSelectInput();

        Invoker invok = new Invoker();
        Resiver resiver = new Resiver(setting, userData);
        invok.SetComand(new DownLoadComand(resiver));

        switch (userData.UserSelect)
        {
            case 2: 
                invok.IfDownLoadInput();
                break;
            case 1:
                invok.IfDescriptionInput();
                break;
            case 3:
                invok.IfDownLoadAudioInput();
                break;
        }
        Console.ReadKey();
    }
}   
