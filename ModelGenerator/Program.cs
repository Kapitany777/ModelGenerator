using BrainCluster.CommonLibrary;
using BrainCluster.PojoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var pojo = new Pojo("hu.braincluster.test.models", "Warehouse");

            pojo
                .AddDataField(new JavaDataField(DataTypes.String, "warehouseCode"))
                .AddDataField(new JavaDataField(DataTypes.String, "warehouseName"))
                .AddDataField(new JavaDataField(DataTypes.Integer, "capacity"));

            var pojoGenerator = new PojoGenerator(pojo);

            Console.WriteLine(pojoGenerator.GetSourceCode());
        }
    }
}
