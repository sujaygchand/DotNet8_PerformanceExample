using System.Reflection;
using System.Runtime.CompilerServices;

namespace ConsoleApp1.Services
{
	public class UnsafeAccessorServiceCaller
    {
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "GetName")]
        public static extern string GetName(UnsafeAccessorService unsafeAccessorService);
    }

    public static class ReflectionService
    {
        public static string GetName(UnsafeAccessorService unsafeAccessorService)
        {
            return (string)typeof(UnsafeAccessorService).GetMethod("GetName", BindingFlags.Instance | BindingFlags.NonPublic)
                !.Invoke(unsafeAccessorService, Array.Empty<object>());
        }
    }

    public class UnsafeAccessorService
	{
        public string GetNamePublic()
        {
            return "Joe";
        }

        private string GetName()
        {
            return "Joe";
        }
    }
}
