using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.AddressableAssets;

namespace Roguelike.Editor.CodeGeneration
{
    public static class AssetAddressGenerator
    {
        [MenuItem("Tools/CodeGenerator/AssetAddress")]
        private static void GenerateAssetAddress()
        {
            var stringBuilder = new StringBuilder();
            var settings = AddressableAssetSettingsDefaultObject.Settings;

            foreach (var group in settings.groups)
            {
                if (group.ReadOnly)
                {
                    continue;
                }

                foreach (var entry in group.entries)
                {
                    stringBuilder.AppendLine();
                    stringBuilder.AppendFormat("        public const string {0} = \"{0}\";", entry.address);
                }
            }

            using (var fileStream = File.Open("Assets/Main/Scripts/Presentation/Common/AssetAddress.cs", FileMode.Create, FileAccess.Write))
            using (var streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.Write(Templates.AssetAddress, stringBuilder.ToString());
            }

            AssetDatabase.Refresh();

            UnityEngine.Debug.Log($"Finish GenerateAssetAddress");
        }
    }
}