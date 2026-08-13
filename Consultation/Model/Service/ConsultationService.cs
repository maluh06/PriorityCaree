using Consultation.Data;
using Consultation.Model.Entites;
using Consultation.Model.Enum;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.NativeInterop;
using System.Net.Http.Headers;

namespace Consultation.Model.Service
{       
    public class ConsultationService
    {
        private readonly ApplicationDb _context;

        public ConsultationService(ApplicationDb context)
        {
            _context = context;
        }

        public async Task PostRegister(string Name, string Cpf, Priority Priority)
        {
            var registerPatient = new RegisterPatient
            {

                name = Name,
                cpf = Cpf,
                priority = Priority

            };

            _context.PatientTable.Add(registerPatient);
            await _context.SaveChangesAsync();

        }

        public void NextPatient(Priority prior)
        {
            var call = _context.PatientTable.FirstOrDefault(y => y.priority == prior);
            // terei que colocar uma expressao para pegar esse paciente e mudar o status de Esperando para Em atendimento
        }


        public async Task GetNextPatient()
        {
            int countHigh = 0;
            int countLow = 0;
            int countMedium = 0;

            var registerPatient = new RegisterPatient();

            registerPatient.OrdemFila = _context.PatientTable.OrderBy(x => x.priority).ThenBy(x => x.arrive).ToList();

            if (countHigh == countLow && countHigh == countMedium)
            {
                NextPatient(Priority.High);

            }
            else if (countMedium != countHigh)
            {
                NextPatient(Priority.High);
            }
            else
            {
                NextPatient(Priority.Low);
            }


            // fazer uma expressaõ para que retorne o proximo paciente da fila, de acordo com o If-else

        }




    }
}
