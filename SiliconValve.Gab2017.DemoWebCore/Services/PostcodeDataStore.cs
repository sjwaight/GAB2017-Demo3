using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SiliconValve.Gab2017.DemoWebCore.Services
{
    public class PostcodeDataStore
    {
        private static List<PostcodeEntry> dataSource;

        public static List<PostcodeEntry> Instance
        {
            get
            {
                if (dataSource == null || dataSource.Count == 0)
                {
                    dataSource = File.ReadAllLines(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "appdata/data.csv"))
                                           .Skip(1)
                                           .Select(v => PostcodeEntry.FromCsv(v))
                                           .ToList();
                }

                return dataSource;
            }
        }
    }
}
