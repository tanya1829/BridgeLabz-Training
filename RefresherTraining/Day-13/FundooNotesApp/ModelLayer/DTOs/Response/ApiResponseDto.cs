namespace FundooNotesApp.ModelLayer.DTOs.Response
{
    // Generic response wrapper - consistent shape for every API response
    public class ApiResponseDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}