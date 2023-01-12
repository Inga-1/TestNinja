using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private TestNinja.Fundamentals.Stack<string> _stack;

        [SetUp]

        public void SetUp() 
        
        {
            _stack = new TestNinja.Fundamentals.Stack<string>();
        }

        [Test]
        public void Push_ArgsAreValid_AddTheNewElementToTheStack()
        {

            //Act
            _stack.Push("a");

            //Assert
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]

        public void Push_ArgIsNull_ThrowArgNullExpression()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);

        }

        [Test]

        public void Count_EmptyStack_ReturnZero()
        {

            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]


        public void Pop_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithObjects_ReturnObjectOnTheTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            Assert.That(_stack.Pop, Is.EqualTo("c"));
        }

        [Test]

        public void Pop_StackWithObjects_RemoveTheObjectOnTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]

        public void Peek_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]

        public void Peek_StackWithObjects_ReturnTheTopObject()
        {

            _stack.Push("a");
            _stack.Push("b");

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]

        public void Peek_StackWithObjects_ObjectOnTopIsNOtRemoved()
        {
            _stack.Push("a");
            _stack.Push("b");
                
            _stack.Peek();

            Assert.That(_stack.Count, Is.EqualTo(2));
        }
    }
}
