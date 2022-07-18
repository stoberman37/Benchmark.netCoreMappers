using System;

namespace ObjectsMapperBenchmark{
    public static class Run
    {
        public static void Start()
        {
            Console.WriteLine("CASE 03");

            AutoMapperOperation.Start();
            ExtensionMethod.Start();
            CreateMethod.Start();
        }
    }
}
