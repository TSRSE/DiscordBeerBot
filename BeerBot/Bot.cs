using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity.Enums;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace BeerBot_1
{
    class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var json = string.Empty;
            using (var fs = File.OpenRead(@"SystemFiles\config.json"))
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                    json = await sr.ReadToEndAsync();

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug
            };

            Client = new DiscordClient(config);

            var commandsConfiguration = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableMentionPrefix = true,
                DmHelp = true,
                EnableDms = true
            };

            Commands = Client.UseCommandsNext(commandsConfiguration);

            Client.UseInteractivity(new InteractivityConfiguration()
            {
                PollBehaviour = PollBehaviour.KeepEmojis,
                Timeout = TimeSpan.FromSeconds(30),
            });

            Commands.RegisterCommands<Info>();
            Commands.RegisterCommands<Economics>();

            Commands.RegisterCommands<Beer>();
            Commands.RegisterCommands<Snacks>();

            Commands.RegisterCommands<Tea>();

            Commands.RegisterCommands<Roll>();

            Commands.RegisterCommands<UndefinedCommands>();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }
    }
}