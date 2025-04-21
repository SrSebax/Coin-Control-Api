using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;
using DotNetEnv;
using CoinControl.Api.Models;

namespace CoinControl.Api.Services
{
    public class FirebaseService
    {
        private readonly FirebaseAuth _firebaseAuth;

        public FirebaseService()
        {
            Env.Load();

            string credentialsPath = Environment.GetEnvironmentVariable("FIREBASE_CREDENTIALS_PATH");

            var app = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(credentialsPath)
            });

            _firebaseAuth = FirebaseAuth.GetAuth(app);
        }

        public async Task<AuthModel> GetUserInfoAsync(string uid)
        {
            try
            {
                var userRecord = await _firebaseAuth.GetUserAsync(uid);
                if (userRecord != null)
                {
                    return new AuthModel
                    {
                        Uid = userRecord.Uid,
                        Email = userRecord.Email,
                        Name = userRecord.DisplayName
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error verifying UID: {ex.Message}");
                return null;
            }
        }
    }
}
