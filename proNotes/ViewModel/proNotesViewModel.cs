using System;
using System.Windows;
using System.Collections.ObjectModel;
//using System.IO.IsolatedStorage;
//using Windows.Storage.ApplicationData;
using System.Linq;
using proNotes.Model;


namespace proNotes.ViewModel
{
    public class proNotesViewModel
    {
        public ObservableCollection<proNotes.Model.proNote> proNotes { get; set; }
        private Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public void GetproNotes()
        {
            if (localSettings.Values.Where(p=> p.GetType() == (new proNote()).GetType()).Count() > 0)
            {
                GetSavedproNotes();
            }
            else
            {
                GetDefaultproNotes();
            }
        }


        public void GetDefaultproNotes()
        {
            ObservableCollection<proNote> a = new ObservableCollection<proNote>();

            // Items to collect
            a.Add(new proNote() { Name = "Potions", Type = "Item" });
            a.Add(new proNote() { Name = "Coins", Type = "Item" });
            a.Add(new proNote() { Name = "Hearts", Type = "Item" });
            a.Add(new proNote() { Name = "Swords", Type = "Item" });
            a.Add(new proNote() { Name = "Shields", Type = "Item" });

            // Levels to complete
            a.Add(new proNote() { Name = "Level 1", Type = "Level" });
            a.Add(new proNote() { Name = "Level 2", Type = "Level" });
            a.Add(new proNote() { Name = "Level 3", Type = "Level" });

            proNotes = a;
            //MessageBox.Show("Got accomplishments from default");
        }


        public void GetSavedproNotes()
        {
            ObservableCollection<proNote> a = new ObservableCollection<proNote>();

            foreach (Object o in localSettings.Values.Where(p=> p.GetType() == (new proNote()).GetType()))
            {
                a.Add((proNote)o);
            }

            proNotes = a;
            //MessageBox.Show("Got accomplishments from storage");
        }
    }
}
