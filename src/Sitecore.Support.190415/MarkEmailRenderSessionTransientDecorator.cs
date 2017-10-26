using Sitecore.Analytics.Pipelines.InitializeTracker;
using Sitecore.Modules.EmailCampaign.Core.Pipelines.InitializeTracker;
using Sitecore.Xdb.Configuration;
using System;

namespace Sitecore.Support.Modules.EmailCampaign.Core.Pipelines.InitializeTracker
{
    /// <summary>
    /// Fix bug 190415
    /// </summary>
    public class MarkEmailRenderSessionTransientDecorator
    {
        static MarkEmailRenderSessionTransient InitLazyObject()
        {
            return new MarkEmailRenderSessionTransient();
        }

        private Lazy<MarkEmailRenderSessionTransient> lazyObject = new Lazy<MarkEmailRenderSessionTransient>(InitLazyObject, true);

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
