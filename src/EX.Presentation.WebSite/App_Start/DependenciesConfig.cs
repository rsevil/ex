using Autofac;
using Autofac.Features.Variance;
using Autofac.Integration.Mvc;
using EX.Data.EF.Behaviors;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace EX.Presentation.WebSite.App_Start
{
    public static class DependenciesConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            RegisterAssembly(builder, Assembly.Load("EX.Data.EF"));
            RegisterAssembly(builder, Assembly.Load("EX.Data.EF.QueryHandlers"));
            RegisterAssembly(builder, Assembly.Load("EX.Core.CommandHandlers"));
            RegisterMediatR(builder);
            RegisterMVC(builder, typeof(DependenciesConfig).Assembly);

            var container = builder.Build();
            SetMVCResolver(container);
        }

        private static void RegisterMediatR(ContainerBuilder builder)
        {
            // enables contravariant Resolve() for interfaces with single contravariant ("in") arg
            builder
              .RegisterSource(new ContravariantRegistrationSource());

            // mediator itself
            builder
              .RegisterType<Mediator>()
              .As<IMediator>()
              .InstancePerLifetimeScope();

            // request handlers
            builder
              .Register<SingleInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => { object o; return c.TryResolve(t, out o) ? o : null; };
              })
              .InstancePerLifetimeScope();

            // notification handlers
            builder
              .Register<MultiInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
              })
              .InstancePerLifetimeScope();

            // enable post processor behaviors
            builder
                .RegisterGeneric(typeof(RequestPostProcessorBehavior<,>))
                .As(typeof(IPipelineBehavior<,>))
                .InstancePerLifetimeScope();

            // transactional behavior on commands
            builder
                .RegisterGeneric(typeof(TransactionalBehavior<,>))
                .As(typeof(IRequestPostProcessor<,>))
                .InstancePerLifetimeScope();
        }

        private static void RegisterAssembly(ContainerBuilder builder, Assembly assembly)
        {
            builder
                .RegisterAssemblyTypes(assembly)
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        private static void SetMVCResolver(IContainer container)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterMVC(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterModelBinderProvider();
            builder.RegisterFilterProvider();
            builder.RegisterControllers(assembly);
        }
    }
}