using System;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ZLogger;
using xpTURN.XLogger.Runtime;

namespace xpTURN.XLogger.Runtime.Tests
{
    [TestFixture]
    public class XLoggerExtensionsTests
    {
        [Test]
        public void XLogTrace_RecordsTraceLevel()
        {
            var capture = new CaptureLogger();
            capture.XLogTrace($"message");
            Assert.That(capture.Entries, Has.Count.EqualTo(1));
            Assert.That(capture.Entries[0].LogLevel, Is.EqualTo(LogLevel.Trace));
            Assert.That(capture.Entries[0].Message, Does.Contain("message"));
        }

        [Test]
        public void XLogDebug_RecordsDebugLevel()
        {
            var capture = new CaptureLogger();
            capture.XLogDebug($"value={42}");
            Assert.That(capture.Entries, Has.Count.EqualTo(1));
            Assert.That(capture.Entries[0].LogLevel, Is.EqualTo(LogLevel.Debug));
            Assert.That(capture.Entries[0].Message, Does.Contain("42"));
        }

        [Test]
        public void XLogInformation_RecordsInformationLevel()
        {
            var capture = new CaptureLogger();
            capture.XLogInformation($"info");
            Assert.That(capture.Entries, Has.Count.EqualTo(1));
            Assert.That(capture.Entries[0].LogLevel, Is.EqualTo(LogLevel.Information));
        }

        [Test]
        public void XLogWarning_RecordsWarningLevel()
        {
            var capture = new CaptureLogger();
            capture.XLogWarning($"warn");
            Assert.That(capture.Entries, Has.Count.EqualTo(1));
            Assert.That(capture.Entries[0].LogLevel, Is.EqualTo(LogLevel.Warning));
        }

        [Test]
        public void XLogError_RecordsErrorLevel()
        {
            var capture = new CaptureLogger();
            capture.XLogError($"err");
            Assert.That(capture.Entries, Has.Count.EqualTo(1));
            Assert.That(capture.Entries[0].LogLevel, Is.EqualTo(LogLevel.Error));
        }

        [Test]
        public void XLogCritical_RecordsCriticalLevel()
        {
            var capture = new CaptureLogger();
            capture.XLogCritical($"critical");
            Assert.That(capture.Entries, Has.Count.EqualTo(1));
            Assert.That(capture.Entries[0].LogLevel, Is.EqualTo(LogLevel.Critical));
        }

        [Test]
        public void XLogTrace_WithEventId_RecordsEventId()
        {
            var capture = new CaptureLogger();
            var eventId = new EventId(100, "Test");
            capture.XLogTrace(eventId, $"msg");
            Assert.That(capture.Entries, Has.Count.EqualTo(1));
            Assert.That(capture.Entries[0].EventId, Is.EqualTo(eventId));
        }

        [Test]
        public void XLogError_WithException_RecordsException()
        {
            var capture = new CaptureLogger();
            var ex = new InvalidOperationException("test");
            capture.XLogError(ex, $"error");
            Assert.That(capture.Entries, Has.Count.EqualTo(1));
            Assert.That(capture.Entries[0].Exception, Is.SameAs(ex));
        }

        [Test]
        public void XLog_WithLogLevel_RecordsCorrectLevel()
        {
            var capture = new CaptureLogger();
            capture.XLog(LogLevel.Warning, $"direct");
            Assert.That(capture.Entries, Has.Count.EqualTo(1));
            Assert.That(capture.Entries[0].LogLevel, Is.EqualTo(LogLevel.Warning));
        }

#if ENABLE_XLOGGER_RELEASE
        [Test]
        public void XLogRelease_RecordsInformationLevel()
        {
            var capture = new CaptureLogger();
            capture.XLogRelease(LogLevel.Information, $"release message");
            Assert.That(capture.Entries, Has.Count.EqualTo(1));
            Assert.That(capture.Entries[0].LogLevel, Is.EqualTo(LogLevel.Information));
            Assert.That(capture.Entries[0].Message, Does.Contain("release message"));
        }
#endif
    }
}