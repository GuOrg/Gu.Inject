// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local
// ReSharper disable PossibleNullReferenceException
#pragma warning disable IDE0051 // Remove unused private members
namespace Gu.Inject.Benchmarks
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using BenchmarkDotNet.Reports;
    using BenchmarkDotNet.Running;
    using Gu.Inject.Benchmarks.Types;
    using BindingFlags = System.Reflection.BindingFlags;

    public static class Program
    {
        public static void Main()
        {
            foreach (var summary in RunSingle<NewAndGetGraph50>())
            {
                CopyResult(summary);
            }
        }

        private static IEnumerable<Summary> RunAll() => new BenchmarkSwitcher(typeof(Program).Assembly).RunAll();

        private static IEnumerable<Summary> RunSingle<T>() => new[] { BenchmarkRunner.Run<T>() };

        private static void CopyResult(Summary summary)
        {
            var name = summary.Title.Split('.').LastOrDefault()?.Split('-').FirstOrDefault();
            if (name is null)
            {
                Console.WriteLine("Did not find name in: " + summary.Title);
                Console.WriteLine("Press any key to exit.");
                _ = Console.ReadKey();
                return;
            }

            var pattern = $"Gu.Inject.Benchmarks.{name}-report-github.md";
            var sourceFileName = Directory.EnumerateFiles(summary.ResultsDirectoryPath, pattern)
                                          .SingleOrDefault();
            if (sourceFileName is null)
            {
                Console.WriteLine("Did not find a file matching the pattern: " + pattern);
                Console.WriteLine("Press any key to exit.");
                _ = Console.ReadKey();
                return;
            }

            var destinationFileName = Path.ChangeExtension(FindCsFile(), ".md");
            Console.WriteLine($"Copy:");
            Console.WriteLine($"Source: {sourceFileName}");
            Console.WriteLine($"Target: {destinationFileName}");
            File.Copy(sourceFileName, destinationFileName, overwrite: true);

            string FindCsFile()
            {
                return Directory.EnumerateFiles(
                                    AppDomain.CurrentDomain.BaseDirectory!.Split(new[] { "\\bin\\" }, StringSplitOptions.RemoveEmptyEntries).First(),
                                    $"{name}.cs",
                                    SearchOption.AllDirectories)
                                .Single();
            }
        }

#pragma warning disable IDE0051 // Remove unused private members
        private static void CodeGen()
#pragma warning restore IDE0051 // Remove unused private members
        {
            var builder = new StringBuilder();
            foreach (var type in typeof(Graph500).GetNestedTypes())
            {
                var ctor = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                               .Single();
#pragma warning disable CA1305 // Specify IFormatProvider
                builder.AppendLine($".Bind(c => new {type.Name}({string.Join(", ", ctor.GetParameters().Select(x => $"c.Get<{x.ParameterType.Name}>()"))}))");
#pragma warning restore CA1305 // Specify IFormatProvider
            }

            // ReSharper disable once UnusedVariable
            var code = builder.ToString();
        }
    }
}
