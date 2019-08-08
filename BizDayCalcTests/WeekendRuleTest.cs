using System;
using System.Collections.Generic;
using Xunit;
using BizDayCalc;
using System.Linq;

namespace BizDayCalcTests
{
    public class WeekendRuleTest
    {
        [Fact]
        public void TestCheckIsBusinessDay()
        {
            var rule = new WeekendRule();
            Assert.True(rule.CheckIsBusinessDay(new DateTime(2016, 6, 27)));
            Assert.False(rule.CheckIsBusinessDay(new DateTime(2016, 6, 26)));
        }

        [Theory]
        [InlineData("2016-06-27")] // Monday
        [InlineData("2016-03-01")] // Tuesday
        [InlineData("2016-09-20")] // Wednesday
        public void IsBusinessDay(string date)
        {
            var rule = new WeekendRule();
            Assert.True(rule.CheckIsBusinessDay(DateTime.Parse(date)));
        }

        [Theory]
        [InlineData("2016-06-26")] // Sunday
        [InlineData("2016-11-12")] // Saturday
        public void IsNotBusinessDay(string date)
        {
            var rule = new WeekendRule();
            Assert.False(rule.CheckIsBusinessDay(DateTime.Parse(date)));
        }

        [Theory]
        [MemberData(nameof(Days))]
        public void TestCheckIsBusinessDay2(bool expected, DateTime date)
        {
            var rule = new WeekendRule();
            Assert.Equal(expected, rule.CheckIsBusinessDay(date));
        }

        public static IEnumerable<object[]> Days
        {
            get 
            {
                yield return new object[] {true, new DateTime(2016, 6, 27)};
                yield return new object[] {true, new DateTime(2016, 3, 1)};
                yield return new object[] {false, new DateTime(2016, 6, 26)};
                yield return new object[] {false, new DateTime(2016, 11, 12)};
            }
        }
    }


}
