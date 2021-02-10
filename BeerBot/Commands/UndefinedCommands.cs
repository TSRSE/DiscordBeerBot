using System;
using System.IO;
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
    class UndefinedCommands : BaseCommandModule
    {
        [Command("банан")]
        public async Task PolskyBanany(CommandContext ctx)
        {
            await ctx.Message.RespondAsync("https://sun9-21.userapi.com/impg/hrL0xHViG9UAV86GfTwBDJb6kpEnxKueEKIaAw/7ZSbmUKSNjw.jpg?size=1500x1484&quality=96&proxy=1&sign=288c1f92af850a7a2fec83eb2b8a3240&type=album");
        }

        [Command("скажи")]
        public async Task Say(CommandContext ctx, [RemainingText] string text)
        {
            await ctx.Message.DeleteAsync();
            System.Threading.Thread.Sleep(500);
            await ctx.Message.RespondAsync(text);
        }

        [Command("аннигиляция")]
        [RequireOwner]
        public async Task Annigilation(CommandContext ctx)
        {
            var AllMessages = await ctx.Channel.GetMessagesAsync();
            foreach (var message in AllMessages)
            {
                await message.DeleteAsync();
                System.Threading.Thread.Sleep(500);
            }
        }

        [Command("спасибо")]
        public async Task ThankBot(CommandContext ctx)
        {
            await ctx.RespondAsync("<3");
        }
    }
}