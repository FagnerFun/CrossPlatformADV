using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.Droid.Service;
using Prism;
using Prism.Ioc;

namespace CrossPlatform.Droid.DependencyInjection
{
    public class AndroidPlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDataBaseAccessService, DataBaseAccessService>();
        }
    }
}