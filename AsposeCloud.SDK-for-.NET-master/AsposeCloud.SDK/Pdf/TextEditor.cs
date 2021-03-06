﻿using Aspose.Cloud.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// This class contains features to work with text
    /// </summary>
    public class TextEditor
    {
        public TextEditor(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// PDF document name
        /// </summary>
        public string FileName { get; set; }


        /// <summary>
        /// Gets raw text from the whole PDF file 
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/TextItems";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());


            StringBuilder stringBuilder = new StringBuilder();


            foreach (TextItem textItem in textItemsResponse.TextItems.List)
            {
                stringBuilder.Append(textItem.Text);
            }

            return stringBuilder.ToString();

        }

        /// <summary>
        /// Gets raw text from a particular page
        /// </summary>
        /// <returns></returns>
        public string GetText(int pageNumber)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/TextItems";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());


            StringBuilder stringBuilder = new StringBuilder();


            foreach (TextItem textItem in textItemsResponse.TextItems.List)
            {
                stringBuilder.Append(textItem.Text);
            }

            return stringBuilder.ToString();

        }


        /// <summary>
        /// Gets text items from the whole PDF file 
        /// </summary>
        /// <returns></returns>
        public List<TextItem> GetTextItems()
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/TextItems";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.List;
        }

        /// <summary>
        /// Gets text items from a particular page
        /// </summary>
        /// <returns></returns>
        public List<TextItem> GetTextItems(int pageNumber)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/TextItems";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.List;
        }


        /// <summary>
        /// Gets all text items from a fragment
        /// </summary>
        /// <returns></returns>
        public List<TextItem> GetTextItems(int pageNumber, int fragmentNumber)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/fragments/" + fragmentNumber.ToString() + "/TextItems";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.List;
        }


        /// <summary>
        /// Gets count of the fragments from a particular page
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public int GetFragmentCount(int pageNumber)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/fragments";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.List.Count;
        }

        /// <summary>
        /// Gets an individual segment
        /// </summary>
        /// /***********Method  GetSegment Added by:Zeeshan*******/
        public string GetSegment(int pageNumber, int fragmentNumber, int segmentNumber)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/fragments/" + fragmentNumber.ToString() + "/segments/" + segmentNumber.ToString();
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            SagmentResponse segmentResponse = JsonConvert.DeserializeObject<SagmentResponse>(parsedJSON.ToString());
            if (segmentResponse.TextItem != null)
                return segmentResponse.TextItem.Text;
            else
                return "segment doesn't exist";
        }

        /// <summary>
        /// Gets count of segments in a fragment
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="fragmentNumber"></param>
        /// <returns></returns>
        public int GetSegmentCount(int pageNumber, int fragmentNumber)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/fragments/" + fragmentNumber.ToString();
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.List.Count;
        }

        /// <summary>
        /// a list of all text segments that are defined in the text fragment.
        /// </summary>

        /// <returns></returns>
        /// 
        /***********Method  GetAllSegmentCount Added by:Zeeshan*******/
        public int GetAllSegmentCount(int pageNumber, int fragmentNumber)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/fragments/" + fragmentNumber.ToString() + "/segments";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.List.Count;
        }


        /// <summary>
        /// Gets TextFormat of a particular Fragment
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="fragmentNumber"></param>
        /// <returns></returns>
        public TextFormat GetTextFormat(int pageNumber, int fragmentNumber)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/fragments/" + fragmentNumber.ToString() + "/textformat";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            TextFormatResponse textformatResponse = JsonConvert.DeserializeObject<TextFormatResponse>(parsedJSON.ToString());

            return textformatResponse.TextFormat;
        }

        /// <summary>
        /// Gets TextFormat of a particular Segment
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="fragmentNumber"></param>
        /// <param name="segmentNumber"></param>
        /// <returns></returns>
        public TextFormat GetTextFormat(int pageNumber, int fragmentNumber, int segmentNumber)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/fragments/" + fragmentNumber.ToString() + "/segments/" + segmentNumber.ToString() + "/textformat";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            TextFormatResponse textformatResponse = JsonConvert.DeserializeObject<TextFormatResponse>(parsedJSON.ToString());

            return textformatResponse.TextFormat;
        }


        /// <summary>
        /// Replace Text in a PDF Document
        /// </summary>
        /// <param name="oldText"></param>
        /// <param name="newText"></param>
        /// <param name="isRegularExpression"></param>
        /// <returns>Number of Matches</returns>
        public int ReplaceText(string oldText, string newText, bool isRegularExpression)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/replaceText";
            string signedURI = Utils.Sign(strURI);

            //serialize the JSON request content
            TextReplace replaceText = new TextReplace();
            replaceText.OldValue = oldText;
            replaceText.NewValue = newText;
            if (isRegularExpression)
                replaceText.Regex = "true";
            else
                replaceText.Regex = "false";

            string strJSON = JsonConvert.SerializeObject(replaceText);

            Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strJSON);

            StreamReader reader = new StreamReader(responseStream);
            string strResponse = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject pJSON = JObject.Parse(strResponse);

            ReplaceTextResponse replaceTextResponse = JsonConvert.DeserializeObject<ReplaceTextResponse>(pJSON.ToString());

            if (replaceTextResponse.Code == "200" && replaceTextResponse.Status == "OK")
                return replaceTextResponse.Matches;
            else
                return 0;


        }

        /// <summary>
        /// Replace Text in Particular Page of PDF Document
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="oldText"></param>
        /// <param name="newText"></param>
        /// <param name="isRegularExpression"></param>
        /// <returns>Number of Matches</returns>
        public int ReplaceText(int pageNumber, string oldText, string newText, bool isRegularExpression)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber + "/replaceText";
            string signedURI = Utils.Sign(strURI);

            //serialize the JSON request content
            TextReplace replaceText = new TextReplace();
            replaceText.OldValue = oldText;
            replaceText.NewValue = newText;
            if (isRegularExpression)
                replaceText.Regex = "true";
            else
                replaceText.Regex = "false";

            string strJSON = JsonConvert.SerializeObject(replaceText);

            Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strJSON);

            StreamReader reader = new StreamReader(responseStream);
            string strResponse = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject pJSON = JObject.Parse(strResponse);

            ReplaceTextResponse replaceTextResponse = JsonConvert.DeserializeObject<ReplaceTextResponse>(pJSON.ToString());

            if (replaceTextResponse.Code == "200" && replaceTextResponse.Status == "OK")
                return replaceTextResponse.Matches;
            else
                return 0;


        }
    }
}
