using System;

class Program
{
    static void Main()
    {
        Video video1 = new Video("Leanr C# Basics", "Inocente Perez", 240);


        video1.AddComment(new Comment("Alice", "This was super helpfulls!"));
        video1.AddComment(new Comment("Bob", "Nice explanation!"));
        video1.AddComment(new Comment("Charlie", "Great job, keep it up!"));


        video1.ShowDetails();
    }
}

class Video
{
    public string title;
    public string author;
    public int Length;
    private List<Comment> comments;


    public Video(string title, string author, int length);
    {
        this.title = tittle;
        this.author = author;
        this.length = lenght;
        comments = new List<Comment>();
    }

    
}