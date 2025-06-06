using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1_2_KM
{
    class Playlist
    {
        private List<Song> list;
        private int currentIndex;

        public Playlist()
        {
            list = new List<Song>();
            currentIndex = 0;
        }

        public Song CurrentSong()
        {
            if (list.Count > 0)
                return list[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        public List<string> WriteAllSongs() // получение списка всех товаров в текстовом формате
        {
            List<string> songs = new List<string>(); // создание списка для хранения строк с информацией о песне

            foreach (var song in list) // перебор всех песен
            {
                songs.Add($"{song.Author} {song.Title} {song.Filename}"); // добавление песни в список
            }

            return songs; // возвращение списка песен
        }

        public void AddSong(string author, string title, string filename)
        {
            Song song = new Song();
            song.Author = author;
            song.Title = title;
            song.Filename = filename;

            list.Add(song);
        }

        public void AddSong(Song song)
        {
            list.Add(song);
        }

        public void AddSong(string filename)
        {
            int index = filename.IndexOf('.');

            if (index >= 0)
            {

                Song song = new Song();
                song.Author = "Неизвестный";
                song.Title = filename.Remove(index);
                song.Filename = filename;

                list.Add(song);
            }
        }

        public Song NextSong()
        {
            if (list.Count > 0)
            {
                currentIndex++;

                if (currentIndex >= list.Count)
                {
                    throw new IndexOutOfRangeException("Невозможно выйти за пределы плейлиста");
                }
                else
                    return list[currentIndex];
            }
            else throw new IndexOutOfRangeException("Список пустой");
        }

        public Song PreviousSong()
        {
            if (list.Count > 0)
            {
                currentIndex--;

                if (currentIndex < 0)
                {
                    throw new IndexOutOfRangeException("Невозможно выйти за пределы плейлиста");
                }
                else
                    return list[currentIndex];
            }
            else throw new IndexOutOfRangeException("Список пустой");
        }

        public Song IndexSong(int index)
        {
            if (list.Count > 0)
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Индекс не может быть отрицательным");
                }
                if (index >= list.Count)
                {
                    throw new IndexOutOfRangeException("Индекс выходить за границы");
                }

                currentIndex = index;
                return list[currentIndex];
            }
            else throw new IndexOutOfRangeException("Список пустой");
        }

        public Song StartPlaylist()
        {
            if (list.Count > 0)
            {
                currentIndex = 0;
                return list[currentIndex];
            }
            else throw new IndexOutOfRangeException("Список пустой");
        }

        public void DeleteSong(string file)
        {
            Song song = new Song();

            list.RemoveAll(song => song.Filename == file);
        }

        public void DeleteSong(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Индекс не может быть отрицательным");
            }
            if (index >= list.Count)
            {
                throw new IndexOutOfRangeException("Индекс выходить за границы");
            }
            else
                list.RemoveAt(index);
        }

        public void DeleteSong(Song song)
        {
            list.Remove(song);
        }

        public void ClearPlaylist()
        {
            list.Clear();
        }

        public int CurrentIndex()
        {
            return currentIndex;
        }
    }
}
