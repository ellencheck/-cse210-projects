public class Comment
{
    public string User { get; set; }
    public string Text { get; set; }

    public Comment(string user, string text)
    {
        User = user;
        Text = text;
    }
}
