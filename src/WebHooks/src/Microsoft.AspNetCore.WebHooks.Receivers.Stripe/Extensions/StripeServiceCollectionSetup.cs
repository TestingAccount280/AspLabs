// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.WebHooks.Filters;
using Microsoft.AspNetCore.WebHooks.Metadata;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Methods to add services for the Stripe receiver.
    /// </summary>
    internal static class StripeServiceCollectionSetup
    {
        /// <summary>
        /// Add services for the Stripe receiver.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to update.</param>
        public static void AddStripeServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            WebHookMetadata.Register<StripeMetadata>(services);
            services.TryAddSingleton<StripeTestEventRequestFilter>();
            services.TryAddSingleton<StripeVerifyNotificationIdFilter>();
            services.TryAddSingleton<StripeVerifySignatureFilter>();
        }
    }
}
