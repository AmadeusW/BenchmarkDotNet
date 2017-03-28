﻿using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace BenchmarkDotNet.Columns
{
    public interface IColumn
    {
        /// <summary>
        /// An unique identificator of the column.
        /// <remarks>If there are several columns with the same Id, only one of them will be shown in the summary.</remarks>
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Display column title in the summary.
        /// </summary>
        string ColumnName { get; }

        /// <summary>
        /// Value in this column formatted using the default style.
        /// </summary>
        string GetValue(Summary summary, Benchmark benchmark);

        /// <summary>
        /// Value in this column formatted using the specified style.
        /// </summary>
        string GetValue(Summary summary, Benchmark benchmark, ISummaryStyle style);

        bool IsDefault(Summary summary, Benchmark benchmark);

        bool IsAvailable(Summary summary);

        bool AlwaysShow { get; }

        ColumnCategory Category { get; }

        /// <summary>
        /// Defines order of column in the same category.
        /// </summary>
        int PriorityInCategory { get; }

        /// <summary>
        /// Defines how to format column's value
        /// </summary>
        UnitType UnitType { get; }
    }
}
