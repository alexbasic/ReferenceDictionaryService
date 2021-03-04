using Domain;
using Model.Store;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal.Tests
{
    public class ReferenceServiceTest
    {
        [Test]
        public void GetTableTest()
        {
            using (var context = new InTestReferenceDataContextFactory().CreateDbContext())
            {
                var rf = new ReferenceService(new TestRepositoryFactory(context));
                var resultData = rf.GetTable(DateTime.Now, "Test");

                var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(resultData);
            }
            Assert.Pass();
        }
    }
}