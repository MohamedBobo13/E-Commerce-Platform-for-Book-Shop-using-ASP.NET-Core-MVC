using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bulky.Models.ViewModel
{
    public class RoleManagmentVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
