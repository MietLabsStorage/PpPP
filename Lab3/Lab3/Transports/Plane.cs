namespace Lab3.Transports
{
    public class Plane : Transport
    {
        public Plane() : base(new TableCost(500, 300, 100), 0)
        {
        }

        public Plane(TableCost tableCost, int dist) : base(tableCost, dist)
        {
        }
    }
}