using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestWithSession.Tests.Helpers
{
    /// <summary>
    /// Class MockHttpSession.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Http.ISession" />
    public class MockHttpSession : ISession
    {
        /// <summary>
        /// The session storage
        /// </summary>
        Dictionary<string, object> sessionStorage = new Dictionary<string, object>();
        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Object.</returns>
        public object this[string name]
        {
            get { return sessionStorage[name]; }
            set { sessionStorage[name] = value; }
        }

        /// <summary>
        /// A unique identifier for the current session. This is not the same as the session cookie
        /// since the cookie lifetime may not be the same as the session entry lifetime in the data store.
        /// </summary>
        /// <value>The identifier.</value>
        /// <exception cref="NotImplementedException"></exception>
        string ISession.Id
        {
            get {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Indicate whether the current session has loaded.
        /// </summary>
        /// <value><c>true</c> if this instance is available; otherwise, <c>false</c>.</value>
        /// <exception cref="NotImplementedException"></exception>
        bool ISession.IsAvailable
        {
            get {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Enumerates all the keys, if any.
        /// </summary>
        /// <value>The keys.</value>
        IEnumerable<string> ISession.Keys
        {
            get { return sessionStorage.Keys; }
        }

        /// <summary>
        /// Remove all entries from the current session, if any.
        /// The session cookie is not removed.
        /// </summary>
        void ISession.Clear()
        {
            sessionStorage.Clear();
        }

        /// <summary>
        /// Store the session in the data store. This may throw if the data store is unavailable.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task ISession.CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load the session from the data store. This may throw if the data store is unavailable.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task ISession.LoadAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove the given key from the session if present.
        /// </summary>
        /// <param name="key">The key.</param>
        void ISession.Remove(string key)
        {
            sessionStorage.Remove(key);
        }

        /// <summary>
        /// Set the given key and value in the current session. This will throw if the session
        /// was not established prior to sending the response.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void ISession.Set(string key, byte[] value)
        {
            sessionStorage[key] = value;
        }

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ISession.TryGetValue(string key, out byte[] value)
        {
            object storageValue = null;
            if (sessionStorage.TryGetValue(key, out storageValue))
            {
                var bytes = sessionStorage[key] as byte[];

                if (bytes != null)
                {
                    value = bytes;
                    return true;
                }

                value = Encoding.UTF8.GetBytes(sessionStorage[key].ToString());
                return true;
            }

            value = null;
            return false;
        }
    }
}