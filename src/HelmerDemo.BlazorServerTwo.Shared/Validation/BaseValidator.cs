using System.ComponentModel.DataAnnotations;

namespace HelmerDemo.BlazorServerTwo.Shared.Validation;

public class BaseValidator<T> : IValidator<T>
{
	public List<ValidationResult> Results { get; } = new();

	public virtual bool IsValid(T model)
	{
		if (model == null)
			return false;

		Validate(model);

		return Results.Count == 0;
	}

	private void Validate(T model)
	{
		var context = new ValidationContext(model ?? throw new ArgumentNullException(nameof(model)));
		Validator.TryValidateObject(model, context, Results, true);
	}
}
