using SimpleAR_DAL.Managers;

namespace SimpleAR_DAL.Factories
{
    public class ManagerFactories
    {
        public static ContextManager CreateContextManager()
        {
            return new ContextManager();
        }
    }
}
