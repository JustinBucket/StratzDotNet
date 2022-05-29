using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratzDotNet;

namespace StratzDotNetTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestBaseUriAssignment()
    {
        using (var caller = new StratzCaller())
        {
            Assert.AreEqual("https://api.stratz.com/api/v1/", caller.BaseAddress.AbsoluteUri);
        }
    }

    [TestMethod]
    public void TestGetGameVersion()
    {
        using (var caller = new StratzCaller())
        {
            var gameVersionResponse = caller.GetGameVersion().Result;

            Assert.AreEqual("", gameVersionResponse);
        }
    }
}