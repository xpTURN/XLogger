#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

using ZLogger;

namespace XLogger.InterpolatedStringHandler;

[InterpolatedStringHandler]
public ref struct _XH
{
    public ZLoggerInterpolatedStringHandler InnerHandler;

    public _XH(int literalLength, int formattedCount, ILogger logger, LogLevel logLevel, out bool enabled)
    {
        InnerHandler = new ZLoggerInterpolatedStringHandler(literalLength, formattedCount, logger, logLevel, out enabled);
    }
    
    public void AppendLiteral([System.Diagnostics.CodeAnalysis.ConstantExpected] string s)
    {
        InnerHandler.AppendLiteral(s);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(T value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
    {
        InnerHandler.AppendFormatted(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(Nullable<T> value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
        where T : struct
    {
        InnerHandler.AppendFormatted<T>(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>((string, T) namedValue, int alignment = 0, string? format = null, string? _ = null)
    {
        InnerHandler.AppendFormatted(namedValue, alignment, format);
    }
}

[InterpolatedStringHandler]
public ref struct _XT
{
    public ZLoggerInterpolatedStringHandler InnerHandler;

    public _XT(int literalLength, int formattedCount, ILogger logger, out bool enabled)
    {
        InnerHandler = new ZLoggerInterpolatedStringHandler(literalLength, formattedCount, logger, LogLevel.Trace, out enabled);
    }
    public void AppendLiteral([System.Diagnostics.CodeAnalysis.ConstantExpected]string s)
    {
        InnerHandler.AppendLiteral(s);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(T value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
    {
        InnerHandler.AppendFormatted(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(Nullable<T> value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
        where T : struct
    {
        InnerHandler.AppendFormatted<T>(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>((string, T) namedValue, int alignment = 0, string? format = null, string? _ = null)
    {
        InnerHandler.AppendFormatted(namedValue, alignment, format);
    }
}

[InterpolatedStringHandler]
public ref struct _XD
{
    public ZLoggerInterpolatedStringHandler InnerHandler;

    public _XD(int literalLength, int formattedCount, ILogger logger, out bool enabled)
    {
        InnerHandler = new ZLoggerInterpolatedStringHandler(literalLength, formattedCount, logger, LogLevel.Debug, out enabled);
    }
    public void AppendLiteral([System.Diagnostics.CodeAnalysis.ConstantExpected]string s)
    {
        InnerHandler.AppendLiteral(s);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(T value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
    {
        InnerHandler.AppendFormatted(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(Nullable<T> value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
        where T : struct
    {
        InnerHandler.AppendFormatted<T>(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>((string, T) namedValue, int alignment = 0, string? format = null, string? _ = null)
    {
        InnerHandler.AppendFormatted(namedValue, alignment, format);
    }
}

[InterpolatedStringHandler]
public ref struct _XI
{
    public ZLoggerInterpolatedStringHandler InnerHandler;

    public _XI(int literalLength, int formattedCount, ILogger logger, out bool enabled)
    {
        InnerHandler = new ZLoggerInterpolatedStringHandler(literalLength, formattedCount, logger, LogLevel.Information, out enabled);
    }
    public void AppendLiteral([System.Diagnostics.CodeAnalysis.ConstantExpected]string s)
    {
        InnerHandler.AppendLiteral(s);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(T value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
    {
        InnerHandler.AppendFormatted(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(Nullable<T> value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
        where T : struct
    {
        InnerHandler.AppendFormatted<T>(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>((string, T) namedValue, int alignment = 0, string? format = null, string? _ = null)
    {
        InnerHandler.AppendFormatted(namedValue, alignment, format);
    }
}

[InterpolatedStringHandler]
public ref struct _XW
{
    public ZLoggerInterpolatedStringHandler InnerHandler;

    public _XW(int literalLength, int formattedCount, ILogger logger, out bool enabled)
    {
        InnerHandler = new ZLoggerInterpolatedStringHandler(literalLength, formattedCount, logger, LogLevel.Warning, out enabled);
    }
    public void AppendLiteral([System.Diagnostics.CodeAnalysis.ConstantExpected]string s)
    {
        InnerHandler.AppendLiteral(s);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(T value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
    {
        InnerHandler.AppendFormatted(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(Nullable<T> value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
        where T : struct
    {
        InnerHandler.AppendFormatted<T>(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>((string, T) namedValue, int alignment = 0, string? format = null, string? _ = null)
    {
        InnerHandler.AppendFormatted(namedValue, alignment, format);
    }
}

[InterpolatedStringHandler]
public ref struct _XE
{
    public ZLoggerInterpolatedStringHandler InnerHandler;

    public _XE(int literalLength, int formattedCount, ILogger logger, out bool enabled)
    {
        InnerHandler = new ZLoggerInterpolatedStringHandler(literalLength, formattedCount, logger, LogLevel.Error, out enabled);
    }
    public void AppendLiteral([System.Diagnostics.CodeAnalysis.ConstantExpected]string s)
    {
        InnerHandler.AppendLiteral(s);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(T value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
    {
        InnerHandler.AppendFormatted(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(Nullable<T> value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
        where T : struct
    {
        InnerHandler.AppendFormatted<T>(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>((string, T) namedValue, int alignment = 0, string? format = null, string? _ = null)
    {
        InnerHandler.AppendFormatted(namedValue, alignment, format);
    }
}

[InterpolatedStringHandler]
public ref struct _XC
{
    public ZLoggerInterpolatedStringHandler InnerHandler;

    public _XC(int literalLength, int formattedCount, ILogger logger, out bool enabled)
    {
        InnerHandler = new ZLoggerInterpolatedStringHandler(literalLength, formattedCount, logger, LogLevel.Critical, out enabled);
    }
    public void AppendLiteral([System.Diagnostics.CodeAnalysis.ConstantExpected]string s)
    {
        InnerHandler.AppendLiteral(s);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(T value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
    {
        InnerHandler.AppendFormatted(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(Nullable<T> value, int alignment = 0, string? format = null, [CallerArgumentExpression("value")] string? argumentName = null)
        where T : struct
    {
        InnerHandler.AppendFormatted<T>(value, alignment, format, argumentName);
    }

    public void AppendFormatted<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>((string, T) namedValue, int alignment = 0, string? format = null, string? _ = null)
    {
        InnerHandler.AppendFormatted(namedValue, alignment, format);
    }
}