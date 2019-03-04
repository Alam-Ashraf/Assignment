using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinAssignment.Droid.Renderers;

[assembly: ResolutionGroupName("XamarinAssignment")]
[assembly: ExportEffect(typeof(CustomEntryEffect), "CustomEntryEffect")]
namespace XamarinAssignment.Droid.Renderers
{
    public class CustomEntryEffect : PlatformEffect
    {
        Android.Graphics.Color backgroundColor;

        protected override void OnAttached()
        {
            try
            {
                backgroundColor = Android.Graphics.Color.Transparent;
                Control.SetBackgroundColor(backgroundColor);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

    }
}
