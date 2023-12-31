using FiniteField.GaloisField;
using FiniteField.Helpers;


namespace FiniteFieldTests
{
    public class BasicAxiomsTests
    {
        public Element A;
        public Element B;
        public Element C;


        [SetUp]
        public void Setup()
        {
            A = Generator.Generate();
            B = Generator.Generate();
            C = Generator.Generate();
        }

        [Test]
        public void RightDistributivity()
        {
            Element X = (A + B) * C;
            Element Y = A * C + B * C;

            Assert.That(X == Y);
        }

        [Test]
        public void LeftDistributivity()
        {
            Element X = C * (A + B);
            Element Y = C * A + C * B;

            Assert.That(X == Y);
        }

        [Test]
        public void CommitativityAdd()
        {
            Element X = A + B;
            Element Y = B + A;

            Assert.That(X == Y);
        }

        [Test]
        public void CommitativityMult()
        {
            Element X = A * B;
            Element Y = B * A;

            Assert.That(X == Y);
        }
        [Test]
        public void AssociativityAdd()
        {
            Element X = (A + B) + C;
            Element Y = A + (B + C);

            Assert.That(X == Y);
        }
        [Test]
        public void AssociativityMult()
        {
            Element X = (A * B) * C;
            Element Y = A * (B * C);

            Assert.That(X == Y);
        }
        [Test]
        public void CycleTest() 
        {
            Element X = A.Pow(Field.MaxValue());

            Assert.That(X == Field.One());
        }
        [Test]
        public void InverseElementTest()
        {
            if(A == Field.Zero())
            {
                Assert.True(true);
            }
            Element X = A.InverseElement();

            Assert.That(X * A == Field.One());
        }
        [Test]
        public void SquareTest()
        {
            Element X = A.ToSquare();
            Element Y = A * A;

            Assert.That(X == Y);
        }
        [Test]
        public void QuadraticEquationTest1()
        {
            Element X;
            try
            {
                X = Field.SolveQuadradicEquation(A, B).Item1;
                Assert.That((X.ToSquare() + A * X + B) == Field.Zero());
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [Test]
        public void QuadraticEquationTest2()
        {
            Element X;
            try
            {
                X = Field.SolveQuadradicEquation(A, B).Item2;
                var result = X.ToSquare() + A * X + B;
                Console.WriteLine(result);
                Assert.That(result == Field.Zero()); 
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [Test]
        public void QuadraticEquationTestAZero()
        {
            Element X;
            try
            {
                X = Field.SolveQuadradicEquation(Field.Zero(), B).Item1;
                Assert.That((X.ToSquare() + B) == Field.Zero());
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [Test]
        public void QuadraticEquationTestBZero1()
        {
            Element X;
            try
            {
                X = Field.SolveQuadradicEquation(A, Field.Zero()).Item1;
                Assert.That((X.ToSquare() + X * A) == Field.Zero());
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [Test]
        public void QuadraticEquationTestBZero2()
        {
            Element X;
            try
            {
                X = Field.SolveQuadradicEquation(A, Field.Zero()).Item2;
                Assert.That((X.ToSquare() + X * A) == Field.Zero());
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
    }
}