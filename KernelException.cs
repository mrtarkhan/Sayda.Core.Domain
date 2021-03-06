﻿using System;
using System.Runtime.Serialization;

namespace Sayda.Core.Domain
{
	public sealed class KernelException : Exception
	{
		public KernelException (string message) : base(message)
		{
		}

		public KernelException (string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
