using System.Collections.Generic;
using System.Linq;

namespace RentalCRM.Util
{
    public static class LinqExtension
    {
        public static List<T> Sort<T>(this List<T> list, string sortType, string column)
        {
            List<T> result = new List<T>();
            var propertyInfo = typeof(T).GetProperty(column);
            if (sortType == "asc")
            {
                result = list.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
            }
            else
            {
                result = list.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();
            }
            return result;
        }
    }
}
