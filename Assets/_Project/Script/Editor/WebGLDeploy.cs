using System.Diagnostics;
using UnityEngine;

#if UNITY_EDITOR
using System.IO;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace _Project.Editor
{
    public class WebGLDeploy : IPostprocessBuildWithReport
    {
        public int callbackOrder { get; }
        private string _batPath;

        public void OnPostprocessBuild(BuildReport report)
        {
            _batPath = Path.Combine(GetBuildFolderPath(), "Build");
            RunCommand(_batPath);
        }

        private static string GetBuildFolderPath()
        {
            return Directory.GetParent(Application.dataPath)?.FullName;
        }

        private static void RunCommand(string buildFolderPath)
        {
            var process = new Process();
            process.StartInfo.WorkingDirectory = buildFolderPath;
            process.StartInfo.FileName = Path.Combine(buildFolderPath, "Deploy.bat");
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }
    }
}
#endif