using System;

namespace WebApplication4.Models.Shared
{
    public class Audit : ValueObject
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public Audit(DateTime dateCreated, DateTime? dateLastModified)
        {
            DateCreated = dateCreated;
            DateLastModified = dateLastModified;
        }

        public override bool Equals(object obj)
        {
            var instance = obj as Audit;

            if (ReferenceEquals(this, instance)) return true;
            if (ReferenceEquals(null, instance)) return false;

            return
                DateCreated.Equals(instance.DateCreated) &&
                DateLastModified.Equals(instance.DateLastModified);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = (hash * 23) + DateCreated.GetHashCode();
                hash = (hash * 23) + (DateLastModified != null ? DateLastModified.GetHashCode() : 0);

                return hash;
            }
        }
    }
}
