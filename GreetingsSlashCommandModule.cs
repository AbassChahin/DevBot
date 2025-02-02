using Discord;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBot
{
    public class GreetingsSlashCommandModule : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly CustomServices _customServices;

        public GreetingsSlashCommandModule(CustomServices customServices)
        {
            _customServices = customServices;
        }

        [SlashCommand("hello", "Greeting!")]
        public async Task HelloCommand()
        {
            _customServices.Log("Hello Command Called");
            Embed embed = _customServices.BuildEmbed("Greetings!", "Nice to meet you!", Context);
            await RespondAsync(embed: embed);
        }
    }
}
