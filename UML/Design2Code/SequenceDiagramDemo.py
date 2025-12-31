class Session:
    def check_session(self):
        print("[Session] Action: Check session")
        return "Session Object"  # Dotted arrow: Session object

    def create_session(self):
        print("[Session] Action: Create session (if needed)")
        return "Session ID"      # Dotted arrow: Session ID

    def save(self):
        print("[Session] Action: Session saved")


class LinkedInOAuth:
    def show_auth_page(self, browser):
        # This triggers the "Show login/authorization page" arrow
        browser.show_login_page()

    def request_access_token_and_user_profile(self):
        print("[LinkedIn OAuth] Action: Request accessToken & user profile")
        return "accessToken + profile"  # Dotted arrow


class Passport:
    def __init__(self):
        self.linkedin_oauth = LinkedInOAuth()
        self.session = Session()

    def authenticate_with_linkedin_strategy(self, browser):
        print("[Passport] Action: Authenticate with LinkedInStrategy")
        print("[Passport] Redirecting user with clientID, scope, callbackURL...")
        self.linkedin_oauth.show_auth_page(browser)

    def exchange_code_for_access_token(self):
        print("[Passport] Action: Exchange code for accessToken")
        data = self.linkedin_oauth.request_access_token_and_user_profile()
        
        print("[Passport] Action: Serialize user")
        self.session.save()


class Express:
    def __init__(self):
        self.session = Session()
        self.passport = Passport()

    def handle_get_root(self):
        print("[Express] Received: GET /")
        session_obj = self.session.check_session()
        print(f"[Express] Returning: 'Home Page' with {session_obj}")

    def handle_auth_linkedin(self, browser):
        print("[Express] Received: GET /auth/linkedin")
        self.session.create_session()
        self.passport.authenticate_with_linkedin_strategy(browser)

    def handle_callback(self, code, browser):
        print(f"[Express] Received: GET /auth/linkedin/callback?code={code}")
        self.passport.exchange_code_for_access_token()
        print("[Express] Action: Done")
        browser.redirect_to_dashboard()


class Browser:
    def __init__(self):
        self.express = Express()

    def open_url(self, url):
        if url == "/":
            self.express.handle_get_root()
        elif url == "/auth/linkedin":
            self.express.handle_auth_linkedin(self)

    def show_login_page(self):
        print("[Browser] <-- Showing LinkedIn Login Page")
        print("[Browser] User enters credentials & clicks Allow...")
        # Simulate the redirect back to the app
        self.express.handle_callback("DUMMY_CODE_123", self)

    def redirect_to_dashboard(self):
        print("[Browser] <-- Logged in / redirect to dashboard")


# --- EXECUTION (The "User" Lifeline) ---
if __name__ == "__main__":
    browser = Browser()
    
    print("--- [User visits home page] ---")
    browser.open_url("/")

    print("\n--- [User clicks Login with LinkedIn] ---")
    browser.open_url("/auth/linkedin")
