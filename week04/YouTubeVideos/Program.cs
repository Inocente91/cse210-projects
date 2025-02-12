using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        Video video1 = new Video("Learn C# Basics", "Inocente Perez", 240);


        video1.AddComment(new Comment("Alice", "This was super helpful!"));
        video1.AddComment(new Comment("Bob", "Nice explanation!"));
        video1.AddComment(new Comment("Charlie", "Great job, keep it up!"));


        video1.ShowDetails();
    }
}

class Video
{
    public string title;
    public string author;
    public int length;
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment c)
    {
        comments.Add(c);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void ShowDetails()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Length: " + length + " sec");
        Console.WriteLine("Comments: " + GetCommentCount());

        foreach (var c in comments)
        {
            Console.WriteLine("- " + c.user + ": " + c.text);
        }
    }
}

class Comment
{
    public string user;
    public string text;

    public Comment(string user, string text)
    {
        this.user = user;
        this.text = text;
    }
}
