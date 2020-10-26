using MedicineTrackingSystem.Models;

namespace MedicineTrackingSystem.Proxies
{
    public interface IMedicineCreateProxy
    {
        int AddNewMedicine(Medicine medicine);
    }
}
