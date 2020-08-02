using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace DesignPatterns.SOLID.SRP
{
    // Just stores a couple of journal entries and ways of working with them
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // Memento pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // Below methods breaks single responsibility principle
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }
    }

    // The Journal class should NOT be handling Journal persistence, this violates the first SOLID principle: The Single Responsibility Principle.
    // Thus, we create a new Persistence class to handle this in order to get a separation of concerns.
    public class Persistence
    {
        public void SaveToFile(Journal j, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
            {
                File.WriteAllText(fileName, j.ToString());
            }
        }

        public static Journal LoadFromFile(string fileName)
        {
            return null;
        }
    } 


    class SOLID
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);

            var p = new Persistence();
            var fileName = @"C:\temp\journal.txt";
            p.SaveToFile(j, fileName, true);

            Process.Start(fileName);
        }
    }
}
