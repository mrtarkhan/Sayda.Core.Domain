using System;
using System.Collections.Generic;

namespace Sayda.Core.Domain
{
	public abstract class AggregateRoot
	{
		private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();
		public virtual IReadOnlyList<DomainEvent> DomainEvents => _domainEvents;

		public Guid Id { get; set; }

		public override bool Equals (object obj)
		{
			var other = obj as AggregateRoot;

			if (ReferenceEquals(other, null))
				return false;

			if (ReferenceEquals(this, other))
				return true;

			if (GetType() != other.GetType())
				return false;

			if (Id == Guid.Empty || other.Id == Guid.Empty)
				return false;

			return Id == other.Id;
		}

		public static bool operator == (AggregateRoot a, AggregateRoot b)
		{
			if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
				return true;

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
				return false;

			return a.Equals(b);
		}

		public static bool operator != (AggregateRoot a, AggregateRoot b)
		{
			return !(a == b);
		}

		public override int GetHashCode ()
		{
			return Id.GetHashCode();
		}


		protected virtual void AddEvent (DomainEvent newEvent)
		{
			_domainEvents.Add(newEvent);
		}

		public virtual void ClearEvents ()
		{
			_domainEvents.Clear();
		}
	}
}
