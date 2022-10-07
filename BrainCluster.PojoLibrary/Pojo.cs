using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainCluster.PojoLibrary
{
    public class Pojo
    {
        public string PackageName { get; set; }

        public string ClassName { get; set; }

        public Pojo(string packageName, string className)
        {
            this.PackageName = packageName;
            this.ClassName = className;
        }


        public string GetSourceCode()
        {
            StringBuilder source = new StringBuilder();

            source.AppendTwoLines($"package {this.PackageName};");
            source.AppendTwoLines("import com.google.gson.annotations.SerializedName;");
            source.AppendLine($"public class {this.ClassName}");
            source.AppendLine("{");

            source.AppendLine("}");

            return source.ToString();
        }
    }
}
