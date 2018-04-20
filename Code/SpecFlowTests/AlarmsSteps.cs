using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecFlowTests
{
    [Binding]
    public class AlarmsSteps
    {
        private const string AlarmsKey = "ALARMS";
        private readonly ScenarioContext _context;

        public AlarmsSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given("I have set an alarm for ([0-9]{1,2}:[0-9]{2}(?:am|pm))")]
        public void IHaveSetMyAlarmFor(string time)
        {
            if (!_context.ContainsKey(AlarmsKey))
            {
                _context.Add(AlarmsKey, new List<Alarm>());
            }
            GetAlarms().Add(Alarm.CreateFromString(time));
        }

        [When("the time is ([0-9]{1,2}:[0-9]{2}(?:am|pm))")]
        public void TheTimeIs(string time)
        {
            var alarms = GetAlarms();
            foreach (var alarm in alarms)
            {
                alarm.SetTime(Alarm.GetTimeFromString(time));
            }
        }

        private List<Alarm> GetAlarms()
        {
            return _context.Get<List<Alarm>>(AlarmsKey);
        }

        [Then("the alarm for ([0-9]{1,2}:[0-9]{2}(?:am|pm)) is ((?:not )?)sounding")]
        public void TheAlarmIsSounding(string timeOfAlarm, string isSounding)
        {
            var ourAlarm = GetSpecificAlarm(timeOfAlarm);
            if (isSounding == "not ")
            {
                ourAlarm.IsSounding.Should().BeFalse();
            }
            else
            {
                ourAlarm.IsSounding.Should().BeTrue();
            }
        }

        private Alarm GetSpecificAlarm(string timeOfAlarm)
        {
            var time = Alarm.GetTimeFromString(timeOfAlarm);
            var alarms = GetAlarms();
            // find the alarm that matches the time
            var ourAlarm = alarms.FirstOrDefault(a => a.TimeOfAlarm == time);
            ourAlarm.Should().NotBeNull($"no alarm exists for {timeOfAlarm}");
            return ourAlarm;
        }

        [When("I hit the reset button on the ([0-9]{1,2}:[0-9]{2}(?:am|pm)) alarm")]
        public void IHitTheResetButtonOnTheAlarm(string timeOfAlarm)
        {
            var ourAlarm = GetSpecificAlarm(timeOfAlarm);
            ourAlarm.Reset();
        }
    }

    public class Alarm
    {
        private readonly TimeSpan _timeOfAlarm;
        private bool _isSounding = false;

        private Alarm(TimeSpan timeOfAlarm)
        {
            _timeOfAlarm = timeOfAlarm;
        }

        public TimeSpan TimeOfAlarm => _timeOfAlarm;

        public bool IsSounding => _isSounding;

        public static Alarm CreateFromString(string time)
        {
            return new Alarm(GetTimeFromString(time));
        }

        public static TimeSpan GetTimeFromString(string time)
        {
            return DateTime.ParseExact(time, "h:mmtt", CultureInfo.InvariantCulture).TimeOfDay;
        }

        public void SetTime(TimeSpan timeNow)
        {
            if (timeNow > _timeOfAlarm)
            {
                _isSounding = true;
            }
        }

        public void Reset()
        {
            _isSounding = false;
        }
    }
}
