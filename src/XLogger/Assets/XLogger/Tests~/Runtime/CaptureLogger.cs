using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace xpTURN.XLogger.Runtime.Tests
{
    public sealed class CaptureLogger : ILogger
    {
        public readonly List<Entry> Entries = new List<Entry>();

        public struct Entry
        {
            public LogLevel LogLevel;
            public EventId EventId;
            public Exception Exception;
            public string Message;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Entries.Add(new Entry
            {
                LogLevel = logLevel,
                EventId = eventId,
                Exception = exception,
                Message = formatter?.Invoke(state, exception) ?? state?.ToString() ?? ""
            });
        }

        public bool IsEnabled(LogLevel logLevel) => true;
        public IDisposable BeginScope<TState>(TState state) => null;
    }
}