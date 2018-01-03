using System;

namespace CryptoTracker.Exceptions
{
    public static class ExceptionHandler
    {
        public static void HandleRepositoryException(Exception ex) {
            throw ex;
        }

        public static void HandleBusinessServiceException(Exception ex)
        {
            throw ex;
        }

        public static void ProcessRepositoryException(RepositoryException rex)
        {
            //normally start logging and bubble up 
            throw rex;
        }
    }
}
