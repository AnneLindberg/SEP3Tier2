using System.Text.Json.Serialization;

namespace Tier2.Network
{
    [Newtonsoft.Json.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumRequest
    {
        GETMESSAGEFROMDATABASE,
        PUTMESSAGEINTODATABASE
    }
}