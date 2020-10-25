using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;

namespace Es.Udc.DotNet.ModelUtil.Transactions
{
    /// <summary>
    /// Defines the Attribute [Transactional] to use it as interceptor for transactional methods
    /// </summary>
    /// <seealso cref="Ninject.Extensions.Interception.Attributes.InterceptAttribute"/>
    public class TransactionalAttribute : InterceptAttribute
    {
        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return request.Kernel.Get<TransactionalInterceptor>();
        }
    }
}