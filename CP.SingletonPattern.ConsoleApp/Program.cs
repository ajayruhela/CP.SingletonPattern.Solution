using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP.SingletonPattern.BLL;
namespace CP.SingletonPattern.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// MainApp startup class for Structural
        /// Singleton Design Pattern.
        /// </summary>
 
            static void Main()
            {
                // Constructor is protected -- cannot use new
                Singleton s1 = Singleton.Instance();
            Console.WriteLine("if s1 Created: {0:s}", s1.TellMeIfCreated());
            Singleton s2 = Singleton.Instance();
            Console.WriteLine("if s2 Created: {0:s}", s2.TellMeIfCreated());

            // Test for same instance
            if (s1 == s2)
                {
                    Console.WriteLine("Objects are the same instance");
                }
            Console.WriteLine("HashCode s1 {0}",s1.GetHashCode());
            Console.WriteLine("HashCode s2 {0}", s2.GetHashCode());
            // Wait for user

            Console.WriteLine("=================LoadBalancer============");
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }
            Console.ReadKey();
            }
     }
}
