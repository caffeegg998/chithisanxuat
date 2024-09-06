

namespace ProductionDirectives.Utils
{
    using BCrypt.Net;

    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return BCrypt.HashPassword(password, BCrypt.GenerateSalt(12));
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Verify(password, hashedPassword);
        }
    }
}
