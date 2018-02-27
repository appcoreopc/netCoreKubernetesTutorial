using ConnectCD.NetCoreWebApi.Configuration;
using NLog;
using System;

namespace ConnectCD.NetCoreWebApi.LogService
{
    public class FluentdLogger
    {
        Settings _settings;

        public FluentdLogger(Settings settings)
        {
            _settings = settings;
        }
        
        public void Write(string message)
        {
            var config = new NLog.Config.LoggingConfiguration();
            
            using (var fluentdTarget = new NLog.Targets.Fluentd())
            {
                // Setting up our docker contianer (fluentD) host //
                fluentdTarget.Host = _settings?.FluentLoggerServerIp;

                fluentdTarget.Layout = new NLog.Layouts.SimpleLayout("${longdate}|${level}|${callsite}|${logger}|${message}");

                config.AddTarget("fluentd", fluentdTarget);
                config.LoggingRules.Add(new NLog.Config.LoggingRule("demo", NLog.LogLevel.Debug, fluentdTarget));

                var loggerFactory = new LogFactory(config);
                var logger = loggerFactory.GetLogger("demo");

                logger.Info(message);
            }           
        }

    }
}
