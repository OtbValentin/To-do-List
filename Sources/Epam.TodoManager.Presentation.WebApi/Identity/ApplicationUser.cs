using Microsoft.AspNet.Identity;

namespace Epam.TodoManager.Presentation.WebApi.Identity
{
    public class ApplicationUser : IUser<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}