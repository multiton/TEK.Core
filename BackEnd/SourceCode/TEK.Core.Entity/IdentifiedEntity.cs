using System.Collections.Generic;

namespace TEK.Core.Entity
{
	public abstract class IdentifiedEntity<TId> where TId : struct
    {
		public TId Id { get; set; }

		public virtual bool IsNew => EqualityComparer<TId>.Default.Equals(this.Id, default(TId));
    }
}