using Autofac;
using Demo.Contracts;

namespace Demo.WebClient.Container;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder
            .RegisterType<DemoClient>()
            .AsSelf();
    }
}