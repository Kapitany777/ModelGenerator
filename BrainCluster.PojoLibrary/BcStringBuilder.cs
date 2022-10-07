using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainCluster.PojoLibrary
{
    public static class BcStringBuilder
    {
        public static void AppendTwoLines(this StringBuilder stringBuilder, string line)
        {
            stringBuilder.AppendLine(line);
            stringBuilder.AppendLine();
        }
    }
}
