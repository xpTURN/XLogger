using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using ZLogger;
using XLogger.InterpolatedStringHandler;

namespace ZLogger
{
    /// <summary>
    /// Extension methods for <see cref="ILogger"/> that provide conditional compile for log calls.
    /// When <c>ENABLE_XLOGGER</c> is not defined, all XLog* calls (except XLogRelease) are removed at compile time.
    /// When <c>ENABLE_XLOGGER_RELEASE</c> is not defined, <see cref="XLogRelease"/> calls are removed at compile time.
    /// Uses interpolated strings and passes caller info (member name, file path, line number) like ZLogger.
    /// </summary>
    /// <example>
    /// <code>
    /// ILogger logger = loggerFactory.CreateLogger("MyCategory");
    ///
    /// // Level-specific (compiled only when ENABLE_XLOGGER is defined)
    /// logger.XLogInformation($"User {userId} logged in");
    /// logger.XLogDebug($"Frame: {frame}, Count: {count}");
    /// logger.XLogWarning($"Low health: {(name: "HP", value: health)}");
    /// logger.XLogError(ex, $"Failed: {ex.Message}");
    ///
    /// // Explicit level
    /// logger.XLog(LogLevel.Information, $"Event: {eventName}");
    ///
    /// // Release-only (compiled only when ENABLE_XLOGGER_RELEASE is defined)
    /// logger.XLogRelease(LogLevel.Information, $"Release message: {info}");
    /// </code>
    /// </example>
    public static partial class XLoggerExtensions
    {
        /// <summary>Logs at the specified level. Compiled only when ENABLE_XLOGGER is defined.</summary>
        [Conditional("ENABLE_XLOGGER")]
        public static void XLog(this ILogger logger, LogLevel logLevel, [InterpolatedStringHandlerArgument("logger", "logLevel")] ref _XH message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, logLevel, default, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLog(this ILogger logger, LogLevel logLevel, EventId eventId, [InterpolatedStringHandlerArgument("logger", "logLevel")] ref _XH message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, logLevel, eventId, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLog(this ILogger logger, LogLevel logLevel, Exception exception, [InterpolatedStringHandlerArgument("logger", "logLevel")] ref _XH message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, logLevel, default, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLog(this ILogger logger, LogLevel logLevel, EventId eventId, Exception exception, [InterpolatedStringHandlerArgument("logger", "logLevel")] ref _XH message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, logLevel, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        /// <summary>Logs at Trace level. Compiled only when ENABLE_XLOGGER is defined.</summary>
        [Conditional("ENABLE_XLOGGER")]
        public static void XLogTrace(this ILogger logger, [InterpolatedStringHandlerArgument("logger")] ref _XT message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Trace, default, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogTrace(this ILogger logger, EventId eventId, [InterpolatedStringHandlerArgument("logger")] ref _XT message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Trace, eventId, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogTrace(this ILogger logger, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XT message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Trace, default, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogTrace(this ILogger logger, EventId eventId, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XT message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Trace, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        /// <summary>Logs at Debug level. Compiled only when ENABLE_XLOGGER is defined.</summary>
        [Conditional("ENABLE_XLOGGER")]
        public static void XLogDebug(this ILogger logger, [InterpolatedStringHandlerArgument("logger")] ref _XD message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Debug, default, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogDebug(this ILogger logger, EventId eventId, [InterpolatedStringHandlerArgument("logger")] ref _XD message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Debug, eventId, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogDebug(this ILogger logger, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XD message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Debug, default, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogDebug(this ILogger logger, EventId eventId, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XD message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Debug, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        /// <summary>Logs at Information level. Compiled only when ENABLE_XLOGGER is defined.</summary>
        [Conditional("ENABLE_XLOGGER")]
        public static void XLogInformation(this ILogger logger, [InterpolatedStringHandlerArgument("logger")] ref _XI message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Information, default, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogInformation(this ILogger logger, EventId eventId, [InterpolatedStringHandlerArgument("logger")] ref _XI message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Information, eventId, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogInformation(this ILogger logger, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XI message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Information, default, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogInformation(this ILogger logger, EventId eventId, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XI message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Information, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        /// <summary>Logs at Warning level. Compiled only when ENABLE_XLOGGER is defined.</summary>
        [Conditional("ENABLE_XLOGGER")]
        public static void XLogWarning(this ILogger logger, [InterpolatedStringHandlerArgument("logger")] ref _XW message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Warning, default, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogWarning(this ILogger logger, EventId eventId, [InterpolatedStringHandlerArgument("logger")] ref _XW message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Warning, eventId, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogWarning(this ILogger logger, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XW message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Warning, default, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogWarning(this ILogger logger, EventId eventId, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XW message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Warning, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        /// <summary>Logs at Error level. Compiled only when ENABLE_XLOGGER is defined.</summary>
        [Conditional("ENABLE_XLOGGER")]
        public static void XLogError(this ILogger logger, [InterpolatedStringHandlerArgument("logger")] ref _XE message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Error, default, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogError(this ILogger logger, EventId eventId, [InterpolatedStringHandlerArgument("logger")] ref _XE message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Error, eventId, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogError(this ILogger logger, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XE message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Error, default, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogError(this ILogger logger, EventId eventId, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XE message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Error, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        /// <summary>Logs at Critical level. Compiled only when ENABLE_XLOGGER is defined.</summary>
        [Conditional("ENABLE_XLOGGER")]
        public static void XLogCritical(this ILogger logger, [InterpolatedStringHandlerArgument("logger")] ref _XC message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Critical, default, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogCritical(this ILogger logger, EventId eventId, [InterpolatedStringHandlerArgument("logger")] ref _XC message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Critical, eventId, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogCritical(this ILogger logger, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XC message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Critical, default, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER")]
        public static void XLogCritical(this ILogger logger, EventId eventId, Exception exception, [InterpolatedStringHandlerArgument("logger")] ref _XC message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, LogLevel.Critical, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        /// <summary>Logs at the specified level in release builds. Compiled only when ENABLE_XLOGGER_RELEASE is defined.</summary>
        [Conditional("ENABLE_XLOGGER_RELEASE")]
        public static void XLogRelease(this ILogger logger, LogLevel logLevel, [InterpolatedStringHandlerArgument("logger", "logLevel")] ref _XH message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, logLevel, default, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER_RELEASE")]
        public static void XLogRelease(this ILogger logger, LogLevel logLevel, EventId eventId, [InterpolatedStringHandlerArgument("logger", "logLevel")] ref _XH message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, logLevel, eventId, null, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER_RELEASE")]
        public static void XLogRelease(this ILogger logger, LogLevel logLevel, Exception exception, [InterpolatedStringHandlerArgument("logger", "logLevel")] ref _XH message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, logLevel, default, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }

        [Conditional("ENABLE_XLOGGER_RELEASE")]
        public static void XLogRelease(this ILogger logger, LogLevel logLevel, EventId eventId, Exception exception, [InterpolatedStringHandlerArgument("logger", "logLevel")] ref _XH message, object context = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            ZLoggerExtensions.ZLog(logger, logLevel, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
        }
    }
}
