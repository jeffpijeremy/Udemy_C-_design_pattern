using System.Diagnostics;

namespace DesignPatterns
{
    //single Responsibilty Principle
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}:{text}");
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt( index );
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine,entries);
        }
    }
    public class Persistence
    {
        public void SaveToFile(Journal j,string filename,bool overite = false)
        {
            if(overite || !File.Exists(filename))
            {
                File.WriteAllText(filename,j.ToString());
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start("notepad.exe",filename);
        }
    }
}