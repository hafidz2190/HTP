using System.Collections.Generic;

namespace POProject.BusinessLogic.Helper
{
    public static class ModelToBusinessModelMapper
    {
        public static TEntityTo Convert<TEntityFrom, TEntityTo>(TEntityFrom entityFrom)
            where TEntityFrom : class
            where TEntityTo : class
        {
            return AutoMapper.Mapper.Map<TEntityTo>(entityFrom);
        }

        public static List<TEntityTo> Convert<TEntityFrom, TEntityTo>(List<TEntityFrom> entityFroms)
            where TEntityFrom : class
            where TEntityTo : class
        {
            var entityTos = new List<TEntityTo>();

            foreach (var entityFrom in entityFroms)
            {
                var entityTo = AutoMapper.Mapper.Map<TEntityTo>(entityFrom);
                entityTos.Add(entityTo);
            }
            return entityTos;
        }
    }
}
