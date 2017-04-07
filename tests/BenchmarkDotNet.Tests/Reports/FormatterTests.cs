using BenchmarkDotNet.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BenchmarkDotNet.Tests.Reports
{
    public class FormatterTests
    {
        private readonly ITestOutputHelper output;

        public FormatterTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("ah","oh")]
        [Theory]
        [InlineData("123.45, 1234.56, 1234.567, 1234.5678", "F1")]
        [InlineData("12.3, 123.45, 1234.567", "F1")]
        [InlineData(".123, 1.23, 12.3, 123.4, 1234", "F1")]
        [InlineData(".12, 1.2, 12", "F1")]
        public void CorrectFormatForDecimalNumbers(string rawValues, string format)
        {
            var values = rawValues.Split(',').Select(n => Double.Parse(n)).ToArray();
            var decimalCount = SummaryStyle.GetBestDecimalCount(values);
            var style = SummaryStyle.Default.WithDecimalFormat(decimalCount);
            var formatted = values.Select(n => n.ToString(style.DecimalFormat));
        }
    }
}
