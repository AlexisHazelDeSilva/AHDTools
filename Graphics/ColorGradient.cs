using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Math;

namespace AHDTools.Graphics
{
    /// <summary>
    /// ColorGradient is a custom class for making a scaled gradient of colors.
    /// </summary>
    public class ColorGradient
    {
        Dictionary<double, Color> colors = new Dictionary<double, Color>();

        /// <summary>
        /// Adds a color to the ColorGradient.
        /// </summary>
        /// <param name="position">Position from 0.0 to 1.0 - should not be in the gradient already.</param>
        /// <param name="color">Any System.Drawing.Color</param>
        public void AddColor(double position, Color color)
        {
            if (!colors.ContainsKey(position))
            {
                colors.Add(position, color);
            }
        }

        /// <summary>
        /// Removes a color from the ColorGradient, requires position.
        /// </summary>
        /// <param name="position">Position from 0.0 to 1.0 - should be in the gradient already.</param>
        public void RemoveColor(double position)
        {
            if (colors.ContainsKey(position))
            {
                colors.Remove(position);
            }
        }

        /// <summary>
        /// Finds the correct color for a certain position.
        /// </summary>
        /// <param name="position">Position from 0.0 to 1.0</param>
        public Color FindColorAtPosition(double position)
        {
            //If the position is less than the minimum value, return the minimum color.
            if (position <= colors.Keys.Min())
                return colors[colors.Keys.Min()];
            //If the position is greater than the maximum value, return the maximum color.
            else if (position >= colors.Keys.Max())
                return colors[colors.Keys.Max()];
            //Or else we are in between two colors.
            else
            {
                double leftPos = 0;  // Position closest to but less than the position
                double rightPos = 1.0; // Position closest to but greater than the position

                foreach(double pos in colors.Keys) //Find closest colors
                {
                    if (pos > leftPos && pos < position)
                        leftPos = pos;
                    else if (pos < rightPos && pos > position)
                        rightPos = pos;
                }

                double weightedPosition = (position - leftPos) / (rightPos - leftPos);

                Color weightedColor = Color.FromArgb
                    (
                    (int)Round(colors[rightPos].A * weightedPosition + colors[leftPos].A * (1 - weightedPosition), 0),
                    (int)Round(colors[rightPos].R * weightedPosition + colors[leftPos].R * (1 - weightedPosition), 0),
                    (int)Round(colors[rightPos].G * weightedPosition + colors[leftPos].G * (1 - weightedPosition), 0),
                    (int)Round(colors[rightPos].B * weightedPosition + colors[leftPos].B * (1 - weightedPosition), 0)
                    );

                return weightedColor;

            }
        }

        /// <summary>
        /// Creates a default ColorGradient with black at 0.0 and white at 1.0.
        /// </summary>
        public ColorGradient()
        {
            colors = new Dictionary<double, Color>
            {
                {0.0,Color.Black},
                {1.0,Color.White}
            };
        }

        /// <summary>
        /// Creates a ColorGradient with a custom color gradient.
        /// </summary>
        public ColorGradient(Dictionary<double, Color> colors)
        {
            this.colors = colors;
        }
    }
}
