using System;
using System.Collections.Generic;

namespace Paradigms.Module_3
{
    public class Polynomial
    {
        public double[] _coeffs { get; set; }
        public double[] remainder { get; private set; }
        private const double eps = 0.00000001;

        public Polynomial(params double[] coeffs)
        {
            _coeffs = coeffs;
        }

        public override bool Equals(object obj)
        {
            Polynomial polynomial = (Polynomial)obj;

            if(_coeffs.Length != polynomial._coeffs.Length)
            {
                return false;
            }

            for(int i = 0; i<_coeffs.Length; i++)
            {
                if((Math.Abs(_coeffs[i] - polynomial._coeffs[i]) >= eps))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return _coeffs.GetHashCode();
        }

        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return Operation(firstPolynomial,
                             secondPolynomial,
                             (double first, double second) => first += second);
        }

        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return Operation(firstPolynomial,
                             secondPolynomial,
                             (double first, double second) => first -= second);
        }

        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return OperationMult(firstPolynomial,
                             secondPolynomial);
        }

        public static Polynomial operator /(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return OperationDiv(firstPolynomial, 
                             secondPolynomial);
        }

        private static Polynomial Operation(Polynomial firstPolynomial, Polynomial secondPolynomial, Func<double, double, double> action)
        {
            int length = (firstPolynomial._coeffs.Length >= secondPolynomial._coeffs.Length) ?
                             firstPolynomial._coeffs.Length :
                             secondPolynomial._coeffs.Length;

            double[] coeffs = new double[length];
            for (int i = 0; i < secondPolynomial._coeffs.Length; i++)
            {
                coeffs[i] = action(firstPolynomial._coeffs[i], secondPolynomial._coeffs[i]);
            }

            for(int i = secondPolynomial._coeffs.Length; i < firstPolynomial._coeffs.Length; i++)
            {
                coeffs[i] = firstPolynomial._coeffs[i];
            }

            return new Polynomial(coeffs);
        }

        private static Polynomial OperationMult(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            int lengthNewPolynomial = firstPolynomial._coeffs.Length + secondPolynomial._coeffs.Length - 1;
            double[] coeffs = new double[lengthNewPolynomial];

            for (int i = 0; i < firstPolynomial._coeffs.Length; i++)
            {
                for(int j = 0; j < secondPolynomial._coeffs.Length; j++)
                {
                    if (firstPolynomial._coeffs[i] == 0)
                    {
                        break;
                    }

                    coeffs[i+j] += firstPolynomial._coeffs[i] * secondPolynomial._coeffs[j];
                }
            }

            return new Polynomial(coeffs);
        }

        private static Polynomial OperationDiv(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial._coeffs[firstPolynomial._coeffs.Length-1] == 0)
            {
                throw new ArithmeticException("The leading term of the divisible polynomial cannot be 0");
            }

            if (secondPolynomial._coeffs[secondPolynomial._coeffs.Length - 1] == 0)
            {
                throw new ArithmeticException("The leading term of the divisor polynomial cannot be 0");
            }

            double[] remainder = (double[])firstPolynomial._coeffs.Clone();
            double[] coeffs = new double[firstPolynomial._coeffs.Length - secondPolynomial._coeffs.Length + 1];

            for (int i = 0; i < coeffs.Length; i++)
            {
                //if (firstPolynomial._coeffs[i] == 0) continue;

                double coeff = remainder[firstPolynomial._coeffs.Length - i - 1] / secondPolynomial._coeffs[secondPolynomial._coeffs.Length-1];
                coeffs[coeffs.Length - i - 1] = coeff;

                for (int j = 0; j < secondPolynomial._coeffs.Length; j++)
                {
                    //if (secondPolynomial._coeffs[j] == 0) continue;

                    remainder[remainder.Length - i - j - 1] -= coeff * secondPolynomial._coeffs[secondPolynomial._coeffs.Length - j - 1];
                }
            }
            
            return new Polynomial(coeffs);
        }

        private static Polynomial OperationInverse(Polynomial polynomial)
        {
            double[] coeffs = new double[polynomial._coeffs.Length];
            
            for(int i = 0, k = polynomial._coeffs.Length - 1; i < polynomial._coeffs.Length; i++, k--)
            {
                coeffs[i] = polynomial._coeffs[k];
            }

            return new Polynomial(coeffs);
        }
    }
}
