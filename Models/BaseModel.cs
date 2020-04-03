using System.Runtime.Serialization;

namespace Databank.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }

}