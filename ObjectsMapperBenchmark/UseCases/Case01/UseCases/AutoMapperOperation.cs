using AutoMapper;
using System.Collections.Generic;

namespace ObjectsMapperBenchmark{
    public static class AutoMapperOperation
    {
        public static void Start()
        {
            Execution.Execute((i) => {
                if (i == 1)
                    WithMapper<UserModel, User>(InitializeAutomapper(), Mock.GenerateMock().First(), i);
                else
                    WithMapper<List<UserModel>, List<User>>(InitializeAutomapper(), Mock.GenerateMock(i), i);
            });
        }

        public static void WithMapper<TSource, TDestiny>(Mapper mapper, TSource source, int quantity) =>
            RunCases.Execute(() => mapper.Map<TDestiny>(source), "AutoMapper", quantity);

        private static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, User>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
