using Microsoft.AspNet.Identity;

namespace Identity.IdentityLibrary
{
    public class MyPasswordHasher : PasswordHasher
    {
        public override string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var passwordMatched = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
            if (!passwordMatched)
            {
                return PasswordVerificationResult.Failed;
            }

            return PasswordVerificationResult.Success;
        }
    }
}
