using Sitecore.Analytics.Pipelines.InitializeTracker;
using Sitecore.Modules.EmailCampaign.Core.Analytics;
using Sitecore.Xdb.Configuration;
using System;

namespace Sitecore.Support.Modules.EmailCampaign.Core.Analytics
{
    /// <summary>
    /// Fix bug 190415
    /// </summary>
    public class DispatchRequestProcessorDecorator
    {
        static DispatchRequestProcessor InitLazyObject()
        {
            return new DispatchRequestProcessor();
        }

        private Lazy<DispatchRequestProcessor> lazyObject = new Lazy<DispatchRequestProcessor>(InitLazyObject, true);

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
