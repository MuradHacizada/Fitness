﻿using System.Text;

namespace FittnessWeb.Utilities.Extensions
{
    public static class FileExtension
    {
        public static bool CheckFileType(this IFormFile file, string type)
        {
            if (file.ContentType.Contains(type))
            {
                return true;
            }
            return false;
        }
        public static bool CheckFileSize(this IFormFile file, int kb)
        {
            if (file.Length <= kb * 1024)
            {
                return true;
            }
            return false;
        }
        public static async Task<string> CreateFileAsync(this IFormFile file, string root, string folder)
        {
            string filename = Guid.NewGuid().ToString() + file.FileName;

            string path = Path.Combine(root, folder, filename);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filename;
        }
        public static void DeleteFile(this string fileName, string root, string folder)
        {
            string path = Path.Combine(root, folder, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        
    }
}
