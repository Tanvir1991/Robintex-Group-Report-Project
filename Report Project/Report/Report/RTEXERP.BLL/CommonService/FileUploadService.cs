using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RTEXERP.Common.FileHelper;
using RTEXERP.Contracts.Common;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;


namespace RTEXERP.BLL.CommonService
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IHostingEnvironment server;
        private readonly CheckFileExtensions checkFileExtensions;
        public FileUploadService(IHostingEnvironment server)
        {
            this.server = server;
            checkFileExtensions = new CheckFileExtensions();
        }

        public async Task<RResult> UploadImage(IFormFile file, string targetFolder, string fileName, bool checkValidExtension)
        {
            RResult rResult = new RResult();
            Random rnd = new Random();
            try
            {
                string fName;
                string extension = Path.GetExtension(file.FileName);
                bool isValid;
                if (checkValidExtension)
                    isValid = CheckValidImageExtension(extension);
                else
                    isValid = true;

                if (isValid)
                {
                    targetFolder = targetFolder + "/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.ToString("MMM");
                    string mainPath = Path.Combine(server.WebRootPath, targetFolder);


                    mainPath = CreateDirectory(mainPath);



                    fileName = fileName.Replace("\'", "").Replace("\"", "").Replace(".", "").Replace("\\", "").Replace(":", "").Replace(@"/", "");
                    fileName += DateTime.Now.ToString("yyyyMMMdd_HHmmss_fffffftt_" + rnd.Next(10000, 999999));
                    fName = fileName + extension;
                    var imageUrl = "/" + targetFolder + "/" + fName;
                    rResult = await UploadFile(file, mainPath, fName);
                    rResult.statusMsg = imageUrl;
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = ReturnMessage.ErrorMessage;
                    rResult.statusMsg = "";
                }

            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;
                rResult.statusMsg = "";
            }
            return rResult;

        }
        public RResult UploadImageWithResize(IFormFile file, string targetFolder, string fileName, bool checkValidExtension, int? height, int? width)
        {
            RResult rResult = new RResult();
            Random rnd = new Random();
            try
            {
                if (!height.HasValue)
                    height = 600;
                if (!width.HasValue)
                    width = 800;

                string fname;
                string extension = Path.GetExtension(file.FileName);
                bool isValid;
                if (checkValidExtension)
                    isValid = CheckValidImageExtension(extension);
                else
                    isValid = true;
                if (isValid)
                {
                    targetFolder = targetFolder + "/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.ToString("MMM");
                    string mainPath = Path.Combine(server.WebRootPath, targetFolder);

                    mainPath = CreateDirectory(mainPath);


                    fileName = fileName.Replace("\'", "").Replace("\"", "").Replace(".", "").Replace("\\", "").Replace(":", "").Replace(@"/", "");
                    fileName += DateTime.Now.ToString("yyyyMMMdd_HHmmss_fffffftt_" + rnd.Next(10000, 999999));
                    fname = fileName + extension;

                    string path = Path.Combine(mainPath, fname);
                    Stream strm = file.OpenReadStream();
                    using (var image = Image.FromStream(strm))
                    {
                        var newWidth = Convert.ToInt32(width == null ? image.Width : width);
                        var newHeight = Convert.ToInt32(height == null ? image.Width : height);
                        var thumbnailImg = new Bitmap(newWidth, newHeight);
                        var thumbGraph = Graphics.FromImage(thumbnailImg);
                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

                        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(image, imageRectangle);
                        thumbnailImg.Save(path, image.RawFormat);
                    }
                    rResult.result = 1;
                    rResult.message = ReturnMessage.InsertMessage;
                    rResult.statusMsg = "/" + targetFolder + "/" + fname;
                }
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;
                rResult.statusMsg = "";
            }
            return rResult;
        }
        public async Task<RResult> UploadDocument(IFormFile file, string targetFolder, string fileName, bool checkValidExtension)
        {
            RResult rResult = new RResult();
            Random rnd = new Random();
            try
            {
                string fName;
                string extension = Path.GetExtension(file.FileName);
                bool isValid;
                if (checkValidExtension)
                    isValid = CheckValidDocumentExtension(extension);
                else
                    isValid = true;

                if (isValid)
                {
                    targetFolder = targetFolder + "/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.ToString("MMM");
                    string mainPath = Path.Combine(server.WebRootPath, targetFolder);

                    mainPath = CreateDirectory(mainPath);

                    fileName = fileName.Replace("\'", "").Replace("\"", "").Replace(".", "").Replace("\\", "").Replace(":", "").Replace(@"/", "");
                    fileName += DateTime.Now.ToString("yyyyMMMdd_HHmmss_fffffftt_" + rnd.Next(10000, 999999));
                    fName = fileName + extension;
                    var imageUrl = "/" + targetFolder + "/" + fName;
                    rResult = await UploadFile(file, mainPath, fName);
                    rResult.statusMsg = imageUrl;
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = ReturnMessage.ErrorMessage;
                    rResult.statusMsg = "";
                }
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;
                rResult.statusMsg = "";
            }
            return rResult;
        }

        private async Task<RResult> UploadFile(IFormFile file, string mainPath, string fName)
        {
            RResult rResult = new RResult();
            try
            {
                if (file.Length > 0)
                {
                    string path = Path.Combine(mainPath, fName);

                    if (!Directory.Exists(mainPath))
                    {
                        Directory.CreateDirectory(mainPath);
                    }
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    rResult.result = 1;
                    rResult.message = ReturnMessage.FileUploadMessage;

                }
                else
                {
                    rResult.result = 0;
                    rResult.message = ReturnMessage.ErrorMessage;

                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return rResult;

        }
        private bool CheckValidImageExtension(string extension)
        {
            if (checkFileExtensions.ValidImageExtensions().Contains(extension))
                return true;
            else
                return false;
        }
        private bool CheckValidDocumentExtension(string extension)
        {
            if (checkFileExtensions.ValidDocumentFileExtensions().Contains(extension))
                return true;
            else
                return false;
        }
        private string CreateDirectory(string folderPath)
        {

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }
    }
}

