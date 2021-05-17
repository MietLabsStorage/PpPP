using Lab3.Transports;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
    public class Track
    {
        private double _cost;
        private double _time;
        private int _volume;

        public Track()
        {
            _cost = new double();
            _time = new double();
            _volume = new int();
        }

        public Track(IEnumerable<Transport> transports, int volume) : base()
        {
            _volume = volume;
            foreach (var transport in transports)
            {
                _cost += transport.SumCost(volume, transport.Distance);
                _time += transport.SumTime(transport.Distance);
            }
        }

        public double Cost => _cost;
    };
}