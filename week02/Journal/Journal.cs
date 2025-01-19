using System;
using System.Text.RegularExpressions;

/*  Added logic to save and load a file from CSV format.
    Added logic to escape CSV characters and enclose fields with double quotes.
    Added logic to split fields in a csv file using regular expressions.
*/

class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                string date = EscapeCsvCharacters(entry._date);
                string promptText = EscapeCsvCharacters(entry._promptText);
                string entryText = EscapeCsvCharacters(entry._entryText);

                writer.WriteLine($"{date},{promptText},{entryText}");
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = ParseCsvCharacters(line);

                if (parts.Length == 3)
                {
                    Entry entry = new Entry();
                    entry._date = parts[0];
                    entry._promptText = parts[1];
                    entry._entryText = parts[2];
                    _entries.Add(entry);
                }
            }
        }

        Console.WriteLine("Journal loaded successfully.");
    }

    public static string EscapeCsvCharacters(string field)
    {
        if (field.Contains("\""))
        {
            field = field.Replace("\"", "\"\"");
        }

        if (field.Contains(",") || field.Contains("\n"))
        {
            field = $"\"{field}\"";
        }

        return field;
    }

    public static string[] ParseCsvCharacters(string line)
    {
        var matches = Regex.Matches(line, "(\"[^\"]*(\"\"[^\"]*)*\"|[^,]+)");
        string[] fields = new string[matches.Count];

        for (int i = 0; i < matches.Count; i++)
        {
            fields[i] = matches[i].Value;

            if (fields[i].StartsWith("\"") && fields[i].EndsWith("\""))
            {
                fields[i] = fields[i].Substring(1, fields[i].Length - 2).Replace("\"\"", "\"");
            }
        }

        return fields;
    }
}
