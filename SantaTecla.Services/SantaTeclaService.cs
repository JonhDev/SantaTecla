﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SantaTecla.Models;
using SantaTecla.Services.Helpers;

namespace SantaTecla.Services
{
    public class SantaTeclaService
    {
        private HttpClient httpClient;

        public SantaTeclaService()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> AuthUser(string user, string password)
        {
            var answer = await httpClient.GetAsync(ConectionHelpers.MainURL+ConectionHelpers.PersonalURL);
            var json = await answer.Content.ReadAsStringAsync();
            List<Personal> personal = JsonConvert.DeserializeObject<List<Personal>>(json);
            var employee = personal.FirstOrDefault(empleado => empleado.Login.User == user);
            if (employee != null)
            {
                if (employee.Login.Password == password)
                    return employee.Puesto;
                else
                    return null;
            }
            else
                return null;
        }
        public async Task<bool> BedCheck(int edf, int bed,int id)
        {
            var answer = await httpClient.GetAsync(ConectionHelpers.MainURL + ConectionHelpers.PacientesURL);
            var json = await answer.Content.ReadAsStringAsync();
            List<Pacientes> pacientes = JsonConvert.DeserializeObject<List<Pacientes>>(json);
            var patient = pacientes.FirstOrDefault(pac => pac.Internado.IdEdificio == edf);
            if (patient != null)
            {
                if (patient.Internado.IdCama != bed || patient.NSS == id)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        public async Task<bool> PostPaciente(Pacientes newPaciente)
        {
            var json = JsonConvert.SerializeObject(newPaciente);
            var answer =
                await httpClient.PostAsync($"{ConectionHelpers.MainURL + ConectionHelpers.PacientesURL}",
                    new StringContent(json, Encoding.UTF8, "application/json"));
            if (answer.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<bool> PostPersonal(Personal newPersonal)
        {
            var json = JsonConvert.SerializeObject(newPersonal);
            var answer =
                await httpClient.PostAsync($"{ConectionHelpers.MainURL + ConectionHelpers.PersonalURL}",
                    new StringContent(json, Encoding.UTF8, "application/json"));
            if (answer.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<bool> PutPaciente(int idPaciente, Pacientes newPaciente)
        {
            var json = JsonConvert.SerializeObject(newPaciente);
            var answer =
                await httpClient.PutAsync($"{ConectionHelpers.MainURL + ConectionHelpers.PacientesURL}{idPaciente}",
                    new StringContent(json, Encoding.UTF8, "application/json"));
            if (answer.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<bool> DeletePaciente(int idPaciente)
        {
            var answer =
                await httpClient.DeleteAsync(ConectionHelpers.MainURL+ConectionHelpers.PacientesURL+idPaciente);
            if (answer.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<bool> DeletePersonal(int idPersonal)
        {
            var answer =
                await httpClient.DeleteAsync(ConectionHelpers.MainURL + ConectionHelpers.PersonalURL + idPersonal);
            if (answer.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<List<Pacientes>> GetPacientes()
        {
            var answer = await httpClient.GetAsync(ConectionHelpers.MainURL + ConectionHelpers.PacientesURL);
            var json = await answer.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Pacientes>>(json);
        }

        public async Task<List<Personal>> GetPersonal()
        {
            var answer = await httpClient.GetAsync(ConectionHelpers.MainURL + ConectionHelpers.PersonalURL);
            var json = await answer.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Personal>>(json);
        }

        public async Task<Pacientes> GetPacienteById(int nss)
        {
            var answer = await httpClient.GetAsync(ConectionHelpers.MainURL + ConectionHelpers.PacientesURL);
            var json = await answer.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Pacientes>>(json);
            return lista.FirstOrDefault(paciente => paciente.NSS == nss);
        }
        public async Task<Personal> GetPersonalById(int id)
        {
            var answer = await httpClient.GetAsync(ConectionHelpers.MainURL + ConectionHelpers.PersonalURL);
            var json = await answer.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Personal>>(json);
            return lista.FirstOrDefault(personal => personal.Id == id);
        }

        public async Task<List<Medicamentos>> GetMedicamentos()
        {
            var answer = await httpClient.GetAsync(ConectionHelpers.MainURL + ConectionHelpers.MedicamentosURL);
            var json = await answer.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Medicamentos>>(json);
        }

        public async Task<List<Medicamentos>> GetMedicamentosByNameOrId(string name)
        {
            var answer = await httpClient.GetAsync(ConectionHelpers.MainURL + ConectionHelpers.MedicamentosURL);
            var json = await answer.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Medicamentos>>(json)
                .Where(medicamento => medicamento.Nombre.ToLower().Contains(name))
                .ToList();
        }

        public async Task<Medicamentos> GetMedicamentosByNameOrId(int id)
        {
            var answer = await httpClient.GetAsync(ConectionHelpers.MainURL + ConectionHelpers.MedicamentosURL);
            var json = await answer.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Medicamentos>>(json)
                .FirstOrDefault(medicamento => medicamento.Id == id);
        }

        public async Task<bool> PutMedicamento(int id, Medicamentos newMedicamento)
        {

            var json = JsonConvert.SerializeObject(newMedicamento);
            var answer =
                await httpClient.PutAsync($"{ConectionHelpers.MainURL + ConectionHelpers.MedicamentosURL}{id}", 
                new StringContent(json, Encoding.UTF8, "application/json"));
            if (answer.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}
