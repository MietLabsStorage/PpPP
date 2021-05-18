namespace Lab3.Transports
{
    public class TransportsDirector
    {
        private ITransportsBuilder _builder;

        public TransportsDirector(ITransportsBuilder builder)
        {
            _builder = builder;
        }

        public void Make1Car(bool reset = false)
        {
            if (reset)
            {
                _builder.Reset();
            }
            _builder.AddCar(1);
        }

        public void Make2Car(bool reset = false)
        {
            if (reset)
            {
                _builder.Reset();
            }
            _builder.AddCar(2);
        }
        
        public void Make3Car(bool reset = false)
        {
            if (reset)
            {
                _builder.Reset();
            }
            _builder.AddCar(3);
        }
        
        public void Make4Car(bool reset = false)
        {
            if (reset)
            {
                _builder.Reset();
            }
            _builder.AddCar(4);
        }
        
        public void Make1Plane(bool reset = false)
        {
            if (reset)
            {
                _builder.Reset();
            }

            _builder.AddPlane(1);
        }
        
        public void Make1Train(bool reset = false)
        {
            if (reset)
            {
                _builder.Reset();
            }
            _builder.AddTrain(1);
        }
        
        public void Make2Train(bool reset = false)
        {
            if (reset)
            {
                _builder.Reset();
            }
            _builder.AddTrain(2);
        }
    }
}