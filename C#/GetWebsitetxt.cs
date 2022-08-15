using System;

public class Program
{
    public static void Main()
    {
        //Get the information
        System.Net.WebClient wc = new System.Net.WebClient();
        byte[] raw = wc.DownloadData("http://fabiangranig.at/info.txt");

        //Convert in an string
        string webData = System.Text.Encoding.UTF8.GetString(raw);

        //Output the webData
        Console.WriteLine(webData);
    }
}
