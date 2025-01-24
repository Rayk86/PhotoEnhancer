using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class GammaParameters : IParameters
    {
       
        public double GammaR { get; set; } = 1.0; // Значение гаммы для красного 
        public double GammaG { get; set; } = 1.0; // Значение гаммы для зеленого 
        public double GammaB { get; set; } = 1.0; // Значение гаммы для синего 

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo() { Name = "Гамма R", MinValue = 0.2, MaxValue = 5.0, DefaultValue = 1.0, Increment = 0.01 },
                new ParameterInfo() { Name = "Гамма G", MinValue = 0.2, MaxValue = 5.0, DefaultValue = 1.0, Increment = 0.01 },
                new ParameterInfo() { Name = "Гамма B", MinValue = 0.2, MaxValue = 5.0, DefaultValue = 1.0, Increment = 0.01 }
            };
        }

        public void SetValues(double[] values)
        {
            GammaR = values[0];
            GammaG = values[1];
            GammaB = values[2];
        }
    }
}