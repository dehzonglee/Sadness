﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Helper.TXT;

namespace Utils.Helper.Encryption
{
    /// <summary>
    /// Base64加密帮助类
    /// 创建日期:2018年3月30日
    /// </summary>
    public class Base64Helper
    {
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="strPlaintext">明文</param>
        /// <returns>Base64密文</returns>
        public static string Base64Encrypt(string strPlaintext)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(strPlaintext);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                TXTHelper.Logs(ex.ToString());
                return string.Empty;
            }
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="strCiphertext">Base64密文</param>
        /// <returns>明文</returns>
        public static string Base64Decrypt(string strCiphertext)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(strCiphertext);
                return Encoding.UTF8.GetString(bytes);
            }
            catch (Exception ex)
            {
                TXTHelper.Logs(ex.ToString());
                return string.Empty;
            }
        }

        /// <summary>
        /// 图片Base64加密
        /// </summary>
        /// <param name="strPlaintext">图片路径</param>
        /// <param name="imageFormat">指定图像格式</param>
        /// <returns>Base64密文</returns>
        public static string ImageBase64Encrypt(string strImagePath, ImageFormat imageFormat)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                Bitmap bitmap = new Bitmap(strImagePath);
                bitmap.Save(memoryStream, imageFormat);
                byte[] bytes = memoryStream.GetBuffer();
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                TXTHelper.Logs(ex.ToString());
                return string.Empty;
            }
        }

        /// <summary>
        /// 图片Base64解密
        /// </summary>
        /// <param name="strCiphertext">Base64密文</param>
        /// <param name="strSaveFilePath">解密图片目录</param>
        /// <param name="imageFormat">指定图像格式</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool ImageBase64Decrypt(string strCiphertext, string strSaveFilePath, ImageFormat imageFormat)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(strCiphertext);
                MemoryStream memoryStream = new MemoryStream(bytes);
                Bitmap bitmap = new Bitmap(memoryStream);
                bitmap.Save(strSaveFilePath, imageFormat);
                return true;
            }
            catch (Exception ex)
            {
                TXTHelper.Logs(ex.ToString());
                return false;
            }
        }
    }
}
