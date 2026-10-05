/*
* Filnamn: Guestbook.cs
* Forfattare: Johanna Hassberg
* Datum: 2026-10-05
* Kurs: Programmering i C#
*
* Beskrivning: Klass för att hantera gästbok
*/

using System.Text.Json;

namespace Uppgift3
{

    // Klass som hanterar gästboken och dess inlägg
    public class Guestbook
    {
        // Filnamn för JSON-filen med gästboksinlägg
        private string filename = @"guestbook.json";

        // Lista som lagrar alla gästboksinlägg
        private List<GuestbookEntry> entries = new List<GuestbookEntry>();

        public Guestbook()
        {
            // Laddar gästboksinlägg från JSON-fil
            Load();
        }

        private void Load()
        {
            // Ladda gästboksinlägg från JSON-fil om filen finns
            if (File.Exists(filename))
            {
                var jsonString = File.ReadAllText(filename);
                entries = JsonSerializer.Deserialize<List<GuestbookEntry>>(jsonString) ?? new List<GuestbookEntry>();
            }
        }

        // Metod för att lägga till inlägg
        public GuestbookEntry AddEntry(string username, string entry)
        {
            GuestbookEntry newEntry = new GuestbookEntry();
            newEntry.UserName = username;
            newEntry.Entry = entry;
            entries.Add(newEntry);
            Save();
            return newEntry;
        }

        // Metod för att ta bort inlägg
        public void DeleteEntry(int index)
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("Det finns inga inlägg att ta bort.");
                return;
            }

            if (index >= 0 && index < entries.Count)
            {
                entries.RemoveAt(index);
                Save();
            }
            else
            {
                Console.WriteLine("Ogiltigt index. Välj en siffra mellan 0 och " + (entries.Count - 1) + ".");
            }
        }

        // Metod för att hämta alla gästboksinlägg
        public List<GuestbookEntry> GetEntries()
        {
            return entries;
        }

        private void Save()
        {
            // Spara gästboksinlägg till JSON-fil
            var jsonString = JsonSerializer.Serialize(entries);
            File.WriteAllText(filename, jsonString);
        }
    }
}