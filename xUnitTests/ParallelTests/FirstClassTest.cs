using FluentAssertions;

namespace DemoLiteCart.nUnitTests.Tests.ParallelTests
{

    public class FirstClassTest
    {
        [Fact]
        public void FirstTest()
        {
            var numberOfIteration = 10;
            var count = GetIterator(numberOfIteration);
            count.Should().Be(numberOfIteration);
        }

        [Fact]
        public void SecondTest()
        {
            var numberOfIteration = 10;
            var count = GetIterator(numberOfIteration);
            count.Should().Be(numberOfIteration);
        }

        [Fact]
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
