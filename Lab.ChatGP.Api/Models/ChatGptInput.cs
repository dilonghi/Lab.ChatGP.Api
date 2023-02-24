namespace Lab.ChatGP.Api.Models
{
    public class ChatGptInput
    {
        public ChatGptInput(string prompt)
        {
            this.model = "text-davinci-003";
            this.prompt = prompt;
            this.max_tokens = 100;
            this.temperature = 0.2m;
        }

        public string model { get; set; }
        public string prompt { get; set; }
        public int max_tokens { get; set; }
        public decimal temperature { get; set; }
    }

}
