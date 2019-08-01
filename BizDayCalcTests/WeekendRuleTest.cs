using System;
using Xunit;
using BizDayCalc;

namespace BizDayCalcTests
{
    public class UnitTest1
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
    }


}
