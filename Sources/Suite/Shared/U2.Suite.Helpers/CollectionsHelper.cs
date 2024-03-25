using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Suite.Helpers;

public static class CollectionsHelper
{
    public static int BinarySearchForInsert<T>(IList<T> items, T newItem)
    {
        int left = 0;
        int right = items.Count() - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparisonResult = Comparer<T>.Default.Compare(items[mid], newItem);

            if (comparisonResult == 0)
            {
                // Found the exact match; insert at this position.
                return mid;
            }
            else if (comparisonResult < 0)
            {
                // newItem should be inserted to the right of mid.
                left = mid + 1;
            }
            else
            {
                // newItem should be inserted to the left of mid.
                right = mid - 1;
            }
        }

        // If the loop exits, the correct position for insertion is 'left'.
        return left;
    }
}
