using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using System.Threading.Tasks;
using System.IO;

namespace BeerBot_1
{
    class AdviseMe : BaseCommandModule
    {
        MediaManager M_mngr = new MediaManager();

        public DiscordEmbedBuilder MyEmbedCreator(string title, string descripton, string footer, string picURL)
        {
            var embed = new DiscordEmbedBuilder();
            embed.Title = title;
            embed.ImageUrl = picURL;
            embed.WithFooter(footer);
            embed.Description = descripton;
            return embed;
        }

        [Command("посоветуй")]
        public async Task AdviceToWatch(CommandContext ctx, string Name)
        {
            switch (Name)
            {
                case "аниме":
                    List<Media> Anime = new List<Media>();
                    M_mngr.GetInfoFromFile(@"GodDamnGayFolder\Anime\AnimeList.txt", Anime);
                    ////
                    //string[] MediaInfoLines = File.ReadAllLines(@"GodDamnGayFolder\Anime\AnimeList.txt");
                    //foreach (var item in MediaInfoLines)
                    //{
                    //    string[] CurrentLineData = item.Split('|');
                    //    try
                    //    {
                    //        Anime.Add(new Media(CurrentLineData[0], CurrentLineData[1], double.Parse(CurrentLineData[2]), int.Parse(CurrentLineData[3]), CurrentLineData[4]));
                    //    }
                    //    catch { Console.WriteLine("Whoooops!"); }
                    //}
                    ////
                    Random a_rnd = new Random();
                    int number = a_rnd.Next(0, Anime.Count - 1);
                    var send = MyEmbedCreator(Anime[number].TitleName, Anime[number].Descripton, Anime[number].Review + " | " + Anime[number].UsersReviewed, Anime[number].PicURL);

                    await ctx.RespondAsync($"", false, send.Build());

                    break;

                default:
                    await ctx.RespondAsync("???");
                    break;
            }
        }
    }
}
