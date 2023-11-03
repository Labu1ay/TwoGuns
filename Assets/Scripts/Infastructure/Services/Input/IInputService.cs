namespace Infastructure.Services.Input {
    public interface IInputService : IService{
        bool LeftFireButton { get; }
        bool RightFireButton { get; }
    }
}