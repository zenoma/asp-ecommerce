using Es.Udc.DotNet.ModelUtil.Log;
using Ninject.Extensions.Interception;
using System;
using System.Transactions;

namespace Es.Udc.DotNet.ModelUtil.Transactions
{
    /// <summary>
    /// Defines a wrapper method to encapsulate a method inside a transaction
    /// </summary>
    /// <seealso cref="Ninject.Extensions.Interception.IInterceptor"/>
    /// <remarks>
    /// Requires the following references in the project (availables at NUGET):
    /// * Ninject.Extensions.Interception
    /// * Ninject.Extensions.Interception.DynamicProxy
    /// </remarks>
    public class TransactionalInterceptor : IInterceptor
    {
        public TransactionalInterceptor()
        {
        }

        public void Intercept(IInvocation invocation)
        {
            string methodName = invocation.Request.Method.Name;
            string returnType = invocation.Request.Method.ReturnType.Name;
            string targetClass = invocation.Request.Target.GetType().Name;

            LogManager.RecordMessage("Transactional interception STARTS for " +
                 returnType + " " + targetClass + "." + methodName + "(...)", MessageType.Info, "Transaction");

            TransactionScopeOption scopeOption = TransactionScopeOption.Required;

            if ((Transaction.Current == null) ||
                (Transaction.Current.TransactionInformation.Status.Equals(TransactionStatus.Aborted)))
                scopeOption = TransactionScopeOption.RequiresNew;

            using (TransactionScope transaction = new TransactionScope(scopeOption))
            {
                try
                {
                    invocation.Proceed();
                }
                catch (Exception e)
                {
                    LogManager.RecordMessage("Transactional interception ENDS for " +
                         returnType + " " + targetClass + "." + methodName + "(...)" +
                         " with EXCEPTION " + e.GetType().Name, MessageType.Info, "Transaction");

                    throw e;

                    // Implicit rollback
                }

                transaction.Complete();
            }

            LogManager.RecordMessage("Transactional interception ENDS for " +
                 returnType + " " + targetClass + "." + methodName + "(...)", MessageType.Info, "Transaction");
        }
    }
}