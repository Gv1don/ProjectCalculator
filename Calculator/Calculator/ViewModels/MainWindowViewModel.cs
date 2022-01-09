using Calculator.Commands;
using Calculator.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private double beforeNumber, previosNumber;
        private string operation;
        private bool isEqual, isNumberNull;

        private RelayCommand switchSign;
        public RelayCommand SwitchSign => switchSign ?? (switchSign = new RelayCommand(obj =>
        {
            NumbersTextBox = -NumbersTextBox;
        }));

        private RelayCommand enterOne;
        public RelayCommand EnterOne => enterOne ?? (enterOne = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "1";
            NumbersTextBox = Convert.ToDouble(temp);
        }));

        private RelayCommand enterTwo;
        public RelayCommand EnterTwo => enterTwo ?? (enterTwo = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "2";
            NumbersTextBox = Convert.ToDouble(temp);
        }));

        private RelayCommand enterThree;
        public RelayCommand EnterThree => enterThree ?? (enterThree = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "3";
            NumbersTextBox = Convert.ToDouble(temp);
        }));

        private RelayCommand enterFour;
        public RelayCommand EnterFour => enterFour ?? (enterFour = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "4";
            NumbersTextBox = Convert.ToDouble(temp);
        }));

        private RelayCommand enterFive;
        public RelayCommand EnterFive => enterFive ?? (enterFive = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "5";
            NumbersTextBox = Convert.ToDouble(temp);
        }));

        private RelayCommand enterSix;
        public RelayCommand EnterSix => enterSix ?? (enterSix = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "6";
            NumbersTextBox = Convert.ToDouble(temp);
        }));

        private RelayCommand enterSeven;
        public RelayCommand EnterSeven => enterSeven ?? (enterSeven = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "7";
            NumbersTextBox = Convert.ToDouble(temp);
        }));

        private RelayCommand enterEight;
        public RelayCommand EnterEight => enterEight ?? (enterEight = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "8";
            NumbersTextBox = Convert.ToDouble(temp);
        }));

        private RelayCommand enterNine;
        public RelayCommand EnterNine => enterNine ?? (enterNine = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "9";
            NumbersTextBox = Convert.ToDouble(temp);
        }));

        private RelayCommand enterNull;
        public RelayCommand EnterNull => enterNull ?? (enterNull = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "0";
            NumbersTextBox = Convert.ToDouble(temp);
        }));

        private RelayCommand backspace;
        public RelayCommand Backspace => backspace ?? (backspace = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            var array = temp.ToArray();
            if (array.Count() == 1)
            {
                NumbersTextBox = 0;
            }
            else if (temp.Length == 2 && Convert.ToInt32(temp) < 0) 
            {
                NumbersTextBox = 0;
            }
            else
            {
                NumbersTextBox = Convert.ToDouble(temp.Substring(0, temp.Length - 1));
            }
        }));

        private RelayCommand plus;
        public RelayCommand Plus => plus ?? (plus = new RelayCommand(obj =>
        {
            isNumberNull = false;
            if (beforeNumber == 0)
            {
                beforeNumber = NumbersTextBox;
                HistoryTextBox = HistoryTextBox + NumbersTextBox.ToString() + " + ";
                NumbersTextBox = 0;
                operation = "sum";
            }
            else if(isNumberNull == true)
            {
                beforeNumber = 0;
                HistoryTextBox = HistoryTextBox + NumbersTextBox.ToString() + " + ";
                NumbersTextBox = 0;
                operation = "sum";
            }
            else
            {
                beforeNumber = NumbersTextBox + beforeNumber;
                HistoryTextBox = beforeNumber.ToString() + " + ";
                NumbersTextBox = 0;
                operation = "sum";
            }
            isEqual = false;
        }));

        private RelayCommand minus;
        public RelayCommand Minus => minus ?? (minus = new RelayCommand(obj =>
        {
            if (beforeNumber == 0)
            {
                beforeNumber = NumbersTextBox - beforeNumber;
                HistoryTextBox = HistoryTextBox + NumbersTextBox.ToString() + " - ";
                operation = "minus";
            }
            else if(NumbersTextBox == 0)
            {
                HistoryTextBox = beforeNumber + " - 0 " + "=";
                operation = "minus";
            }
            else
            {
                previosNumber = beforeNumber;
                beforeNumber = NumbersTextBox;
                NumbersTextBox = previosNumber - NumbersTextBox;
                HistoryTextBox = NumbersTextBox.ToString() + " - ";
                operation = "minus";
                if (NumbersTextBox == 0)
                {
                    beforeNumber = 0;
                    previosNumber = 0;
                }
            }
            isEqual = false;
        }));

        private RelayCommand equal;
        public RelayCommand Equal => equal ?? (equal = new RelayCommand (obj => 
        {
            if (!isEqual)
            {
                switch (operation)
                {
                    case "sum":
                        if (NumbersTextBox == 0)
                        {
                            isNumberNull = true;
                        }
                        HistoryTextBox = HistoryTextBox + NumbersTextBox.ToString() + " =";
                        NumbersTextBox = NumbersTextBox + beforeNumber;
                        isEqual = true;
                        break;
                    case "minus":
                        if (NumbersTextBox == 0)
                        {   
                            isNumberNull = true;
                            HistoryTextBox = "";
                            NumbersTextBox = beforeNumber;
                            beforeNumber = 0;
                        }
                        else
                        {
                            previosNumber = NumbersTextBox;
                            HistoryTextBox = HistoryTextBox + NumbersTextBox.ToString() + " =";
                            NumbersTextBox = beforeNumber - NumbersTextBox;
                        }
                        isEqual = true;
                        break;
                }
            }
            else
            {
                switch (operation)
                {
                    case "sum":
                        beforeNumber = previosNumber;
                        if (isNumberNull == true)
                        {
                            HistoryTextBox = "";
                            isNumberNull = false;
                        }
                        else
                        {
                            HistoryTextBox = NumbersTextBox.ToString() + " + " + beforeNumber.ToString() + " =";
                            NumbersTextBox = NumbersTextBox + beforeNumber;
                        }
                        break;
                    case "minus":
                        /*if (NumbersTextBox == 0)
                        {
                            beforeNumber = 0; 
                        }*/
                        if (isNumberNull == true)
                        {
                            HistoryTextBox = "";
                            isNumberNull = false;
                        }
                        beforeNumber = previosNumber;
                        HistoryTextBox = NumbersTextBox.ToString() + " - " + beforeNumber.ToString() + " =";
                        NumbersTextBox = NumbersTextBox - beforeNumber;
                        break;
                }
             }
        }));

        private double numbersTextBox;
        public double NumbersTextBox
        {
            get => numbersTextBox;
            set 
            {
                if (value.ToString().Length <= 9)
                {
                    numbersTextBox = value;
                    OnPropertyChanged(nameof(NumbersTextBox));
                }
            }
        }

        private string historyTextBox;
        public string HistoryTextBox
        {
            get => historyTextBox;
            set
            {
                historyTextBox = value;
                OnPropertyChanged(nameof(HistoryTextBox));
            }
        }

        public MainWindowViewModel()
        {
            beforeNumber = 0;
            previosNumber = 0;
            isEqual = false;
            isNumberNull = false;
        }
    }
    
}
