using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AvaloniaEdit.TextMate.Resources;
using Newtonsoft.Json;
using TextMateSharp.Internal.Themes.Reader;
using TextMateSharp.Registry;
using TextMateSharp.Themes;

namespace AvaloniaEdit.TextMate
{
    public class RegistryOptions : IRegistryOptions
    {
        readonly ThemeName _defaultTheme;
        readonly Dictionary<string, GrammarDefinition> _availableGrammars = new Dictionary<string, GrammarDefinition>();

        public RegistryOptions(ThemeName defaultTheme)
        {
            _defaultTheme = defaultTheme;
            InitializeGrammars();
        }

        public List<Language> GetAvailableLanguages()
        {
            List<Language> result = new List<Language>();

            foreach (GrammarDefinition definition in _availableGrammars.Values)
            {
                foreach (Language language in definition.Contributes.Languages)
                {
                    if (language.Aliases == null || language.Aliases.Count == 0)
                        continue;

                    result.Add(language);
                }
            }

            return result;
        }

        public Language GetLanguageByExtension(string extension)
        {
            return _availableGrammars.Values.SelectMany(definition => 
                definition.Contributes.Languages.Where(language => 
                    language.Extensions != null).Where(language => 
                    language.Extensions.Any(languageExtension => 
                        extension.Equals(languageExtension, StringComparison.OrdinalIgnoreCase))))
                .FirstOrDefault();
        }

        public string GetScopeByExtension(string extension)
        {
            return (from definition in _availableGrammars.Values 
                from language in definition.Contributes.Languages 
                from languageExtension 
                    in language.Extensions 
                where extension.Equals(languageExtension, StringComparison.OrdinalIgnoreCase) 
                select definition.Contributes.Grammars.FirstOrDefault()?.ScopeName).FirstOrDefault();
        }

        public string GetScopeByLanguageId(string languageId)
        {
            if (string.IsNullOrEmpty(languageId))
                return null;

            foreach (var definition in _availableGrammars.Values)
            {
                foreach (var grammar in definition.Contributes.Grammars)
                {
                    if (languageId.Equals(grammar.Language))
                        return grammar.ScopeName;
                }
            }

            return null;
        }

        public IRawTheme LoadTheme(ThemeName name)
        {
            var themeFile = GetThemeFile(name);

            if (themeFile == null)
                return null;

            using var s = ResourceLoader.TryOpenThemeStream(GetThemeFile(name));
            using var reader = new StreamReader(s);
            return ThemeReader.ReadThemeSync(reader);
        }

        static string GetThemeFile(ThemeName name)
        {
            return name switch
            {
                ThemeName.Abbys => "abyss-color-theme.json",
                ThemeName.Dark => "dark_vs.json",
                ThemeName.DarkPlus => "dark_plus.json",
                ThemeName.DimmedMonokai => "dimmed-monokai-color-theme.json",
                ThemeName.KimbieDark => "kimbie-dark-color-theme.json",
                ThemeName.Light => "light_vs.json",
                ThemeName.LightPlus => "light_plus.json",
                ThemeName.Monokai => "monokai-color-theme.json",
                ThemeName.QuietLight => "quietlight-color-theme.json",
                ThemeName.Red => "Red-color-theme.json",
                ThemeName.SolarizedDark => "solarized-dark-color-theme.json",
                ThemeName.SolarizedLight => "solarized-light-color-theme.json",
                ThemeName.TomorrowNightBlue => "tomorrow-night-blue-color-theme.json",
                _ => null
            };
        }

        private void InitializeGrammars()
        {
            var serializer = new JsonSerializer();

            foreach (var grammar in GrammarNames.SupportedGrammars)
            {
                using var stream = ResourceLoader.OpenGrammarPackage(grammar);
                using var reader = new StreamReader(stream);
                using var jsonTextReader = new JsonTextReader(reader);
                var definition = serializer.Deserialize<GrammarDefinition>(jsonTextReader);
                _availableGrammars.Add(grammar, definition);
            }
        }

        string IRegistryOptions.GetFilePath(string scopeName)
        {
            foreach (var grammarName in _availableGrammars.Keys)
            {
                var definition = _availableGrammars[grammarName];

                foreach (var grammar in definition.Contributes.Grammars)
                {
                    if (!scopeName.Equals(grammar.ScopeName))
                    {
                        continue;
                    }
                    var grammarPath = grammar.Path;

                    if (grammarPath.StartsWith("./"))
                        grammarPath = grammarPath[2..];

                    grammarPath = grammarPath.Replace("/", ".");

                    return grammarName.ToLower() + "." + grammarPath;
                }
            }

            return null;
        }

        ICollection<string> IRegistryOptions.GetInjections(string scopeName)
        {
            return Array.Empty<string>();
        }

        Stream IRegistryOptions.GetInputStream(string scopeName)
        {
            var themeStream = ResourceLoader.TryOpenThemeStream(scopeName.Replace("./", string.Empty));

            return themeStream ?? ResourceLoader.TryOpenGrammarStream(((IRegistryOptions)this).GetFilePath(scopeName));
        }

        IRawTheme IRegistryOptions.GetTheme()
        {
            return LoadTheme(_defaultTheme);
        }
    }
}
