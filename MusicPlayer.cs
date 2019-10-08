using System;
using System.IO;
using System.Collections.Generic;
using MusicClasses;

namespace MusicPlayer
{
    public class MP
    {
        private Playlist queue;
        private List<Song> library;
        private List<Playlist> playlists;
        private int lengthPlayed;
        private int numSong;
        private bool playing;
        
        public MP()
        {
            numSong = 0;
            lengthPlayed = 0;
            queue = new Playlist("Queue", "system");
            playing = false;
            library = new List<Song>();
            playlists = new List<Playlist>();
        }

        public void addSong(Song s)
        {
            queue.addSong(s);
        }

        public void addSong(List<Song> songs)
        {
            foreach(Song s in songs)
                queue.addSong(s);
        }

        public void initSongList() //read the file and divide it into individual entries for parseSong
        {
            string path = Directory.GetCurrentDirectory();
            String file = System.IO.File.ReadAllText(path+"//songlist.txt"); //add file name to cd
            String[] songsSplit = file.Split("<song>");
            foreach(String s in songsSplit)
            {
                library.Add(ParseSong(s));
            }
        }

        public Song ParseSong(String line) //splits line of song and makes artist, album, and song objects
        {
            String[] results = line.Split('|', 5); //0 = title, 1 = artist, 2 = album, 3 = length, 4 = lyrics
            Artist newArt = new Artist(results[1]);
            Album newAlbum = new Album(results[2], newArt);
            Song newSong = new Song(results[0], newArt, newAlbum, Int32.Parse(results[3]), results[4]);
            return newSong;
        }

        public static String getDisplayTime(int length) //returns the min:sec display from an int
        {
            if(length%60 < 10)
                return(length/60+":0"+length%60);
            return(length/60+":"+length%60); 
        }

        public void printQueue() //iterate through and print numbered list (eventually rework to list style)
        {
            for(int i = 0; i < queue.getSongs().Count; i++)
            {
                Console.WriteLine((i+1) +") "+ queue.getSongs()[i]);
            }
        }
    
        public void printLibrary() //print all default songs in library
        {
            Console.WriteLine("Songs Library");
            for(int i = 0; i < library.Count; i++)
                Console.WriteLine(i+1 + ") "+library[i]);
        }

        public void startPlayer() //starts player and loops takeRequest()
        {
            Console.WriteLine("Welcome to the Music Player!");
            while(takeRequest() != -1) {}
        }

        public int takeRequest() //gets user input and runs resulting command
        {
            writeMenu();
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    return -1;
                case 1:
                    makePlaylist();
                    break;
                case 2:
                    playPlaylists();
                    break;
                default:
                    Console.WriteLine("Invalid Input, try again");
                    break;
            }
            return 1;
        }

        public void playPause() //plays the queue made, or pauses if it is being played
        {
            if(playing)
            {
                playing = false;
            }
            else
            {
                playing = true;
                while(numSong < queue.getSongs().Count)
                {
                    playSong(queue.getSongs()[numSong]);
                    numSong++;
                }
            }
        }

        public void playSong(Song s) //"plays" the song by printing lyrics
        {
            Console.WriteLine("Playing "+s);
            Console.WriteLine(s.getLyrics());
        }

        public void nextSong() //skips queue to next song
        {

        }

        public void previousSong() //goes back in queue to previous song
        {
            
        }

        public void makePlaylist() //constructs a new playlist with songs from library
        {
            Console.Write("Enter the name of the playlist: ");
            Playlist pl = new Playlist(Console.ReadLine(), "user");
            printLibrary();
            int result = 1;
            while(result != 0)
            {
                Console.WriteLine("Select Numbers to Add (0 to quit)");
                if(Int32.TryParse(Console.ReadLine(), out result))
                {
                    if(result <= library.Count && result != 0)
                    {
                        pl.addSong(library[result-1]);
                        Console.WriteLine("Added "+library[result-1]);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input, try again");
                }
            }
            playlists.Add(pl);
                
        }

        public void playPlaylists() //selects playlist to add to queue and play!
        {
            Console.WriteLine("Select Playlist to play");
            for(int i = 0; i < playlists.Count; i++)
            {
                Console.WriteLine(i+1 +") "+playlists[i]);
            }
            int result = -1;
            if(Int32.TryParse(Console.ReadLine(), out result))
            {
                queue.addPlaylist(playlists[result-1]);
                playPause();
            }
        }

        public void writeMenu() //prints the menu for selection
        {
            Console.WriteLine("Enter your request");
            Console.WriteLine("1: Make Playlist\n2: Play Playlist\n0: Quit");
        }
    }

    
}