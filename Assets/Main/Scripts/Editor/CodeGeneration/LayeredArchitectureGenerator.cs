using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace Roguelike.Editor.CodeGeneration
{
    public static class LayeredArchitectureGenerator
    {
        private const string Data = "Data";
        private const string Model = "Model";
        private const string IRepository = "IRepository";
        private const string Repository = "Repository";
        private const string UseCase = "UseCase";
        private const string Presenter = "Presenter";
        private const string View = "View";
        private const string Scope = "Scope";

        [MenuItem("Tools/CodeGenerator/LayeredArchitecture")]
        private static void GenerateLayeredArchitecture()
        {
            var domains = new Dictionary<string, HashSet<string>>() {
                { "Root", new HashSet<string>() { Scope } },
                { "Game", new HashSet<string>() { UseCase, Presenter, Scope } },
                { "Title", new HashSet<string>() { Presenter, View, Scope } },
                { "Result", new HashSet<string>() { Presenter, View, Scope } },
                { "Home", new HashSet<string>() { UseCase, Presenter, View, Scope } },
                { "Girl", new HashSet<string>() { Presenter, View, Scope } },
                { "Quest", new HashSet<string>() { Model, IRepository, Repository, UseCase, Presenter, Scope } },
                { "Floor", new HashSet<string>() { Presenter, View, Scope } },
                { "Room", new HashSet<string>() { Presenter, View, Scope } },
                { "Card", new HashSet<string>() { Presenter, View, Scope } },
                { "Player", new HashSet<string>() { Presenter, View, Scope } },
                { "Battle", new HashSet<string>() { Model, IRepository, Repository, UseCase, Presenter, View, Scope } },
                { "SaveData", new HashSet<string>() { IRepository } },
                { "MasterData", new HashSet<string>() { IRepository } },
            };

            foreach (var domain in domains)
            {
                var upperName = domain.Key;
                var lowerName = upperName.ToLower();

                var options = new string[][] {
                    new string[] { Data, $"Domain/Data/{upperName}", string.Format(Templates.DomainData, upperName) },
                    new string[] { Model, $"Domain/Model/{upperName}Model", string.Format(Templates.DomainModel, upperName) },
                    new string[] { IRepository, $"Domain/Repository/I{upperName}Repository", string.Format(Templates.DomainRepository, upperName) },
                    new string[] { Repository, $"Infrastructure/Repository/{upperName}Repository", string.Format(Templates.InfrastructureRepository, upperName) },
                    new string[] { UseCase, $"Application/UseCase/{upperName}UseCase", string.Format(Templates.ApplicationUseCase, upperName, lowerName) },
                    new string[] { Presenter, $"Presentation/Presenter/{upperName}Presenter", string.Format(Templates.PresentationPresenter, upperName, lowerName) },
                    new string[] { View, $"Presentation/View/{upperName}View", string.Format(Templates.PresentationView, upperName) },
                    new string[] { Scope, $"Injection/Scope/{upperName}Scope", string.Format(Templates.InjectionScope, upperName) },
                };

                foreach (var option in options)
                {
                    var path = $"Assets/Main/Scripts/{option[1]}.cs";

                    if (!domain.Value.Contains(option[0]))
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);

                            UnityEngine.Debug.Log($"Delete {path}");
                        }
                        continue;
                    }

                    if (File.Exists(path))
                    {
                        continue;
                    }

                    using (var fileStream = File.Open(path, FileMode.Create, FileAccess.Write))
                    using (var streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.Write(option[2]);
                    }

                    UnityEngine.Debug.Log($"Generate {path}");
                }
            }

            AssetDatabase.Refresh();

            UnityEngine.Debug.Log($"Finish GenerateLayeredArchitecture");
        }
    }
}