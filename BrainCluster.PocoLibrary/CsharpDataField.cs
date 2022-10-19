using BrainCluster.CommonLibrary;
using BrainCluster.TextUtilsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainCluster.PocoLibrary
{
    public class CsharpDataField
    {
        public DataTypes DataType { get; set; }

        public string FieldName { get; }

        public string Summary { get; set; }

        public string DataTypeName => DataTypeToString(this.DataType);

        public string Property => $"public {DataTypeToString(this.DataType)} {this.FieldName} {{ get; set; }}";

        public CsharpDataField(DataTypes dataType, string fieldName)
        {
            this.DataType = dataType;
            this.FieldName = TextUtils.UppercaseFirst(fieldName); ;
        }

        public CsharpDataField(DataTypes dataType, string fieldName, string summary)
            : this(dataType, fieldName)
        {
            this.Summary = summary;
        }

        private string DataTypeToString(DataTypes dataType)
        {
            switch (dataType)
            {
                case DataTypes.Boolean:
                    return "bool";

                case DataTypes.Double:
                    return "double";

                case DataTypes.Integer:
                    return "int";

                case DataTypes.String:
                    return "string";

                default:
                    return string.Empty;
            }
        }
    }
}
