using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public interface ISalad : ICollection<Ingredient>
    {
        string Name { get; }
        ICollection<Ingredient> _ingredients { get; }
        Double TotalCalories { get; }
      //  void FindBy();
    }  
}