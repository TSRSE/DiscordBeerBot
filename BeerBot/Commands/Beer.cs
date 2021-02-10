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
    public class Beer : BaseCommandModule
    {
        EconomicManager E_mngr = new EconomicManager();

        [Command("дуэль")]
        public async Task DuelBeerCommand(CommandContext ctx, DiscordMember member)
        {
            Random duelrandom = new Random();
            int d1 = duelrandom.Next(1, 1000);
            int d2 = duelrandom.Next(1, 1000);

            var embed = new DiscordEmbedBuilder();
            embed.Color = new DiscordColor(255, 146, 24);
            embed.ImageUrl = "https://thumbs.gfycat.com/ShockedScaryCrane-size_restricted.gif";

            if (member.Id == 265334610085412865) //Если это я
            {
                embed.Description = $"Из дуэли победителем и на своих ногах выходит {member.Mention}!\n\nПоздравляем!";
                embed.WithFooter($"Ничего, {ctx.Message.Author.Username}, повезет в другой раз");
            }

            else if (ctx.Message.Author.Id == 265334610085412865) //Если это я
            {
                embed.Description = $"Из дуэли победителем и на своих ногах выходит {ctx.Message.Author.Mention}!\n\nПоздравляем!";
                embed.WithFooter($"Ничего, {member.DisplayName}, повезет в другой раз");
            }

            else if (d1 > d2)
            {
                embed.Description = $"Из дуэли победителем и на своих ногах выходит {ctx.Message.Author.Mention}!\n\nПоздравляем!";
                embed.WithFooter($"Ничего, {member.DisplayName}, повезет в другой раз");
            }

            else if (d1 < d2)
            {
                embed.Description = $"Из дуэли победителем и на своих ногах выходит {member.Mention}!\n\nПоздравляем!";
                embed.WithFooter($"Ничего, {ctx.Message.Author.Username}, повезет в другой раз");
            }

            else if (d1 == d2)
            {
                embed.Description = $"Из дуэли победителем и на своих ногах выходит, {ctx.Message.Author.Mention} и {member.Mention}.\n\nБывает";
                embed.WithFooter($"Ого!");
            }

            await ctx.Message.RespondAsync($"", false, embed.Build());
        }

        [Command("пива")]
        public async Task BeerCommand(CommandContext ctx)
        {
            if (E_mngr.MoneyDes(ctx.Member, 50))
            {
                var embed = new DiscordEmbedBuilder();
                embed.Color = new DiscordColor(255, 146, 24);
                embed.ImageUrl = "https://thumbs.gfycat.com/ShockedScaryCrane-size_restricted.gif";

                embed.Description = $"Пиво пивное, вкусное нежное специально для вас, {ctx.Message.Author.Mention}";
                embed.WithFooter("Вкусное пиво, однако!");

                await ctx.Message.RespondAsync($"", false, embed.Build());

                if (ctx.Message.Author.Id == 345969516221825026)
                {
                    await ctx.RespondAsync("С вас 500 кибер рублей " + ctx.Message.Author.Mention);
                }
            }
            else
            {
                await ctx.RespondAsync($"Вам недостаточно денег.\nТребуется: **50 CR**\nВаш баланс: **{E_mngr.MoneyGet(ctx.Member)}**");
            }
        }

        [Command("пива")] // + юзер
        public async Task BeerCommand(CommandContext ctx, DiscordMember member)
        {
            if (E_mngr.MoneyDes(ctx.Member, 50))
            {
                var embed = new DiscordEmbedBuilder();
                embed.Color = new DiscordColor(255, 146, 24);
                embed.ImageUrl = "https://thumbs.gfycat.com/ShockedScaryCrane-size_restricted.gif";

                embed.Description = $"Пиво пивное, вкусное нежное специально для вас, {member.Mention} от {ctx.Message.Author.Mention}";

                Random getmocha = new Random();
                if (getmocha.Next(0, 1000) == 1000)
                    embed.WithFooter("Моча какая-то.");
                else
                    embed.WithFooter("Вкусное пиво, однако!");

                await ctx.Message.RespondAsync($"", false, embed.Build());

                System.Threading.Thread.Sleep(500);
                if (member.Id == 345969516221825026)
                {
                    E_mngr.MoneyAdd(member, 50);
                    await ctx.RespondAsync("С вас 500 кибер рублей " + ctx.Message.Author.Mention);
                }
            }
            else
            {
                await ctx.RespondAsync($"Вам недостаточно денег.\nТребуется: 50 CR\nВаш баланс:{E_mngr.MoneyGet(ctx.Member)}");
            }
        }
    }
}