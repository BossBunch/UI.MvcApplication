namespace MVC_MS_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, 1,"Fail Test case");
            Assert.AreEqual(1, 0,"Fail Test case");
        }
    }
}