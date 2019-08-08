using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.iOS.Service;
using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;

namespace CrossPlatform.iOS.DependencyInjection
{
    public class IOSPlatformInitializer: IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDataBaseAccessService, DataBaseAccessService>();
        }
    }
}