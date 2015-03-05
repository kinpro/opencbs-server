using System;
using System.Security.Authentication;
using Nancy.Responses;
using Nancy;

namespace OPENCBS.Server
{
    public class ErrorResponse : JsonResponse
    {
        readonly Error _error;

        public ErrorResponse(Error error) : base(error, new DefaultJsonSerializer())
        {
            _error = error;
        }

        public static Response FromException(Exception e)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var errorMessage = e.Message;
            if (e is InvalidCredentialException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                errorMessage = "Invalid username or password.";
            }

            var error = new Error { ErrorMessage = errorMessage };
            var response = new ErrorResponse(error);
            response.StatusCode = statusCode;
            return response;
        }
    }
}
