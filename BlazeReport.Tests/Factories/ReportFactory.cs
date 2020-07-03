using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Reporter;

namespace BlazeReport.Tests.Factories
{
    public static class ReportFactory
    {
        public static readonly string ReportPath = "C:\\Dev\\ExtentReport\\";

        public static IExtentReporter Default()
        {
            return new ExtentHtmlReporter(ReportPath);
        }
    }
}
