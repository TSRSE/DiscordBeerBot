using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace BeerBot_1
{
    class Economics : BaseCommandModule
    {
        EconomicManager E_mngr = new EconomicManager();

        [Command("чаевые")]
        public async Task Tips(CommandContext ctx, int amount)
        {
            if (amount > 0)
            {
                if (E_mngr.MoneyDes(ctx.Member, amount))
                {
                    int totalamount = int.Parse(File.ReadAllText(@"Stats\BotMoney.txt"));
                    totalamount = totalamount + amount;
                    await ctx.RespondAsync($"Спасибо!!!\nТеперь у меня **{totalamount}** CR!");
                    File.WriteAllText(@"Stats\BotMoney.txt", totalamount.ToString());
                }
                else
                {
                    await ctx.RespondAsync($"Вы не можете оставить столько чаевых, ваш баланс: {E_mngr.MoneyGet(ctx.Member)}");
                }
            }
        }

        [Command("баланс")]
        public async Task Wallet(CommandContext ctx)
        {
            await ctx.RespondAsync($"Баланс {ctx.Message.Author.Mention}\nCR: **{E_mngr.MoneyGet(ctx.Member)}**");
        }

        [Command("баланс")]
        public async Task Wallet(CommandContext ctx, DiscordMember member)
        {
            await ctx.RespondAsync($"Баланс {member.Mention}\nCR: **{E_mngr.MoneyGet(member)}**");
        }

        [Command("перевод")]
        public async Task Payment(CommandContext ctx, DiscordMember member, int money)
        {
            if (E_mngr.MoneyDes(ctx.Member, money))
            {
                E_mngr.MoneyAdd(member, money);
                await ctx.RespondAsync($"Ваша суммы была переведена на баланс {member.Mention}");
            }
            else
            {
                await ctx.RespondAsync($"Вы не можете перевести такую сумму на баланс пользователя {member.Mention}\nВаш баланс: **{E_mngr.MoneyGet(ctx.Member)} CR**");
            }
        }

        [Command("топ")]
        public async Task Top10(CommandContext ctx)
        {
            List<MyTopUsers> Users = new List<MyTopUsers>();
            DirectoryInfo dir = new DirectoryInfo(@"Stats");

            foreach (var item in dir.GetFiles())
            {
                int money = int.Parse(File.ReadAllText($@"Stats\{item.Name}"));
                Users.Add(new MyTopUsers(item.Name, money));
            }

            //sort

            Users.Sort((x,y) => y.money.CompareTo(x.money));

            //

            string SendTop = "";
            for (int i = 0; i < 10; i++)
            {
                int Position = i + 1;
                SendTop = SendTop + $"**{Position}]** *{Users[i].name.Replace(".txt", "")}* - `{Users[i].money}` CR\n";
            }

            var embed = new DiscordEmbedBuilder();
            embed.Color = new DiscordColor(255, 146, 24);
            embed.Title = "__Топ пользователей__\n\n";
            embed.Description = $"{SendTop}\n\n";
            embed.WithFooter($"Топ 10 пользователей по счету из {Users.Count}");

            await ctx.Message.RespondAsync($"", false, embed.Build());

        }


        [Command("зафармить")]
        [Cooldown(1, 60, CooldownBucketType.User)]
        public async Task Farm(CommandContext ctx)
        {
            Random rnd = new Random();
            int farmed = rnd.Next(1, 100);
            E_mngr.MoneyAdd(ctx.Member, farmed);

            await ctx.RespondAsync($"{ctx.Member.Mention}\nВы зафармили {farmed} **C**yber**R**ubels\n__Кулдаун: **1** минута__");
        }
    }
}
