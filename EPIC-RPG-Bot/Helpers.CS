using NAudio.Utils;
using NAudio.Wave;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BOT
{
    public static class Helpers
    {
        public static string RandomIntAsString()
        {
            Random random = new Random();
            return random.Next(int.MaxValue).ToString();
        }

        public static void PrintRuntimeStats()
        {
            Console.WriteLine(new StringBuilder()
                .Append($"{DateTime.Now} :: {Utility.Runtime.Elapsed} Elapsed")
                .Append(" & ")
                .Append($"{TimeSpan.FromHours(ENV.RuntimeInHours) - Utility.Runtime.Elapsed} Remaining")
                .ToString());
        }

        public static void PrintDashes(int amount)
        {
            for (int i = 0; i < amount; i++)
                Console.Write("-");

            Console.WriteLine();
        }

        public static void PrintEnclosedInNewLines(string content)
        {
            Console.Write(Environment.NewLine);
            Console.Write(content);
            Console.Write(Environment.NewLine);
        }

        public static async void PlayAlert()
        {
            using var audioFile = new AudioFileReader("Assets" + Path.DirectorySeparatorChar + "Epic-Guard-Alert.MP3");
            using var outputDevice = new WaveOutEvent();

            outputDevice.Init(audioFile);
            outputDevice.Play();

            // Asynchronously Wait Until Playback Completes
            if (outputDevice.PlaybackState == PlaybackState.Playing)
                await Task.Delay(audioFile.TotalTime);
        }
    }
}
