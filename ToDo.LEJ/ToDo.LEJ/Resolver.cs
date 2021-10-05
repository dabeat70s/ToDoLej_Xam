using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace ToDo.LEJ
{
    //autofac resolving DI**
    public static class Resolver
    {
        private static IContainer _container;
        public static void Initialize(IContainer container)
        {
            Resolver._container = container;
        }
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
