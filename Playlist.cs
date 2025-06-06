using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1_2_KM
{
    // класс, представляющий плейлист музыкальных композиций
    class Playlist
    {
        private List<Song> list;         // список песен в плейлисте
        private int currentIndex;        // индекс текущей воспроизводимой песни

        // конструктор плейлиста
        public Playlist()
        {
            list = new List<Song>();  // инициализация пустого списка песен
            currentIndex = 0;         // начинаем с первого элемента
        }

        public Song CurrentSong()
        {
            if (list.Count > 0)
                return list[currentIndex];  // возвращение текущей песни
            else // создание исключения
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

        // добавление песни с указанием автора, названия и файла
        public void AddSong(string author, string title, string filename)
        {
            Song song = new Song(); // создание объекта
            song.Author = author;
            song.Title = title;
            song.Filename = filename;

            // проверка, нет ли уже такой песни в плейлисте
            if (!list.Contains(song))
                list.Add(song);  // добавление, если песни нет
            else
                throw new Exception("Песня уже есть в плейлисте");  // иначе выбрасываем исключение
        }

        // добавление готового объекта Song
        public void AddSong(Song song)
        {
            if (!list.Contains(song))
                list.Add(song);  // добавление, если песни нет
            else // создание исключения
                throw new Exception("Песня уже есть в плейлисте");
        }

        // добавление песни только по имени файла
        public void AddSong(string filename)
        {
            int index = filename.IndexOf('.');  // поиск точки в имени файла

            if (index >= 0)  // если точка найдена
            {
                Song song = new Song(); // создание объекта
                song.Author = "Неизвестный";  // автор по умолчанию
                song.Title = filename.Remove(index);  // название = имя файла без расширения
                song.Filename = filename;

                if (!list.Contains(song))
                    list.Add(song);  // добавление, если песни нет
                else // создание исключения
                    throw new Exception("Песня уже есть в плейлисте");
            }
        }

        // переход к следующей песне
        public Song NextSong()
        {
            if (list.Count > 0)  // если плейлист не пустой
            {
                currentIndex++;  // увеличивание индекса

                if (currentIndex >= list.Count)  // проверка выхода за границы
                {
                    // создание исключения
                    throw new IndexOutOfRangeException("Невозможно выйти за пределы плейлиста");
                }
                else
                    return list[currentIndex];  // возвращение следующей песни
            }
            else // создание исключения
                throw new IndexOutOfRangeException("Список пустой");
        }

        // переход к предыдущей песне
        public Song PreviousSong()
        {
            if (list.Count > 0)  // если плейлист не пустой
            {
                currentIndex--;  // уменьшение индекса

                if (currentIndex < 0)  // проверка выходы за границы
                {
                    // создание исключения
                    throw new IndexOutOfRangeException("Невозможно выйти за пределы плейлиста");
                }
                else
                    return list[currentIndex];  // возвращение предыдущей песни
            }
            else // создание исключения
                throw new IndexOutOfRangeException("Список пустой");
        }

        // получение песни по индексу
        public Song IndexSong(int index)
        {
            if (list.Count > 0)  // если плейлист не пустой
            {
                // проверка корректности индекса
                if (index < 0)
                {
                    // создание исключения
                    throw new IndexOutOfRangeException("Индекс не может быть отрицательным");
                }
                if (index >= list.Count)
                {
                    throw new IndexOutOfRangeException("Индекс выходить за границы");
                }

                currentIndex = index;  // установление текущего индекса
                return list[currentIndex];  // возвращени песни
            }
            else // создание исключения
                throw new IndexOutOfRangeException("Список пустой");
        }

        // начало воспроизведения плейлиста (первая песня)
        public Song StartPlaylist()
        {
            if (list.Count > 0)  // если плейлист не пустой
            {
                currentIndex = 0;  // сбрасывание индекса на начало
                return list[currentIndex];  // возвращение первой песни
            }
            else // создание исключения
                throw new IndexOutOfRangeException("Список пустой");
        }

        // удаление песни по имени файла
        public void DeleteSong(string file)
        {
            // удаление всеъ песен с указанным именем файла
            list.RemoveAll(song => song.Filename == file);
        }

        // удаление песни по индексу
        public void DeleteSong(int index)
        {
            // проверка корректности индекса
            if (index < 0)
            {
                // создание исключения
                throw new IndexOutOfRangeException("Индекс не может быть отрицательным");
            }
            if (index >= list.Count)
            {
                // создание исключения
                throw new IndexOutOfRangeException("Индекс выходить за границы");
            }
            else
                list.RemoveAt(index);  // удаление песни по индексу
        }

        // удаление конкретной песни
        public void DeleteSong(Song song)
        {
            list.Remove(song);  // удаление указанной песни
        }

        // очистка всего плейлиста
        public void ClearPlaylist()
        {
            list.Clear();  // удаление всех песен
        }

        // получение текущего индекса
        public int CurrentIndex()
        {
            return currentIndex;  // возвращение индекса текущей песни
        }
    }
}
