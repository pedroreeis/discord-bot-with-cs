using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Client
    {
        static void Main(string[] args)
        {
            var client = new ClientConstructor();

            client.Run().GetAwaiter().GetResult();
        }
    }
}
