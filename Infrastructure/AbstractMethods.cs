namespace ChipsForm.Infrastructure
{
    public abstract class AbstractMethods
    {
        /// <summary>
        /// Insert the webrootpath and the folder directory and the image file to
        /// save image
        /// </summary>
        /// <param name="img"></param>
        /// <param name="webrootPath"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public virtual async Task<string> CreateImage(IFormFile img, string webrootPath, string folderName)
        {
            //Getting the Image upload from server converuing to a url
            var savePath = Path.Combine(webrootPath + $"/{folderName}/");
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            try
            {
                string filePath = Path.Combine(savePath, Path.GetFileName(img.FileName));

                await img.CopyToAsync(new FileStream(filePath, FileMode.Create));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            string url = $"{folderName}/{img.FileName}";
            return url;
        }


        public void DeleteImage(string webroothPath, string url)
        {
            string img = Path.Combine(webroothPath, url);
            FileInfo filename = new FileInfo(img);
            if(filename.Exists)
            {
                try
                {
                    System.IO.File.Delete(filename.FullName);
                    filename.Delete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
