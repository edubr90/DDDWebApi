using System;
using System.Collections.Generic;

namespace DDDWebApi.CrossCutting.Responses
{
 public class ApiResponse<T>
 {
 public bool Success { get; set; }
 public T? Data { get; set; }
 public string? Message { get; set; }
 public IEnumerable<string>? Errors { get; set; }
 public int StatusCode { get; set; }
 public DateTime Timestamp { get; set; }

 public ApiResponse()
 {
 Timestamp = DateTime.UtcNow;
 }

 public static ApiResponse<T> SuccessResponse(T data, string? message = null, int statusCode =200)
 {
 return new ApiResponse<T>
 {
 Success = true,
 Data = data,
 Message = message,
 StatusCode = statusCode,
 Errors = null
 };
 }

 public static ApiResponse<T> FailResponse(IEnumerable<string>? errors = null, string? message = null, int statusCode =400)
 {
 return new ApiResponse<T>
 {
 Success = false,
 Data = default,
 Message = message,
 StatusCode = statusCode,
 Errors = errors
 };
 }
 }
}