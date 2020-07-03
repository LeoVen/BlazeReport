using System;
using System.Threading;

namespace BlazeReport.Tests.Common
{
    /// <summary>
    /// Defines common wait times. For example, when we change a page, we might
    /// want to wait one second for all the elements to reload, but when we call
    /// an API that queries a database, bringing a lot of data, we might want to
    /// wait more than one second.
    ///
    /// Since Blazor is server-side rendered, the time for the components to
    /// change their state might fluctuate. 500 ms should be enough though.
    ///
    /// So this class defines some default wait times after a certain action has
    /// been taken.
    /// </summary>
    public static class ActionWaits
    {
        // Values given in milliseconds
        private static readonly int stateLoadTimeout = 500;
        private static readonly int pageLoadTimeout = 1000;
        private static readonly int apiLoadTimeout = 2000;
        private static readonly int dbLoadTimeout = 4000;

        public static void StateWait(Action action)
        {
            action();
            Thread.Sleep(stateLoadTimeout);
        }

        public static void PageWait(Action action)
        {
            action();
            Thread.Sleep(pageLoadTimeout);
        }

        public static void ApiWait(Action action)
        {
            action();
            Thread.Sleep(apiLoadTimeout);
        }

        public static void DbWait(Action action)
        {
            action();
            Thread.Sleep(dbLoadTimeout);
        }
    }
}
