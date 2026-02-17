namespace HelmerDemo.BlazorServerTwo.Application.Business.Clock.MVVM;

public class ClockModel
{
     /// <summary>
    /// Gets the hours
    /// </summary>
    public int Hours { get; private set; }

    /// <summary>
    /// Gets the minutes
    /// </summary>
    public int Minutes { get; private set; }

    /// <summary>
    /// Gets the seconds
    /// </summary>
    public int Seconds { get; private set; }

    /// <summary>
    /// Creates a new digital time
    /// </summary>
    /// <param name="dateTime">The DateTime</param>
    public ClockModel(DateTime dateTime)
    {
        Hours = dateTime.Hour; Minutes = dateTime.Minute; Seconds = dateTime.Second;
    }
    
    /// <summary>
    /// Creates a new digital time   
    /// </summary>
    /// <param name="hours"></param>
    /// <param name="minutes"></param>
    /// <param name="seconds"></param>
    public ClockModel(int hours, int minutes, int seconds)
    {
        Validate(hours, minutes, seconds);

        //Logic

        if (seconds == 60)
        {
            seconds = 0;
            minutes++;
        }

        if (minutes == 60)
        {
            minutes = 0;
            hours++;
        }

        if (hours == 24)
        {
            hours = 0;
        }

        // Set

        Hours = hours; Minutes = minutes; Seconds = seconds;
    }
    
    public ClockModel AddSecond()
    {
        Seconds++;
        if (Seconds == 60)
        {
            Seconds = 0;
            Minutes++;
        }

        if (Minutes == 60)
        {
            Minutes = 0;
            Hours++;
        }

        if (Hours == 24)
        {
            Hours = 0;
        }
        
        return this;
    }
    
    /// <summary>
    /// Validates the input to hours, minutes and second
    /// </summary>
    /// <param name="hours"></param>
    /// <param name="minutes"></param>
    /// <param name="seconds"></param>
    /// <exception cref="ArgumentException"></exception>
    private static void Validate(int hours, int minutes, int seconds)
    {
        if (hours >= 24)
        {
            throw new ArgumentException("Invalid time");
        }

        if (minutes >= 60)
        {
            throw new ArgumentException("Invalid time");
        }

        if (seconds > 60)
        {
            throw new ArgumentException("Invalid time");
        }
    }
}