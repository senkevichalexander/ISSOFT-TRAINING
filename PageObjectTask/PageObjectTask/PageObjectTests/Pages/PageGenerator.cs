using PageObjectTests.Helpers;

namespace PageObjectTests.Pages
{
    public static class PageGenerator
    {
        public static TutByHeader TutByHeader => PageFactoryHelper.InitElements<TutByHeader>();

        public static TutByHomepage TutByHomepage => PageFactoryHelper.InitElements<TutByHomepage>();

        public static LoginWindow LoginWindow => PageFactoryHelper.InitElements<LoginWindow>();

        public static AuthorizeForm AuthorizeForm => PageFactoryHelper.InitElements<AuthorizeForm>();
    }
}
