using Abp.Application.Services.Dto;

namespace PruebaApiSpa.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

