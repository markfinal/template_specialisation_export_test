using Bam.Core;
namespace tempspecexport
{
    class TestApp :
        C.Cxx.ConsoleApplication
    {
        protected override void Init(Module parent)
        {
            base.Init(parent);

            var source = this.CreateCxxSourceContainer("$(packagedir)/source/app.cpp");
            source.PrivatePatch(settings =>
            {
                var compiler = settings as C.ICommonCompilerSettings;
                compiler.WarningsAsErrors = true;

                var cxxCompiler = settings as C.ICxxOnlyCompilerSettings;
                cxxCompiler.ExceptionHandler = C.Cxx.EExceptionHandler.Asynchronous;

                if (settings is VisualCCommon.ICommonCompilerSettings vcCompiler)
                {
                    vcCompiler.WarningLevel = VisualCCommon.EWarningLevel.Level4;
                }
                else if (settings is GccCommon.ICommonCompilerSettings gccCompiler)
                {
                    gccCompiler.AllWarnings = true;
                    gccCompiler.ExtraWarnings = true;
                    gccCompiler.Pedantic = true;
                }
                else if (settings is ClangCommon.ICommonCompilerSettings clangCompiler)
                {
                    clangCompiler.AllWarnings = true;
                    clangCompiler.ExtraWarnings = true;
                    clangCompiler.Pedantic = true;
                }
            });

            this.CompileAndLinkAgainst<DynamicLibraryWithExports>(source);
        }
    }
}
