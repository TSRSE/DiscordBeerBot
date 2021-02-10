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

namespace BeerBot_1
{
    class Snacks : BaseCommandModule
    {
        [Command("закуска")]
        public async Task Entree(CommandContext ctx, string nameOfTheSnack)
        {
            var emoji1 = DiscordEmoji.FromName(ctx.Client, ":point_right:");
            var emoji2 = DiscordEmoji.FromName(ctx.Client, ":point_left:");

            string url_pic = "", description = "", footer = "";
            var embed = new DiscordEmbedBuilder();
            embed.Color = new DiscordColor(255, 146, 24);

            //void Embed(string descr, string url, string footer, DiscordColor Color)
            //{

            //}

            switch (nameOfTheSnack.ToLower())
            {
                case "рыба":
                    description = $"Вкуснейшая рыба для {ctx.Message.Author.Mention}";
                    url_pic = "https://pngimg.com/uploads/fish/fish_PNG25168.png";
                    footer = "Ля какая рыбеха!";
                    break;

                case "хлеб":
                    description = $"Вкуснейший хлеб для {ctx.Message.Author.Mention}";
                    url_pic = "https://pngimg.com/uploads/bread/bread_PNG2218.png";
                    footer = "Хлеб мммм";
                    break;

                case "лапа":
                    embed.Color = new DiscordColor(254, 254, 254);
                    description = $"АААААААААААААА";
                    url_pic = "https://sun9-6.userapi.com/impg/K8K30jgi0iIz1nrdTA_87WwWfsyAkV3Pv8voGQ/ksQSEgA8f1o.jpg?size=667x667&quality=96&proxy=1&sign=bc5eb721034d5d6edb66cfaeb9681af6&type=album";
                    footer = $"!!!";
                    break;

                case "снек":
                    embed.Color = DiscordColor.Gray;
                    description = $"Снек";
                    url_pic = "https://sun9-36.userapi.com/impg/k2HRyUwmEXxxedWMm0h_pszTAEEZLInUAqxpJw/tDN7cHDcQSE.jpg?size=258x235&quality=96&proxy=1&sign=8a9b30fbfbcdf5bc07403e930f44b78d&type=album";
                    footer = $"\'Слишком горячо, чтобы съесть\'";
                    break;

                case "утка":
                    embed.Color = DiscordColor.Gold;
                    description = DiscordEmoji.FromName(ctx.Client, ":cheese:");
                    url_pic = "https://sun9-39.userapi.com/impg/y4ne8g2qIWyaTDJTgMBxpRzYtsvxDue30ibr5A/1F5VZlrVVus.jpg?size=204x162&quality=96&proxy=1&sign=30584c7fc162e21d1a579f98eaa12ebb&type=album";
                    footer = $")0) Cheese (0(";
                    break;

                default:
                    url_pic = "https://pbs.twimg.com/media/EAfpnKiWkAA2WE_.jpg";
                    footer = "Такого не было, но вот чипсеки.жпег";
                    break;
            }
            embed.ImageUrl = url_pic;
            embed.Description = description;
            embed.WithFooter(footer);
            await ctx.Message.RespondAsync($"", false, embed.Build());
        }
    }
}