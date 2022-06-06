namespace WebDriverTests.Models
{
    public class Letter
    {
        public string EmailReciever { get; set; }
        public string LettersText { get; set; }

        public Letter(string emailReciever, string lettersText)
        {
            EmailReciever = emailReciever;
            LettersText = lettersText;
        }
    }
}
