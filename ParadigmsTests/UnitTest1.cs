using NUnit.Framework;
using Paradigms;
using Paradigms.Module_1;
using Paradigms.Module_3;
using System.Collections.Generic;

namespace ParadigmsTests
{
    public class Tests
    {
        static public IEnumerable<TestCaseData> combination_tests()
        {
            yield return new TestCaseData(new int[,] { { 6, 2, 2 }, { 2, 10, 1 }, { 7, 3, 9 } },
                                          new MaxMinOfRows(TypeSort.Min),
                                          SortOrder.Decrease,
                                          new int[,] { { 7, 3, 9 }, { 6, 2, 2 }, { 2, 10, 1 } }).SetName("[SORT] test 1"); ;

            yield return new TestCaseData(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
                                            new MaxMinOfRows(TypeSort.Max),
                                            SortOrder.Increase,
                                            new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }).SetName("[SORT] test 2"); ;

            yield return new TestCaseData(new int[,] { { 2, 2, 8 }, { 1, 3, 7 }, { 0, 0, 5 } },
                                          new SumRows(),
                                          SortOrder.Increase,
                                          new int[,] { { 0, 0, 5 }, { 1, 3, 7 }, { 2, 2, 8 } }).SetName("[SORT] test 3");

            yield return new TestCaseData(new int[,] { { 9, 2, 8 }, { 1, 3, 7 }, { 0, 0, 5 } },
                                          new SumRows(),
                                          SortOrder.Decrease,
                                          new int[,] { { 9, 2, 8 }, { 1, 3, 7 }, { 0, 0, 5 } }).SetName("[SORT] test 4");

            yield return new TestCaseData(new int[,] { { 9, 4, 4 }, { 3, 12, 0 }, { 8, 2, 10 } },
                                          new MaxMinOfRows(TypeSort.Min),
                                          SortOrder.Decrease,
                                          new int[,] { { 9, 4, 4 }, { 8, 2, 10 }, { 3, 12, 0 } }).SetName("[SORT] test 5"); ;
        }

        [TestCaseSource("combination_tests")]
        public void Sort_Tests(int[,] array, Sorts strategy, SortOrder sortOrder, int[,] expectedArray)
        {
            SortContext sortContext = new SortContext(strategy);
            sortContext.ExecuteSort(array, sortOrder);
            Assert.AreEqual(array, expectedArray);
        }


        static public IEnumerable<TestCaseData> combination_tests_polynomial_addition()
        {
            yield return new TestCaseData(new Polynomial(new double[] { 1.0, 2.0 }),
                                          new Polynomial(new double[] { 1.0, 2.0 }),
                                          new Polynomial(new double[] { 2.0, 4.0 })).SetName("[Polynomial_Addition] test 1");

            yield return new TestCaseData(new Polynomial(new double[] { 1.5, 2.7 }),
                                          new Polynomial(new double[] { 2.35, 2.1 }),
                                          new Polynomial(new double[] { 3.85, 4.8 })).SetName("[Polynomial_Addition] test 2");

            yield return new TestCaseData(new Polynomial(new double[] { 11.3623, 21.0, 31.4 }),
                                          new Polynomial(new double[] { 1.0, 2.0 }),
                                          new Polynomial(new double[] { 12.3623, 23.0, 31.4 })).SetName("[Polynomial_Addition] test 3");

            yield return new TestCaseData(new Polynomial(new double[] { 0.0, 1.0, 2.0 }),
                                          new Polynomial(new double[] { 1.0, 2.0 }),
                                          new Polynomial(new double[] { 1.0, 3.0, 2.0 })).SetName("[Polynomial_Addition] test 4");

            yield return new TestCaseData(new Polynomial(new double[] { 0.0, 12.5 }),
                                          new Polynomial(new double[] { 0.0, 3.5 }),
                                          new Polynomial(new double[] { 0.0, 16.0 })).SetName("[Polynomial_Addition] test 5"); ;
        }

        [TestCaseSource("combination_tests_polynomial_addition")]
        public void Polynomial_addition_Tests(Polynomial polynomialFirst, Polynomial polynomialSecond, Polynomial resultPolynomial)
        {
            Assert.AreEqual(true, resultPolynomial.Equals(polynomialFirst + polynomialSecond));
        }

        static public IEnumerable<TestCaseData> combination_tests_polynomial_subtraction()
        {
            yield return new TestCaseData(new Polynomial(new double[] { 1.0, 2.0 }),
                                          new Polynomial(new double[] { 1.0, 2.0 }),
                                          new Polynomial(new double[] { 0.0, 0.0 })).SetName("[Polynomial_Subtraction] test 1");

            yield return new TestCaseData(new Polynomial(new double[] { 1.5, 2.7 }),
                                          new Polynomial(new double[] { 2.35, 2.1 }),
                                          new Polynomial(new double[] { -0.85, 0.6 })).SetName("[Polynomial_Subtraction] test 2");

            yield return new TestCaseData(new Polynomial(new double[] { 11.3623, 21.0, 31.4 }),
                                          new Polynomial(new double[] { 1.0, 2.0 }),
                                          new Polynomial(new double[] { 10.3623, 19.0, 31.4 })).SetName("[Polynomial_Subtraction] test 3");

            yield return new TestCaseData(new Polynomial(new double[] { 0.0, 1.0, 2.0 }),
                                          new Polynomial(new double[] { 1.0, 2.0 }),
                                          new Polynomial(new double[] { -1.0, -1.0, 2.0 })).SetName("[Polynomial_Subtraction] test 4");

            yield return new TestCaseData(new Polynomial(new double[] { 0.0, 12.5 }),
                                          new Polynomial(new double[] { 0.0, 3.5 }),
                                          new Polynomial(new double[] { 0.0, 9.0 })).SetName("[Polynomial_Subtraction] test 5"); ;
        }

        [TestCaseSource("combination_tests_polynomial_subtraction")]
        public void Polynomial_subtraction_Tests(Polynomial polynomialFirst, Polynomial polynomialSecond, Polynomial resultPolynomial)
        {
            Polynomial polynomial = polynomialFirst - polynomialSecond;
            Assert.AreEqual(true, resultPolynomial.Equals(polynomial));
        }

        static public IEnumerable<TestCaseData> combination_tests_polynomial_multiplication()
        {
            yield return new TestCaseData(new Polynomial(new double[] { 0.0, 0.0, 2.0 }),
                                          new Polynomial(new double[] { 1.0, 3.0 }),
                                          new Polynomial(new double[] { 0.0, 0.0, 2.0, 6.0 })).SetName("[Polynomial_Multiplication] test 1");

            yield return new TestCaseData(new Polynomial(new double[] { 5.0, 3.0, 21.0 }),
                                          new Polynomial(new double[] { 2.0, 1.0, 6.0, 2.0 }),
                                          new Polynomial(new double[] { 10.0, 11.0, 75.0, 49.0, 132.0, 42.0 })).SetName("[Polynomial_Multiplication] test 2");

            yield return new TestCaseData(new Polynomial(new double[] { 5.0, 0.0, 1.0 }),
                                          new Polynomial(new double[] { 5.0, 1.0 }),
                                          new Polynomial(new double[] { 25.0, 5.0, 5.0, 1.0 })).SetName("[Polynomial_Multiplication] test 3");

            yield return new TestCaseData(new Polynomial(new double[] { 0.0, 0.0, 2.0 }),
                                          new Polynomial(new double[] { 0.0, 0.0, 2.0 }),
                                          new Polynomial(new double[] { 0.0, 0.0, 0.0, 0.0, 4.0 })).SetName("[Polynomial_Multiplication] test 4");

            yield return new TestCaseData(new Polynomial(new double[] { 0.0, 12.5 }),
                                          new Polynomial(new double[] { 0.0, 3.5 }),
                                          new Polynomial(new double[] { 0.0, 0.0, 43.75 })).SetName("[Polynomial_Multiplication] test 5"); ;
        }

        [TestCaseSource("combination_tests_polynomial_multiplication")]
        public void Polynomial_multiplication_Tests(Polynomial polynomialFirst, Polynomial polynomialSecond, Polynomial resultPolynomial)
        {
            Polynomial polynomial = polynomialFirst * polynomialSecond;
            Assert.AreEqual(true, resultPolynomial.Equals(polynomial));
        }

        static public IEnumerable<TestCaseData> combination_tests_polynomial_div()
        {
            yield return new TestCaseData(new Polynomial(new double[] { 3.0, -6.333333333333333, 2.0, -8.0 }),
                                          new Polynomial(new double[] { -1.0, 2.0 }),
                                          new Polynomial(new double[] { -3.666666666666667, -1.0, -4.0 })).SetName("[Polynomial_div] test 1");

            yield return new TestCaseData(new Polynomial(new double[] { 5.0, 0.0, 2.0 }),
                                          new Polynomial(new double[] { 2.0, 1.0}),
                                          new Polynomial(new double[] { -4.0, 2.0})).SetName("[Polynomial_div] test 2");

            yield return new TestCaseData(new Polynomial(new double[] { 0.0, 0.0, 0.0, 1.0 }),
                                          new Polynomial(new double[] { 4.0, 2.0, 1.0 }),
                                          new Polynomial(new double[] { -2.0, 1.0})).SetName("[Polynomial_div] test 3");

            yield return new TestCaseData(new Polynomial(new double[] { 0.0, 1.0}),
                                          new Polynomial(new double[] { 0.0, 1.0}),
                                          new Polynomial(new double[] { 1.0})).SetName("[Polynomial_div] test 4");

            yield return new TestCaseData(new Polynomial(new double[] { 1.0, 0.0, 1.0 }),
                                          new Polynomial(new double[] { 5.0, 0.0, 1.0 }),
                                          new Polynomial(new double[] { 1.0})).SetName("[Polynomial_div] test 5"); ;
        }

        [TestCaseSource("combination_tests_polynomial_div")]
        public void Polynomial_div_Tests(Polynomial polynomialFirst, Polynomial polynomialSecond, Polynomial resultPolynomial)
        {
            Polynomial polynomial = polynomialFirst / polynomialSecond;
            Assert.AreEqual(true, resultPolynomial.Equals(polynomial));
        }
    }
}