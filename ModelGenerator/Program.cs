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
            Pojo pojo = new Pojo("hu.braincluster.test.models", "Raktar");

            pojo
                .AddDataField(new DataField(DataTypes.String, "raktarKod"))
                .AddDataField(new DataField(DataTypes.String, "raktarNev"))
                .AddDataField(new DataField(DataTypes.Integer, "kapacitas"));

            PojoGenerator pojoGenerator = new PojoGenerator(pojo);

            Console.WriteLine(pojoGenerator.GetSourceCode());
        }
    }
}
