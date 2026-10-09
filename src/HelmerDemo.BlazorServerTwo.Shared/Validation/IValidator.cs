using System.ComponentModel.DataAnnotations;

namespace HelmerDemo.BlazorServerTwo.Shared.Validation;

public interface IValidator<T>
{
	List<ValidationResult> Results { get; }
	bool IsValid(T model);
}
