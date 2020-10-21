using NuGet.Frameworks;
using NUnit.Framework;
using MyList;

namespace Lab.Tests
{
    public class Tests
    {
        [Test]
        public void Add()
        {
            string item = "123";
            bool expected = true;
            AnnularList<string> ts = new AnnularList<string>();
            bool actual = ts.Add(item);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Empty()
        {
            string item = "123";
            AnnularList<string> ts = new AnnularList<string>();
            ts.Add(item);
            bool actual = ts.Empty;
            Assert.IsFalse(actual);
        }
        [Test]
        public void Count()
        {
            int expected = 2;
            AnnularList<string> ts = new AnnularList<string>();
            ts.Add("Vova");
            ts.Add("Katia");
            int actual = ts.Count;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(ts.Contains("Vova"), true);
        }
        [Test]
        public void Remove_Exception()
        {
            AnnularList<string> ts = new AnnularList<string>();
            var ex = Assert.Throws<System.Exception>(() => ts.Remove("1"));
            Assert.That(ex.Message == "List is empty");
            Assert.IsNull(ts.head);
        }
        [Test]
        public void Remove()
        {
            string item = "123";
            bool expected = true;
            AnnularList<string> ts = new AnnularList<string>();
            ts.Add(item);
            bool actual = ts.Remove(item);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Clear()
        {
            int expectedcount = 0;
            bool expected = true;
            AnnularList<string> ts = new AnnularList<string>();
            ts.Add("1");
            bool actual = ts.Clear();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedcount, ts.Count);
            Assert.IsNull(ts.tail);
            Assert.IsNull(ts.head);
        }
        [Test]
        public void Contains_Exception()
        {
            AnnularList<string> ts = new AnnularList<string>();
            var ex = Assert.Throws<System.Exception>(() => ts.Contains("1"));
            Assert.That(ex.Message == "List is empty");
        }
        [Test]
        public void Contains()
        {
            string item = "123";
            AnnularList<string> ts = new AnnularList<string>();
            ts.Add(item);
            bool actual = ts.Contains(item);
            Assert.IsTrue(actual);
            Assert.IsNotNull(ts.head);
            Assert.IsNotNull(ts.tail);
        }
    }
}