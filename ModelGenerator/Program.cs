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

            Console.WriteLine(pojo.GetSourceCode());
        }
    }
}
