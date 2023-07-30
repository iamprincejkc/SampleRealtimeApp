namespace SampleRealtimeApp.Contracts
{
    public interface IProductHub
    {
        Task ReceiveProduct(string name, string description, string status, string actionType);
    }
}
