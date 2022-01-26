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
        private bool isEqual, isNumberNull, isBackspace, operationChanged, overflow;

        private void OperationChanged(string afterOperation)
        {
            if (operation == afterOperation)
            {
                operationChanged = false;
            }
            else if (operation != null && operation != afterOperation)
            {
                operationChanged = true;
            }
        }

        private RelayCommand switchSign;
        public RelayCommand SwitchSign => switchSign ?? (switchSign = new RelayCommand(obj =>
        {
            NumbersTextBox = -NumbersTextBox;
        }, obj => overflow == false));

        private RelayCommand enterOne;
        public RelayCommand EnterOne => enterOne ?? (enterOne = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "1";
            NumbersTextBox = Convert.ToDouble(temp);
        }, obj => overflow == false));

        private RelayCommand enterTwo;
        public RelayCommand EnterTwo => enterTwo ?? (enterTwo = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "2";
            NumbersTextBox = Convert.ToDouble(temp);
        }, obj => overflow == false));

        private RelayCommand enterThree;
        public RelayCommand EnterThree => enterThree ?? (enterThree = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "3";
            NumbersTextBox = Convert.ToDouble(temp);
        }, obj => overflow == false));

        private RelayCommand enterFour;
        public RelayCommand EnterFour => enterFour ?? (enterFour = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "4";
            NumbersTextBox = Convert.ToDouble(temp);
        }, obj => overflow == false));

        private RelayCommand enterFive;
        public RelayCommand EnterFive => enterFive ?? (enterFive = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "5";
            NumbersTextBox = Convert.ToDouble(temp);
        }, obj => overflow == false));

        private RelayCommand enterSix;
        public RelayCommand EnterSix => enterSix ?? (enterSix = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "6";
            NumbersTextBox = Convert.ToDouble(temp);
        }, obj => overflow == false));

        private RelayCommand enterSeven;
        public RelayCommand EnterSeven => enterSeven ?? (enterSeven = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "7";
            NumbersTextBox = Convert.ToDouble(temp);
        }, obj => overflow == false));

        private RelayCommand enterEight;
        public RelayCommand EnterEight => enterEight ?? (enterEight = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "8";
            NumbersTextBox = Convert.ToDouble(temp);
        }, obj => overflow == false));

        private RelayCommand enterNine;
        public RelayCommand EnterNine => enterNine ?? (enterNine = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "9";
            NumbersTextBox = Convert.ToDouble(temp);
        }, obj => overflow == false));

        private RelayCommand enterNull;
        public RelayCommand EnterNull => enterNull ?? (enterNull = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            temp += "0";
            NumbersTextBox = Convert.ToDouble(temp);
        }, obj => overflow == false));

        private RelayCommand clearAll;
        public RelayCommand ClearAll => clearAll ?? (clearAll = new RelayCommand(obj =>
        {
            HistoryTextBox = "";
            NumbersTextBox = 0;
            beforeNumber = 0;
            previosNumber = 0;
            isEqual = true;
            isBackspace = true;
            isNumberNull = false;
        }));

        private RelayCommand clear; 
        public RelayCommand Clear => clear ?? (clear = new RelayCommand(obj => 
        {
            NumbersTextBox = 0;
            isEqual = true;
            isBackspace = true;
            isNumberNull = false;
        }));

        private RelayCommand backspace;
        public RelayCommand Backspace => backspace ?? (backspace = new RelayCommand(obj =>
        {
            var temp = NumbersTextBox.ToString();
            var array = temp.ToArray();
            if (isBackspace == true)
            {
                HistoryTextBox = "";
                beforeNumber = 0;
                previosNumber = 0;
                operation = "";
                isBackspace = false;
            }
            else
            {
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
            }
        }));

        private RelayCommand plus;
        public RelayCommand Plus => plus ?? (plus = new RelayCommand(obj =>
        {
            isBackspace = true;
            isNumberNull = false;
            OperationChanged("sum");
            operation = "sum";
            if (beforeNumber == 0)
            {
                HistoryTextBox = "";
                beforeNumber = NumbersTextBox;
                HistoryTextBox = HistoryTextBox + NumbersTextBox.ToString() + " + ";
                NumbersTextBox = 0;
            }
            else if(isNumberNull == true)
            {
                beforeNumber = 0;
                HistoryTextBox = HistoryTextBox + NumbersTextBox.ToString() + " + ";
                NumbersTextBox = 0;
            }
            else
            {
                beforeNumber = NumbersTextBox + beforeNumber;
                HistoryTextBox = beforeNumber.ToString() + " + ";
                NumbersTextBox = 0;
            }
            isEqual = false;
        }, obj => overflow == false));

        private RelayCommand minus;
        public RelayCommand Minus => minus ?? (minus = new RelayCommand(obj =>
        {
            isBackspace = true;
            if (beforeNumber == 0)
            {
                HistoryTextBox = "";
                beforeNumber = NumbersTextBox - beforeNumber;
                HistoryTextBox = HistoryTextBox + NumbersTextBox.ToString() + " - ";
                operation = "minus";
                NumbersTextBox = 0;
            }
            else if(NumbersTextBox == 0)
            {
                HistoryTextBox = beforeNumber + " - 0 " + " =";
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
        }, obj => overflow == false));


        private RelayCommand multiplication;
        public RelayCommand Multiplication => multiplication ?? (multiplication = new RelayCommand(obj =>
        {
            OperationChanged("multiplication");
            if (beforeNumber == 0 && previosNumber == 0)
            {
                NumbersTextBox = NumbersTextBox;
                beforeNumber = NumbersTextBox;
                previosNumber = 0;
                HistoryTextBox = NumbersTextBox.ToString() + " *";
                operation = "multiplication";
                NumbersTextBox = 0; // Новое!!!
            }
            else
            {
                previosNumber = beforeNumber;
                beforeNumber = NumbersTextBox;
                NumbersTextBox = previosNumber * beforeNumber;
                HistoryTextBox = NumbersTextBox.ToString() + " *";
                beforeNumber = NumbersTextBox;
                operation = "multiplication";
                NumbersTextBox = 0;// Новое!!!
            }
        }, obj => overflow == false));

        private RelayCommand procent;
        public RelayCommand Procent => procent ?? (procent = new RelayCommand(obj =>
        {
            NumbersTextBox = NumbersTextBox / 100;
        }, obj => overflow == false));

        private RelayCommand divisionDecimal;
        public RelayCommand DivisionDecimal => divisionDecimal ?? (divisionDecimal = new RelayCommand(obj =>
        {
            NumbersTextBox = 1 / NumbersTextBox;
        }, obj => overflow == false));

        private RelayCommand degree;
        public RelayCommand Degree => degree ?? (degree = new RelayCommand(obj =>
        {
            NumbersTextBox = NumbersTextBox * NumbersTextBox;
        }, obj => overflow == false));

        private RelayCommand root;
        public RelayCommand Root => root ?? (root = new RelayCommand(obj =>
        {
            NumbersTextBox = Math.Sqrt(NumbersTextBox);
        }, obj => overflow == false));

        private RelayCommand division;
        public RelayCommand Division => division ?? (division = new RelayCommand(obj =>
        {
            NumbersTextBox = beforeNumber;
            HistoryTextBox = beforeNumber.ToString() + " / " + NumbersTextBox.ToString();
        }, obj => overflow == false));

        private RelayCommand comma;
        public RelayCommand Comma => comma ?? (comma = new RelayCommand(obj =>
        {

        }, obj => overflow == false));

        private RelayCommand equal;
        public RelayCommand Equal => equal ?? (equal = new RelayCommand (obj => 
        {
            isBackspace = true;
            if (!isEqual)
            {
                switch (operation)
                {
                    case "sum":
                        if (NumbersTextBox == 0)
                        {
                            isNumberNull = true;
                            HistoryTextBox = "";
                        }
                        else
                        {
                            previosNumber = NumbersTextBox;
                            HistoryTextBox = HistoryTextBox + NumbersTextBox.ToString() + " =";
                            NumbersTextBox = NumbersTextBox + beforeNumber;
                        }
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

                    case "multiplication":
                        if (beforeNumber == 0 && previosNumber == 0)
                        {
                            NumbersTextBox = NumbersTextBox;
                            beforeNumber = NumbersTextBox;
                            previosNumber = 0;
                            HistoryTextBox = NumbersTextBox.ToString() + " *";
                            operation = "multiplication";
                        }
                        else 
                        { 
                            previosNumber = beforeNumber;
                            beforeNumber = NumbersTextBox;
                            NumbersTextBox = previosNumber * NumbersTextBox;
                            HistoryTextBox = beforeNumber.ToString() + " * " + previosNumber.ToString() + " =";
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
                        else if (NumbersTextBox == 0)
                        {
                            HistoryTextBox = "";
                            //NumbersTextBox = beforeNumber;
                            previosNumber = 0;
                            beforeNumber = 0;
                            isNumberNull = true;
                        }
                        else
                        {
                            beforeNumber = previosNumber;
                            HistoryTextBox = NumbersTextBox.ToString() + " + " + beforeNumber.ToString() + " =";
                            NumbersTextBox = NumbersTextBox + beforeNumber;
                        }
                        break;

                    case "minus":
                        if (NumbersTextBox == 0)
                        {
                            beforeNumber = 0;
                            HistoryTextBox = "";
                            previosNumber = 0;
                        }
                        else
                        {
                            beforeNumber = previosNumber;
                            HistoryTextBox = NumbersTextBox.ToString() + " - " + beforeNumber.ToString() + " =";
                            NumbersTextBox = NumbersTextBox - beforeNumber;
                        }
                        break;

                    case "multiplication":
                        HistoryTextBox = NumbersTextBox.ToString() + " * " + beforeNumber.ToString() + " =";
                        NumbersTextBox = beforeNumber * NumbersTextBox;
                        isEqual = true;
                        break;
                }
             }
        }, obj => overflow == false));

        private double numbersTextBox;
        public double NumbersTextBox
        {
            get => numbersTextBox;
            set 
            {
                //value - нынешнее значение во время операции
                //NumbersTextBox - конечное значение после преобразований, выводимое на экран
                if (value.ToString().Length <= 9)
                {
                    numbersTextBox = value;
                    OnPropertyChanged(nameof(NumbersTextBox));
                }
                else if (value.ToString().IndexOf(',') != -1)
                {
                    if (value.ToString().IndexOf(',') < 7)
                    {
                        int round;
                        switch (value.ToString().IndexOf(','))
                        {
                            case 1:
                                round = 7;
                                break;
                            case 2:
                                round = 6;
                                break;
                            case 3:
                                round = 5;
                                break;
                            case 4:
                                round = 4;
                                break;
                            case 5:
                                round = 3;
                                break;
                            case 6:
                                round = 2;
                                break;
                            default:
                                round = 0;
                                break;
                        }
                        value = Math.Round(value, round);
                        numbersTextBox = value;
                        OnPropertyChanged(nameof(NumbersTextBox));
                    }
                    else
                    {
                        overflow = true;
                        HistoryTextBox = "Предел точности превышен!";
                    }
                }
                else
                {
                    overflow = true;
                    HistoryTextBox = "Предел точности превышен!";
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
            operationChanged = true;
            isEqual = false;
            isNumberNull = false;
            isBackspace = true;
            overflow = false;
        }
    }
    
}
