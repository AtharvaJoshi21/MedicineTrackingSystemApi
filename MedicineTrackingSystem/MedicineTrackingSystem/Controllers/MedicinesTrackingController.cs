using MedicineTrackingSystem.Models;
using MedicineTrackingSystem.Proxies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MedicineTrackingSystem.Controllers
{
    /// <summary>
    /// Controller class for -
    ///     getting list of all medicines
    ///     retrieve a single medicine
    ///     search medicines by name
    ///     add a new medicine
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesTrackingController : ControllerBase
    {
        private readonly IMedicinesTrackingProxy medTrackProxy;

        public MedicinesTrackingController(IMedicinesTrackingProxy medicinesTrackingProxy)
        {
            this.medTrackProxy = medicinesTrackingProxy;
        }

        // GET: api/<MedicinesTrackingController>
        [HttpGet]
        public IEnumerable<Medicine> Get()
        {
            return medTrackProxy.GetMedicines();
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public Medicine GetMedicineById(int id)
        {
            return medTrackProxy.GetMedicineById(id);
        }

        [Route("[action]/{name}")]
        public IEnumerable<Medicine> GetMedicinesByName(string name)
        {
            return medTrackProxy.GetMedicines(name);
        }

        // POST api/<MedicinesTrackingController>
        [HttpPost]
        public int Post([FromBody] Medicine newMed)
        {
            return medTrackProxy.AddNewMedicine(newMed);
        }
    }
}
