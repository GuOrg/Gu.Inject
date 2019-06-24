using Gu.Roslyn.Asserts;

[assembly: MetadataReference(typeof(object), new[] { "global", "mscorlib" })]
[assembly: MetadataReference(typeof(System.Diagnostics.Debug), new[] { "global", "System" })]
[assembly: MetadataReference(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute))]
[assembly: TransitiveMetadataReferences(typeof(Gu.Inject.Container<>))]