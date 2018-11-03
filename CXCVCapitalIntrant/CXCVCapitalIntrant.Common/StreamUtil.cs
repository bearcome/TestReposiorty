using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CXCVCapitalIntrant.Common
{
    public class StreamUtil
    {
        /// <summary>
        /// 读取文件流
        /// </summary>
        /// <param name="files"></param>
        /// <param name="name"></param>
        /// <param name="filetype"></param>
        /// <returns></returns>
        public static byte[] StreamToByte(HttpFileCollectionBase files, string name, ref string filetype)
        {
            if (files == null || files[name] == null)
                return null;
            var file = files[name];
            long length = file.InputStream.Length;
            byte[] bytes = new byte[length];
            var inputStream = file.InputStream.Read(bytes, 0, bytes.Length);
            filetype = file.ContentType;
            return bytes;
        }
    }
}
