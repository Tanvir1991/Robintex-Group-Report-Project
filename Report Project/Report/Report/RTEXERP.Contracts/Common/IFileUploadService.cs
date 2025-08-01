using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Common
{
    public interface IFileUploadService
    {

        Task<RResult> UploadImage(IFormFile file, string targetFolder, string fileName, bool checkValidExtension);
        RResult UploadImageWithResize(IFormFile file, string targetFolder, string fileName, bool checkValidExtension, int? height, int? width);
        Task<RResult> UploadDocument(IFormFile file, string targetFolder, string fileName, bool checkValidExtension);
    }
}
