using MedicineTrackingSystem.Models;
using System.Collections.Generic;

namespace MedicineTrackingSystem.Proxies
{
    public interface IMedicineRetrievalProxy
    {
        IEnumerable<Medicine> GetMedicines();
        Medicine GetMedicineById(int id);
        IEnumerable<Medicine> GetMedicines(string Name);
    }
}
