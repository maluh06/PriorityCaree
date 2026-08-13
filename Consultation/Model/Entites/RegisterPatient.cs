using Consultation.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace Consultation.Model.Entites
{
    public class RegisterPatient
    {
        public string name { get; set; }
        [Key] public string cpf { get; set; }
        public Priority priority { get; set; }
        public Status status { get; set; } = Status.Waiting;
        public DateTime arrive { get; set; } = DateTime.Now;
        public DateTime departure { get; set; }
        public List<RegisterPatient> OrdemFila { get; set; }
    }
}
