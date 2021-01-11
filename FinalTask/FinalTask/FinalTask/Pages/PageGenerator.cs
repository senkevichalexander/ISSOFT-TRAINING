using PageObjectTests.Helpers;
using PageObjectTests.LoginPage;

namespace PageObjectTests.Pages
{
    public static class PageGenerator
    {
        public static Header Header => PageFactoryHelper.InitElements<Header>();
        public static LoginPage LoginPage => PageFactoryHelper.InitElements<LoginPage>();
        public static CreateAnAccountPage CreateAnAccountPage => PageFactoryHelper.InitElements<CreateAnAccountPage>();
        public static Homepage Homepage => PageFactoryHelper.InitElements<Homepage>();

    }
}
