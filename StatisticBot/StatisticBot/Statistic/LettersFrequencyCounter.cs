using StatisticBot.Statistic.Base;

namespace StatisticBot.Statistic
{
    public class LettersFrequencyCounter : FrequencyCounter
    {
        protected override bool IsCountedCharacter(char character) => char.IsLetter(character);
    }
}
