using Prism.Ioc;
using Prism.Modularity;
using System;

namespace Smallify.Module.Settings
{
    public class Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new NotImplementedException();
        }
    }
}
