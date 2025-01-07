using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public record Session(
  Guid Id,
  [property: Description("The title of the session")]
  [property: MaxLength(120)]
  string Title,
  [property: Description("The speaker of the session")]
  string Speaker,
  [property: Description("The date of the session")]
  DateTime Date,
  [property: Description("The type of the session")]
  SessionType Type,
  [property: Description("The tags of the session")]
  List<string> Tags
);

[JsonConverter(typeof(JsonStringEnumConverter<SessionType>))]
public enum SessionType
{
    [Description("A session for beginners")]
    Beginner,
    [Description("A session for intermediate users")]
    Intermediate,
    [Description("A session for advanced users")]
    Advanced
}