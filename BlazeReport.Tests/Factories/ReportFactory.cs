using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Reporter;
using System.Diagnostics;

namespace BlazeReport.Tests.Factories
{
    public static class ReportFactory
    {
        public static readonly string ReportPath = "C:\\Dev\\ExtentReport\\index.html";

        public static IExtentReporter Default()
        {
            var reporter = new ExtentHtmlReporter(ReportPath);

            return reporter;
        }

        public static void LaunchReport()
        {
            Process.Start(@"cmd.exe ", @$"/c {ReportPath}");
        }
    }
}
