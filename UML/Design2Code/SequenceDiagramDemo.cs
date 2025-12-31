using System;

namespace SequenceDiagramDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // The "User" starts the process
            var user = new User();
            user.OpenHomePage();
        }
    }

    // LIFELINE: User
    public class User
    {
        private Browser browser = new Browser();

        public void OpenHomePage()
        {
            Console.WriteLine("[User] Opens http://localhost:3000");
            browser.GetRoot();

            Console.WriteLine("\n[User] Clicks 'Login with LinkedIn'");
            browser.ClickLoginWithLinkedIn();
        }
    }

    // LIFELINE: Browser
    public class Browser
    {
        private Express express = new Express();

        public void GetRoot()
        {
            Console.WriteLine("[Browser] Sending: GET /");
            express.HandleGetRoot();
        }

        public void ClickLoginWithLinkedIn()
        {
            Console.WriteLine("[Browser] Sending: GET /auth/linkedin");
            express.HandleAuthLinkedIn();
        }

        public void ShowLoginPage()
        {
            Console.WriteLine("[Browser] Showing login/authorization page to User...");
            // Simulate user entering credentials and LinkedIn redirecting back
            Console.WriteLine("[Browser] User entered credentials. Redirecting to callback URL...");
            express.HandleAuthLinkedInCallback("DUMMY_CODE_123");
        }

        public void RedirectToDashboard()
        {
            Console.WriteLine("[Browser] Success: Logged in / redirect to dashboard");
        }
    }

    // LIFELINE: Express
    public class Express
    {
        private Session session = new Session();
        private Passport passport = new Passport();

        public void HandleGetRoot()
        {
            Console.WriteLine("[Express] Action: Check session");
            session.CheckSession();
            Console.WriteLine("[Express] Response: 'Home Page'");
        }

        public void HandleAuthLinkedIn()
        {
            Console.WriteLine("[Express] Action: Create session (if needed)");
            session.CreateSession();

            Console.WriteLine("[Express] Action: Authenticate with LinkedInStrategy");
            passport.AuthenticateWithLinkedInStrategy();
        }

        public void HandleAuthLinkedInCallback(string code)
        {
            Console.WriteLine($"[Express] Received: GET /auth/linkedin/callback?code={code}");
            passport.ExchangeCodeForAccessToken();

            // After passport is done
            Console.WriteLine("[Express] Action: Done");
            var browser = new Browser(); // Simplified for demo
            browser.RedirectToDashboard();
        }
    }

    // LIFELINE: Session
    public class Session
    {
        public void CheckSession()
        {
            Console.WriteLine("[Session] Returning: Session object");
        }

        public void CreateSession()
        {
            Console.WriteLine("[Session] Returning: Session ID");
        }

        public void Save()
        {
            Console.WriteLine("[Session] Status: Session saved");
        }
    }

    // LIFELINE: Passport
    public class Passport
    {
        private LinkedInOAuth linkedInOAuth = new LinkedInOAuth();
        private Session session = new Session();

        public void AuthenticateWithLinkedInStrategy()
        {
            Console.WriteLine("[Passport] Action: Redirect user with clientID, scope, callbackURL");
            linkedInOAuth.ShowAuthPage();
        }

        public void ExchangeCodeForAccessToken()
        {
            Console.WriteLine("[Passport] Action: Exchange code for accessToken");
            linkedInOAuth.RequestAccessTokenAndUserProfile();

            Console.WriteLine("[Passport] Action: Serialize user");
            session.Save();
        }
    }

    // LIFELINE: LinkedIn OAuth
    public class LinkedInOAuth
    {
        public void ShowAuthPage()
        {
            // In a real app, this sends a 302 redirect to the browser
            var browser = new Browser();
            browser.ShowLoginPage();
        }

        public void RequestAccessTokenAndUserProfile()
        {
            Console.WriteLine("[LinkedIn OAuth] Action: Request accessToken & user profile");
            Console.WriteLine("[LinkedIn OAuth] Returning: accessToken + profile");
        }
    }
}
