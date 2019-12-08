using Autofac;
using Domain.ServiceContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class CoreModule:Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<GoodService>().As<IGoodService>().InstancePerLifetimeScope();
		}

	}
}
