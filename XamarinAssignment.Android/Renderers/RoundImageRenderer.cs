using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;
using Android.Runtime;
using System.ComponentModel;
using Android.Content;
using XamarinAssignment.Renderers;
using XamarinAssignment.Droid.Renderers;

[assembly: ExportRenderer(typeof(RoundImage), typeof(RoundImageRenderer))]
namespace XamarinAssignment.Droid.Renderers
{
    [Preserve(AllMembers = true)]
    public class RoundImageRenderer : ImageRenderer
    {
        public RoundImageRenderer(Context context) : base(context)
        {
        }

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public async static void Init()
        {
            var temp = DateTime.Now;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //Only enable hardware accelleration on lollipop
                if ((int)Android.OS.Build.VERSION.SdkInt < 21)
                {
                    SetLayerType(Android.Views.LayerType.Software, null);
                }

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundImage.BorderColorProperty.PropertyName ||
              e.PropertyName == RoundImage.BorderThicknessProperty.PropertyName ||
              e.PropertyName == RoundImage.FillColorProperty.PropertyName)
            {
                this.Invalidate();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="child"></param>
        /// <param name="drawingTime"></param>
        /// <returns></returns>
        protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime)
        {
            try
            {
                var radius = Math.Min(Width, Height) / 2;

                var borderThickness = (float)((RoundImage)Element).BorderThickness;

                int strokeWidth = 0;

                if (borderThickness > 0)
                {
                    var logicalDensity = Xamarin.Forms.Forms.Context.Resources.DisplayMetrics.Density;
                    strokeWidth = (int)Math.Ceiling(borderThickness * logicalDensity + .5f);
                }

                radius -= strokeWidth / 2;

                var path = new Path();
                path.AddCircle(Width / 2.0f, Height / 2.0f, radius, Path.Direction.Ccw);


                canvas.Save();
                canvas.ClipPath(path);

                var paint = new Paint();
                paint.AntiAlias = true;
                paint.SetStyle(Paint.Style.Fill);
                paint.Color = ((RoundImage)Element).FillColor.ToAndroid();
                canvas.DrawPath(path, paint);
                paint.Dispose();

                var result = base.DrawChild(canvas, child, drawingTime);

                canvas.Restore();

                path = new Path();
                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);


                if (strokeWidth > 0.0f)
                {
                    paint = new Paint();
                    paint.AntiAlias = true;
                    paint.StrokeWidth = strokeWidth;
                    paint.SetStyle(Paint.Style.Stroke);
                    paint.Color = ((RoundImage)Element).BorderColor.ToAndroid();
                    canvas.DrawPath(path, paint);
                    paint.Dispose();
                }

                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }


        //protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.OldElement == null)
        //    {

        //    }

        //    //if ( (int)Android.OS.Build.VERSION.SdkInt < 18 )
        //    // SetLayerType( Android.Views.LayerType.Software, null );
        //}




        //protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        //{
        //    try
        //    {
        //        var radius = Math.Min(Width, Height) / 2;
        //        var strokeWidth = 10;
        //        radius -= strokeWidth / 2;

        //        //Create path to clip
        //        var path = new Path();
        //        path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
        //        canvas.Save();
        //        canvas.ClipPath(path);

        //        var result = base.DrawChild(canvas, child, drawingTime);

        //        canvas.Restore();

        //        // Create path for circle border
        //        path = new Path();
        //        path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

        //        var paint = new Paint();
        //        paint.AntiAlias = true;
        //        paint.StrokeWidth = 5;
        //        paint.SetStyle(Paint.Style.Stroke);
        //        paint.Color = global::Android.Graphics.Color.White;

        //        canvas.DrawPath(path, paint);

        //        //Properly dispose
        //        paint.Dispose();
        //        path.Dispose();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Debug.WriteLine( "Unable to create circle image: " + ex );
        //    }

        //    return base.DrawChild(canvas, child, drawingTime);
        //}
    }
}