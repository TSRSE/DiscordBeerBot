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
    class Tea : BaseCommandModule
    {
        [Command("чаю")]
        public async Task TeaCommand(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder();
            embed.Color = new DiscordColor(255, 146, 24);

            embed.Description = $"Чай, вкусный, сочный наливной, специально для вас, { ctx.Message.Author.Mention}";

            Random getmocha = new Random();
            if (getmocha.Next(0, 1000) == 1000)
            {
                embed.ImageUrl = "https://heaclub.ru/tim/d33bc2bbcaa12a18d8b28da4d33af1f8/sdacha-mochi-na-posev-trebuet-osoboi-sterilnosti.jpg";
                embed.WithFooter("Моча какая-то.");
            }
            else
            {
                embed.ImageUrl = "https://clipart-best.com/img/tea/tea-clip-art-1.png";
                embed.WithFooter("Великолепный выбор!");
            }

            await ctx.Message.RespondAsync($"", false, embed.Build());

            System.Threading.Thread.Sleep(500);
            if (ctx.Message.Author.Id == 345969516221825026)
            {
                await ctx.RespondAsync("С вас 500 кибер рублей " + ctx.Message.Author.Mention);
            }
        }

        [Command("чаю")] // + юзер
        public async Task TeaCommand(CommandContext ctx, DiscordMember member)
        {
            var embed = new DiscordEmbedBuilder();
            embed.Color = new DiscordColor(255, 146, 24);

            embed.Description = $"Чай, вкусный, сочный наливной, специально для вас, {member.Mention} от {ctx.Message.Author.Mention}";
            Random getmocha = new Random();
            if (getmocha.Next(0, 1000) == 1000)
            {
                embed.ImageUrl = "https://heaclub.ru/tim/d33bc2bbcaa12a18d8b28da4d33af1f8/sdacha-mochi-na-posev-trebuet-osoboi-sterilnosti.jpg";
                embed.WithFooter("Моча какая-то.");
            }
            else
            {
                embed.ImageUrl = "https://clipart-best.com/img/tea/tea-clip-art-1.png";
                embed.WithFooter("Великолепный выбор!");
            }

            await ctx.Message.RespondAsync($"", false, embed.Build());

            System.Threading.Thread.Sleep(500);
            if (member.Id == 345969516221825026)
            {
                await ctx.RespondAsync("С вас 500 кибер рублей " + ctx.Message.Author.Mention);
            }
        }
    }
}
