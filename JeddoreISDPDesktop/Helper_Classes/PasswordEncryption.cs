using System;
using System.Security.Cryptography;
using System.Text;

namespace JeddoreISDPDesktop.Helper_Classes
{
    public static class PasswordEncryption
    {
        //creates and returns a hashed to be used for storage in the DB
        public static string GetHash(string password)
        {
            //SHA256 is disposable by inheritance
            using (SHA256 sha256 = SHA256.Create())
            {
                //sending in the text (password) to hash
                //ComputeHash returns an array of bytes (computed hash code)
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                //get and return the hashed string
                //replacing dashes in the string, and converting all letters to lowercase before returning
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        //salting creates an extra layer of security, without it, are prone to rainbow table attacks with just hashing
        //creates and returns a salt to be used for a password
        //could add the salt string returned below onto the beginning or end of the raw non-hashed password,
        //before calling getHash() and then storing the hashed password string in the DB
        public static string GetSalt()
        {
            byte[] bytes = new byte[128 / 8];
            using (var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(bytes);

                //get and return the hashed salt
                //replacing dashes in the string, and converting all letters to lowercase before returning
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
