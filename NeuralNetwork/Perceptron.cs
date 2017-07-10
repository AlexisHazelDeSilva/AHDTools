using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDTools.NeuralNetwork
{
    class Perceptron
    {
        public float[] weights;
        float learningConstant = 0.01f;

        public int FeedForward(float[] inputs)
        {
            float sum = 0;
            for (int i = 0; i < weights.Count(); i++)
            {
                sum += inputs[i] * weights[i];
            }

            return Activate(sum);
        }

        int Activate(float sum)
        {
            if (sum > 0)
                return 1;
            else
                return -1;
        }

        public void Train(float[] inputs, int desired)
        {
            int guess = FeedForward(inputs);

            float error = desired - guess;

            for (int i = 0; i < weights.Count(); i++)
            {
                weights[i] += learningConstant * error * inputs[i];
            }

        }

        public Perceptron(int n)
        {
            weights = new float[n];
            Random r = new Random();

            for (int i = 0; i < weights.Count(); i++)
            {
                weights[i] = (float)r.NextDouble() * 2 - 1;
            }
        }
    }
}
