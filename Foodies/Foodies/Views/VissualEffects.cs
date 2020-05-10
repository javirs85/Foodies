using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;


namespace Foodies.VisualEffects
{
    public class LinelessEntry : RoutingEffect
    {
        public LinelessEntry() : base($"Foodies.{nameof(LinelessEntry)}")
        {
        }
    }

    public interface IStatusBarColor
    {
        void MakeMe(string color);
    }
}
