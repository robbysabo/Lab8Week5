using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace Lab8Week5;

public class MyColors
{
    public string color {  get; set; }
    public string value { get; set; }
}

public partial class MainPage : ContentPage
{
    public List<MyColors> MyColor = new();
    private string contentUri = "http://localhost/myColors.json";

    public MainPage()
    {
        InitializeComponent();
        ShowJson();
    }

    public async void ShowJson()
    {

        var _client = new HttpClient();

        var jsonRes = await _client.GetFromJsonAsync<List<MyColors>>(contentUri);
        jsonRes.ForEach(s =>  MyColor.Add(s));

        string buildText = "";

        foreach (MyColors c in MyColor)
        {
            buildText += c.color;
            buildText += ": " + c.value + "\n";
        }

        JsonText.Text = buildText;
    }
}
