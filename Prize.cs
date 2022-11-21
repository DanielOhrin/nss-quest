namespace Quest
{
    public class Prize
    {
        private string _text = "You won the holy grail!";

        public string ShowPrize(Adventurer adventurer)
        {
            if (adventurer.Awesomeness > 0)
            {
                return _text;
            }
            else
            {
                return "You did not earn a prize.";
            }
        }
    }
}