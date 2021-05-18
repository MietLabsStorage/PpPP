using System.Collections.Generic;

namespace Lab3.Transports
{
    public class TransportsListBuilder: ITransportsBuilder
    {
        private List<Transport> _result = new List<Transport>();
        private readonly int[] _path;

        public TransportsListBuilder(int[] path)
        {
            _path = path;
        }

        public List<Transport> Result => _result;
        
        public void AddCar(int i = 1)
        {
            switch (i)
            {
                case 1:
                {
                    Car car1 = new Car();
                    foreach (var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[_path[0]]))
                        {
                            car1 = new Car(States.TableCosts.Value[it.Value * 3 + 2],
                                States.MatrixDist.Value[_path[0]][_path[1]]);
                        }
                    }
                    _result.Add(car1);

                    break;
                }
                case 2:
                {
                    Car car1 = new Car();
                    Car car2 = new Car();
                    foreach (var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[_path[0]]))
                        {
                            car1 = new Car(States.TableCosts.Value[it.Value * 3 + 2],
                                States.MatrixDist.Value[_path[0]][_path[1]]);
                            car2 = new Car(States.TableCosts.Value[it.Value * 3 + 2],
                                States.MatrixDist.Value[_path[2]][_path[3]]);
                        }
                    }
                    _result.Add(car1);
                    _result.Add(car2);

                    break;
                }
                case 3:
                {
                    Car car1 = new Car();
                    Car car2 = new Car();
                    Car car3 = new Car();
                    foreach (var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[_path[0]]))
                        {
                            car1 = new Car(States.TableCosts.Value[it.Value * 3 + 2],
                                States.MatrixDist.Value[_path[0]][_path[1]]);
                            car2 = new Car(States.TableCosts.Value[it.Value * 3 + 2],
                                States.MatrixDist.Value[_path[2]][_path[3]]);
                            car3 = new Car(States.TableCosts.Value[it.Value * 3 + 2],
                                States.MatrixDist.Value[_path[4]][_path[5]]);
                        }
                    }
                    _result.Add(car1);
                    _result.Add(car2);
                    _result.Add(car3);
                    
                    break;
                }
                case 4:
                {
                    Car car1 = new Car();
                    Car car2 = new Car();
                    Car car3 = new Car();
                    Car car4 = new Car();
                    foreach (var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[_path[0]]))
                        {
                            car1 = new Car(States.TableCosts.Value[it.Value * 3 + 2],
                                States.MatrixDist.Value[_path[0]][_path[1]]);
                            car2 = new Car(States.TableCosts.Value[it.Value * 3 + 2],
                                States.MatrixDist.Value[_path[2]][_path[3]]);
                            car3 = new Car(States.TableCosts.Value[it.Value * 3 + 2],
                                States.MatrixDist.Value[_path[4]][_path[5]]);
                            car4 = new Car(States.TableCosts.Value[it.Value * 3 + 2],
                                States.MatrixDist.Value[_path[6]][_path[7]]);
                        }
                    }
                    _result.Add(car1);
                    _result.Add(car2);
                    _result.Add(car3);
                    _result.Add(car4);
                    
                    break;
                }
            }
        }

        public void AddPlane( int i = 1)
        {
            Plane plane1 = new Plane();
            foreach (var it in States.Table.Value)
            {
                if (States.Points.Value[_path[3]].Contains("AP"))
                {
                    if (it.Key.Contains(States.Points.Value[_path[3]]))
                    {
                        plane1 = new Plane(States.TableCosts.Value[it.Value * 3], 
                            States.MatrixDist.Value[_path[1]][_path[2]]);
                    }
                    else if (it.Key.Contains(States.Points.Value[_path[1]]))
                    {
                        plane1 = new Plane(States.TableCosts.Value[it.Value * 3], 
                            States.MatrixDist.Value[_path[3]][_path[4]]);
                    }
                }
            }
            _result.Add(plane1);
        }

        public void AddTrain(int i = 1)
        {
            switch (i)
            {
                case 1:
                {
                    Train train1 = new Train();
                    foreach (var it in States.Table.Value)
                    {
                        if (States.Points.Value[_path[1]].Contains("TS"))
                        {
                            if (it.Key.Contains(States.Points.Value[_path[1]]))
                            {
                                train1 = new Train(States.TableCosts.Value[it.Value * 3 + 1], 
                                    States.MatrixDist.Value[_path[1]][_path[2]]);
                            }
                            else if (it.Key.Contains(States.Points.Value[_path[3]]))
                            {
                                train1 = new Train(States.TableCosts.Value[it.Value * 3 + 1], 
                                    States.MatrixDist.Value[_path[3]][_path[4]]);
                            }
                        }
                    }
                    _result.Add(train1);

                    break;
                }
                case 2:
                {
                    Train train1 = new Train();
                    Train train2 = new Train();
                    foreach (var it in States.Table.Value)
                    {
                        if (States.Points.Value[_path[1]].Contains("TS"))
                        {
                            train1 = new Train(States.TableCosts.Value[it.Value * 3 + 1], 
                                States.MatrixDist.Value[_path[1]][_path[2]]);
                            train2 = new Train(States.TableCosts.Value[it.Value * 3 + 1], 
                                States.MatrixDist.Value[_path[3]][_path[4]]);
                        }
                    }
                    _result.Add(train1);
                    _result.Add(train2);
                    
                    break;
                }
            }
        }

        public void Reset()
        {
            _result = new List<Transport>();
        }
    }
}