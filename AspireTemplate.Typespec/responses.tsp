import "@typespec/http";

using TypeSpec.Http;

alias ApiErrors = Forbidden | Unauthorized | NotFound | InternalServer | Validation;

model Error
{
    requestId: string;
    traceId: string;
    detail: string;   
    title: string;
    type: string;
   
}

@error
model Forbidden {
  @statusCode statusCode: 403;
  @body error: Error;
}

@error
model Unauthorized {
  @statusCode statusCode: 401;
  @body error: Error;
}

@error
model NotFound {
  @statusCode statusCode: 404;
  @body error: Error;
}

@error
model InternalServer  extends Error {
  @statusCode statusCode: 500;
 
}

@error
model Validation {
  @statusCode statusCode: 400;
  @body error: ValidationError;
}

model ValidationError extends Error {  
  errors: ErrorDetail[];
}

model ErrorDetail {
  key: string;
  messages: string[];
}
