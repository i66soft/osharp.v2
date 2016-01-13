﻿// -----------------------------------------------------------------------
//  <copyright file="Log4NetLog.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-02-08 15:51</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using log4net.Core;

using OSharp.Utility.Logging;

using ILogger = log4net.Core.ILogger;


namespace OSharp.Demo.Web.Logging
{
    /// <summary>
    /// log4net 日志输出者适配类
    /// </summary>
    internal class Log4NetLog : LogBase
    {
        private static readonly Type DeclaringType = typeof(Log4NetLog);
        private readonly ILogger _logger;

        /// <summary>
        /// 初始化一个<see cref="Log4NetLog"/>类型的新实例
        /// </summary>
        public Log4NetLog(ILoggerWrapper wrapper)
        {
            _logger = wrapper.Logger;
        }

        #region Overrides of LogBase

        /// <summary>
        /// 获取日志输出处理委托实例
        /// </summary>
        /// <param name="level">日志输出级别</param>
        /// <param name="message">日志消息</param>
        /// <param name="exception">日志异常</param>
        protected override void Write(LogLevel level, object message, Exception exception, bool isData = false)
        {
            Level log4NetLevel = GetLevel(level);
            _logger.Log(DeclaringType, log4NetLevel, message, exception);
        }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Trace"/>级别的日志
        /// </summary>
        public override bool IsTraceEnabled { get { return _logger.IsEnabledFor(Level.Trace); } }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Debug"/>级别的日志
        /// </summary>
        public override bool IsDebugEnabled { get { return _logger.IsEnabledFor(Level.Debug); } }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Info"/>级别的日志
        /// </summary>
        public override bool IsInfoEnabled { get { return _logger.IsEnabledFor(Level.Info); } }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Warn"/>级别的日志
        /// </summary>
        public override bool IsWarnEnabled { get { return _logger.IsEnabledFor(Level.Warn); } }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Error"/>级别的日志
        /// </summary>
        public override bool IsErrorEnabled { get { return _logger.IsEnabledFor(Level.Error); } }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Fatal"/>级别的日志
        /// </summary>
        public override bool IsFatalEnabled { get { return _logger.IsEnabledFor(Level.Fatal); } }

        public override bool IsDataLogging
        {
            get
            {
                return false;
            }
        }

        #endregion

        private static Level GetLevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.All:
                    return Level.All;
                case LogLevel.Trace:
                    return Level.Trace;
                case LogLevel.Debug:
                    return Level.Debug;
                case LogLevel.Info:
                    return Level.Info;
                case LogLevel.Warn:
                    return Level.Warn;
                case LogLevel.Error:
                    return Level.Error;
                case LogLevel.Fatal:
                    return Level.Fatal;
                case LogLevel.Off:
                    return Level.Off;
                default:
                    return Level.Off;
            }
        }
        
    }
}