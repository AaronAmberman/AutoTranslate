using System;
using System.IO;

namespace AutoTranslate
{
    internal class Logger
    {
        private bool logRolled = false;

        /// <summary>Gets or sets the absolute path for the log file.</summary>
        public string LogFile { get; set; }

        /// <summary>Gets or sets the log file size, in bytes, limit before the log file is rolled.</summary>
        public long LogRollSize { get; set; } = 102400; // 100 KB by default

        /// <summary>Initializes a new instance of the <see cref="Logger"/> class.</summary>
        public Logger()
        {
        }

        private void EnsureLogFile()
        {
            if (string.IsNullOrWhiteSpace(LogFile))
            {
                throw new ArgumentNullException(nameof(LogFile), "The LogFile cannot be null, empty or consist of whitespace characters only.");
            }
        }

        private void RollLogFileIfNeeded()
        {
            if (File.Exists(LogFile))
            {
                try
                {
                    FileInfo file = new FileInfo(LogFile);

                    if (file.Length > LogRollSize)
                    {
                        string nameAddition = DateTime.Now.ToString("+MM-dd-yyyy+hh.mm.ss");
                        string extension = Path.GetExtension(file.Name);
                        string newName = Path.GetFileNameWithoutExtension(file.Name) + nameAddition + extension;
                        string path = file.DirectoryName;
                        string absolutePath = Path.Combine(path, newName);

                        file.CopyTo(absolutePath);

                        logRolled = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Unable to roll the log file.{Environment.NewLine}{ex}");
                }
            }
        }

        private void WriteToLog(string logLevel, string message)
        {
            try
            {
                FileStream fs = null;

                if (logRolled)
                {
                    fs = new FileStream(LogFile, FileMode.Truncate, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(LogFile, FileMode.Append, FileAccess.Write);
                }

                StreamWriter writer = new StreamWriter(fs);

                string date = DateTime.Now.ToString("MM/dd/yyyy-hh:mm:ss");

                writer.WriteLine($"{date}|{logLevel}|{message}");

                writer.Close();
                fs.Close();

                writer.Dispose();
                fs.Dispose();

                if (logRolled)
                {
                    logRolled = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Unable to write to the log file.{Environment.NewLine}{ex}");
            }
        }

        public void Debug(string message)
        {
            EnsureLogFile();
            RollLogFileIfNeeded();

            WriteToLog("DEBUG", message);
        }

        public void Error(string message)
        {
            EnsureLogFile();
            RollLogFileIfNeeded();

            WriteToLog("ERROR", message);
        }

        public void Info(string message)
        {
            EnsureLogFile();
            RollLogFileIfNeeded();

            WriteToLog("INFO", message);
        }

        public void Warning(string message)
        {
            EnsureLogFile();
            RollLogFileIfNeeded();

            WriteToLog("WARNING", message);
        }
    }
}
