using Autofac;
using Demo.Contracts;
using Demo.Contracts.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Demo.WebAdmin.Container;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder
            .RegisterType<DemoClient>()
            .AsSelf();

        builder
            .RegisterType<SignInManager<LoginResponseDto>>()
            .AsSelf();

        builder
            .RegisterType<UserManager<LoginResponseDto>>()
            .AsSelf();
    }
}