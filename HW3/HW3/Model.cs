using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HW3
{
    public class Model:INotifyPropertyChanged
    {
        private double show;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Show
        {
            get { return show; }
            set
            {
                if (show != value)
                {
                    show = value;
                    this.OnPropertyChanged("Show");
                }
            }
        }

        /// <summary>
        /// Constr
        /// </summary>
        //public Model()
        //{
        //    this.Show = 0;
        //}

        /// <summary>
        /// All operations of the Calculator are handled via this method
        /// </summary>
        /// <param name="lastOp">represent one of math operations( + - * /)</param>
        /// <param name="x">first Double to opertate</param>
        /// <param name="y">second Double to operate</param>
        public void Calculate(double y, double x,  LastOp lastOp)
        {
            switch (lastOp)
            {
                case LastOp.Add:
                    Show = (x + y);
                    break;
                case LastOp.Divide:
                    {
                        if (y == 0)
                        Show = (double.PositiveInfinity);
                        else
                            Show = x / y;
                        break;
                    }
                case LastOp.Multiply:
                    Show = x * y;
                    break;
                case LastOp.Subtract:
                    Show = x - y;
                    break;
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
