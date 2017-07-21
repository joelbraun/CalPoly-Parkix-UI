using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkixUI2.Services.Contracts
{
    public interface IAuthTokenService
    {

        /// <summary>
        /// Regenerates tokens for use with Parkix services.
        /// </summary>
        void GenerateTokens();

        /// <summary>
        /// Returns the Parkix configuration auth token.
        /// </summary>
        string ConfigureAuthToken { get; }

        /// <summary>
        /// Returns the Parkix report auth token.
        /// </summary>
        string ReportAuthToken { get; }
    }
}
