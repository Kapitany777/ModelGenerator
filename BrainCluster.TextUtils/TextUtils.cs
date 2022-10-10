using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainCluster.TextUtilsLibrary
{
    public static class TextUtils
    {
        public static string UppercaseFirst(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
