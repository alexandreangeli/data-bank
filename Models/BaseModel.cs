using System.Runtime.Serialization;

namespace BancoDataCoper.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }

}