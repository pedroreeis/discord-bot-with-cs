using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class FunCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Retorna a palavra Pong.")]
        public async Task Ping(CommandContext ctx)
        {

            var embed = new DiscordEmbedBuilder
            {
                Title = "Pong!",
                Color = DiscordColor.Red,
                Thumbnail =
                {
                    Url = ctx.Client.CurrentUser.AvatarUrl
                },
                Description = "É só isso kkkkkkkk",
                Timestamp = DateTime.Now,
                Footer =
                {
                    Text = "Isso é um comando para diversão, apenas."
                }
            };
            await ctx.Channel.SendMessageAsync(embed).ConfigureAwait(false);  
        }
    }
}
