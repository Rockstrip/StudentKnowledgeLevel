using InferenceLibrary;

namespace InferenceTests
{
    [TestClass]
    public class FuzzifierTests
    {
        public FuzzifierTests()
        {
            ModelCacheManager.InitializeModel();
        }

        [TestMethod]
        public void TestOutputLength()
        {
            var input = new double[3];

            var result = Fuzzifier.Fuzzification(input);

            Assert.AreEqual(result.Length, 3);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestOutputException()
        {
            var input = new double[2];

            var result = Fuzzifier.Fuzzification(input);
        }

        [TestMethod]
        public void TestNormalSeverity()
        {
            var input = new double[] { 1, 3.5, 6.5 };

            var result = Fuzzifier.Fuzzification(input);

            var first = result[0];

            Assert.AreEqual(first[Severity.Unsatisfactory], 1, 0.1);
            Assert.AreEqual(first[Severity.Satisfactory], 0, 0.1);
            Assert.AreEqual(first[Severity.Good], 0, 0.1);
            Assert.AreEqual(first[Severity.Excellent], 0, 0.1);
        }

        [TestMethod]
        public void TestMildSeverity()
        {
            var input = new double[] { 1, 3.5, 6.5 };

            var result = Fuzzifier.Fuzzification(input);

            var second = result[1];

            Assert.AreEqual(second[Severity.Satisfactory], 1, 0.1);
            Assert.AreEqual(second[Severity.Unsatisfactory], 0, 0.1);
            Assert.AreEqual(second[Severity.Good], 0, 0.1);
            Assert.AreEqual(second[Severity.Excellent], 0, 0.1);
        }

        [TestMethod]
        public void TestModerateSeverity()
        {
            var input = new double[] { 1, 3.5, 6.5 };

            var result = Fuzzifier.Fuzzification(input);

            var third = result[2];

            Assert.AreEqual(third[Severity.Good], 1, 0.1);
            Assert.AreEqual(third[Severity.Unsatisfactory], 0, 0.1);
            Assert.AreEqual(third[Severity.Satisfactory], 0, 0.1);
            Assert.AreEqual(third[Severity.Excellent], 0, 0.1);
        }

        [TestMethod]
        public void TestSevereSeverity()
        {
            var input = new double[] { 9, 3.5, 6.5 };

            var result = Fuzzifier.Fuzzification(input);

            var first = result[0];

            Assert.AreEqual(first[Severity.Excellent], 1, 0.1);
            Assert.AreEqual(first[Severity.Unsatisfactory], 0, 0.1);
            Assert.AreEqual(first[Severity.Satisfactory], 0, 0.1);
            Assert.AreEqual(first[Severity.Good], 0, 0.1);
        }

        [TestMethod]
        public void TestNormalMildSeverity()
        {
            var input = new double[] { 2.5, 5.1, 7.65 };

            var result = Fuzzifier.Fuzzification(input);

            var first = result[0];

            Assert.IsTrue(first[Severity.Unsatisfactory] < 0.55);
            Assert.IsTrue(first[Severity.Satisfactory] > 0.45);
            Assert.AreEqual(first[Severity.Good], 0, 0.1);
            Assert.AreEqual(first[Severity.Excellent], 0, 0.1);
        }

        [TestMethod]
        public void TestMildModerateSeverity()
        {
            var input = new double[] { 2.5, 5.1, 7.65 };

            var result = Fuzzifier.Fuzzification(input);

            var second = result[1];

            Assert.IsTrue(second[Severity.Satisfactory] < 0.55);
            Assert.IsTrue(second[Severity.Good] > 0.45);
            Assert.AreEqual(second[Severity.Unsatisfactory], 0, 0.1);
            Assert.AreEqual(second[Severity.Excellent], 0, 0.1);
        }

        [TestMethod]
        public void TestModerateSevereSeverity()
        {
            var input = new double[] { 2.5, 5.1, 7.65 };

            var result = Fuzzifier.Fuzzification(input);

            var third = result[2];

            Assert.IsTrue(third[Severity.Good] < 0.55);
            Assert.IsTrue(third[Severity.Excellent] > 0.45);
            Assert.AreEqual(third[Severity.Unsatisfactory], 0, 0.1);
            Assert.AreEqual(third[Severity.Satisfactory], 0, 0.1);
        }
    }
}