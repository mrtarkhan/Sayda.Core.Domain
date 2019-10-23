using System;
using System.Runtime.Serialization;

namespace Sayda.Core.Domain
{
	internal sealed class KernelException : Exception
	{
		public KernelException ()
		{
		}

		public KernelException (string message) : base(message)
		{
		}

		public KernelException (string message, Exception innerException) : base(message, innerException)
		{
		}

		protected KernelException (SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
