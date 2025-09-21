using CleanArchitecture.Core.Exceptions;

namespace CleanArchitecture.Core.Helper.GaurdClause
{
    public static class Guard
    {
        public static void AgainstNullOrEmpty<TException>(object argument)
            where TException : DomainException, new()
        {
            if (argument == null)
            {
                throw new TException();
            }
        }
    }
}
