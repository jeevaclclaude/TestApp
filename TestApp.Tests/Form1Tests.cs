using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp;

namespace TestApp.Tests
{
    [TestClass]
    public class Form1Tests
    {
        [TestMethod]
        public void Form1_Initializes_WithoutException()
        {
            Form1 form = null;
            try
            {
                form = new Form1();
                Assert.IsNotNull(form);
            }
            finally
            {
                form?.Dispose();
            }
        }

        [TestMethod]
        public void Button1_Click_ThrowsDivideByZeroException()
        {
            using (var form = new Form1())
            {
                var method = typeof(Form1).GetMethod("button1_Click",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                try
                {
                    method.Invoke(form, new object[] { null, EventArgs.Empty });
                    Assert.Fail("Expected DivideByZeroException was not thrown.");
                }
                catch (System.Reflection.TargetInvocationException ex)
                {
                    Assert.IsInstanceOfType(ex.InnerException, typeof(DivideByZeroException));
                }
            }
        }
    }
}
