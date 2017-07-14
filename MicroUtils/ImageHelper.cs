using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MicroUtils
{
    /// <summary>
    /// 图片的帮助类
    /// </summary>
    public class ImageHelper
    {
        #region Image、byte[]

        /// <summary>
        /// 图片转二进制流，根据图片文件的路径使用文件流打开，并保存为byte[] 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] PictureToByte(string url)
        {
            if (url.StartsWith("http"))
            {
                // 网络图片 http、https
                WebClient client = new WebClient();
                byte[] byData = client.DownloadData(url);
                return byData;
            }
            else
            {
                FileStream fs = new FileStream(url, FileMode.Open);
                byte[] byData = new Byte[fs.Length];
                fs.Position = 0;
                fs.Read(byData, 0, byData.Length);
                fs.Close();
                return byData;
            }
        }

        /// <summary>
        /// 图片转二进制流，将Image转换成流数据，并保存为byte[] 
        /// </summary>
        /// <param name="pic"></param>
        /// <returns></returns>
        public static byte[] PictureToByte(Image pic)
        {
            MemoryStream ms = new MemoryStream();
            pic.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[ms.Length];
            ms.Position = 0;
            ms.Read(byData, 0, byData.Length);
            ms.Close();
            return byData;
        }

        /// <summary>
        /// 二进制流转图片，将byte[]转换成流数据，并保存为Image
        /// </summary>
        /// <param name="byData"></param>
        /// <returns></returns>
        public static Image PictureByByte(byte[] byData)
        {
            MemoryStream ms = new MemoryStream(byData);
            Image pic = Image.FromStream(ms);
            return pic;
        }

        #endregion

        #region 图片Base64显示： data:image/jpg;base64,

        /// <summary>
        /// 图片Base64显示，传入网络或本地路径
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string PictureBase64String(string url)
        {
            if (url.StartsWith("http"))
            {
                // 网络图片 http、https
                WebClient client = new WebClient();
                byte[] byData = client.DownloadData(url);
                return PictureBase64String(byData);
            }
            else
            {
                FileStream fs = new FileStream(url, FileMode.Open);
                byte[] byData = new Byte[fs.Length];
                fs.Position = 0;
                fs.Read(byData, 0, byData.Length);
                fs.Close();
                return PictureBase64String(byData);
            }
        }

        /// <summary>
        /// 图片Base64显示，传入二进制流
        /// </summary>
        /// <param name="byData"></param>
        /// <returns></returns>
        public static string PictureBase64String(byte[] byData)
        {
            string str = Convert.ToBase64String(byData);
            return string.Format("data:image/jpg;base64,{0}", str);
        }

        #endregion

    }
}
