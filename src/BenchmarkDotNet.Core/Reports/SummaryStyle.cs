using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Columns;

namespace BenchmarkDotNet.Reports
{
    public class SummaryStyle : ISummaryStyle
    {
        public bool PrintUnitsInHeader { get; set; } = false;
        public bool PrintUnitsInContent { get; set; } = true;
        public SizeUnit SizeUnit { get; set; } = null;
        public TimeUnit TimeUnit { get; set; } = null;
        public string DecimalFormat { get; set; } = null;

        public static SummaryStyle Default => new SummaryStyle()
        {
            PrintUnitsInHeader = false,
            PrintUnitsInContent = true,
            SizeUnit = null,
            TimeUnit = null
        };

        public ISummaryStyle WithTimeUnit(TimeUnit timeUnit)
        {
            return new SummaryStyle()
            {
                PrintUnitsInHeader = this.PrintUnitsInHeader,
                PrintUnitsInContent = this.PrintUnitsInContent,
                SizeUnit = this.SizeUnit,
                TimeUnit = timeUnit,
                DecimalFormat = this.DecimalFormat,
            };
        }

        public ISummaryStyle WithSizeUnit(SizeUnit sizeUnit)
        {
            return new SummaryStyle()
            {
                PrintUnitsInHeader = this.PrintUnitsInHeader,
                PrintUnitsInContent = this.PrintUnitsInContent,
                SizeUnit = sizeUnit,
                TimeUnit = this.TimeUnit,
                DecimalFormat = this.DecimalFormat,
            };
        }

        public ISummaryStyle WithDecimalFormat(int count)
        {
            var decimalFormat = "F" + count.ToString();
            return new SummaryStyle()
            {
                PrintUnitsInHeader = this.PrintUnitsInHeader,
                PrintUnitsInContent = this.PrintUnitsInContent,
                SizeUnit = this.SizeUnit,
                TimeUnit = this.TimeUnit,
                DecimalFormat = decimalFormat,
            };
        }

        internal static int GetBestDecimalCount(double[] timeData)
        {
            if (timeData.Length == 0)
                return 0;
            double smallestNumber = timeData.Min();

            var asString = smallestNumber.ToString();
            var digitsBeforeSeparator = asString.IndexOf('.');
            if (digitsBeforeSeparator == -1)
                return 1;
            return 4 - digitsBeforeSeparator;
            //var digitsAfterSeparator = asString.Length - digitsBeforeSeparator - 1;


        }
    }
}
