using System.Linq;

namespace Entitas.CodeGenerator {

    public class ContextAttributesGenerator : ICodeGenerator {

        public CodeGenFile[] Generate(CodeGeneratorData[] data) {
            return data.Where(d => d.ContainsKey(ContextDataProvider.CONTEXT_NAME))
                       .Select(d => d.GetContextName())
                       .Select(contextName => new CodeGenFile(
                            contextName + "Attribute",
                            generateContextAttributes(contextName),
                            GetType().FullName
                        )).ToArray();
        }

        static string generateContextAttributes(string contextName) {
            return string.Format(@"using Entitas.CodeGenerator;

public class {0}Attribute : ContextAttribute {{

    public {0}Attribute() : base(""{0}"") {{
    }}
}}

", contextName);
        }
    }
}
