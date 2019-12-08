using Autofac;
using DataAccess.Repository;
using Domain.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
	public class InfrastructorModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<GoodRepository>().As<IGoodRepository>().InstancePerLifetimeScope();
		}
	}
}
