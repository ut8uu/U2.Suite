using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace U2.MultiRig.Code
{
    public sealed class MultiRigApplicationContext
    {
        private IContainer _container;

        static MultiRigApplicationContext()
        {
            Instance = new MultiRigApplicationContext();
        }

        private MultiRigApplicationContext()
        {
            Builder = new ContainerBuilder();
        }

        public static MultiRigApplicationContext Instance { get; set; }

        public ContainerBuilder Builder { get; }

        public IContainer Container
        {
            get => _container ??= Builder.Build();
            private set => _container = value;
        }

        public void BuildContainer()
        {
            Container ??= Builder.Build();
        }
    }
}
