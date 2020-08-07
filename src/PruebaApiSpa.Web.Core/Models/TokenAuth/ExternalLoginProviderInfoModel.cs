using Abp.AutoMapper;
using PruebaApiSpa.Authentication.External;

namespace PruebaApiSpa.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
