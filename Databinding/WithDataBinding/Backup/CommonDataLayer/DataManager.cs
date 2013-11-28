using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDataLayer
{
    public static class DataManager
    {
        public static DataContainer GetData(string title)
        {
            var itemSelection = new DataItem[5];
            itemSelection[0] = new DataItem()  { AuthorName = "I. Litterate", BookTitle = "Learning to reed and right"};
            itemSelection[1] = new DataItem() { AuthorName = "Eta Lottafood", BookTitle = "Handy recipes"};
            itemSelection[2] = new DataItem() { AuthorName = "Holin Mipants", BookTitle = "Embarrasing moments"};
            itemSelection[3] = new DataItem() { AuthorName = "Mr D. Hoffman", BookTitle = "The care and maintenance of chest hair"};
            itemSelection[4] = new DataItem() { AuthorName = "K. Thefrog", BookTitle = "It aint easy being green"};

            var dc = new DataContainer();
            dc.Title = title;
            dc.Comments = string.Format("These are the comments for the item titled '{0}'", title);
            Random rnd = new Random(DateTime.Now.Millisecond);

            dc.MajorVersion = rnd.Next(1, 9);
            dc.MinorVersion = rnd.Next(0, 20);
            dc.Revision = rnd.Next(0, 100);

            for (int i = 0; i < 2000; i++)
            {
                dc.Items.Add(itemSelection[rnd.Next(0, 4)]);
            }
            return dc;
        }
    }
}
