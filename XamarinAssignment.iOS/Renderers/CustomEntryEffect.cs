using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinAssignment.ios.Renderers;

[assembly: ResolutionGroupName("XamarinAssignment")]
[assembly: ExportEffect(typeof(CustomEntryEffect), "CustomEntryEffect")]
namespace XamarinAssignment.ios.Renderers
{
    public class CustomEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var entry = Control as UITextField;
            if (entry != null)
            {
                // remove border
                entry.BorderStyle = UITextBorderStyle.None;
            }
        }

        protected override void OnDetached()
        {
        }

    }
}
