using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WANDERLEYFLORES_WF.WF_Models
{
    internal class WF_AllNotesValid
    {

        public ObservableCollection<WF_Note> Notes { get; set; } = new ObservableCollection<WF_Note>();

        public WF_AllNotesValid() =>
            LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<WF_Note> notes = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.notes.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new WF_Note()
                                        {
                                            Filename = filename,
                                            Text = File.ReadAllText(filename),
                                            Date = File.GetCreationTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(note => note.Date);

            // Add each note into the ObservableCollection
            foreach (WF_Note note in notes)
                Notes.Add(note);
        }
    }
}
