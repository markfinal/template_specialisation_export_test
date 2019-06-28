using Bam.Core;
namespace tempspecexport
{
    sealed class Runtime :
        Publisher.Collation
    {
        protected override void Init(Module parent)
        {
            base.Init(parent);

            this.SetDefaultMacrosAndMappings(EPublishingType.ConsoleApplication);
            this.Include<TestApp>(C.Cxx.ConsoleApplication.ExecutableKey);
        }
    }
}
