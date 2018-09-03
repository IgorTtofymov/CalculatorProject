using System;

namespace HW3
{
    public delegate void ButtonHandler(string buttonContent);
    public class MainViewModel
    {
        private double leftNumber = 0;
        private double rightNumber = 0;
        private bool isAssigned;
        private LastOp lastOperation = LastOp.None;

        public Model CalcModel { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            this.CalcModel = new Model();
        }

        /// <summary>
        /// Represent all actions, which happens when any button is clicked
        /// </summary>
        /// <param name="key">represent a button's content</param>
        public void Operation(string key)
        {
            if (double.TryParse(key, out double d))
            {
                if (lastOperation == LastOp.None)
                {
                    leftNumber = leftNumber * 10 + d;
                }
                else
                {
                    if (!isAssigned)
                    {
                        rightNumber = leftNumber;
                        leftNumber = 0;
                        isAssigned = true;
                    }
                    leftNumber = leftNumber * 10 + d;
                }
                this.CalcModel.Show = leftNumber;
            }

            else if ((Enum.TryParse(key, true, out LastOp last)) && (!double.TryParse(key, out double a)))
            {
                if (lastOperation ==LastOp.None)
                {
                    lastOperation = last;
                    leftNumber = CalcModel.Show;
                }
                if (isAssigned)
                {
                    //invoke previous operation
                    CalcModel.Calculate(leftNumber, rightNumber, lastOperation);
                    
                    //set a new operation for future invokation
                    lastOperation = last;
                    rightNumber = 0;
                    isAssigned = false;
                    
                    //set the result of operation to LeftOp
                    leftNumber = CalcModel.Show;
                }
                else
                    lastOperation = last;
            }

            else
            {
                if (key == "C")
                {
                    lastOperation = LastOp.None;
                    leftNumber = 0;
                    rightNumber = 0;
                    CalcModel.Show = 0;
                    isAssigned = false;
                    

                }
                else//if (s == "=")
                {
                        CalcModel.Calculate(leftNumber, rightNumber, lastOperation);
                        rightNumber = 0;
                        lastOperation = LastOp.None;
                        isAssigned = false;
                        leftNumber = 0;
                }
            }
        }
    } 
}
