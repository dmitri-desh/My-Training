using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public interface IIngredient
    {
         string Name { get; set; }
         double Calorie { get; set; }
         double Weight { get; set; }
         double Proteins { get; set; }
         double Fats { get; set; }
         double Carbohydrates { get; set; }
         //int CompareTo(object obj);
    }
}