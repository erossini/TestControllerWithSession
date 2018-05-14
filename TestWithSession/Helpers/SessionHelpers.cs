using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithSession.Models;

namespace TestWithSession.Helpers
{
    /// <summary>
    /// Class SessionHelpers.
    /// </summary>
    public static class SessionHelpers
    {
        /// <summary>
        /// Gets the details.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>SessionData.</returns>
        public static SessionData GetDetails(ISession session)
        {
            SessionData rtn = new SessionData();
            rtn.ClientId = GetString(session, "ClientId");
            return rtn;
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public static string GetString(this ISession session, string key)
        {
            byte[] value = null;
            session.TryGetValue(key, out value);

            string rtn = string.Empty;
            if (value != null)
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                rtn = encoding.GetString(value);
            }

            return rtn;
        }
    }
}