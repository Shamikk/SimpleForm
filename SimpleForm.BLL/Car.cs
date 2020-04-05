using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleForm.BLL
{
    public class Car
    {
        public Car()
        {

        }

        public Car(string carBrand)
        {
            CarBrand = carBrand;
            SetSteringWheel();

        }

        public string CarBrand { get; set; }
        public String CarColor { get; set; }
        public int NumberOfSeats { get; set; }
        public SteringWheel SteringWheel { get; set; }


        public void SetColor(string color)
        {
            CarColor = color;
        }

        public void SetNumberOfSeatsr(int numberOfSeats)
        {
            NumberOfSeats = numberOfSeats;
        }

        public void SetSteringWheel()
        {
            if (CarBrand == "Fiat")
            {
                SteringWheel.IsLeather = false;
            }
            else if (CarBrand == "Toyota")
            {
                SteringWheel.IsLeather = true;
            }
        }

    }


}
