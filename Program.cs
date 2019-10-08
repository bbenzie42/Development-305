using System;
using System.Collections.Generic;
using MusicClasses;
using MusicPlayer;

namespace Program
{
    class Program
    {
        static void Main()
        {
            MusicPlayer.MP mp = new MusicPlayer.MP(); //makes MusicPlayer mp
            mp.initSongList();
            mp.startPlayer();
            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }
    }
}