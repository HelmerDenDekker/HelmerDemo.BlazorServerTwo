namespace HelmerDemo.BlazorServerTwo.Shared;

/// <summary>
///     This class returns a result on a query-type function
/// </summary>
/// <typeparam name="TValue">Any class returning an object as a result from the query</typeparam>
public class ValueResult<TValue>
{
	private readonly TValue? _value;

	protected ValueResult(Result result, TValue value)
	{
		_value = value;
		Result = result;
	}

	protected ValueResult(Result result)
	{
		Result = result;
	}

	public Result Result { get; }

	public TValue Value => _value ?? throw new InvalidOperationException("The value of a failure result can not be accessed");

	public static ValueResult<TValue> Created => new(Result.Created);

	public static ValueResult<TValue> NoContent => new(Result.NoContent);

	public static ValueResult<TValue> BadRequest => new(Result.BadRequest);

	public static ValueResult<TValue> Unauthorized => new(Result.Unauthorized);

	public static ValueResult<TValue> Forbidden => new(Result.Forbidden);

	public static ValueResult<TValue> NotFound => new(Result.NotFound);

	public static ValueResult<TValue> NotAcceptable => new(Result.NotAcceptable);

	public static ValueResult<TValue> Timeout => new(Result.Timeout);

	public static ValueResult<TValue> Conflict => new(Result.Conflict);

	public static ValueResult<TValue> InsecureUrl => new(Result.InsecureUrl);

	public static ValueResult<TValue> UnavailableForLegalReasons => new(Result.UnavailableForLegalReasons);

	public static ValueResult<TValue> InternalServerError => new(Result.InternalServerError);

	public static ValueResult<TValue> NotImplemented => new(Result.NotImplemented);

	public static ValueResult<TValue> Ok(TValue value) => new(Result.Ok, value);
}
