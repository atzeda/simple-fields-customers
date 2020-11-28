
namespace WebApplication4.Models.Shared
{
    public interface IEntity
    {
        int Id { get; }

        bool SameIdentityAs(IEntity other);
    }
}
