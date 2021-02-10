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
    class AdminSettings : BaseCommandModule
    {
        [Command("бан")]
        [RequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task PermBan(CommandContext ctx, DiscordMember MemberToBan)
        {
            if (MemberToBan.Id != 265334610085412865)
            {
                await MemberToBan.BanAsync();
            }
            else
                await ctx.RespondAsync("Сорянба, но это создатель.");
        }
    }
}
