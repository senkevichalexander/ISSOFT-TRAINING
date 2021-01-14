﻿using FinalTask.Helpers;
using FinalTask.Pages.Header;
using FinalTask.Pages.LoginPage;

namespace FinalTask.Pages
{
    public static class PageGenerator
    {
        public static Header.Header Header => PageFactoryHelper.InitElements<Header.Header>();

        public static LoginPage.LoginPage LoginPage => PageFactoryHelper.InitElements<LoginPage.LoginPage>();

        public static CreateAnAccountPage CreateAnAccountPage => PageFactoryHelper.InitElements<CreateAnAccountPage>();

        public static Homepage.Homepage Homepage => PageFactoryHelper.InitElements<Homepage.Homepage>();

        public static MyAccountPage.MyAccountPage MyAccountPage =>
            PageFactoryHelper.InitElements<MyAccountPage.MyAccountPage>();

        public static ProductPage.ProductPage ProductPage => PageFactoryHelper.InitElements<ProductPage.ProductPage>();

        public static MyWishlistsPage.MyWishlistsPage MyWishlistsPage => 
            PageFactoryHelper.InitElements<MyWishlistsPage.MyWishlistsPage>();

        public static TopSellersBlock TopSellersBlock => PageFactoryHelper.InitElements<TopSellersBlock>();

        public static ShoppingCartPage.ShoppingCartPage ShoppingCartPage =>
            PageFactoryHelper.InitElements<ShoppingCartPage.ShoppingCartPage>();

        public static CartMenu CartMenu => PageFactoryHelper.InitElements<CartMenu>();
    }
}
