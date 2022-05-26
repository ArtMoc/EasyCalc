using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EasyCalc
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        double _first, _second;
        string _result;
        int _third;
        public ViewModel()
        {
            Third = 1;
        }

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                Notify("Result");
            }
        }
        public double First
        {
            get { return _first; }
            set
            {
                _first = value;
                Notify("First");
            }
        }
        public double Second
        {
            get { return _second; }
            set
            {
                _second = value;
                Notify("Second");
            }
        }
        public int Third
        {
            get { return _third; }
            set
            {
                _third = value;
                Notify("Third");
            }
        }

        public ICommand PlusBtn
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                    {
                        Result = $"{_first}+{_second}={_first + _second}";
                    }));
            }
        }

        public ICommand MinusBtn
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    Result = $"{_first}-{_second}={_first - _second}";
                }));
            }
        }

        public ICommand MultBtn
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    Result = $"{_first}*{_second}={_first * _second}";
                }));
            }
        }

        public ICommand DecBtn
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    Result = $"{_first}/{_second}={_first / _second}";
                }));
            }
        }

        public ICommand DoubleBtn
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    Third = _third*2;
                }));
            }
        }
    }
}
