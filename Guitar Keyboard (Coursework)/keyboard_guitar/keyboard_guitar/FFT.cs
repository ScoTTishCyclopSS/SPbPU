using System;
using System.Linq;

namespace SoundAnalysis
{
    class FFT
    {
        /// <summary>
        /// Gets number of significat bytes.
        /// </summary>
        /// <param name="n">Number</param>
        /// <returns>Amount of minimal bits to store the number.</returns>
        public static int Log2(int n)
        {
            int i = 0;
            while (n > 0)
            {
                ++i;
                n >>= 1;
            }

            return i;
        }

        /// <summary>
        /// Reverses bits in the number.
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="bitsCount">Significant bits in the number.</param>
        /// <returns>Reversed binary number.</returns>
        private static int ReverseBits(int n, int bitsCount)
        {
            int reversed = 0;
            for (int i = 0; i < bitsCount; i++)
            {
                int nextBit = n & 1;
                n >>= 1;

                reversed <<= 1;
                reversed |= nextBit;
            }

            return reversed;
        }


        /// <summary>
        /// Checks if number is power of 2.
        /// </summary>
        /// <param name="n">number</param>
        /// <returns>true if n=2^k and k is positive integer</returns>
        private static bool IsPowerOfTwo(int n)
        {
            return n > 1 && (n & (n - 1)) == 0;
        }

        /// <summary>
        /// Calculates FFT using Cooley-Tukey FFT algorithm.
        /// </summary>
        /// <param name="x">input data</param>
        /// <returns>spectrogram of the data</returns>
        /// <remarks>
        /// If amount of data items not equal a power of 2, then algorithm
        /// automatically pad with 0s to the lowest amount of power of 2.
        /// </remarks>
        private static float[] Calculate(float[] x)
        {
            int length;
            int bitsInLength;
            if (IsPowerOfTwo(x.Length))
            {
                length = x.Length;
                bitsInLength = Log2(length) - 1;
            }
            else
            {
                bitsInLength = Log2(x.Length);
                length = 1 << bitsInLength;
                // the items will be pad with zeros
            }

            // bit reversal
            ComplexNumber[] data = new ComplexNumber[length];
            for (int i = 0; i < x.Length; i++)
            {
                int j = ReverseBits(i, bitsInLength);
                data[j] = new ComplexNumber(x[i]);
            }

            // Cooley-Tukey 
            for (int i = 0; i < bitsInLength; i++)
            {
                int m = 1 << i;
                int n = m * 2;
                double alpha = -(2 * Math.PI / n);

                for (int k = 0; k < m; k++)
                {
                    // e^(-2*pi/N*k)
                    ComplexNumber oddPartMultiplier = new ComplexNumber(0, alpha * k).PoweredE();

                    for (int j = k; j < length; j += n)
                    {
                        ComplexNumber evenPart = data[j];
                        ComplexNumber oddPart = oddPartMultiplier * data[j + m];
                        data[j] = evenPart + oddPart;
                        data[j + m] = evenPart - oddPart;
                    }
                }
            }

            // calculate spectrogram
            float[] spectrogram = new float[length];
            for (int i = 0; i < spectrogram.Length; i++)
            {
                spectrogram[i] = (float)data[i].AbsPower2();
            }

            return spectrogram;
        }

        public static float[] FillSampleAgr(byte[] buffer, int BytesRecorded)
        {
            float[] sampleAggregator = new float[8192];
            for (int index = 0; index < BytesRecorded && index < 8192; index += 2)
            {
                short sample = (short)((buffer[index + 1] << 8) | buffer[index + 0]);

                float sample32 = sample / 32768f;
                float level = Math.Abs(sample32); // от 0 до 1                    
                sampleAggregator[index] = sample32;
            }

            return sampleAggregator;
        }

        public static float Level(float[] sampleAggregator)
        {
            float level = 0;
            for (int index = 0; index < sampleAggregator.Length; index += 2)
            {
                level += Math.Abs(sampleAggregator[index]); // от 0 до 1                                  
            }

            return level;
        }

        public static int Generative(float[] sampleAggregator)
        {
            float hz = 0; //частота

            float[] transform = new float[8192];
            {
                transform = Calculate(sampleAggregator);
                int k = 0;
                float maxtemp = transform.Max();

                foreach (float t in transform)
                {
                    if (t < 700) transform[k] = 0;
                    else transform[k] = t / (maxtemp * 10);
                    ++k;
                }

                float pr, prev_pr;
                prev_pr = 0;
                hz = 0;
                bool proizv = false;

                for (int j = 0; j < 250; ++j)
                {
                    //какие-то проверки
                    pr = 1 / (transform[j + 1] - transform[j]);
                    if (prev_pr > 0 && pr < 0 && !proizv)
                    {
                        if (j > 7 && transform[j] > 0.1)
                        {
                            hz = j;
                            proizv = true;
                        }
                    }

                    prev_pr = pr;
                }
            }
            return (int)hz;
        }
    }
}
