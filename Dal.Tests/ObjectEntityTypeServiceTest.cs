using Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Tests
{
    [TestFixture]
    public class ObjectEntityTypeServiceTest
    {
        [Test]
        public void GetTableTest()
        {
            using (var context = new InTestReferenceDataContextFactory().CreateDbContext())
            {
                var rf = new ObjectEntityTypeService(new TestRepositoryFactory(context));
                //var resultData = rf.Add(new );

               // var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(resultData);
            }
            Assert.Pass();
        }
    }
}
