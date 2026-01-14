using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BookManageSystem
{
    public static class LoginSession
    {
        public static int userId;

        public static string ComputeHash(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                // UTF-8
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // 暗号化
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // string型に変換
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
