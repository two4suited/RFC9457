import "./errors.tsp";
import "@typespec/http";

using TypeSpec.Http;

alias ApiErrors = Forbidden | Unauthorized | NotFound | BadRequest | Validation;

@error
model Forbidden {
  @statusCode statusCode: 403;
  @body error: ForbiddenError;
}

@error
model Unauthorized {
  @statusCode statusCode: 401;
  @body error: UnauthorizedError;
}

@error
model NotFound {
  @statusCode statusCode: 404;
  @body error: NotFoundError;
}

@error
model BadRequest {
  @statusCode statusCode: 500;
  @body error: BadRequestError;
}

@error
model Validation {
  @statusCode statusCode: 400;
  @body error: ValidationError;
}