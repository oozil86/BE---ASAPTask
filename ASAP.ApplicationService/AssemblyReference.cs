using System.Reflection;

namespace ASAP.ApplicationService
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
