namespace Lab3.Transports
{
    public interface ITransportsBuilder
    {
        void AddCar(int i);
        void AddPlane(int i);
        void AddTrain(int i);

        void Reset();
    }
}