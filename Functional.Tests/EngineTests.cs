using System;
using System.Linq;
using Functional.Bad;
using Xunit;

namespace Functional.Tests
{
    public abstract class BaseClassFixture
    {
        public int IntField
        {
            get;
            set;
        }
    }

    public class ClassFixture : BaseClassFixture
    {
        
    }

    public class CollectionFixture
    {
        public CollectionFixture()
        {
            CalcEngine = new Engine();
        }

        public Engine CalcEngine
        {
            get;
            private set;
        }

        public void AssertSequence(int[] expected, int[] actual)
        {
            Assert.True(expected.SequenceEqual(actual));
            Assert.Same(expected, actual);
        }
    }

    [CollectionDefinition("TestContext")]
    public class Collection : ICollectionFixture<CollectionFixture>
    {
        
    }

    [Collection("TestContext")]
    public class EngineTestsWithState
    {
        private readonly CollectionFixture collectionFixture;
        public EngineTestsWithState(CollectionFixture collectionFixture)
        {
            this.collectionFixture = collectionFixture;
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 })]
        [InlineData(new[] { 6, 7, 8, 9, 10 })]
        public void TestMethod(int[] expected)
        {
            int[] actual = collectionFixture.CalcEngine.Calc(expected);
            collectionFixture.AssertSequence(expected, actual);
        }
    }

    [Collection("TestContext")]
    public class EngineTests : IClassFixture<ClassFixture>, IDisposable
    {
        private readonly CollectionFixture collectionFixture;
        private BaseClassFixture classFixture;

        public EngineTests(CollectionFixture collectionFixture, ClassFixture classFixture)
        {
            this.collectionFixture = collectionFixture;
            this.classFixture = classFixture;
        }

        [Fact]
        public void TestMethod()
        {
            int[] expected = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            int[] actual = collectionFixture.CalcEngine.Calc(expected);
            collectionFixture.AssertSequence(expected, actual);
        }

        [Fact]
        public void TestMethod2()
        {
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] actual = collectionFixture.CalcEngine.Calc(expected);
            collectionFixture.AssertSequence(expected, actual);
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            
        }

        #endregion
    }
}
