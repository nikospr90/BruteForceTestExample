using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceTestExample
{
    public class HackingClass
    {
        String current = "";

        int[] pos = { 0, 0, 0, 0, 0, 0 };

        String[] alphabet = { "", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "å", "ä", "ö" };

        int count = 0;
        int captchaCount = 0;


        public string GenerateCaptcha()
        {
            byte[] captchaBytes = new byte[4];
            RandomNumberGenerator rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(captchaBytes);
            string captchaString = Convert.ToBase64String(captchaBytes);
            return captchaString;
        }

        public bool CaptchaCheck(string captchaString, string attemptForCaptcha)
        {
            if (!captchaString.Equals(attemptForCaptcha))
            {
                Console.WriteLine("Captcha incorrect!\n" +
                    "Our system will block the incoming IP now.");
                return false;
            }
            else
            {
                captchaCount++;
                count = 0;
                if (captchaCount >= 3)
                {
                    Console.WriteLine("\nToo many captcha attempts.\nYour IP is blocked");
                    return false;
                }
                else
                {
                    Console.WriteLine("Captcha correct");
                    return true;
                }
            }
        }


        public void BruteForceHacking(string password, string captchaString)
        {
            while (!current.Equals(password))
            {
                for (int i = 0; i < pos.Length; i++)
                {
                    if (pos[i] == alphabet.Length)
                    {
                        pos[i] = 0;
                        pos[i + 1]++;
                    }
                }

                current = (alphabet[pos[5]] + alphabet[pos[4]] + alphabet[pos[3]] + alphabet[pos[2]] + alphabet[pos[1]] + alphabet[pos[0]]).ToString();

                if (count % 1 == 0) Console.WriteLine($"\nLetter sequence: {current}");

                pos[0]++;

                count++;

                if (count >= 3)
                {
                    Console.Write($"\nToo many password attempts!\nWrite captcha \"{captchaString}\" to proceed....: ");
                    string attemptForCaptcha = Console.ReadLine();
                    CaptchaCheck(captchaString, attemptForCaptcha);
                    if (captchaCount < 3)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

            }
        }
    }
}
