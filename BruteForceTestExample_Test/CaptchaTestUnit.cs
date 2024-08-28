using BruteForceTestExample;

namespace BruteForceTestExample_Test
{
    public class CaptchaTestUnit
    {
        [Theory]
        [InlineData("password", "password", true)]
        [InlineData("Kzx4G", "Kzx4G", true)]
        public void CheckCaptchaStatus_ShouldReturnTrue(string password, string captcha, bool expected)
        {
            // Arrange

            HackingClass hackingClass = new HackingClass();

            // Act
            bool actual = hackingClass.CaptchaCheck(password, captcha);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Kzx4G", "randomCaptcha", false)]
        [InlineData("password", "randomCaptcha", false)]
        public void CheckCaptchaStatus_ShouldReturnFalse(string password, string captcha, bool expected)
        {
            // Arrange

            HackingClass hackingClass = new HackingClass();

            // Act
            bool actual = hackingClass.CaptchaCheck(password, captcha);

            // Assert
            Assert.Equal(expected, actual); 
        }
    }
}