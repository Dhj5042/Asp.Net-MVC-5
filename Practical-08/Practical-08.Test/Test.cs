using NUnit.Framework;
using Practical_08.Controllers;
using Practical_08.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_08.Test
{
    [TestFixture]
    class Test
    {
        [Test]
        public void CheckReturnString()
        {
            var str = new ReturnString();
            Assert.That(str.ReturnStringvalue(), Is.EqualTo("Hello World"));
        }
    }
}
