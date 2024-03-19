using BackendCase.Models.Input;
using BackendCase.Operations.AbstractClientOperation;
namespace BackendCase.Operations.GetDataOperation
{
    public interface IGetDoctorsDataService: IBookingService<DoctorListWrapper>
    {

    }
}
