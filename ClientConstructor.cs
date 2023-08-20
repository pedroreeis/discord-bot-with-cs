using DiscordBot.Commands;
using DiscordBot.Models;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace DiscordBot
{
    public class ClientConstructor
    {

        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }


        public async Task Run()
        {

            var json = string.Empty;

            using (var fs = File.OpenRead("settings.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
            json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigModel>(json);

                var config = new DiscordConfiguration
                {
                    Token = configJson.Token,
                    TokenType = TokenType.Bot,
                    AutoReconnect = true,
                    MinimumLogLevel = LogLevel.Debug
                };

            Client = new DiscordClient(config);
            Client.Ready += onClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] {configJson.Prefix}, 
                EnableMentionPrefix = true,
                EnableDms = false,
                DmHelp = true
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<FunCommands>();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private Task onClientReady(DiscordClient client, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}