using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainCluster.PocoLibrary
{
    public class Poco
    {
        #region Properties
        public string NamespaceName { get; }

        public string ClassName { get; }

        public List<CsharpDataField> DataFields { get; }
        #endregion

        public Poco(string namespaceName, string className)
        {
            this.NamespaceName = namespaceName;
            this.ClassName = className;

            DataFields = new List<CsharpDataField>();
        }

        public Poco AddDataField(CsharpDataField dataField)
        {
            DataFields.Add(dataField);

            return this;
        }
    }
}
