using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PIN.Generator
{
    public class PINGeneratorService : IPINGeneratorService
    {
        public HashSet<string> GenerateUniqueNumericPINs(int numberOfPins, int length)
        {
            if (numberOfPins < 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(numberOfPins), numberOfPins, $"{nameof(numberOfPins)} must be greater than 0");
            }

            var validChars = "0123456789".ToCharArray();
            var collisionCounter = 0;

            var pins = new HashSet<string>();          

            while (pins.Count < numberOfPins)
            {
                if (collisionCounter >= numberOfPins)
                {
                    throw new System.Exception($"Could not generate {numberOfPins} unique pins. Generated {pins.Count} pins before giving up after {collisionCounter} collisions.");
                }

                var token = GenerateToken(length, validChars);

                if (pins.Add(token))
                {
                    collisionCounter = 0;
                }
                else
                {
                    collisionCounter++;
                }
            }

            return pins;
        }

        private string GenerateToken(int length, char[] validChars)
        {
            if (length < 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(length), length, $"{nameof(length)} must be greater than 0");
            }

            if (validChars == null)
            {
                throw new System.ArgumentNullException(nameof(validChars), $"{nameof(validChars)} cannot be null");
            }

            var token = new StringBuilder();
                    
            for (int i = 0; i < length; i++)
            {
                var randomNumber = RandomNumberGenerator.GetInt32(validChars.Length);
                token.Append(validChars[randomNumber]);
            }

            return token.ToString();
        }
    }
}
