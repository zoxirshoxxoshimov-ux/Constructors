using System;
public class Song
{
    // Fields
    private string _code;
    private string _title;
    private int _durationSeconds;
    private int _playCount;

    // Constructor
    public Song(string code, string title, int durationSeconds)
    {
        _code = code;
        _title = title;
        _durationSeconds = durationSeconds;
        _playCount = 0;
    }

    // Properties
    public string Code => _code;
    public string Title => _title;
    public int DurationSeconds => _durationSeconds;
    public int PlayCount => _playCount;

    // Methods
    public void Play()
    {
        _playCount++;
    }

    public string GetInfo()
    {
        return $"{Code} — {Title}, {DurationSeconds} soniya, {PlayCount} marta ijro etildi";
    }
}

public class Playlist
{
    // Fields
    private List<Song> _songs;
    private int _capacity;

    // Constructor
    public Playlist(string name, int capacity)
    {
        Name = name;
        _capacity = capacity;
        _songs = new List<Song>();
    }

    // Properties
    public string Name { get; }

    public int SongCount => _songs.Count;

    // Methods
    public bool AddSong(Song song)
    {
        if (_songs.Count >= _capacity)
        {
            return false;
        }

        foreach (Song existingSong in _songs)
        {
            if (existingSong.Code == song.Code)
            {
                return false;
            }
        }

        _songs.Add(song);
        return true;
    }

    public bool PlaySong(int index)
    {
        if (index < 0 || index >= _songs.Count)
        {
            return false;
        }

        _songs[index].Play();
        return true;
    }

    public int GetTotalDuration()
    {
        int total = 0;

        foreach (Song song in _songs)
        {
            total += song.DurationSeconds;
        }

        return total;
    }

    public void PrintSongs()
    {
        Console.WriteLine($"\nPlaylist: {Name}");

        foreach (Song song in _songs)
        {
            Console.WriteLine(song.GetInfo());
        }
    }
}

class Program
{
    static void Main()
    {
        Song song1 = new("S01", "Focus", 210);
        Song song2 = new("S02", "Break", 185);
        Song song3 = new("S03", "Review", 240);

        Playlist playlist = new("Study Mix", 3);

        Console.WriteLine(playlist.AddSong(song1));
        Console.WriteLine(playlist.AddSong(song2));
        Console.WriteLine(playlist.AddSong(song3));

        Console.WriteLine("Duplicate: " + playlist.AddSong(song2));

        Console.WriteLine("PlaySong(1): " + playlist.PlaySong(1));
        Console.WriteLine("PlaySong(1): " + playlist.PlaySong(1));

        Console.WriteLine("PlaySong(-1): " + playlist.PlaySong(-1));
        Console.WriteLine("PlaySong(3): " + playlist.PlaySong(3));

        playlist.PrintSongs();

        Console.WriteLine("\nTotal duration: " + playlist.GetTotalDuration());

        Playlist emptyPlaylist = new("Empty Playlist", 3);

        Console.WriteLine("\nEmpty playlist song count: " + emptyPlaylist.SongCount);
    }
}