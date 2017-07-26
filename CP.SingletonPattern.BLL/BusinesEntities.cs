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
}
