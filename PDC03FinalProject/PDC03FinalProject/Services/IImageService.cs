using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PDC03FinalProject.Services
{
    public interface IImageService
    {
        Task<Stream> GetImageStreamAsync(string imageName);
    }
}
