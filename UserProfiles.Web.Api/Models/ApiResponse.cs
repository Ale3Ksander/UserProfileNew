namespace UserProfiles.Web.Api.Models
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Status = 1;
            Description = "Success";
        }

        public ApiResponse(int status, string description)
        {
            Status = status;
            Description = description;
        }


        public int Status { get; set; }
        public string Description { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Model { get; set; }

        public ApiResponse()
        {

        }

        public ApiResponse(T model)
        {
            Model = model;
        }
    }
}
