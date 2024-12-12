using FluentAssertions;

namespace nUnitTests.ParallelTests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class ThirdClassTest
    {
        [Test]
        public void FirstTest()
        {
            var numberOfIteration = 10;
            var count = GetIterator(numberOfIteration);
            count.Should().Be(numberOfIteration);
        }

        [Test]
        public void SecondTest()
        {
            var numberOfIteration = 10;
            var count = GetIterator(numberOfIteration);
            count.Should().Be(numberOfIteration);
        }

        [Test]
        public void ThirdTest()
        {
            var numberOfIteration = 10;
            var count = GetIterator(numberOfIteration);
            count.Should().Be(numberOfIteration);
        }

        private int GetIterator(int number)
        {
            var counter = 0;
            for (int i = 0; i < number; i++)
            {
                counter++;
                Thread.Sleep(500);
            }
            return counter;
        }
    }
}
