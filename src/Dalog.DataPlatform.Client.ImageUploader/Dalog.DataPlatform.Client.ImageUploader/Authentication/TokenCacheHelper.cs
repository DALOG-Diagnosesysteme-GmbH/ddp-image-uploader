// -----------------------------------------------------------------------
// <copyright file="TokenCacheHelper.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Reflection;
using System.Security.Cryptography;
using Microsoft.Identity.Client;

namespace Dalog.DataPlatform.Client.ImageUploader.Authentication
{
    /// <summary>
    /// The token cache helper static class.
    /// </summary>
    internal static class TokenCacheHelper
    {
        /// <summary>
        /// Path to the token cache
        /// </summary>
        public static readonly string CacheFilePath = Assembly.GetExecutingAssembly().Location + ".msalcache.bin3";

        /// <summary>
        /// The file lock object.
        /// </summary>
        private static readonly object FileLock = new();

        /// <summary>
        /// Method called after access notification.
        /// </summary>
        /// <param name="args">The token cache notification args.</param>
        public static void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            // if the access operation resulted in a cache update
            if (args.HasStateChanged)
            {
                lock (FileLock)
                {
                    // reflect changesgs in the persistent store
                    File.WriteAllBytes(CacheFilePath,
                                       ProtectedData.Protect(args.TokenCache.SerializeMsalV3(),
                                                             null,
                                                             DataProtectionScope.CurrentUser)
                                      );
                }
            }
        }

        /// <summary>
        /// Method called before access notification.
        /// </summary>
        /// <param name="args">The token cache notification args.</param>
        public static void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            lock (FileLock)
            {
                args.TokenCache.DeserializeMsalV3(File.Exists(CacheFilePath)
                        ? ProtectedData.Unprotect(File.ReadAllBytes(CacheFilePath),
                                                 null,
                                                 DataProtectionScope.CurrentUser)
                        : null);
            }
        }

        /// <summary>
        /// Enables the serialization
        /// </summary>
        /// <param name="tokenCache">The token cache</param>
        internal static void EnableSerialization(ITokenCache tokenCache)
        {
            tokenCache.SetBeforeAccess(BeforeAccessNotification);
            tokenCache.SetAfterAccess(AfterAccessNotification);
        }
    }
}