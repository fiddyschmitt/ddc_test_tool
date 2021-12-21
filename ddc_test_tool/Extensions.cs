using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddc_test_tool
{
    public static class Extensions
    {
        public static string ToString(this IEnumerable<string> list, string separator)
        {
            string result = string.Join(separator, list);
            return result;
        }
    }
}
