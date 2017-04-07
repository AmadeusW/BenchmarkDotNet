using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Columns;

namespace BenchmarkDotNet.Reports
{
    public interface ISummaryStyle
    {
        bool PrintUnitsInHeader { get; }
        bool PrintUnitsInContent { get; }
        SizeUnit SizeUnit { get; }
        TimeUnit TimeUnit { get; }
        string DecimalFormat { get; set; }

        ISummaryStyle WithTimeUnit(TimeUnit timeUnit);
        ISummaryStyle WithSizeUnit(SizeUnit sizeUnit);
        ISummaryStyle WithDecimalFormat(int count);
    }
}