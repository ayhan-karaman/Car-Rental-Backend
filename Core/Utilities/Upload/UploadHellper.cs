using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Constants;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Upload
{
    public class UploadHelper
    {

         private struct CombineFeature
        {
             public string FileName { get; set; } 
             public string FilePath { get; set; }  
        }


        private static Dictionary<ExtensionType, List<string>> Extensions = new Dictionary<ExtensionType, List<string>>
        {
            {(ExtensionType)ExtensionType.Image, new List<string>(){".jpg", ".png", ".jpeg"}},
            {(ExtensionType)ExtensionType.Write, new List<string>(){".txt", ".doc", "docx", ".pdf"}},
        };


        public static IDataResult<string> AddFile(FileFeature feature)
        {
            var createPath = FolderAndFileCombine(feature);
            if(feature.Files?.Length > 0 && createPath.Success)
            {
                  
                    CreateFolder(feature.FolderName);
                    using (FileStream stream = File.Create(createPath.Data.FilePath))
                    {
                        feature.Files.CopyTo(stream);
                        stream.Flush();
                        var result = $"/{feature.FolderName}{createPath.Data.FileName}";
                        return new SuccessDataResult<string>(result, null);
                    }

            }
            return createPath.Success ?  new ErrorDataResult<string>("Lütfen bir dosya seçiniz")
            : new ErrorDataResult<string>(createPath.Message);
        }


       


     

        private static IDataResult<CombineFeature> FolderAndFileCombine(FileFeature feature)
        {
            
            var typeResult = IsExtensionTypeValid(feature.ExtensionType, feature.Files.FileName);
            if(typeResult.Success)
            {
              
                string extension = typeResult.Data;
                string fileName = Guid.NewGuid().ToString(format: "D") + extension;
                string folderPath = Environment.CurrentDirectory;
                string lowerFolderPath = Path.Combine(@"wwwroot/",  feature.FolderName );
                string filePath = Path.Combine(folderPath, lowerFolderPath, fileName);
                 var result =   new CombineFeature{
                    FileName = fileName,
                    FilePath = filePath
                };


                return new SuccessDataResult<CombineFeature>(result);
            }
            return  new ErrorDataResult<CombineFeature>(typeResult.Message);
            
        }


        // Deleted File
        public static IResult DeleteFile(string lowerFilePath)
        {
            string filePath = Environment.CurrentDirectory + "/wwwroot" + lowerFilePath;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return new SuccessResult();
            }
                return new ErrorResult();
        }
       

         // Update File
         public static IDataResult<string> UpdatedFile(FileFeature feature)
         {
            var result = DeleteFile(feature.FolderName);
             
            if(result.Success)
            {
                feature.FolderName =  feature.FolderName.Substring(1, feature.FolderName.IndexOf('/', 1));
                var addedFile =  AddFile(feature);
                return addedFile.Success 
                ? new SuccessDataResult<string>(addedFile.Data, null) 
                : new ErrorDataResult<string> (addedFile.Message);
            }
            return new ErrorDataResult<string>();
         }


        // Extension Valid Operation
        private static IDataResult<string> IsExtensionTypeValid(ExtensionType exType, string fileName)
       {
                Type type = typeof(Message);
                
                string extension = Path.GetExtension(fileName);
                var message =  type.GetField($"Not{exType.ToString()}")?.GetValue(type);
                return exType == ExtensionType.None 
                ? new SuccessDataResult<string>(extension, null) 
                : Extensions[exType].Contains(extension) 
                ?  new SuccessDataResult<string>(extension, null) 
                : new ErrorDataResult<string>(message.ToString());
          
       }
       
        

        // Created Folder
        private static IResult CreateFolder(string folderName)
        {

            bool exists =  Directory.Exists("wwwroot/"+ folderName); 

            if(!exists)
            {
                Directory.CreateDirectory("wwwroot/"+ folderName);
                return new SuccessResult(); 
            }
            return new SuccessResult();
        }


        
    }
}