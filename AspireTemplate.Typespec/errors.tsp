model Error
{
    requestId: string;
    traceId: string;
    detail: string;
    statusCode: int32;
    title: string;
    type: string;
   
}

model BadRequestError extends Error
{
    statusCode: 500;
}
@error
model NotFoundError extends Error
{
    statusCode: 404;
}
model UnauthorizedError extends Error
{
    statusCode: 401;
}
model ForbiddenError extends Error
{
    statusCode: 403;
}

model ValidationError extends Error {  
    statusCode: 400;
    errors: ErrorDetail[];
}

model ErrorDetail {
    key: string;
    messages: string[];
}

