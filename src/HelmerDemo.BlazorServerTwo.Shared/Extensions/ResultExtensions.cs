using System.Net;

namespace HelmerDemo.BlazorServerTwo.Shared.Extensions;

public static class ResultExtensions
{
	/// <summary>
	///     A successful response
	/// </summary>
	/// <param name="result"></param>
	/// <returns>true if the response was successful</returns>
	public static bool IsSuccess(this Result result)
	{
		switch (result)
		{
			case Result.Ok:
				return true;
			case Result.Created:
				return true;
			case Result.NoContent:
				return true;
			default:
				return false;
		}
	}

	/// <summary>
	///     The information message containing the generic description of the error
	/// </summary>
	/// <param name="result"></param>
	/// <returns>The information message containing the generic description of the error</returns>
	public static string Content(this Result result)
	{
		switch (result)
		{
			case Result.Ok:
				return "The request succeeded and the requested information is in the response.";
			case Result.Created:
				return "A new resource was successfully created.";
			case Result.NoContent:
				return "The request has been successfully processed.";
			case Result.BadRequest:
				return "The request cannot be processed by the code due to a validation error.";
			case Result.Unauthorized:
				return "The request cannot be processed by the code, user is not authorized.";
			case Result.Forbidden:
				return "Access to the resource is forbidden.";
			case Result.NotFound:
				return "The resource cannot be found by the code.";
			case Result.NotAcceptable:
				return "The resource was found by the code, but the content is not conform the criteria.";
			case Result.Timeout:
				return "The request cannot be processed by the code due to cancellation or timeout.";
			case Result.Conflict:
				return "The request cannot be processed by the code due to a conflict.";
			case Result.InsecureUrl:
				return "The request cannot be processed by the server, due to an insecure url address being used.";
			case Result.UnavailableForLegalReasons:
				return "The request cannot be processed by the server, due to legal reasons.";
			case Result.InternalServerError:
				return "The request cannot be processed by the server. A generic error has occurred.";
			case Result.NotImplemented:
				return "The request cannot be processed by the server. This functionality is not implemented.";
			case Result.GatewayTimeout:
				return "The request cannot be processed by the server. Gateway timed out.";
			default:
				throw new NotImplementedException();
		}
	}

	/// <summary>
	///     The corresponding HttpStatusCode for the Error
	/// </summary>
	/// <param name="result"></param>
	/// <returns></returns>
	/// <exception cref="NotImplementedException"></exception>
	public static HttpStatusCode StatusCode(this Result result)
	{
		switch (result)
		{
			case Result.Ok:
				return HttpStatusCode.OK;
			case Result.Created:
				return HttpStatusCode.Created;
			case Result.NoContent:
				return HttpStatusCode.NoContent;
			case Result.BadRequest:
				return HttpStatusCode.BadRequest;
			case Result.Unauthorized:
				return HttpStatusCode.Unauthorized;
			case Result.Forbidden:
				return HttpStatusCode.Forbidden;
			case Result.NotFound:
				return HttpStatusCode.NotFound;
			case Result.NotAcceptable:
				return HttpStatusCode.NotAcceptable;
			case Result.Timeout:
				return HttpStatusCode.RequestTimeout;
			case Result.Conflict:
				return HttpStatusCode.Conflict;
			case Result.InsecureUrl:
				return HttpStatusCode.UpgradeRequired;
			case Result.UnavailableForLegalReasons:
				return HttpStatusCode.UnavailableForLegalReasons;
			case Result.InternalServerError:
				return HttpStatusCode.InternalServerError;
			case Result.NotImplemented:
				return HttpStatusCode.NotImplemented;
			case Result.GatewayTimeout:
				return HttpStatusCode.GatewayTimeout;
			default:
				throw new NotImplementedException();
		}
	}
}
