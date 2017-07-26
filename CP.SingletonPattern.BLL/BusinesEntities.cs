using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.SingletonPattern.BLL
{
    /// <summary>
    /// The 'Singleton' class
    /// </summary>
   public class Singleton
    {
        private static Singleton _instance;
        private static bool ifCreated = false;
        // Constructor is 'protected'
        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new Singleton();
                ifCreated = true;
            }
            else
            {
                ifCreated = false;
            }
            return _instance;
        }

        public bool TellMeIfCreated()
        {
            return ifCreated;
        }
    }

    /// <summary>
    /// The 'Singleton' class
    /// </summary>
   public class LoadBalancer
    {
        private static LoadBalancer _instance;
        private List<string> _servers = new List<string>();
        private Random _random = new Random();

        // Lock synchronization object
        private static object syncLock = new object();

        // Constructor (protected)
        protected LoadBalancer()
        {
            // List of available servers
            _servers.Add("ServerI");
            _servers.Add("ServerII");
            _servers.Add("ServerIII");
            _servers.Add("ServerIV");
            _servers.Add("ServerV");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoadBalancer();
                    }
                }
            }

            return _instance;
        }

        // Simple, but effective random load balancer
        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r].ToString();
            }
        }
    }
}
