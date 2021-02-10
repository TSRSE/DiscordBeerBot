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
    class Roll : BaseCommandModule
    {
        [Command("рулетка")]
        public async Task RussianRulette(CommandContext ctx)
        {
            Random DeathBullet = new Random();

            var emoji = DiscordEmoji.FromName(ctx.Client, ":gun:");

            if (DeathBullet.Next(1, 6) == 3)
            {
                await ctx.RespondAsync($"{ctx.Message.Author.Mention} <===  {emoji}" +
                    $"\nВы умерли, получив пулю себе в весок, {ctx.Message.Author.Mention}");
            }
            else
                await ctx.RespondAsync($"Вы выжили, поздравляем, {ctx.Message.Author.Mention}");
        }

        [Command("ролл")]
        public async Task RollD(CommandContext ctx)
        {
            Random thisrandom = new Random();
            await ctx.Message.RespondAsync($"Вам выпало {thisrandom.Next(1, 20)} из 20, мастер " + ctx.Message.Author.Mention);
        }

        [Command("ролл")] // + число
        public async Task RollD(CommandContext ctx, int number)
        {
            try
            {
                Random thisrandomSet = new Random();
                await ctx.Message.RespondAsync($"Вам выпало {thisrandomSet.Next(1, number)} из {number}, мастер " + ctx.Message.Author.Mention);
            }
            catch
            {
                await ctx.Message.RespondAsync("Извините, не получилось перевести число...\nП-Простите, Мастер " + ctx.Message.Author.Mention);
            }
        }
    }
}