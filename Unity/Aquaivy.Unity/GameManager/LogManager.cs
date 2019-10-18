using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aquaivy.Core.Common;
using Aquaivy.Core.Logs;
using UnityEngine;

namespace Aquaivy.Unity
{
    /// <summary>
    /// 
    /// </summary>
    public class LogManager : Singleton<LogManager>
    {
        private LogMessageType LogLevel;
        private string logDir = Application.persistentDataPath + "/LocalLog";
        private string logIndexPath = Application.persistentDataPath + "/LocalLog/index.txt";

        private LogManager() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        public void Init(LogMessageType logLevel)
        {
            this.LogLevel = logLevel;

            AddLogAppender();
        }

        private void AddLogAppender()
        {
            ReadLogLevelFromLocal();

            //Unity
            var unitylog = new UnityAppender { Level = LogLevel };
            Log.AddAppender(unitylog);

            if (LogLevel <= LogMessageType.MSG_INFO)
            {
                //Full Unity Log
                AddFullUnityLogReceivedHandler();
            }
            else
            {
                AddFileLogAppender(LogLevel);
            }
        }

        private void ReadLogLevelFromLocal()
        {

        }


        private int GetLogIndex()
        {
            int index = 1;
            if (!File.Exists(logIndexPath))
                return index;

            try
            {
                index = Convert.ToInt32(File.ReadAllText(logIndexPath, Encoding.UTF8));
                return index;
            }
            catch (Exception ex)
            {
                Debug.Log("LogManager.GetLogIndex()");
                return index;
            }
        }

        private void AddLogIndex()
        {
            int index = GetLogIndex();

            File.WriteAllText(logIndexPath, (index + 1).ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// 缓存本地log
        /// </summary>
        private void AddFileLogAppender(LogMessageType level)
        {
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            int index = GetLogIndex();

            string file = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            file = string.Format("{0:D3}_{1}.log", index, file);

            string logPath = logDir + "/" + file;

            if (File.Exists(logPath))
                File.Delete(logPath);

            Log.ConfigLogFile(logPath, level);

            Log.Info("AddFileLogAppender:  " + logPath);
        }

        /// <summary>
        /// 缓存所有unity log
        /// </summary>
        private void AddFullUnityLogReceivedHandler()
        {
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            int index = GetLogIndex();

            string file = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            file = string.Format("{0:D3}_{1}_Full.log", index, file);

            string logPath = logDir + "/" + file;

            if (File.Exists(logPath))
                File.Delete(logPath);

            Log.Info("AddFullUnityLogReceivedHandler:  " + logPath);

            Application.logMessageReceived += (condition, stackTrace, type) =>
            {
                using (StreamWriter writer = File.AppendText(logPath))
                {
                    writer.WriteLine($"[{DateTime.Now.ToString("hh:mm:ss.fff")}] {condition.ToString()}");
                }
            };
        }
    }
}
