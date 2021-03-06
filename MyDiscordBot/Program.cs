﻿using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiscordBot
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _handler;
        private bool number;

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            if (Config.bot.token == "" || Config.bot.token == null) return;
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = Discord.LogSeverity.Verbose
            });
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);
            await _client.SetGameAsync("Being Developed");
            await Task.Delay(-1);
        }

        private async Task Log(Discord.LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }


    }


}
