using VContainer;
using VContainer.Unity;

namespace _Project
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameInput>(Lifetime.Singleton);
        }
    }
}