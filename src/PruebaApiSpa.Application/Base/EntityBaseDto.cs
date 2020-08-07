using Abp.Application.Services.Dto;
using Newtonsoft.Json;

namespace PruebaApiSpa.Base
{
    [JsonObject(IsReference = false)]
    public abstract class EntityBaseDto : EntityDto<long>
    {

    }
}
