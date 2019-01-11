using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OBTestApi.DbModels;

namespace OBTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly OBDbContext context;

        public PatientsController(OBDbContext context)
        {
            this.context = context;
        }

        // GET api/Patients
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> Get()
        {
            List<Patient> patientList = (from patient in this.context.Patient
                select patient).ToList();
            return Ok(patientList);
        }

        // GET api/Patients/5
        [HttpGet("{id}")]
        public ActionResult<Patient> Get(string id)
        {
            Patient specificPatient = (from patient in this.context.Patient
                where patient.Id == id
                select patient).FirstOrDefault();
            if (specificPatient == null)
                return NotFound($"Patient with Id {id} not found!");
            return Ok(specificPatient);
        }

        // POST api/Patients
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Patient patientToAdd)
        {
            if (string.IsNullOrEmpty(patientToAdd.LastName))
                return BadRequest("Lastname is mandatory");
            if (string.IsNullOrEmpty(patientToAdd.FirstName))
                return BadRequest("Firstname is mandatory");
            if (!(patientToAdd.Mobis > 0 && patientToAdd.Mobis < 5))
                return BadRequest("Value for Mobis must be 1, 2, 3 or 4");
            Patient specificPatient = (from patient in this.context.Patient
                where patient.FirstName == patientToAdd.FirstName && patient.LastName == patientToAdd.LastName
                select patient).FirstOrDefault();
            if (specificPatient != null)
                return BadRequest($"Patient {patientToAdd.FirstName} {patientToAdd.LastName} already exists!");
            patientToAdd.Id = null;
            this.context.Add(patientToAdd);
            await this.context.SaveChangesAsync();
            return Ok("Successfully added patient");
        }

        // PUT api/Patients/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Patient patientToUpdate)
        {
            try
            {
                Patient specificPatient = (from patient in this.context.Patient
                    where patient.Id == id
                    select patient).FirstOrDefault();
                if (specificPatient == null)
                    return NotFound($"Patient with Id {id} not found!");
                if (string.IsNullOrEmpty(patientToUpdate.LastName))
                    return BadRequest("Lastname is mandatory");
                if (string.IsNullOrEmpty(patientToUpdate.FirstName))
                    return BadRequest("Firstname is mandatory");
                if (!(patientToUpdate.Mobis > 0 && patientToUpdate.Mobis < 5))
                    return BadRequest("Value for Mobis must be 1, 2, 3 or 4");
                specificPatient.LastName = patientToUpdate.LastName;
                specificPatient.FirstName = patientToUpdate.FirstName;
                specificPatient.AmputationLevel = patientToUpdate.AmputationLevel;
                specificPatient.BirthDate = patientToUpdate.BirthDate;
                specificPatient.HasOBDevice = patientToUpdate.HasOBDevice;
                specificPatient.Mobis = patientToUpdate.Mobis;
                specificPatient.ProfileImage = patientToUpdate.ProfileImage;
                //this.context.Patient.Update(patientToUpdate);
                await this.context.SaveChangesAsync();
                return Ok($"Successfully updated patient with id {id}");
            }
            catch (Exception)
            {
                return BadRequest($"Error updated patient with id {id}"); 
            }
        }

        // DELETE api/Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            Patient specificPatient = (from patient in this.context.Patient
                where patient.Id == id
                select patient).FirstOrDefault();
            if (specificPatient == null)
                return NotFound($"Patient with Id {id} not found!");
            specificPatient.Id = id;
            this.context.Patient.Remove(specificPatient);
            await this.context.SaveChangesAsync();
            return Ok($"Successfully deleted patient with id {id}");
        }
    }
}
