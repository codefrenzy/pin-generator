using System.Collections.Generic;

namespace PIN.Generator
{
    public interface IPINGeneratorService
    {
        HashSet<string> GenerateUniqueNumericPINs(int totalPins, int length);
    }
}
