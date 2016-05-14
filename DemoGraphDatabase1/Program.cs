using ConsoleApplication2.Ralationship;
using DemoGraphDatabase1;
using DemoGraphDatabase1.Node;
using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static GraphClient client;

        static void Main(string[] args)
        {
            try
            {
                ////no authorize
                //client = new GraphClient(new Uri("http://localhost:7474/db/data"));

                //authorize
                client = new GraphClient(
                    new Uri("http://localhost:7474/db/data"),
                    new HttpClientAuthWrapper("neo4j", "123456")
                    );
                client.Connect();

                ////INSERT
                //Person p = new Person();
                //p.name = "Dummy";
                //var query = client.Cypher
                //    .Create("(n:Person{name: \"" + p.name + "\" })")
                //    .Return<Person>("n.birthday");
                //Person dummy = ((List<Person>)query.Results)[0];

                //RETURN List<Actor>
                var query2 = client.Cypher
                    .Match("(n:Actor)-[r]-> (p:Movie)")
                    .Where("n.name='Tom Cruise'")
                    .Return<Movie>("p")
                    .Limit(5);
                List<Movie> list = (List<Movie>)query2.Results;

                //RETURN List<Person>
                var query3 = client.Cypher
                    .Match("(p:Person)-[r:ACTS_IN]-()")
                    //.Where("p.id = '692' ")                    
                    .ReturnDistinct<Person>("p")
                    .Limit(5);
                List<Person> list2 = (List<Person>)query3.Results;

                //Return relationship
                var query4 = client.Cypher
                    .Match("(n:Actor{name:'Roger Moore'})-[r]->()")
                    .ReturnDistinct<ACTS_IN>("r");
                List<ACTS_IN> list3 = (List<ACTS_IN>)query4.Results;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
    }
}
