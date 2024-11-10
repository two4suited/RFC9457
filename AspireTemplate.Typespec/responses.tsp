import "./errors.tsp";
import "@typespec/http";

using TypeSpec.Http;

alias ApiErrors = Forbidden | Unauthorized | NotFound | InternalServer | Validation;

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
model InternalServer {
  @statusCode statusCode: 500;
  @body error: InternalServerError;
}

@error
model Validation {
  @statusCode statusCode: 400;
  @body error: ValidationError;
}