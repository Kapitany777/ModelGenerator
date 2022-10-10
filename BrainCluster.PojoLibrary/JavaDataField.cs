using BrainCluster.CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainCluster.PojoLibrary
{
    public class JavaDataField
    {
        public DataTypes DataType { get; set; }

        public string FieldName { get; }

        public string SerializedName => $"@SerializedName(\"{this.FieldName}\")";

        public string DataTypeName => DataTypeToString(this.DataType);

        public string Variable => $"private {DataTypeToString(this.DataType)} {this.FieldName};";

        public JavaDataField(DataTypes dataType, string fieldName)
        {
            this.DataType = dataType;
            this.FieldName = fieldName;
        }

        private string DataTypeToString(DataTypes dataType)
        {
            switch (dataType)
            {
                case DataTypes.Boolean:
                    return "boolean";

                case DataTypes.Double:
                    return "double";

                case DataTypes.Integer:
                    return "int";

                case DataTypes.String:
                    return "String";

                default:
                    return string.Empty;
            }
        }
    }
}
