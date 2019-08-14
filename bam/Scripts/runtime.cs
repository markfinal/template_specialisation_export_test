using Bam.Core;
namespace tempspecexport
{
    sealed class Runtime :
        Publisher.Collation
    {
        protected override void Init()
        {
            base.Init();

            this.SetDefaultMacrosAndMappings(EPublishingType.ConsoleApplication);
            this.Include<TestApp>(C.Cxx.ConsoleApplication.ExecutableKey);
        }
    }
}
