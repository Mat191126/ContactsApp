using System.Text.RegularExpressions;

namespace ContactAppProject.Test
{
    public class ContactServiceTest
    {
        [Theory]
        [InlineData("test.email@example.com", true)]
        [InlineData("invalid-email", false)]
        [InlineData("user@domain", false)]
        [InlineData("name@domain.com", true)]
        public void EmailRegex_ShouldValidateProperly(string email, bool expectedValidity)
        {
            // Arrange
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            
            // Act
            var isValid = emailRegex.IsMatch(email);
            
            // Assert
            Assert.Equal(expectedValidity, isValid);
        }

        [Theory]
        [InlineData("123456789", true)]
        [InlineData("12345", false)]
        [InlineData("abcdefghi", false)]
        [InlineData("987654321", true)]
        public void PhoneNumberRegex_ShouldValidateProperly(string phoneNumber, bool expectedValidity)
        {
            // Arrange
            var phoneRegex = new Regex(@"^\d{9}$");
            
            // Act
            var isValid = phoneRegex.IsMatch(phoneNumber);
            
            // Assert
            Assert.Equal(expectedValidity, isValid);
        }
    }
}
