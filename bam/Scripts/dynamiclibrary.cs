using Bam.Core;
namespace tempspecexport
{
    class DynamicLibraryWithExports :
        C.Cxx.DynamicLibrary
    {
        protected override void Init()
        {
            base.Init();

            this.CreateHeaderContainer("$(packagedir)/include/*.h");

            var source = this.CreateCxxSourceContainer("$(packagedir)/source/lib.cpp");
            source.PrivatePatch(settings =>
            {
                var preprocessor = settings as C.ICommonPreprocessorSettings;
                preprocessor.PreprocessorDefines.Add("BUILD_LIB");

                var compiler = settings as C.ICommonCompilerSettings;
                compiler.WarningsAsErrors = true;

                if (settings is VisualCCommon.ICommonCompilerSettings vcCompiler)
                {
                    vcCompiler.WarningLevel = VisualCCommon.EWarningLevel.Level4;
                }
                else if (settings is GccCommon.ICommonCompilerSettings gccCompiler)
                {
                    gccCompiler.AllWarnings = true;
                    gccCompiler.ExtraWarnings = true;
                    gccCompiler.Pedantic = true;
                    gccCompiler.Visibility = GccCommon.EVisibility.Hidden;
                }
                else if (settings is ClangCommon.ICommonCompilerSettings clangCompiler)
                {
                    clangCompiler.AllWarnings = true;
                    clangCompiler.ExtraWarnings = true;
                    clangCompiler.Pedantic = true;
                    clangCompiler.Visibility = ClangCommon.EVisibility.Hidden;
                }
            });

            this.PublicPatch((settings, appliedTo) =>
            {
                if (settings is C.ICommonPreprocessorSettings preprocessor)
                {
                    preprocessor.IncludePaths.AddUnique(this.CreateTokenizedString("$(packagedir)/include"));
                }
            });
        }
    }
}
