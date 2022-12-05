using System;
using System.IO;

namespace Model
{
    public static class DotEnv
    {
        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($".env file not found: {filePath}");
            }

            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                {
                    continue;
                }

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }

        public static string Get(string key) =>
            Environment.GetEnvironmentVariable(key) ??
            throw new NullReferenceException($".env variable not defined: {key}");
    }
}