using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Gateway;

namespace notsobot_shell
{
    class Program
    {
        public static string username = "Sinfull";
        static void Main(string[] args)
        {

            Console.Write(" * Channel : ");
            File.WriteAllText("channel.txt", Console.ReadLine());
            DiscordSocketClient client = new DiscordSocketClient();
            Console.Write(" * token : ");

            client.Login(Console.ReadLine());



            client.OnLoggedIn += Client_OnLoggedIn;
            client.OnMessageReceived += Client_OnMessageReceived;

            Thread.Sleep(-1);
        }

        private static void Client_OnMessageReceived(DiscordSocketClient client, MessageEventArgs args)
        {
            if (args.Message.Channel.Id.ToString() == File.ReadAllText("channel.txt").ToString())
            {
                if (args.Message.Author.User.Id.ToString() == "439205512425504771")
                {
                    Console.WriteLine($"\n{args.Message.Content.Replace("```", "").Replace("py", "")}\n");
                    sendshell(client);
                }
            }
        }

        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            sendshell(client);
        }
        public static void sendshell(DiscordSocketClient client)
        {
            Console.Write($"{username}@NotSoBot:-# ");
            string cmd = Console.ReadLine();
            if (cmd == "clear") { Console.Clear(); sendshell(client); }
            else
            {
                client.SendMessage(Convert.ToUInt64(File.ReadAllText("channel.txt")), $".rex bash {cmd}");
            }
            
        }
    }
}
