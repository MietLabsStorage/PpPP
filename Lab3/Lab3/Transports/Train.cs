namespace Lab3.Transports
{
    public class Train : Transport
    {
        public Train() : base(new TableCost(200, 100, 500), 0)
        {
        }

        public Train(TableCost tableCost, int dist) : base(tableCost, dist)
        {
        }
    }
}