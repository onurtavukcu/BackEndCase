namespace BackendCase.Operations.AbstractClientOperation
{
    public interface IBookingService<TReturn>
    {
        Task<TReturn> Handle();
    }

    public interface IBookingService<TInput, TReturn>: IBookingService<TReturn>
    {
        Task<TReturn> Handle(TInput input);
    }
}
