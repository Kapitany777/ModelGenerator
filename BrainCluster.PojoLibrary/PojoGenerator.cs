using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainCluster.PojoLibrary
{
    public class PojoGenerator
    {
        #region Properties
        public int TabSize { get; set; }
        #endregion

        #region Private fields
        private Pojo pojo { get; }
        #endregion

        public PojoGenerator(Pojo pojo)
        {
            this.pojo = pojo;

            TabSize = 4;
        }

        private void AddPrivateField(StringBuilder source, DataField dataField)
        {
            source.AppendLineWithTabs(dataField.SerializedName, this.TabSize);
            source.AppendLineWithTabs(dataField.Variable, this.TabSize);

            source.AppendLine();
        }

        private void AddGetter(StringBuilder source, DataField dataField)
        {
            source.AppendLine();
        }

        private void AddSetter(StringBuilder source, DataField dataField)
        {
            source.AppendLine();
        }

        public string GetSourceCode()
        {
            StringBuilder source = new StringBuilder();

            source.AppendTwoLines($"package {pojo.PackageName};");
            source.AppendTwoLines("import com.google.gson.annotations.SerializedName;");
            source.AppendLine($"public class {pojo.ClassName}");
            source.AppendLine("{");

            pojo.DataFields.ForEach(dataField => AddPrivateField(source, dataField));
            pojo.DataFields.ForEach(dataField => AddGetter(source, dataField));
            pojo.DataFields.ForEach(dataField => AddSetter(source, dataField));

            source.AppendLine("}");

            return source.ToString();
        }
    }
}
