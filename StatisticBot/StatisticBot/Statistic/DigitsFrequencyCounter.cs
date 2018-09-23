using StatisticBot.Statistic.Base;

namespace StatisticBot.Statistic
{
    public class DigitsFrequencyCounter : FrequencyCounter
    {
        protected override bool IsCountedCharacter(char character) => char.IsDigit(character);
    }
}
