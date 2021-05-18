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
        private TransportsDirector _director;
        private TransportsListBuilder _builder;

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

            _builder = new TransportsListBuilder(path);
            _director = new TransportsDirector(_builder);
            switch (count)
            {
                case 1:
                {
                    _director.Make1Car(true);
                    Track track = new Track(_builder.Result, volume);
                    return track;
                }
                case 3:
                {
                    _director.Make2Car(true);
                    Track track = new Track();
                    foreach (var it in States.Table.Value)
                    {
                        if (it.Key.Contains(States.Points.Value[path[1]]) &&
                            States.Points.Value[path[1]].Contains("TS"))
                        {
                            _director.Make1Train(1,2);
                            track = new Track(_builder.Result, volume);
                        }
                        if (it.Key.Contains(States.Points.Value[path[1]]) &&
                            States.Points.Value[path[1]].Contains("AP"))
                        {
                            _director.Make1Plane(1,2);
                            track = new Track(_builder.Result, volume);
                        }
                    }
                    return track;
                }
                case 5:
                {
                    _director.Make3Car(true);
                    foreach (var it in States.Table.Value)
                    {
                        if (States.Points.Value[path[1]].Contains("TS"))
                        {
                            if (it.Key.Contains(States.Points.Value[path[3]]))
                            {
                                _director.Make1Train(3,4);
                            }
                            else if (it.Key.Contains(States.Points.Value[path[1]]))
                            {
                                _director.Make1Train(1,2);

                            }
                        }
                        if (States.Points.Value[path[3]].Contains("AP"))
                        {
                            if (it.Key.Contains(States.Points.Value[path[3]]))
                            {
                                _director.Make1Plane(1,2);
                            }
                            else if (it.Key.Contains(States.Points.Value[path[3]]))
                            {
                                _director.Make1Plane(3,4);
                            }
                        }
                    }
                    Track track = new Track(_builder.Result, volume);
                    return track;
                }
                case 7:
                {
                    _director.Make4Car(true);
                    _director.Make1Plane(1,2);
                    _director.Make2Train();
                    Track track = new Track(_builder.Result, volume);

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

            do
            {
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