// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace VetPlatform.Auth
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("vp_portal_api", "VP Portal API"),
                new ApiResource("vp_store_api", "VP Store API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // SPA client using implicit flow
                new Client
                {
                    ClientId = "vp_portal",
                    ClientName = "VP Portal",
                    ClientUri = "vetplatform.com",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =
                    {
                        "http://pets.vetplatform.local:4200",
                        "http://pets.vetplatform.local:4200/index.html",
                        "http://pets.vetplatform.local:4200/callback.html",
                        "http://pets.vetplatform.local:4200/silent.html",
                        "http://pets.vetplatform.local:4200/popup.html",
                    },

                    PostLogoutRedirectUris = { "http://pets.vetplatform.local:4200" },
                    AllowedCorsOrigins = { "http://pets.vetplatform.local:4200" },

                    AllowedScopes = { "openid", "profile", "vp_portal_api" },

                    RequireConsent = false
                }
            };
        }
    }
}