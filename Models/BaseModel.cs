using System.Runtime.Serialization;

namespace DataBank.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }

}