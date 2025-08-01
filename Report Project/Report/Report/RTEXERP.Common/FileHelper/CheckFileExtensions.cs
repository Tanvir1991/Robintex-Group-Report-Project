using System.Collections.Generic;

namespace RTEXERP.Common.FileHelper
{
    public class CheckFileExtensions
    {
        public List<string> ValidImageExtensions(List<string> notInclude = null)
        {
            List<string> ext = new List<string>();

            ext.Add(".jpg");
            ext.Add(".jpeg");
            ext.Add(".png");
            ext.Add(".gif");
            if (notInclude != null)
            {
                foreach (var rv in notInclude)
                {
                    ext.Remove(rv);
                }
            }

            return ext;
        }
        public List<string> ValidDocumentFileExtensions(List<string> notInclude = null)
        {
            List<string> ext = new List<string>();

            ext.Add(".pdf");
            ext.Add(".doc");
            if (notInclude != null)
            {
                foreach (var rv in notInclude)
                {
                    ext.Remove(rv);
                }
            }
            return ext;
        }


    }
}
