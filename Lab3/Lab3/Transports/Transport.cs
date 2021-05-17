namespace Lab3.Transports
{
    public abstract class Transport
    {
        protected int _speed;
        protected int _price;
        protected double _volume;
        protected int _distance;

        protected Transport()
        {
        }

        protected Transport(TableCost tableCost, int dist)
        {
            _speed = tableCost.Speed;
            _volume = tableCost.Volume;
            _price = tableCost.Price;
            _distance = dist;
        }

        public virtual double SumCost(int mass, int dist)
        {
            return (mass / _volume) * SumTime(dist) * _price;
        }

        public virtual double SumTime(int dist)
        {
            return dist / (double) _speed;
        }

        public virtual int Distance => _distance;
    }
}