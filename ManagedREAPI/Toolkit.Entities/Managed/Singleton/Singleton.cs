using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Managed.Singleton
{
    public static class Singleton<T> where T : new()
    {
        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        private static T Instance
        {
            get
            {
                // Thread safe, lazy implementation of the singleton pattern.
                // See http://www.yoda.arachsys.com/csharp/singleton.html
                // for the full story.
                return SingletonInternal.instance;
            }
        }

        private class SingletonInternal
        {
            private SingletonInternal() { }
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit.
            static SingletonInternal()
            {
            }

            internal static readonly T instance = new T();
        }
    }
}
