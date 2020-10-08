using System;
using System.Net;

namespace ProcTest
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Main App");

            var EntryPoint = typeof(ProcTest.Sub.Program).Assembly.Location;
            {
                var find = ".dll";
                var replace = ".exe";

                if (EntryPoint.EndsWith(find, StringComparison.InvariantCultureIgnoreCase))
                {
                    EntryPoint = EntryPoint[..^replace.Length] + replace;
                }

            }

            


            var PSI = new System.Diagnostics.ProcessStartInfo()
            {
                FileName = EntryPoint,
                UseShellExecute = true,
            };

            var Proc = System.Diagnostics.Process.Start(PSI);

            Console.WriteLine("Waiting on Process to Exit");
            Proc.WaitForExit();
            Console.WriteLine("Exited");

            Console.ReadLine();


        }
    }
}
