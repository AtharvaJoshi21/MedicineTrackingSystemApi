using MedicineTrackingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicineTrackingSystem.Proxies
{
    public class MedicinesTrackingProxy : IMedicinesTrackingProxy
    {
        public int AddNewMedicine(Medicine medicine)
        {
            return medicine.Id;
        }

        public Medicine GetMedicineById(int id)
        {
            var medicine = new Medicine();
            return medicine;
        }

        public IEnumerable<Medicine> GetMedicines()
        {
            List<Medicine> medsList = new List<Medicine>();
            return medsList;
        }

        public IEnumerable<Medicine> GetMedicines(string Name)
        {
            List<Medicine> medsList = new List<Medicine>();
            return medsList.Where(med => med.Name.Contains(Name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
