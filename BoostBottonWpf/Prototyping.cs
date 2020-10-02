using Microsoft.Toolkit.Uwp.Notifications;
using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace BoostBottonWpf
{
    public static class Prototyping
    {
        public static void Background(this ToastContent g)
        {


            XmlDocument doc = new XmlDocument();

            var d = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText04);

            Console.WriteLine(d.CreateElement("Background"));


            XmlElement el = doc.CreateElement("BackGround");
            foreach (var i in g.AdditionalProperties)
            {

            }

        }

        public static void Background(this ToastVisual g)
        {


            XmlDocument doc = new XmlDocument();



            XmlElement el = doc.CreateElement("BackGround");

            Console.WriteLine(g);

        }
    }

    public class p2 : ToastContentBuilder
    {
        public p2()
        {



        }
    }

    public partial class P3
    {
        public P3()
        {

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
