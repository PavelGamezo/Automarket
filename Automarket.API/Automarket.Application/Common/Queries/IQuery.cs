using MediatR;

namespace Automarket.Application.Common.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
