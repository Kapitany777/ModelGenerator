using BrainCluster.CommonLibrary;
using BrainCluster.PocoLibrary;
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
        static void Test1()
        {
            var pojo = new Pojo("hu.braincluster.test.models", "Warehouse");

            pojo
                .AddDataField(new JavaDataField(DataTypes.String, "warehouseCode"))
                .AddDataField(new JavaDataField(DataTypes.String, "warehouseName"))
                .AddDataField(new JavaDataField(DataTypes.Integer, "capacity"));

            var pojoGenerator = new PojoGenerator(pojo);

            Console.WriteLine(pojoGenerator.GetSourceCode());
        }

        static void Test2()
        {
            var poco = new Poco("BrainCluster.Models", "KeszletKmozgTip", "A készletmozgások típusai");

            poco
                .AddDataField(new CsharpDataField(DataTypes.String, "KmozgTipId", "A készletmozgás típus azonosítója"))
                .AddDataField(new CsharpDataField(DataTypes.String, "KmozgTipNev", "A készletmozgás típus megnevezése"))
                .AddDataField(new CsharpDataField(DataTypes.String, "KmozgTipRovNev", "A készletmozgás típus rövid megnevezése"))
                .AddDataField(new CsharpDataField(DataTypes.String, "KmozgTipSor", "A készletmozgás típus rövid megnevezése + azonosító"))
                .AddDataField(new CsharpDataField(DataTypes.String, "KeszletmozgasKod", "A készletmozgás kódja"))
                .AddDataField(new CsharpDataField(DataTypes.String, "RaktarKod", "A raktár kódja"))
                .AddDataField(new CsharpDataField(DataTypes.String, "AtvevoRaktarKod", "Az átvevő raktár kódja"));

            var pocoGenerator = new PocoGenerator(poco);

            Console.WriteLine(pocoGenerator.GetSourceCode());
        }

        static void Test3()
        {
            var pojo = new Pojo("hu.braincluster.test.models", "KeszletKmozgTip");

            pojo
                .AddDataField(new JavaDataField(DataTypes.String, "KmozgTipId"))
                .AddDataField(new JavaDataField(DataTypes.String, "KmozgTipNev"))
                .AddDataField(new JavaDataField(DataTypes.String, "KmozgTipRovNev"))
                .AddDataField(new JavaDataField(DataTypes.String, "KmozgTipSor"))
                .AddDataField(new JavaDataField(DataTypes.String, "KeszletmozgasKod"))
                .AddDataField(new JavaDataField(DataTypes.String, "RaktarKod"))
                .AddDataField(new JavaDataField(DataTypes.String, "AtvevoRaktarKod"));

            var pojoGenerator = new PojoGenerator(pojo);

            Console.WriteLine(pojoGenerator.GetSourceCode());
        }

        static void Main(string[] args)
        {
            // Test1();
            // Test2();
            Test3();
        }
    }
}
