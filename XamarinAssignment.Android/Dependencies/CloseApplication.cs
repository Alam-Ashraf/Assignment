using System;
using Xamarin.Forms;
using XamarinAssignment.Dependencies;
using XamarinAssignment.Droid.Dependencies;

[assembly: Dependency(typeof(CloseApplication))]
namespace XamarinAssignment.Droid.Dependencies
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}
