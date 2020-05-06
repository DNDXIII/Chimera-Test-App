// We use this as a class and not a simple int list in the user so that it could be further expanded
//   to have different levels, modifiers, etc

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Score
{
    [Key]
    public long ScoreId { get; set; }

    public int FinalScore { get; set; }

    // public Level ScoreLevel ...
    public User User { get; set; }

}