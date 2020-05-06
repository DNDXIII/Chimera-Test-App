using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


// We are using a simple user, not the Identity User from the core library
public class User
{
    [Key]
    public long UserId { get; set; }

    public string UserName { get; set; }

    // We use a simple list in this example but this could be expanded.
    // If we had only a single level (i.e. tetris) then this could be an ordered data structure to ease the retrieval 
    //   of a leaderboard.
    public List<Score> Scores { get; set; } = new List<Score>();


    // We could always save the highest score of the user to facilitate the leaderboard process.
    // This would however have to be changed in the case that we have multiple levels.
    // public Score HighestScore { get; set; }

}