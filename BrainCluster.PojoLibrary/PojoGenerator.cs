using BrainCluster.CommonLibrary;
using BrainCluster.TextUtilsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainCluster.PojoLibrary
{
    public class PojoGenerator : ISourceGenerator
    {
        #region Properties
        public bool AddConstructor { get; set; }

        public int TabSize { get; set; }
        #endregion

        #region Private fields
        private Pojo pojo { get; }
        #endregion

        public PojoGenerator(Pojo pojo)
        {
            this.pojo = pojo;

            AddConstructor = true;
            TabSize = 4;
        }

        private void AddPrivateField(StringBuilder source, JavaDataField dataField)
        {
            source.AppendLineWithTabs(dataField.SerializedName, this.TabSize);
            source.AppendLineWithTabs(dataField.Variable, this.TabSize);

            source.AppendLine();
        }

        private void AddDefaultConstructor(StringBuilder source)
        {
            source.AppendLineWithTabs($"public {pojo.ClassName}()", this.TabSize);
            source.AppendLineWithTabs("{", this.TabSize);
            source.AppendLineWithTabs("}", this.TabSize);
            source.AppendLine();
        }

        private void AddGetter(StringBuilder source, JavaDataField dataField)
        {
            source.AppendLineWithTabs($"public {dataField.DataTypeName} get{TextUtils.UppercaseFirst(dataField.FieldName)}", this.TabSize);
            source.AppendLineWithTabs("{", this.TabSize);
            source.AppendLineWithTabs($"return {dataField.FieldName};", this.TabSize * 2);
            source.AppendLineWithTabs("}", this.TabSize);
            source.AppendLine();
        }

        private void AddSetter(StringBuilder source, JavaDataField dataField)
        {
            source.AppendLineWithTabs($"public void set{TextUtils.UppercaseFirst(dataField.FieldName)}({dataField.DataTypeName} {dataField.FieldName})", this.TabSize);
            source.AppendLineWithTabs("{", this.TabSize);
            source.AppendLineWithTabs($"this.{dataField.FieldName} = {dataField.FieldName};", this.TabSize * 2);
            source.AppendLineWithTabs("}", this.TabSize);
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

            if (AddConstructor)
            {
                AddDefaultConstructor(source);
            }

            pojo.DataFields.ForEach(dataField =>
            {
                AddGetter(source, dataField);
                AddSetter(source, dataField);
            });

            source.AppendLine("}");

            return source.ToString();
        }
    }
}
