﻿using System;
using System.Linq;
using Comet.Samples.Models;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Hosting;

namespace Comet.Samples
{
	public class MyApp : CometApp
	{
		readonly State<int> clickCount = 0;
		readonly State<double> progress = .5;
		readonly State<bool> isToggled = false;
		readonly State<string> textValue = "Test";
		readonly State<TimeSpan> timePickerTime = TimeSpan.FromSeconds(0);
		[Body]
		View view() =>
			//new ListView<string>(Enumerable.Range(0,100).Select(x=> $"Item {x} !!!!!").ToList()){
			//	ViewFor = (s) => new HStack()
			//		{
			//			new Text(s),
			//			new Spacer()
			//		}.Frame(height: 44).Margin(left: 10)
			//};
			new VStack(spacing: 6)
			{
				new Text("Welcome to Comet!").Margin(top: 100),
				new Image("turtlerock.jpg").Frame(100,100), 
				new Text(() => !isToggled ?  "Off" : "Hey I am toggled"),
				new Button(()=>  $"I was Clicked: {clickCount}!",()=>{
					clickCount.Value++;
				}).Color(Colors.Yellow)
					.Background(Colors.Blue),
				new ActivityIndicator(),
				new CheckBox(isToggled),
				new Toggle(isToggled),
				new TextEditor(textValue),
				new ProgressBar(progress),
				new Slider(progress),
				new Text(textValue),
				new TextField(textValue),
				new SecureField(textValue),
			//}
		}.Background(Colors.Beige);

		public override void Configure(IAppHostBuilder appBuilder)
		{
			base.Configure(appBuilder);

			appBuilder.UseMauiApp<MyApp>();
#if DEBUG
			appBuilder.EnableHotReload();
#endif

		}
	}
}
