using System;

namespace Sayda.Core.Domain
{
	public abstract class DomainEvent
	{
		public Guid EventId { get; private set; } = Guid.NewGuid();
		public DateTime CreateDate { get; private set; } = DateTime.Now;
	}

}
