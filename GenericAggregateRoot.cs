using System;
using System.Collections.Generic;

namespace Sayda.Core.Domain
{
	public abstract class AggregateRoot<T>
	{
		private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();
		public virtual IReadOnlyList<DomainEvent> DomainEvents => _domainEvents;


		public T Id { get; private set; }

		public override bool Equals (object obj)
		{
			var other = obj as AggregateRoot<T>;

			if (ReferenceEquals(other, null))
				return false;

			if (ReferenceEquals(this, other))
				return true;

			if (GetType() != other.GetType())
				return false;


			if (typeof(T) == typeof(Guid))
			{
				var _id = Guid.Parse(Id.ToString());
				var otherId = Guid.Parse(other.Id.ToString());
				if
					(
						_id == Guid.Empty ||
						otherId == Guid.Empty
					)
					return false;
				else
					return _id == otherId;
			}

			if (typeof(T) == typeof(long))
			{
				var _id = long.Parse(Id.ToString());
				var otherId = long.Parse(other.Id.ToString());
				if
					(
						_id == 0 ||
						otherId == 0
					)
					return false;
				else
					return _id == otherId;
			}

			if (typeof(T) == typeof(int))
			{
				var _id = int.Parse(Id.ToString());
				var otherId = int.Parse(other.Id.ToString());
				if
					(
						_id == 0 ||
						otherId == 0
					)
					return false;
				else
					return _id == otherId;
			}

			if (typeof(T) == typeof(string))
			{
				var _id = Id.ToString();
				var otherId = other.Id.ToString();
				if
					(
						string.IsNullOrWhiteSpace(_id) ||
						string.IsNullOrWhiteSpace(otherId)
					)
					return false;
				else
					return _id == otherId;
			}


			return false;

		}

		public static bool operator == (AggregateRoot<T> a, AggregateRoot<T> b)
		{
			if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
				return true;

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
				return false;

			return a.Equals(b);
		}

		public static bool operator != (AggregateRoot<T> a, AggregateRoot<T> b)
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
