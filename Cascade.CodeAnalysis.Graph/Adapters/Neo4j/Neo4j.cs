using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4j.Driver.V1;

namespace Cascade.CodeAnalysis.Graph.Adapters.Neo4j
{
    public class Neo4j : IAdapter
    {
        private readonly IDriver _driver;

        public Neo4j(string uri, string user, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        }

        public void PrintGreeting(string message)
        {
            //TODO - figure out how neo4j works
            using (var session = _driver.Session())
            {
//                var greeting = session.WriteTransaction(tx =>
//                {
//                    var result = tx.Run("CREATE (a:Greeting) " +
//                                        "SET a.message = $message " +
//                                        "RETURN a.message + ', from node ' + id(a)",
//                        new { message });
//                    return result.Single()[0].As();
//                });
//                Console.WriteLine(greeting);
            }
        }



        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}
