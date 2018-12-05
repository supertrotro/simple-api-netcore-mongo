using System;
using Mongo2Go;

namespace Simple.Api.Tests.Repository
{
    public class MongoIntegrationTest:IDisposable
    {
        internal static MongoDbRunner Runner;
        internal static void CreateConnection()
        {
            Runner = MongoDbRunner.Start(singleNodeReplSet: false);
        }

        public void Dispose()
        {
            Runner.Dispose();
        }
    }
}
