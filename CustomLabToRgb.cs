using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define el color en el espacio de color LAB
            double L = 30.58;
            double A = -0.11;
            double B = -0.102;

            // Conversión de LAB a XYZ
            double var_Y = (L + 16) / 116;
            double var_X = A / 500 + var_Y;
            double var_Z = var_Y - B / 200;

            double X = var_X > 0.206893 ? 0.95047 * Math.Pow(var_X, 3) : 0.96422 * var_X + 0.12566;
            double Y = L > 8 ? 1.00000 * Math.Pow(var_Y, 3) : 0.79752 * var_Y + 0.13800;
            double Z = var_Z > 0.206893 ? 1.08883 * Math.Pow(var_Z, 3) : 0.95799 * var_Z + 0.06252;

            // Conversión de XYZ a RGB
            double R = X *  3.2406 + Y * -1.5372 + Z * -0.4986;
            double G = X * -0.9689 + Y *  1.8758 + Z *  0.0415;
            double B = X *  0.0557 + Y * -0.2040 + Z *  1.0570;

            R = R > 0.0031308 ? 1.055 * Math.Pow(R, 1 / 2.4) - 0.055 : 12.92 * R;
            G = G > 0.0031308 ? 1.055 * Math.Pow(G, 1 / 2.4) - 0.055 : 12.92 * G;
            B = B > 0.0031308 ? 1.055 * Math.Pow(B, 1 / 2.4) - 0.055 : 12.92 * B;

            // Limita los valores RGB entre 0 y 1
            R = Math.Min(Math.Max(R, 0), 1);
            G = Math.Min(Math.Max(G, 0), 1);
            B = Math.Min(Math.Max(B, 0), 1);

            // Imprime los valores de color en RGB
            Console.WriteLine("Red: " + Math.Round(R * 255));
            Console.WriteLine("Green: " + Math.Round(G * 255));
            Console.WriteLine("Blue: " + Math.Round(B * 255));
        }
    }
}
