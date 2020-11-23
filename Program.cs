using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace EndomondoJsonToSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("local.appsettings.json", optional: true)
                .AddCommandLine(args)
                .Build();

            var context = new EndomondoContext(config);
            var path = config["WorkoutPath"];

            Console.WriteLine("Hi, going to read json files from here: " + path);

            var files = Directory.GetFiles(path);
            System.Console.WriteLine("Looks like there are "+files.Length+ " files in that directory.");

            var workouts = GetWorkouts(files);
            Console.WriteLine($"Found {workouts.Count} workout files");
            //var first400 = workouts.Take(400);
            //context.Workouts.AddRange(first400);
            //context.SaveChanges();
            //Console.WriteLine("Saved 400 things");
        
            var next100 = workouts.Skip(400).Take(100);
            context.Workouts.AddRange(next100);
            context.SaveChanges();
            System.Console.WriteLine("Saved the next 100 things");
        }

        private static List<EndomondoWorkout> GetWorkouts(string[] files)
        {
            var jsonFiles = from f in files
                            where f.EndsWith(".json")
                            select f;
            var extractor = new WorkoutExtractor();
            var result = new List<EndomondoWorkout>();
            foreach (var item in jsonFiles)
            {
                var contents = File.ReadAllText(item);
                var workout = extractor.ExtractWithStringMagic(contents);
                result.Add(workout);
            }
            return result;
        }
    }
}
