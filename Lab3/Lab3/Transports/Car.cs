namespace Lab3.Transports
{
    public class Car : Transport
    {
        public Car() : base(new TableCost(100, 60, 50), 0)
        {
        }

        public Car(TableCost tableCost, int dist) : base(tableCost, dist)
        {
        }
    }
}