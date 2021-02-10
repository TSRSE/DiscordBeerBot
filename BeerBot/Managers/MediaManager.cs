using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BeerBot_1
{
    public class MediaManager
    {
        public void GetInfoFromFile(string path, List<Media> CurrentMedia)
        {
            string[] MediaInfoLines = File.ReadAllLines(path);
            foreach (var item in MediaInfoLines)
            {
                string[] CurrentLineData = item.Split('|');
                try
                {
                    string a, b, e;
                    double c;
                    int d;
                    a = CurrentLineData[0];
                    b = CurrentLineData[1];
                    c = double.Parse(CurrentLineData[2]);
                    d = int.Parse(CurrentLineData[3]);
                    e = CurrentLineData[4];

                    Media m = new Media(CurrentLineData[0], CurrentLineData[1], double.Parse(CurrentLineData[2]), int.Parse(CurrentLineData[3]), CurrentLineData[4]);
                    a = "wwwwwwwwwww";
                    CurrentMedia.Add(new Media(CurrentLineData[0], CurrentLineData[1], double.Parse(CurrentLineData[2]), int.Parse(CurrentLineData[3]), CurrentLineData[4]));
                }
                catch { Console.WriteLine("Whoooops!"); }
            }
        }
    }
}