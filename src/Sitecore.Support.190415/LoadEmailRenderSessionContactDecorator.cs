using Sitecore.Analytics.Pipelines.InitializeTracker;
using Sitecore.Modules.EmailCampaign.Core.Pipelines.EnsureSessionContext;
using Sitecore.Xdb.Configuration;
using System;

namespace Sitecore.Support.Modules.EmailCampaign.Core.Pipelines.EnsureSessionContext
{
    /// <summary>
    /// Fix bug 190415
    /// </summary>
    public class LoadEmailRenderSessionContactDecorator
    {
        static LoadEmailRenderSessionContact InitLazyObject()
        {
            return new LoadEmailRenderSessionContact();
        }

        private Lazy<LoadEmailRenderSessionContact> lazyObject = new Lazy<LoadEmailRenderSessionContact>(InitLazyObject, true);

        public void Process(InitializeTrackerArgs args)
        {            
            if (!XdbSettings.Enabled)
            {
                return;
            }
            lazyObject.Value.Process(args);
        }
    }
}
