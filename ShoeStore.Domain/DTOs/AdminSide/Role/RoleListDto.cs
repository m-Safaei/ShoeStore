using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.AdminSide.Role
{
    public class RoleListDto
    {
        public int RoleId { get; set; }

        public string RoleTitle { get; set; }
    }
}
