﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Harmony;
using HarmonyLib;

namespace BepInEx.NetLauncher.RuntimeFixes
{
	internal class AssemblyFix
	{
		private static Assembly EntryAssembly { get; set; }

		public static void Execute(Assembly entryAssembly)
		{
			EntryAssembly = entryAssembly;
			HarmonyWrapper.PatchAll(typeof(AssemblyFix), "bepinex.assemblyfix");
		}

		[HarmonyPrefix, HarmonyPatch(typeof(Assembly), nameof(Assembly.GetEntryAssembly))]
		public static bool GetEntryAssemblyPrefix(ref Assembly __result)
		{
			__result = EntryAssembly;
			return false;
		}
	}
}