using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopt.Domain.Interfaces
{
    public interface IFileAzure
    {
        string UploadFile(string base64, string container);
        Task<byte[]> DowloadFile(string urlImage);
        Task DeleteFile(string urlImage);
    }
}
