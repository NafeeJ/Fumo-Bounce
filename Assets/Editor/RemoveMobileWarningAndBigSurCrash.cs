// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveMobileSupportWarningWebBuild.cs" company="Supyrb">
//   Copyright (c) 2020 Supyrb. All rights reserved.
// </copyright>
// <author>
//   Johannes Deml
//   public@deml.io
// </author>
// --------------------------------------------------------------------------------------------------------------------

//Modified by NafeeJ

using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
public class RemoveMobileWarningAndBigSurCrash
{
	[PostProcessBuild]
	public static void OnPostProcessBuild(BuildTarget target, string targetPath)
	{
		if (target != BuildTarget.WebGL)
		{
			return;
		}

		var buildFolderPath = Path.Combine(targetPath, "Build");
		var info = new DirectoryInfo(buildFolderPath);
		var files = info.GetFiles("*.js");
		for (int i = 0; i < files.Length; i++)
		{
			var file = files[i];
			var filePath = file.FullName;
			var text = File.ReadAllText(filePath);
			//fixes mobile warning
			text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
			//fixes Big Sur crash
			//source: https://issuetracker.unity3d.com/issues/unity-webgl-builds-do-not-run-on-macos-big-sur
			text = text.Replace(@"/Mac OS X (10[\.\_\d]+)/.exec(i)[1];", @"/Mac OS X (1[0-1][\.\_\d]+)/.exec(i)[1];");

			Debug.Log("Removing iOS warning from " + filePath);
			File.WriteAllText(filePath, text);


		}
	}
}