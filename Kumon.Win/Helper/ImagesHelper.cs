using DevExpress.Utils;
using DevExpress.XtraBars;
using EMQV;
using Kumon.Win.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kumon.Win.Helper
{
    public static class ImagesHelper
    {
        private static Icon appIcon;


        public static Icon AppIcon
        {
            get
            {
                if (ImagesHelper.appIcon == null)
                    ImagesHelper.appIcon = Resources.Acquisite;
                return ImagesHelper.appIcon;
            }
            set
            {
                ImagesHelper.appIcon = value;
            }
        }

        public static Image GetImage(string name, ImageSize size, Assembly assembly = null)
        {
            if (string.IsNullOrEmpty(name))
                return (Image)null;
            if (assembly == (Assembly)null)
                assembly = typeof(Utility).Assembly;
            try
            {
                return ResourceImageHelper.CreateImageFromResources(string.Format("{0}_{1}.png", (object)name, (object)ImagesHelper.GetImageSizeString(size)), assembly);
            }
            catch (Exception ex)
            {
                return (Image)null;
            }
        }

        public static void SetBarButtonImage(BarItem item, string name, Assembly assembly = null)
        {
            if (string.IsNullOrEmpty(name))
                return;
            if (assembly == (Assembly)null)
                assembly = typeof(Utility).Assembly;
            try
            {
                item.LargeGlyph = ImagesHelper.GetImage(name, ImageSize.Large32, assembly);
                item.Glyph = ImagesHelper.GetImage(name, ImageSize.Small16, assembly);
            }
            catch (Exception ex)
            {
            }
        }

        private static string GetImageSizeString(ImageSize size)
        {
            return size == ImageSize.Small16 ? "16x16" : "32x32";
        }
    }
}
