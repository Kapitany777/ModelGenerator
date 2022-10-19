using BrainCluster.CommonLibrary;
using BrainCluster.TextUtilsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainCluster.PocoLibrary
{
    public class PocoGenerator : ISourceGenerator
    {
        #region Properties
        public bool AddConstructor { get; set; }

        public int TabSize { get; set; }
        #endregion

        #region Private fields
        private Poco poco;
        #endregion

        #region Constructors
        public PocoGenerator(Poco poco)
        {
            this.poco = poco;

            AddConstructor = true;
            TabSize = 4;
        }
        #endregion

        private void AddProperty(StringBuilder source, CsharpDataField dataField)
        {
            if (!string.IsNullOrEmpty(dataField.Summary))
            {
                source.AppendLineWithTabs("/// <summary>", this.TabSize * 2);
                source.AppendLineWithTabs($"/// {dataField.Summary}", this.TabSize * 2);
                source.AppendLineWithTabs("/// </summary>", this.TabSize * 2);
            }

            source.AppendLineWithTabs($"{dataField.Property}", this.TabSize * 2);
            source.AppendLine();
        }

        public string GetSourceCode()
        {
            StringBuilder source = new StringBuilder();

            source.AppendLine($"namespace {poco.NamespaceName}");
            source.AppendLine("{");

            if (!string.IsNullOrEmpty(poco.Summary))
            {
                source.AppendLineWithTabs("/// <summary>", this.TabSize);
                source.AppendLineWithTabs($"/// {poco.Summary}", this.TabSize);
                source.AppendLineWithTabs("/// </summary>", this.TabSize);
            }

            source.AppendLineWithTabs($"public class {poco.ClassName}", this.TabSize);
            source.AppendLineWithTabs("{", this.TabSize);

            poco.DataFields.ForEach(datafield => AddProperty(source, datafield));

            source.AppendLineWithTabs("}", this.TabSize);
            source.AppendLine("}");

            return source.ToString();
        }
    }
}
