using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public interface IHasCaloriesAndCarbohydrates
    {
        double Calories { get; }
        double Carbohydrates { get; }
    }
}