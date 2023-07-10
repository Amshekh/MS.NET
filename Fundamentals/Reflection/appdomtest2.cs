using System;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

static class Test
{
	public static void Main()
	{
		AppDomainSetup setup = new AppDomainSetup();
		setup.ApplicationBase = "commands";

		PermissionSet permissions = new PermissionSet(PermissionState.None);  // no permission allowed for load, execution etc.
		permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
		permissions.AddPermission(new UIPermission(PermissionState.Unrestricted));

		for(;;)
		{
			Console.Write("CMD>");
			string cmd = Console.ReadLine();
			if(cmd == "quit") break;

			AppDomain sandbox = AppDomain.CreateDomain(cmd, null, setup, permissions);
			try
			{
				sandbox.ExecuteAssemblyByName(cmd);
			}
			catch(Exception ex)
			{
				Console.WriteLine("Execution failure: {0}", ex.Message);
			}
			AppDomain.Unload(sandbox);

			Console.WriteLine();
		}
	}
}

// In this prg we see execution with restricted access. CMD>greet we get o/p as Hello User not administrator.