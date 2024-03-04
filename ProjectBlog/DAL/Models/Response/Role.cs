using Microsoft.AspNetCore.Identity;

namespace ProjectBlog.DAL.Models.Response
{
    public class Role : IdentityRole
    {
        //Id, Name, NormalizedName,  -> распологаются в классе родителя
        public int? SecurityLvl { get; set; } = null;
    }
}
