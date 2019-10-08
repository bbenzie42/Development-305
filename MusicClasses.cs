using System;
using System.Collections.Generic;
using MusicPlayer;

namespace MusicClasses
{
    public class Song 
    {
        private String title;
        private Artist artist;
        private Album album;
        private int length;
        private String lyrics;

        public Song(String title, Artist artist, Album album, int length, String lyrics)
        {
            this.title = title;
            this.length = length;
            this.album = album;
            this.artist = artist;
            this.lyrics = lyrics;
        }

        public override String ToString()
        {
            return title+" by "+artist+" - "+album+" ("+MusicPlayer.MP.getDisplayTime(length)+")";
        }

        public Artist GetArtist() {return artist;}
        public String GetTitle() {return title;}
        public Album GetAlbum() {return album;}
        public int GetLength() {return length;}
        public String getLyrics() {return lyrics;}
    }

    public class Artist
    {
        private String name;
        private List<Album> albums;

        public Artist(String name)
        {
            this.name = name;
            albums = new List<Album>();
        }

        public void addAlbum(Album alb)
        {
            albums.Add(alb);
        }

        public override String ToString()
        {
            return name;
        }
    }

    public class Album
    {
        private String name;
        private Artist artist;
        private List<Song> songs;

        public Album(String name, Artist artist)
        {
            this.name = name;
            this.artist = artist;
            songs = new List<Song>();
        }

        public override String ToString()
        {
            return name;
        }
    }

    public class Playlist
    {
        private String title;
        private List<Song> songs;
        private String author;

        public Playlist(String title, String author)
        {
            this.title = title;
            this.author = author;
            songs = new List<Song>();
        }

        public void addSong(Song s)
        {
            songs.Add(s);
        }

        public void addPlaylist(Playlist p)
        {
            foreach(Song s in p.getSongs())
                songs.Add(s);
        }

        public List<Song> getSongs(){return songs;}

        public override String ToString()
        {
            return title+" ("+songs.Count+" songs)";
        }
    }
}