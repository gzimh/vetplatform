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
                new IdentityResource("role", new[] { "role" }),
                new IdentityResource("tenantId", new[] { "tenantId" }),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("vp_portal_api", "VP Portal API", new [] { "role", "tenantId"}),
                new ApiResource("vp_store_api", "VP Store API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            var dev = "http://localhost:4200";
            var pets = "http://pets.vetplatform.local:4200";
            var meds = "http://meds.vetplatform.local:4201";
            var mystore = "http://mystore.vetplatform.local:4202";

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

                    RedirectUris = { dev, pets, meds, mystore},
                    PostLogoutRedirectUris = { dev, pets, meds, mystore },
                    AllowedCorsOrigins = { dev, pets, meds, mystore },

                    AllowedScopes = { "openid", "profile", "vp_portal_api", "role", "tenantId" },

                    RequireConsent = false
                }
            };
        }
    }
}