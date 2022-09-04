using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void ClearOneByOne<T>(this ObservableCollection<T> collection)
        {
            foreach (var item in collection)
            {
                collection.Remove(item);
            }
        }
    }
}
