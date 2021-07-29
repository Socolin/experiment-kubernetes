using System;

namespace SimpleWebApplication
{
	public class InstanceId
	{
		public Guid Id { get; } = Guid.NewGuid();
	}
}