using FluentAssertions;

namespace nUnitTests.ParallelTests
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class FirstClassTest
    {
        [Test, Order(1)]
        public void FirstTest()
        {
            var numberOfIteration = 10;
            var count = GetIterator(numberOfIteration);
            count.Should().Be(numberOfIteration);
        }

        [Test, Order(2)]
        public void SecondTest()
        {
            var numberOfIteration = 10;
            var count = GetIterator(numberOfIteration);
            count.Should().Be(numberOfIteration);
        }

        [Test, Order(3)]
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
