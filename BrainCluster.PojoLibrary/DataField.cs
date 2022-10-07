using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainCluster.PojoLibrary
{
    public class DataField
    {
        public DataTypes DataType { get; set; }

        public string FieldName { get; }

        public string SerializedName => $"@SerializedName(\"{this.FieldName}\")";

        public string Variable
        {
            get
            {
                return $"private {DataTypeToString(this.DataType)} {this.FieldName};";
            }
        }

        public string Getter
        {
            get
            {
                return "";
            }
        }

        public string Setter
        {
            get
            {
                return "";
            }
        }

        public DataField(DataTypes dataType, string fieldName)
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
