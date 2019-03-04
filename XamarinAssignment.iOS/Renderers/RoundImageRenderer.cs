using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreAnimation;
using Foundation;
using XamarinAssignment.Renderers;
using XamarinAssignment.iOS.Renderers;

[assembly: ExportRenderer(typeof(RoundImage), typeof(RoundImageRenderer))]
namespace XamarinAssignment.iOS.Renderers
{
    /// <summary>
    /// ImageCircle Implementation
    /// </summary>
    [Preserve(AllMembers = true)]
    public class RoundImageRenderer : ImageRenderer
    {

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
            if (Element == null)
                return;
            CreateCircle();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName ||
              e.PropertyName == RoundImage.BorderColorProperty.PropertyName ||
              e.PropertyName == RoundImage.BorderThicknessProperty.PropertyName ||
              e.PropertyName == RoundImage.FillColorProperty.PropertyName)
            {
                CreateCircle();
            }
        }

        private void CreateCircle()
        {
            try
            {
                var min = Math.Min(Element.Width, Element.Height);
                Control.Layer.CornerRadius = (nfloat)(min / 2.0);
                Control.Layer.MasksToBounds = false;
                Control.BackgroundColor = ((RoundImage)Element).FillColor.ToUIColor();
                Control.ClipsToBounds = true;

                var borderThickness = ((RoundImage)Element).BorderThickness;
                var externalBorder = new CALayer();
                externalBorder.CornerRadius = Control.Layer.CornerRadius;
                externalBorder.Frame = new CGRect(-.5, -.5, min + 1, min + 1);
                externalBorder.BorderColor = ((RoundImage)Element).BorderColor.ToCGColor();
                externalBorder.BorderWidth = ((RoundImage)Element).BorderThickness;

                Control.Layer.AddSublayer(externalBorder);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("Unable to create circle image: " + ex);
            }
        }




        //protected override void OnElementChanged( ElementChangedEventArgs<Image> e )
        //{
        //    base.OnElementChanged( e );

        //    if ( e.OldElement != null || Element == null )
        //        return;

        //    CreateCircle();
        //}


        //private void CreateCircle()
        //{
        //    try
        //    {
        //        double min = Math.Min( Element.Width, Element.Height );
        //        //Control.Layer.CornerRadius = (float)( min / 2.0 );
        //        Control.Layer.CornerRadius = (float)( Element.Width/2 );
        //        Control.Layer.MasksToBounds = false;
        //        Control.Layer.BorderColor = Color.White.ToCGColor();
        //        Control.Layer.BorderWidth = 1;
        //        Control.ClipsToBounds = true;
        //    }
        //    catch ( Exception ex )
        //    {
        //        //Debug.WriteLine( "Unable to create circle image: " + ex )
        //    }
        //}


        // Before

        //protected override void OnElementChanged( ElementChangedEventArgs<Image> e )
        //{
        //    base.OnElementChanged( e );

        //    if ( Control == null || e.OldElement != null || Element == null || Element.Aspect != Aspect.Fill )
        //        return;

        //    var min = Math.Min( Element.Width, Element.Height );
        //    Control.Layer.CornerRadius = (float)( min / 2.0 );
        //    Control.Layer.MasksToBounds = false;
        //    Control.ClipsToBounds = true;
        //}

        ///// <summary>
        ///// Handles the <see cref="E:ElementPropertyChanged" /> event.
        ///// </summary>
        ///// <param name="sender">The sender.</param>
        ///// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        //protected override void OnElementPropertyChanged( object sender, PropertyChangedEventArgs e )
        //{
        //    base.OnElementPropertyChanged( sender, e );

        //    if ( Control == null ) return;

        //    if ( Element.Aspect == Aspect.Fill )
        //    {
        //        if ( e.PropertyName == VisualElement.HeightProperty.PropertyName ||
        //            e.PropertyName == VisualElement.WidthProperty.PropertyName )
        //        {
        //            DrawFill();
        //        }
        //    }
        //    else
        //    {
        //        if ( e.PropertyName == Image.IsLoadingProperty.PropertyName
        //            && !Element.IsLoading && Control.Image != null )
        //        {
        //            DrawOther();
        //        }
        //    }
        //}

        ///// <summary>
        ///// Draws the other.
        ///// </summary>
        ///// <exception cref="System.NotImplementedException"></exception>
        //private void DrawOther()
        //{
        //    int height;
        //    int width;

        //    switch ( Element.Aspect )
        //    {
        //        case Aspect.AspectFill:
        //            height = (int)Control.Image.Size.Height;
        //            width = (int)Control.Image.Size.Width;
        //            height = MakeSquare( height, ref width );
        //            break;
        //        case Aspect.AspectFit:
        //            height = (int)Control.Image.Size.Height;
        //            width = (int)Control.Image.Size.Width;
        //            height = MakeSquare( height, ref width );
        //            break;
        //        default:
        //            throw new NotImplementedException();
        //    }

        //    UIImage image = Control.Image;
        //    var clipRect = new CGRect( 0, 0, width, height );
        //    var scaled = image.Scale( new CGSize( width, height ) );
        //    UIGraphics.BeginImageContextWithOptions( new CGSize( width, height ), false, 0f );
        //    UIBezierPath.FromRoundedRect( clipRect, Math.Max( width, height ) / 2 ).AddClip();

        //    scaled.Draw( new CGRect( 0, 0, scaled.Size.Width, scaled.Size.Height ) );
        //    UIImage final = UIGraphics.GetImageFromCurrentImageContext();
        //    UIGraphics.EndImageContext();
        //    Control.Image = final;
        //}

        ///// <summary>
        ///// Draws the fill.
        ///// </summary>
        //private void DrawFill()
        //{
        //    double min = Math.Min( Element.Width, Element.Height );
        //    Control.Layer.CornerRadius = (float)( min / 2.0 );
        //    Control.Layer.MasksToBounds = false;
        //    Control.ClipsToBounds = true;
        //}

        ///// <summary>
        ///// Makes the square.
        ///// </summary>
        ///// <param name="height">The height.</param>
        ///// <param name="width">The width.</param>
        ///// <returns>System.Int32.</returns>
        //private int MakeSquare( int height, ref int width )
        //{
        //    if ( height < width )
        //    {
        //        width = height;
        //    }
        //    else
        //    {
        //        height = width;
        //    }
        //    return height;
        //}
    }
}