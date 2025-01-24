using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PhotoEnhancer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление / Затемение",
                (pixel, parameters) => parameters.Coefficient * pixel
            ));

            mainForm.AddFilter(new  PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (pixel, parameters) =>
                {
                    var lightness = pixel.R * 0.3 + pixel.G * 0.6 + pixel.B * 0.1;

                    return new Pixel(lightness, lightness, lightness);
                }
                ));

           mainForm.AddFilter(new PixelFilter<GammaParameters>(
                "Гамма-коррекция",
                (pixel, parameters) => Convertors.ApplyGammaCorrection(pixel, parameters.GammaR, parameters.GammaG, parameters.GammaB)
            ));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 90° по часовой стрелке и отражение по горизонтали",
                size => new Size(size.Height, size.Width), // Поворот
                 (point, size) =>
                 {
                     // Повернём по часовой
                     var rotatedPoint = new Point(point.Y, size.Height - point.X - 1);
                     // И отразим по диагонали. 
                      return new Point(size.Width - rotatedPoint.X - 1, rotatedPoint.Y);
                 }
    ));

            Application.Run(mainForm);
        }
    }
}
