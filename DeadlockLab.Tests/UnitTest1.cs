using NUnit.Framework;
using System.Threading.Tasks;
using DeadlockLab;

namespace DeadlockLab.Tests
{
    [TestFixture]
    public class DeadlockTest
    {
        [Test]
        public void DeadlockDetectionTest()
        {
            var task = Task.Run(() => Program.Main());
            bool completed = task.Wait(5000);
            Assert.False(completed);
        }

        [Test, Timeout(5000)]
        public void DeadlockDetectionTestFail()
        {
            Task.Run(() => Program.Main()).Wait();
        }
    }
}


