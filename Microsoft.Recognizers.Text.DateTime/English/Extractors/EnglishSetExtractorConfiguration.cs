﻿using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.DateTime.English
{
    public class EnglishSetExtractorConfiguration : ISetExtractorConfiguration
    {
        public static readonly Regex UnitRegex =
            new Regex(
                @"(?<unit>years|year|months|month|weeks|week|days|day|hours|hour|hrs|hr|h|minutes|minute|mins|min|seconds|second|secs|sec)\b",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex PeriodicRegex = new Regex(
            @"\b(?<periodic>daily|monthly|weekly|biweekly|yearly|annually|annual)\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EachUnitRegex = new Regex(
            $@"(?<each>(each|every)\s*{UnitRegex})", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EachPrefixRegex = new Regex(@"(?<each>(each|every)\s*$)",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex LastRegex = new Regex(@"(?<last>last|this|next)",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EachDayRegex = new Regex(@"^\s*(each|every)\s*day\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public EnglishSetExtractorConfiguration()
        {
            DurationExtractor = new BaseDurationExtractor(new EnglishDurationExtractorConfiguration());
            TimeExtractor = new BaseTimeExtractor(new EnglishTimeExtractorConfiguration());
            DateExtractor = new BaseDateExtractor(new EnglishDateExtractorConfiguration());
            DateTimeExtractor = new BaseDateTimeExtractor(new EnglishDateTimeExtractorConfiguration());
            DatePeriodExtractor = new BaseDatePeriodExtractor(new EnglishDatePeriodExtractorConfiguration());
            TimePeriodExtractor = new BaseTimePeriodExtractor(new EnglishTimePeriodExtractorConfiguration());
            DateTimePeriodExtractor = new BaseDateTimePeriodExtractor(new EnglishDateTimePeriodExtractorConfiguration());
        }

        public IExtractor DurationExtractor { get; }

        public IExtractor TimeExtractor { get; }

        public IExtractor DateExtractor { get; }

        public IExtractor DateTimeExtractor { get; }

        public IExtractor DatePeriodExtractor { get; }

        public IExtractor TimePeriodExtractor { get; }

        public IExtractor DateTimePeriodExtractor { get; }

        Regex ISetExtractorConfiguration.LastRegex => LastRegex;

        Regex ISetExtractorConfiguration.EachPrefixRegex => EachPrefixRegex;

        Regex ISetExtractorConfiguration.PeriodicRegex => PeriodicRegex;

        Regex ISetExtractorConfiguration.EachUnitRegex => EachUnitRegex;

        Regex ISetExtractorConfiguration.EachDayRegex => EachDayRegex;

        Regex ISetExtractorConfiguration.BeforeEachDayRegex => null;
    }
}