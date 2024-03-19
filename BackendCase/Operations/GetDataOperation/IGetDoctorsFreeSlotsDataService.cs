using BackendCase.Models.Input;
using BackendCase.Operations.AbstractClientOperation;

namespace BackendCase.Operations.GetDataOperation
{
    public interface IGetDoctorsFreeSlotsDataService: IBookingService<int, DoctorFreeSlotsWrapper>
    {

    }
}
