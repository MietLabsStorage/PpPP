namespace Lab3.Transports
{
    public interface ITransportsBuilder
    {
        void AddCar(int i);
        void AddPlane(int x, int y, int i);
        void AddTrain(int x, int y, int i);

        void Reset();
    }
}