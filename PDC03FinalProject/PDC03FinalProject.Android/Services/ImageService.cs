using PDC03FinalProject.Droid;
using PDC03FinalProject.Services;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageService))]
namespace PDC03FinalProject.Droid
{
    public class ImageService : IImageService
    {
        public Task<Stream> GetImageStreamAsync(string imageName)
        {
            var context = Android.App.Application.Context;
            var resourceId = context.Resources.GetIdentifier(imageName.ToLower(), "drawable", context.PackageName);

            if (resourceId != 0)
            {
                Stream stream = context.Resources.OpenRawResource(resourceId);
                return Task.FromResult(stream);
            }
            else
            {
                // Debug logging
                Android.Util.Log.Error("ImageService", $"Image not found: {imageName}");
                return Task.FromResult<Stream>(null);
            }
        }
    }
}