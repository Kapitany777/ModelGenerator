using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainCluster.PojoLibrary
{
    public class Pojo
    {
        #region Properties
        public string PackageName { get; }

        public string ClassName { get; }

        public List<DataField> DataFields { get; }
        #endregion

        public Pojo(string packageName, string className)
        {
            this.PackageName = packageName;
            this.ClassName = className;

            DataFields = new List<DataField>();
        }

        public Pojo AddDataField(DataField dataField)
        {
            DataFields.Add(dataField);

            return this;
        }
    }
}
