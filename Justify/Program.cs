using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace Justify
{
    class Program
    {
        private static void PrintRightJustify(IEnumerable<List<string>> ll)
        {
            if (!ll.Any() || !ll.Any())
            {
                return;
            }
            var itemsPerLine = ll.First().Count();
            var maxArray = new int[itemsPerLine];


            foreach (var line in ll)
            {
                var count = 0;
                foreach (var column in line)
                {
                    if (column.Length > maxArray[count])
                    {
                        maxArray[count] = column.Length;
                    }
                    count++;
                }
            }

            foreach (var line in ll)
            {
                var count = 0;
                var toPrint = string.Join(" ", line.Select(x => $"{new string(' ', maxArray[count] - x.Length)}{x}"));
                Console.WriteLine(toPrint);
            }
        }

        private static void Main(string[] args)
        {
            try
            {
                var l = new List<List<string>>();
                var r = new Random();
                var ll = Enumerable.Range(1, 100).Select(x => Enumerable.Range(1, 10).Select(y => r.Next(10_000_000).ToString()).ToList()).ToList();
                Justify(ll);
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine($"{progname} Error: {ex.Message}");
            }

        }
    }
}
