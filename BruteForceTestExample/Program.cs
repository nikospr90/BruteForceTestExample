using BruteForceTestExample;

namespace BruteForceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Password (max 6 characters, recommended 4): ");
            string password = Console.ReadLine() ?? "Empty string!";

            Console.WriteLine("\nBrute-Force hacking starts...");
            Thread.Sleep(3000);
            HackingClass hackingClass = new HackingClass();
            //string captcha = hackingclass.generatecaptcha();
            string captcha = "randomCaptcha";
            hackingClass.BruteForceHacking(password, captcha);
        }
    }
}
