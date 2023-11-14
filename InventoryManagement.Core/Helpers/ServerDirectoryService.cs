﻿using InventoryManagement.Core.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Core;
using InventoryManagement.Core.Acls;

namespace InventoryManagement.Core.Helpers
{
    public class ServerDirectoryService : IServerDirectoryService
    {
        protected readonly IWebHostEnvironment _hostingEnvironment;
        protected readonly IConfiguration _configuration;
        protected readonly ISignInHelper _loggedInUserService;
        protected readonly AppSettings _appSettings;

        public ServerDirectoryService(
            IWebHostEnvironment hostingEnvironment,
            IConfiguration configuration,
            ISignInHelper loggedInUserService,
            IOptions<AppSettings> options)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._configuration = configuration;
            this._loggedInUserService = loggedInUserService;
            this._appSettings = options.Value;
        }


        public bool Exists(string path)
        {
            return System.IO.Directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            return System.IO.File.Exists(path);
        }

        public string GetApplicationPath()
        {
            return this._hostingEnvironment.ContentRootPath;
        }
        public string GetWWWRootPath()
        {
            return _hostingEnvironment.WebRootPath;
        }

        public void SaveFile(string path, byte[] buffer)
        {
            using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            fs.Write(buffer, 0, buffer.Length);
        }

        public void SaveFile(string path, IFormFile formFile)
        {
            using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            formFile.CopyTo(fs);
        }

        public async Task SaveFileAsync(string path, IFormFile formFile)
        {
            await using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            await formFile.CopyToAsync(fs);
        }

        public void RemoveFile(string path)
        {
            if (!this.FileExists(path))
                throw new FileNotFoundException();

            System.IO.File.Delete(path);
        }

      
        public void MoveFileUsingRelativePath(string fromDirectoryPath, string toDirectoryPath)
        {
            fromDirectoryPath = Path.Combine(GetApplicationPath(), fromDirectoryPath);
            toDirectoryPath = Path.Combine(GetApplicationPath(), toDirectoryPath);

            var files = System.IO.Directory.GetFiles(fromDirectoryPath);

            if (files.Length > 0)
            {
                if (!Directory.Exists(toDirectoryPath))
                {
                    Directory.CreateDirectory(toDirectoryPath);
                }

                foreach (var file in files)
                {
                    var backupFileName = Path.GetFileName(file);
                    var destSource = Path.Combine(toDirectoryPath, backupFileName);
                    File.Move(file, destSource);
                }
            }
            if (Directory.Exists(fromDirectoryPath))
            {
                Directory.Delete(fromDirectoryPath, true);
            }
        }


        public void CopyFileUsingRelativePath(string fromDirectoryPath, string toDirectoryPath)
        {
            fromDirectoryPath = Path.Combine(GetApplicationPath(), fromDirectoryPath);
            toDirectoryPath = Path.Combine(GetApplicationPath(), toDirectoryPath);

            var files = System.IO.Directory.GetFiles(fromDirectoryPath);

            if (files.Length > 0)
            {
                if (!Directory.Exists(toDirectoryPath))
                {
                    Directory.CreateDirectory(toDirectoryPath);
                }

                foreach (var file in files)
                {
                    var backupFileName = Path.GetFileName(file);
                    var destSource = Path.Combine(toDirectoryPath, backupFileName);
                    File.Copy(file, destSource);
                }
            }
        }


        public void MoveFileFromPhysicalPathToServer(string fromDirectoryPath, string toDirectoryPath)
        {
            fromDirectoryPath = Path.Combine(GetApplicationPath(), fromDirectoryPath);
            //toDirectoryPath = HttpContext.Current.Server.MapPath(toDirectoryPath);

            var files = System.IO.Directory.GetFiles(fromDirectoryPath);

            if (files.Length > 0)
            {
                if (!Directory.Exists(toDirectoryPath))
                {
                    Directory.CreateDirectory(toDirectoryPath!);
                }

                foreach (var file in files)
                {
                    var backupFileName = Path.GetFileName(file);
                    var destSource = Path.Combine(toDirectoryPath, backupFileName);
                    File.Move(file, destSource);
                }

            }
            if (Directory.Exists(fromDirectoryPath))
            {
                Directory.Delete(fromDirectoryPath, true);
            }

        }

        public List<string> GetAllFileName(string directory)
        {

            var fileNames = Directory.GetFiles(directory)
                                     .Select(Path.GetFileName)
                                     .ToList();
            return fileNames;
        }

        public List<string> GetAllFileName(string directory, string url)
        {

            var fileNames = GetAllFileName(directory)
                            .Select(c => url + "\\" + c)
                                     .ToList();
            return fileNames;
        }

        public List<string> GetAllFiles(string directory)
        {
            var files = Directory.GetFiles(directory)
                                    .ToList();
            return files;
        }
    }
}
