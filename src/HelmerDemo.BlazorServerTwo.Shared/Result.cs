namespace HelmerDemo.BlazorServerTwo.Shared;

public enum Result
{
	/// <summary>
	///     Request passed, data is in the result class. Equivalent to 200 OK.
	/// </summary>
	Ok,

	/// <summary>
	///     Request passed, a new resource was successfully created. Equivalent to 201 Created.
	/// </summary>
	Created,

	/// <summary>
	///     Request passed, the request has been successfully processed. Equivalent to 204 NoContent.
	/// </summary>
	NoContent,

	/// <summary>
	///     Request failed, the request cannot be processed by the code. Equivalent to 400 Bad Request.
	/// </summary>
	BadRequest,

	/// <summary>
	///     Request failed, the request cannot be processed by the code. Equivalent to 401 Unauthorized.
	/// </summary>
	Unauthorized,

	/// <summary>
	///     Request failed, access to the resource is Forbidden. Equivalent to 403 Forbidden. Re-authenticating has no use.
	/// </summary>
	Forbidden,

	/// <summary>
	///     Request failed, the resource cannot be found by the code. Equivalent to 404 Not found.
	/// </summary>
	NotFound,

	/// <summary>
	///     Request failed, The resource was found by the code, but the content is not conform the criteria. Equivalent to 406
	///     Not acceptable.
	/// </summary>
	NotAcceptable,

	/// <summary>
	///     Request failed, the request cannot be fully processed by the code due to cancellation or timeout. Equivalent to 408
	///     timeout
	/// </summary>
	Timeout,

	/// <summary>
	///     Request failed, the request cannot be processed by the code. Equivalent to 409 conflict
	/// </summary>
	Conflict,

	/// <summary>
	///     Request failed, an insecure url address is used (http:// instead of https://) Refers to 426 Upgrade Required.
	/// </summary>
	InsecureUrl,

	/// <summary>
	///     Request failed, an insecure url address is used (http:// instead of https://) Refers to 451, in the meaning that
	///     this resource is not available due to legal reasons (gdpr)
	/// </summary>
	UnavailableForLegalReasons,

	/// <summary>
	///     Request failed, a generic error occurred. Equivalent to 500 Internal server error.
	/// </summary>
	InternalServerError,

	/// <summary>
	///     Request failed, the code is not implemented. Equivalent to 501 NotImplemented.
	/// </summary>
	NotImplemented,

	/// <summary>
	///     Request failed, the request cannot be fully processed by the code due to gateway timeout.
	/// </summary>
	GatewayTimeout
}
