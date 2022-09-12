using Autofac;
using Demo.DAL;
using Demo.EntityFramework;
using Demo.WebServer.DAL;
using Microsoft.EntityFrameworkCore;

namespace Demo.WebServer.Container;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        var mainAssembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder
            .RegisterType<UnitOfWork>()
            .As<IUnitOfWork>();

        builder
            .RegisterType<Context>()
            .As<DbContext>();

        builder
            .RegisterAssemblyTypes(mainAssembly)
            .Where(c => c.Name.EndsWith("Query"))
            .AsSelf();

        builder
            .RegisterAssemblyTypes(mainAssembly)
            .Where(c => c.Name.EndsWith("Action"))
            .AsSelf();
    }
}