namespace Hospital.Server.Services.Contracts
{
    using Models;

    public interface ISpecialitiesService
    {
        SpecialitiesViewModel GetById(int id);
    }
}