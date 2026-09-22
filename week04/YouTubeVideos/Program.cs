/*
 * ============================================================================
 *  YOUTUBE VIDEOS  -  CSE 210  -  Week 04
 * ============================================================================
 *
 *  CORE REQUIREMENTS
 *    - A Comment class stores a commenter's name and comment text.
 *    - A Video class stores a title, author, length (seconds), and a list
 *      of Comments, plus a method that returns the comment count directly
 *      from the backing list (GetCommentCount).
 *    - The program creates 4 videos, each with 3-4 comments, puts them in
 *      a list, and iterates through it to display each video's title,
 *      author, length, comment count, and every comment. No user input.
 * ============================================================================
 */

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learning C# for Beginners", "Code Academy", 620);
        video1.AddComment(new Comment("Kenneth", "This video helped me understand C# better."));
        video1.AddComment(new Comment("Daniel", "Very useful explanation."));
        video1.AddComment(new Comment("Sarah", "I learned a lot from this video."));

        Video video2 = new Video("How to Build a Website", "Web Dev School", 845);
        video2.AddComment(new Comment("Michael", "The HTML explanation was great."));
        video2.AddComment(new Comment("Grace", "I am going to try this project."));
        video2.AddComment(new Comment("John", "Thanks for sharing this tutorial."));
        video2.AddComment(new Comment("David", "Very clear and easy to follow."));

        Video video3 = new Video("Introduction to JavaScript", "Programming World", 735);
        video3.AddComment(new Comment("James", "JavaScript makes more sense now."));
        video3.AddComment(new Comment("Linda", "Great beginner tutorial."));
        video3.AddComment(new Comment("Chris", "The examples were helpful."));

        Video video4 = new Video("CSS Responsive Design", "Frontend Learning", 910);
        video4.AddComment(new Comment("Peter", "Responsive design is very important."));
        video4.AddComment(new Comment("Mary", "I enjoyed this tutorial."));
        video4.AddComment(new Comment("Alex", "The examples were easy to understand."));
        video4.AddComment(new Comment("Samuel", "This helped me with my website project."));

        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
