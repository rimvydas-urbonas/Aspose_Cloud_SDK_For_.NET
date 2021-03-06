﻿using Aspose.Cloud.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Aspose.Cloud.Words
{
    public class Field
    {
        public string Format { get; set; }
        public string Alignment { get; set; }
        public bool IsTop { get; set; }
        public bool SetPageNumberOnFirstPage { get; set; }

        /// <summary>
        /// insert page number filed into the document
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="alignment"></param>
        /// <param name="format"></param>
        /// <param name="isTop"></param>
        /// <param name="SetPageNumberOnFirstPage"></param>
        /// <param name="documentFolder"></param>

        public Boolean InsertPageNumber(string fileName, string alignment, string format, Boolean isTop, Boolean setPageNumberOnFirstPage, string documentFolder = "")
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + fileName + "/insertPageNumbers" +
                    (documentFolder == "" ? "" : "?folder=" + documentFolder);

                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                Field field = new Field();
                field.Alignment = alignment;
                field.Format = format;
                field.IsTop = isTop;
                field.SetPageNumberOnFirstPage = setPageNumberOnFirstPage;

                string strJSON = JsonConvert.SerializeObject(field);
                JObject pJSON = null;
                using (Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strJSON))
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        string strResponse = reader.ReadToEnd();

                        //Parse the json string to JObject
                        pJSON = JObject.Parse(strResponse);
                    }
                }
                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(pJSON.ToString());

                if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        /// <summary>
        /// Gets all merge filed names from document
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="documentFolder"></param>
        public List<string> GetMailMergeFieldNames(string fileName, string documentFolder = "")
        {
            try
            {
                //check whether file is set or not
                if (fileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + fileName;
                strURI += "/mailMergeFieldNames" + (documentFolder == "" ? "" : "?folder=" + documentFolder); ;

                //sign URI
                string signedURI = Utils.Sign(strURI);
                string strJSON = null;
                using (StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET")))
                {
                    //further process JSON response
                    strJSON = reader.ReadToEnd();
                }
                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                MergeFieldResponse Response = JsonConvert.DeserializeObject<MergeFieldResponse>(parsedJSON.ToString());

                //return document property
                return Response.FieldNames.Names;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
