namespace Minesweeper.Properties
{
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    public sealed partial class Statistics
    {

        public Statistics()
        {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }

        public StatisticPerType Mini() => new("Mini", this);

        public StatisticPerType Beginner() => new("Beginner", this);

        public StatisticPerType Intermediate() => new("Intermediate", this);

        public StatisticPerType Expert() => new("Expert", this);

        public StatisticPerType Custom() => new("Custom", this);

        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            // Add code to handle the SettingChangingEvent event here.
        }

        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Add code to handle the SettingsSaving event here.
        }
    }

    public sealed class StatisticPerType
    {
        private readonly string _statisticPrefix;
        private readonly Statistics _statistics;

        public static string[] StatisticPrefixes { get; } = { "Mini", "Beginner", "Intermediate", "Expert", "Custom" };

        public StatisticPerType(string statisticPrefix, Statistics statistics)
        {
            if (!StatisticPrefixes.Contains(statisticPrefix))
                throw new ArgumentException($"Invalid statistic prefix '{statisticPrefix}'. Available prefixes: '{string.Join(", ", StatisticPrefixes)}'");

            _statisticPrefix = statisticPrefix;
            _statistics = statistics;
        }

        public int GamesWon
        {
            get => (int)_statistics[$"{_statisticPrefix}_GamesWon"];
            set => _statistics[$"{_statisticPrefix}_GamesWon"] = value;
        }

        public int GamesLost
        {
            get => (int)_statistics[$"{_statisticPrefix}_GamesLost"];
            set => _statistics[$"{_statisticPrefix}_GamesLost"] = value;
        }

        public int TotalMines
        {
            get => (int)_statistics[$"{_statisticPrefix}_TotalMines"];
            set => _statistics[$"{_statisticPrefix}_TotalMines"] = value;
        }

        public TimeSpan TotalTime
        {
            get => (TimeSpan)_statistics[$"{_statisticPrefix}_TotalTime"];
            set => _statistics[$"{_statisticPrefix}_TotalTime"] = value;
        }

        public TimeSpan ShortTime
        {
            get => (TimeSpan)_statistics[$"{_statisticPrefix}_ShortTime"];
            set => _statistics[$"{_statisticPrefix}_ShortTime"] = value;
        }
    }
}
