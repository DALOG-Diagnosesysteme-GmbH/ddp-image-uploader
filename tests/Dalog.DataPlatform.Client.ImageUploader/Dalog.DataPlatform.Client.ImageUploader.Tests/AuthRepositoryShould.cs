// -----------------------------------------------------------------------
// <copyright file="AuthRepositoryShould.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Dalog.DataPlatform.Client.ImageUploader.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dalog.DataPlatform.Client.ImageUploader.Tests
{
    /// <summary>
    /// The authentication repository should test class.
    /// </summary>
    public sealed class AuthRepositoryShould
    {
        private readonly IHost _host;

        public AuthRepositoryShould()
        {
            this._host = Utils.CreateHostBuilder([]).Build();
        }

        [Trait("Category", "Unit Tests")]
        [Fact(Skip = "Requires user authentication")]
        public void Login_ReturnToken()
        {
            var sut = this._host.Services.GetRequiredService<AuthRepository>();
            Assert.NotNull(sut);
            var loginSuccess = sut.Login(["https://dalogddpb2cprd.onmicrosoft.com/61c2523e-05a5-4f17-ab7e-9b463279e3bf/access_as_user"]);
            Assert.True(loginSuccess, "The logging process was not successful.");
        }
    }
}
