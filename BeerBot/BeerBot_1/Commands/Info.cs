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
    class Info : BaseCommandModule
    {
        [Command("инфо")]
        public async Task InfoCommand(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder();
            embed.Color = new DiscordColor(255, 146, 24);
            embed.Title = "Команды и их описание";
            embed.Description = "Чтобы вывести разом **все** команды, напишите `пивбот, инфо фулл`\n" +
                "**Пивные** комманды - `пивбот, инфо пиво`\n" +
                "**Чайные** комманды - `пивбот, инфо чай`\n" +
                "**Экономика** - `пивбот, инфо эко`\n" +
                "**Фан** Комманды - `пивбот, инфо фан`\n" +
                "";
            
            embed.WithFooter("Версия бота: BETA 1.2.1 | Репорты и вопросы сюда -> TSRSE#4743 ");

            await ctx.Message.RespondAsync(embed: embed);
        }

        [Command("инфо")]
        public async Task InfoCommand(CommandContext ctx, string Instance)
        {
            var embed = new DiscordEmbedBuilder();
            embed.Color = new DiscordColor(255, 146, 24);
            embed.Title = "Команды и их описание";

            string Beer = "**Дуэль** `< *упоминание пользователя *>` -дуэль пивом\n" +
                "**Пива** - выдает вам пиво **[50 CR]**\n" +
                "**Пива** `<*упоминание пользователя*>` - дарит пиво выбранному пользователю **[50 CR]**\n\n";
            string Tea = "**Чаю** - выдает вам чай\n" +
                "**Чаю** `<*упоминание пользователя*>` - дарит чай выбранному пользователю\n\n";
            string Eco = "**Перевод** `<*упоминание пользователя*>` [сумма] - переводит сумму на счет выбранного пользователя\n" +
                "**Баланс** - показывает ваш баланс\n" +
                "**Баланс** `<*упоминание пользователя*>` - показывает баланс выбранного пользователя\n" +
                "**Зафармить** - выдает вам денежку раз в некторое время\n\n";
            string Fun = "**Ролл** - выдается число от 1 до 20\n" +
                "**Ролл 10** - выдается число от 1 до числа, которое вы поставите **вместо** 10\n" +
                "**Скажи** - повторю фразу после слова 'скажи' [ваше сообщение удалиться]\n" +
                "**Закуска** + `рыба` или `хлеб` или `[слово]` -  выдает вам чипсеки или то, что вы выбрали\n\n" +
                "**Спасибо** - поблагодарить меня\n\n";

            embed.Description = $" *Перед каждой командой пишите* __пивбот, __\n\n";
            string Full = Beer + Tea + Eco + Fun;

            switch (Instance)
            {
                case "фулл":
                    embed.Description += Full;
                    break;

                case "пиво":
                    embed.Description += Beer;
                    break;

                case "чай":
                    embed.Description += Tea;
                    break;

                case "эко":
                    embed.Description += Eco;
                    break;

                case "фан":
                    embed.Description += Fun;
                    break;

                default:
                    break;
            }

            embed.WithFooter("Версия бота: BETA 1.2.1 | Репорты и вопросы сюда -> TSRSE#4743 ");

            await ctx.Message.RespondAsync(embed: embed);
        }

        [Command("статус")]
        public async Task StatusCommand(CommandContext ctx)
        {
            UInt64 totalamount = UInt64.Parse(File.ReadAllText(@"Stats\BotMoney.txt"));
            var embed = new DiscordEmbedBuilder();
            embed.Color = new DiscordColor(255, 146, 24);
            embed.Title = "__Информация__\n";
            embed.Description = $"" +
                    $"CR: **{totalamount}**\n";
            embed.WithFooter("Напишите 'пивбот, инфо' чтобы получить информацию по всем командам");

            await ctx.Message.RespondAsync($"", false, embed.Build());
        }
    }
}