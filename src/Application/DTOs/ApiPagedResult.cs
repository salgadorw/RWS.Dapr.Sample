
namespace Application.DTOs
{
    public class ApiPagedResult<T>
    {
        public IList<T> Items { get; set; }

        public int TotalItems { get; set; }
    }
}
