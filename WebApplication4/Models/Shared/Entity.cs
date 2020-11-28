
namespace WebApplication4.Models.Shared
{
    public abstract class Entity : IEntity, IAuditable
    {
        public int Id { get; set; }
        public Audit Audit { get; set; }

        public bool SameIdentityAs(IEntity other)
        {
            return other != null && GetType() == other.GetType() && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;

            var other = obj as IEntity;

            return SameIdentityAs(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
