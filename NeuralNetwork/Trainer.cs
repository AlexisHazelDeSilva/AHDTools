using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDTools.NeuralNetwork
{
    /// <summary>
    /// LinearTrainer is a Trainer for the Perceptron class which has an x, y, and line that we are either above or below
    /// </summary>
    class LinearTrainer
    {
        public float[] inputs;
        public int answer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">X of the point in Cartesian coordinates</param>
        /// <param name="y">Y of the point in Cartesian coordinates</param>
        /// <param name="slope">Slope of the line we are testing with in y=slope*x+yInt format</param>
        /// <param name="yint">Y-intercept of the line we are testing with in y=slope*x+yInt format</param>
        public LinearTrainer(float x, float y, float slope, float yint)
        {
            inputs = new float[3];
            inputs[0] = x;
            inputs[1] = y;
            inputs[2] = 1;

            if (y > slope * x + yint)
            {
                answer = 1;
            }
            else
            {
                answer = -1;
            }
        }
    }
}
