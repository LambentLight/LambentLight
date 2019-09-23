using System.Collections.Generic;
using System.Windows.Forms;

namespace LambentLight.Extensions
{
    public static class ListControlExtensions
    {
        /// <summary>
        /// Fills the ComboBox with the specific set of items.
        /// </summary>
        public static void Fill<T>(this ComboBox control, IEnumerable<T> items, bool selectFirst = false)
        {
            // Start by wiping the existing items
            control.Items.Clear();
            // Then, add all of the items
            foreach (T obj in items)
            {
                control.Items.Add(obj);
            }
            // If there is at least one item, select it if the user wants to
            if (control.Items.Count > 0 && selectFirst)
            {
                control.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Fills the ListBox with the specific set of items.
        /// </summary>
        public static void Fill<T>(this ListBox control, IEnumerable<T> items, bool selectFirst = false)
        {
            // Start by wiping the existing items
            control.Items.Clear();
            // Then, add all of the items
            foreach (T obj in items)
            {
                control.Items.Add(obj);
            }
            // If there is at least one item, select it if the user wants to
            if (control.Items.Count > 0 && selectFirst)
            {
                control.SelectedIndex = 0;
            }
        }
    }
}
