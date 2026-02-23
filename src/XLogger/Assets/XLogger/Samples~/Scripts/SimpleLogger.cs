using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

using ZLogger;
using ZLogger.Unity;
using UnityEngine;

public class SimpleLogger : MonoBehaviour
{
    ILogger logger;

    int frame = 0;
    int count = 0;
    long value = 1000;
    string info = "MyGame";

    void Awake()
    {
        // LoggerFactory setup (same as ZLogger)
        var loggerFactory = LoggerFactory.Create(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Trace);
            logging.AddZLoggerUnityDebug();
        });

        logger = loggerFactory.CreateLogger("MyCategory");
    }

    void Update()
    {
        ++frame;
        ++count;
        // If ENABLE_XLOGGER is not defined, the following calls are not included in the build output
        logger.XLogInformation($"Start! Frame: {frame}");
        logger.XLogDebug($"Value: {value}");
        logger.XLogWarning($"Something: {(name, count)}"); // named

        // Output only when ENABLE_XLOGGER_RELEASE is defined
        logger.XLogRelease(LogLevel.Information, $"Release-only message: {info}");
    }
}
