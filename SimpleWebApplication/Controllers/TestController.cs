using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleWebApplication.Controllers
{
	public class TestController : ControllerBase
	{
		private readonly InstanceId _instanceId;

		public TestController(InstanceId instanceId)
		{
			_instanceId = instanceId;
		}

		[HttpGet("Test")]
		public IActionResult GetTestAsync()
		{
			return new ObjectResult(new
			{
				Instance = _instanceId.Id,
				Version = GetVersion(typeof(TestController).Assembly)
			});
		}

		private static string GetVersion(Assembly callingAssembly)
		{
			var assemblyCustomAttributes = callingAssembly
				.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
			var version = callingAssembly.GetName().Version;
			if (assemblyCustomAttributes.Length <= 0) return version.ToString();
			var informationalVersion = ((AssemblyInformationalVersionAttribute) assemblyCustomAttributes[0]).InformationalVersion;
			return $"{version}-{informationalVersion}";
		}
	}
}