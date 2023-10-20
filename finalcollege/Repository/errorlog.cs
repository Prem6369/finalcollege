﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace finalcollege.Repository
{
    public class errorlog
    {
        public static void LogError(Exception exception)
        {
            try
            {
                string logPath = @"C:\Users\premk\OneDrive\Desktop\Errorlog.txt";

                // Create or open the error log file for appending
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine($"Error occurred at {DateTime.Now}");
                    sw.WriteLine($"Message: {exception.Message}");
                    sw.WriteLine($"Stack Trace: {exception.StackTrace}");
                    sw.WriteLine(new string('-', 50)); // Separator for different errors
                }
            }
            catch (Exception logEx)
            {
                // Handle any exceptions that occur while logging, you can log them to the console or another log file.
                Console.WriteLine($"An error occurred while logging: {logEx.Message}");
            }
        }
    }
}