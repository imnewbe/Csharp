using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    public static class PictureHelper
    {
        public static string[] GetFileList()
        {
            string[] files = Directory.GetFiles(
                Properties.Settings.Default.Dir);

            //只保留文件名
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }

            return files;
        }

        public static byte[] GetFileBytes(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            byte[] buffer = new byte[fileInfo.Length];
            using (FileStream stream = fileInfo.OpenRead())
            {
                stream.Read(buffer, 0, buffer.Length);
            }

            return buffer;
        }

        public static byte[] GetFileListBytes()
        {
            string[] files = GetFileList();
            StringBuilder responseMsg = new StringBuilder();
            foreach (string s in files)
            {
                responseMsg.Append(s);
                responseMsg.Append(":");
            }

            byte[] responseBuffer = Encoding.ASCII.GetBytes(
                responseMsg.ToString().TrimEnd(':'));
            return responseBuffer;
        }
    }
}
