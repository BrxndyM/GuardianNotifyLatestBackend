using Abp.Application.Services.Dto;

namespace GuardianNotifyBackend.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

