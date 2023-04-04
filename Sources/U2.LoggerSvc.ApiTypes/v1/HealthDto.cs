using System.ComponentModel;

namespace U2.LoggerSvc.ApiTypes.v1
{
    public sealed class HealthDto
    {
        [Description("Shows current status of service.")]
        public string Status { get; set; }
    }
}