using Lab3.Transports;
using System.Collections.Generic;

namespace Lab3
{
    public class Order
    {
        private double _cost;
        private int _volume;
        private string _startPoint;
        private string _finishPoint;
        private Lab3.Type _type;
        private readonly Track _track;

        public Order()
        {
            _cost = new double();
            _volume = new int();
            _startPoint = "";
            _finishPoint = "";
            _track = new Track();
            _type = Type.Economy;
        }

        public Order(Type deliv, string startP, string finishP, int vol)
        {
            _startPoint = startP;
            _finishPoint = finishP;
            _type = deliv;
            _track = Best(startP, finishP, deliv, vol);
            _cost = _track.Cost;
            _volume = vol;
        }

        public Track Best(string startP, string finishP, Type deliv, int volume)
        {
            int start = decr(startP);
            int finish = decr(finishP);
            int[][] mat = new int[States.Points.Value.Count][];
            for (int i = 0; i < States.Points.Value.Count; i++)
                mat[i] = new int[States.Points.Value.Count];
            mat = matrixUpd(deliv);
            int[] path = new int[States.Points.Value.Count];
            for (int i = 0; i < States.Points.Value.Count; i++)
            {
                path[i] = -1;
            }

            path = optim(mat, start, finish);
            int count = 0;
            for (int i = 0; i < States.Points.Value.Count; i++)
            {
                if (path[i] != -1)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            switch (count)
            {
                case 1:
                {
                    Car car1 = new Car();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[0]]))
                        {
                            car1 = new Car(States.TableCosts.Value[it.Value * 3 + 2], States.MatrixDist.Value[path[0]][path[1]]);
                        }
                    }

                    Track track = new Track(new List<Transport>(){car1}, volume);
                    return track;
                }
                case 3:
                {
                    Car car1 = new Car();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[0]]))
                        {
                            car1 = new Car(States.TableCosts.Value[it.Value * 3 + 2], States.MatrixDist.Value[path[0]][path[1]]);
                        }
                    }

                    Car car2 = new Car();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[2]]))
                        {
                            car2 = new Car(States.TableCosts.Value[it.Value * 3 + 2], States.MatrixDist.Value[path[2]][path[3]]);
                        }
                    }

                    Train train1 = new Train();
                    Plane plane1 = new Plane();
                    Track track = new Track();

                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[1]]) && States.Points.Value[path[1]].Contains("TS"))
                        {
                            train1 = new Train(States.TableCosts.Value[it.Value * 3 + 1], States.MatrixDist.Value[path[1]][path[2]]);
                            track = new Track(new List<Transport> {car1, car2, train1}, volume);
                        }

                        if (it.Key.Contains(States.Points.Value[path[1]]) && States.Points.Value[path[1]].Contains("AP"))
                        {
                            plane1 = new Plane(States.TableCosts.Value[it.Value * 3], States.MatrixDist.Value[path[1]][path[2]]);
                            track = new Track(new List<Transport> {car1, car2, plane1}, volume);
                        }
                    }

                    return track;
                }
                case 5:
                {
                    Car car1 = new Car();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[0]]))
                        {
                            car1 = new Car(States.TableCosts.Value[it.Value * 3 + 2], States.MatrixDist.Value[path[0]][path[1]]);
                        }
                    }

                    Train train1 = new Train();
                    Plane plane1 = new Plane();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[1]]) && States.Points.Value[path[1]].Contains("TS"))
                        {
                            train1 = new Train(States.TableCosts.Value[it.Value * 3 + 1], States.MatrixDist.Value[path[1]][path[2]]);
                        }

                        if (it.Key.Contains(States.Points.Value[path[1]]) && States.Points.Value[path[1]].Contains("AP"))
                        {
                            plane1 = new Plane(States.TableCosts.Value[it.Value * 3], States.MatrixDist.Value[path[1]][path[2]]);
                        }
                    }

                    Car car2 = new Car();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[2]]))
                        {
                            car2 = new Car(States.TableCosts.Value[it.Value * 3 + 2], States.MatrixDist.Value[path[2]][path[3]]);
                        }
                    }

                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[3]]) && States.Points.Value[path[3]].Contains("AP"))
                        {
                            plane1 = new Plane(States.TableCosts.Value[it.Value * 3], States.MatrixDist.Value[path[3]][path[4]]);
                        }

                        if (it.Key.Contains(States.Points.Value[path[3]]) && States.Points.Value[path[3]].Contains("TS"))
                        {
                            train1 = new Train(States.TableCosts.Value[it.Value * 3 + 1], States.MatrixDist.Value[path[3]][path[4]]);
                        }
                    }

                    Car car3 = new Car();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[4]]))
                        {
                            car3 = new Car(States.TableCosts.Value[it.Value * 3 + 2], States.MatrixDist.Value[path[4]][path[5]]);
                        }
                    }

                    Track track = new Track(new List<Transport> {car1, car2, car3, train1, plane1}, volume);
                    return track;
                }
                case 7:
                {
                    Car car1 = new Car();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[0]]))
                        {
                            car1 = new Car(States.TableCosts.Value[it.Value * 3 + 2], States.MatrixDist.Value[path[0]][path[1]]);
                        }
                    }

                    Train train1 = new Train();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[1]]))
                        {
                            train1 = new Train(States.TableCosts.Value[it.Value * 3 + 1], States.MatrixDist.Value[path[1]][path[2]]);
                        }
                    }

                    Car car2 = new Car();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[2]]))
                        {
                            car2 = new Car(States.TableCosts.Value[it.Value * 3 + 2], States.MatrixDist.Value[path[2]][path[3]]);
                        }
                    }

                    Plane plane1 = new Plane();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[3]]))
                        {
                            plane1 = new Plane(States.TableCosts.Value[it.Value * 3], States.MatrixDist.Value[path[3]][path[4]]);
                        }
                    }

                    Car car3 = new Car();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[4]]))
                        {
                            car3 = new Car(States.TableCosts.Value[it.Value * 3 + 2], States.MatrixDist.Value[path[4]][path[5]]);
                        }
                    }

                    Train train2 = new Train();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[5]]))
                        {
                            train2 = new Train(States.TableCosts.Value[it.Value * 3 + 1], States.MatrixDist.Value[path[5]][path[6]]);
                        }
                    }

                    Car car4 = new Car();
                    foreach(var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[6]]))
                        {
                            car4 = new Car(States.TableCosts.Value[it.Value * 3 + 2], States.MatrixDist.Value[path[6]][path[7]]);
                        }
                    }

                    Track track = new Track(new List<Transport> {car1, car2, car3, car4, train1, train2, plane1}, volume);

                    return track;
                }
            }

            return null;
        }
        
        public int[][] matrixUpd(Type type)
        {
            int[][] matrix = new int[States.Points.Value.Count][];
            for (int i = 0; i < States.Points.Value.Count; i++)
            {
                matrix[i] = new int[States.Points.Value.Count];
                for (int j = 0; j < States.Points.Value.Count; j++)
                {
                    matrix[i][j] = States.MatrixDist.Value[i][j];
                }
            }
            switch (type)
            {
                case Type.Economy:
                    for (int i = 0; i < States.Points.Value.Count; i++)
                    {
                        if (States.Points.Value[i].Contains("TS"))
                            for (int j = 0; j < States.Points.Value.Count; j++)
                                matrix[i][j] = 99999;
                    }
                    break;
                    
                case Type.Standart:
                    for (int i = 0; i < States.Points.Value.Count; i++)
                    {
                        if (States.Points.Value[i].Contains("AP"))
                            for (int j = 0; j < States.Points.Value.Count; j++)
                                matrix[i][j] = 99999;
                    }
                    break;
                    
                case Type.Turbo:
                    for (int i = 0; i < States.Points.Value.Count; i++)
                    {
                        for (int j = 0; j < States.Points.Value.Count; j++)
                            if (matrix[i][j] == 0)
                                matrix[i][j] = 99999;
                    }
                    break;
                
            }
            return matrix;
        }

        public int[] optim(int[][] arr, int beginPoint, int endPoint)
        {
            int[] d = new int[States.Points.Value.Count];
            int[] v = new int[States.Points.Value.Count];
            int temp, minindex, min;
            int beginIndex = beginPoint;

            for (int i = 0; i < States.Points.Value.Count; i++)
            {
                d[i] = 99999;
                v[i] = 1;
            }
            d[beginIndex] = 0;

            do {
                minindex = 99999;
                min = 99999;
                for (int i = 0; i < States.Points.Value.Count; i++)
                {
                    if ((v[i] == 1) && (d[i] < min))
                    {
                        min = d[i];
                        minindex = i;
                    }
                }

                if (minindex != 99999)
                {
                    for (int i = 0; i < States.Points.Value.Count; i++)
                    {
                        if (arr[minindex][i] > 0)
                        {
                            temp = min + arr[minindex][i];
                            if (temp < d[i])
                            {
                                d[i] = temp;
                            }
                        }
                    }
                    v[minindex] = 0;
                }
            } while (minindex < 99999);

            int[] ver = new int[States.Points.Value.Count];
            int end = endPoint;
            ver[0] = end;
            int k = 1;
            int weight = d[end];

            while (end != beginIndex)
            {
                for (int i = 0; i < States.Points.Value.Count; i++)
                    if (arr[end][i] != 0)
                    {
                        int tmp = weight - arr[end][i];
                        if (tmp == d[i])
                        {
                            weight = tmp;
                            end = i;
                            ver[k] = i + 1;
                            k++;
                        }
                    }
            }

            for (int i = 0; i < k / 2; i++)
            {
                var tmp = ver[k - 1 - i];
                ver[k - 1 - i] = ver[i];
                ver[i] = tmp;
            }

            return ver;
        }

        int decr(string str)
        {
            foreach (var it in States.Towns.Value)
            {
                if (str.Equals(it.Key))
                    return it.Value;
            }
            return -1;
        }
    }
}