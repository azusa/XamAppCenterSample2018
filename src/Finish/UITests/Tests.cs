﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamAppCenterSample2018.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public async void SucceedTranslate()
        {
            await Task.Delay(2000);
            app.Screenshot("App launched");
            await Task.Delay(2000);
            app.Tap(c => c.Marked("inputText"));
            await Task.Delay(2000);
            app.EnterText("私は毎日電車に乗って会社に行きます。");
            await Task.Delay(2000);
            app.Screenshot("Japanese text entered");
            await Task.Delay(2000);
            app.DismissKeyboard();
            await Task.Delay(2000);
            app.Tap(c => c.Button("translateButton"));
            await Task.Delay(4000);
            var elements = app.Query(c => c.Marked("translatedText"));
            await Task.Delay(2000);
            app.Screenshot("Japanese text translated");
            await Task.Delay(2000);
            Assert.AreEqual("I take the train to the office every day.", elements.FirstOrDefault().Text);
        }

        [Test]
        public async void FailTranslate()
        {
            await Task.Delay(2000);
            app.Screenshot("App launched");
            await Task.Delay(2000);
            app.Tap(c => c.Button("translateButton"));
            await Task.Delay(4000);
            var elements = app.Query(c => c.Marked("translatedText"));
            await Task.Delay(2000);
            app.Screenshot("None message displayed");
            await Task.Delay(2000);
            StringAssert.Contains(string.Empty, elements.FirstOrDefault().Text);
        }
    }
}
