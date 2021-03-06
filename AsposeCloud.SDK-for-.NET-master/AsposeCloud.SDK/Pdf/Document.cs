﻿using Aspose.Cloud.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;



namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// Deals with PDF document level aspects
    /// </summary>
    public class Document
    {
        public Document(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// PDF document name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets the page count of the specified PDF document
        /// </summary>
        /// <returns>page count</returns>
        public int GetPageCount()
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/Pages";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            PagesResponse pagesResponse = JsonConvert.DeserializeObject<PagesResponse>(parsedJSON.ToString());

            int count = pagesResponse.Pages.List.Count;


            return count;
        }

        /// <summary>
        /// Add Stamp to the page
        /// </summary>
        /// <returns>Stamp</returns>
        /// 

        /***********Method  AddStampWithTextState Added by:Zeeshan*******/
        public bool AddStampWithTextState(StampRequest stampRequest)
        {
            try
            {
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + stampRequest.PageIndex + "/stamp/";
                string signedURI = Utils.Sign(strURI);


                string strJSON = JsonConvert.SerializeObject(stampRequest);

                Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", strJSON);

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                StampResponse baseResponse = JsonConvert.DeserializeObject<StampResponse>(pJSON.ToString());

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
        /***********Method  AddStamp Added by:Zeeshan*******/
       
        public bool AddStamp(StampRequest stampRequest)
        {
            try
            {
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + stampRequest.PageIndex + "/stamp/";
                string signedURI = Utils.Sign(strURI);

                string strJSON = JsonConvert.SerializeObject(stampRequest);

                Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", strJSON);

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                StampResponse baseResponse = JsonConvert.DeserializeObject<StampResponse>(pJSON.ToString());

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
        /// Gets the page count of the specified PDF document
        /// </summary>
        /// <returns>page count</returns>
        /// \
        /// 
        /***********Method  GetTotalWordCount Added by:Zeeshan*******/
        public int GetTotalWordCount()
        {
            try
            {

                //build URI 
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/Pages";
                strURI += "/wordCount";
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();


                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);


                //Deserializes the JSON to a object. 
                WordsPerPage wordsResponse = JsonConvert.DeserializeObject<WordsPerPage>(parsedJSON.ToString());
                int count = 0;
                foreach (WordResponse wordResponse in wordsResponse.Wordsperpage.List)
                    count += wordResponse.Count;
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetWordsPerPage(int pageNumber)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/Pages";
                strURI += "/wordCount";
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();


                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);


                //Deserializes the JSON to a object. 
                WordsPerPage wordsResponse = JsonConvert.DeserializeObject<WordsPerPage>(parsedJSON.ToString());
                int count = 0;
                if (pageNumber <= wordsResponse.Wordsperpage.List.Count)
                {
                    count = wordsResponse.Wordsperpage.List[pageNumber - 1].Count;
                }

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /***********Method  GetDocument Added by:Zeeshan*******/
        public PdfDocument GetDocument()
        {
            try
            {
                //build URI 
                string strURI = Product.BaseProductUri + "/pdf/" + FileName;
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();


                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                DocumentResponse documentPropertiesResponse = JsonConvert.DeserializeObject<DocumentResponse>(parsedJSON.ToString());

                return documentPropertiesResponse.Document;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets all the properties of the specified document
        /// </summary>
        /// <returns>list of properties</returns>
        public List<DocumentProperty> GetDocumentProperties()
        {
            try
            {

                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/documentProperties";
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();


                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);


                //Deserializes the JSON to a object. 
                DocumentPropertiesResponse documentPropertiesResponse = JsonConvert.DeserializeObject<DocumentPropertiesResponse>(parsedJSON.ToString());

                return documentPropertiesResponse.DocumentProperties.List;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the value of a particular property
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns>value of the specified property</returns>
        public DocumentProperty GetDocumentProperty(string propertyName)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/documentProperties/" + propertyName;
            string signedURI = Utils.Sign(strURI);


            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            DocumentPropertyResponse documentPropertyResponse = JsonConvert.DeserializeObject<DocumentPropertyResponse>(parsedJSON.ToString());

            return documentPropertyResponse.DocumentProperty;

        }

        /// <summary>
        /// Sets the value of a particular property
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        public bool SetDocumentProperty(string propertyName, string propertyValue)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/documentProperties/" + propertyName;
            string signedURI = Utils.Sign(strURI);

            //serialize the JSON request content
            DocumentProperty docProperty = new DocumentProperty();
            docProperty.Value = propertyValue;
            string strJSON = JsonConvert.SerializeObject(docProperty);

            Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", strJSON);

            StreamReader reader = new StreamReader(responseStream);
            string strResponse = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject pJSON = JObject.Parse(strResponse);

            DocumentPropertyResponse baseResponse = JsonConvert.DeserializeObject<DocumentPropertyResponse>(pJSON.ToString());

            if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                return true;
            else
                return false;


        }

        /// <summary>
        /// removes values of all the properties
        /// </summary>
        /// <returns></returns>
        public bool RemoveAllProperties()
        {

            //throw new Exception("Resource removeAll throws exception");

            //with POST following exception
            //throw new Exception("Exception received: The remote server returned an error: (405) Method Not Allowed");
            //if GET works then documentation needs to be updated

            //with GET following exception
            //The remote server returned an error: (400) Bad Request

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/documentProperties";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "DELETE");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

            if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                return true;
            else
                return false;
        }

        public bool RemoveDocumentProperty()
        {


            //build URI
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/documentProperties/Author";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "DELETE");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

            if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets the form field count
        /// </summary>
        /// <returns>count of the form fields</returns>
        public int GetFormFieldCount()
        {
            try
            {
                //build URI 
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/fields";
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();


                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);


                //Deserializes the JSON to a object. 
                FormFieldsResponse formFieldsResponse = JsonConvert.DeserializeObject<FormFieldsResponse>(parsedJSON.ToString());

                return formFieldsResponse.Fields.List.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets list of all the fields in the PDF file
        /// </summary>
        /// <returns>list of the form fields</returns>
        public List<FormField> GetFormFields()
        {
            try
            {
                //build URI 
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/fields";
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();


                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);


                //Deserializes the JSON to a object. 
                FormFieldsResponse formFieldsResponse = JsonConvert.DeserializeObject<FormFieldsResponse>(parsedJSON.ToString());

                return formFieldsResponse.Fields.List;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets a particular form field
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>form field</returns>
        public FormField GetFormField(string fieldName)
        {
            try
            {
                //build URI 
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/fields/" + fieldName;
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();


                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);


                //Deserializes the JSON to a object. 
                FormFieldResponse formFieldResponse = JsonConvert.DeserializeObject<FormFieldResponse>(parsedJSON.ToString());

                return formFieldResponse.Field;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Creates a Pdf from XML
        /// </summary>
        /// <param name="pdfFileName"></param>
        /// <param name="xsltFileName"></param>
        /// <param name="xmlFileName"></param>
        /// <returns></returns>
        public bool CreateFromXml(string pdfFileName, string xsltFileName, string xmlFileName)
        {
            try
            {

                string strURI = Product.BaseProductUri + "/pdf/" + pdfFileName + "?templateFile=" + xsltFileName + "&dataFile=" + xmlFileName + "&templateType=xml";
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Creates a Pdf from HTML
        /// </summary>
        /// <param name="pdfFileName"></param>
        /// <param name="htmlFileName"></param>
        /// <returns></returns>
        public bool CreateFromHtml(string pdfFileName, string htmlFileName)
        {
            try
            {

                string strURI = Product.BaseProductUri + "/pdf/" + pdfFileName + "?templateFile=" + htmlFileName + "&templateType=html";
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Creates an Empty Pdf document
        /// </summary>
        /// <param name="newDocumentName"></param>
        /// <returns></returns>

        public bool CreateEmptyPdf(String newDocumentName)
        {

            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + newDocumentName;
                string signedURI = Utils.Sign(strURI);



                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Merge two or more Pdf documents. A new pdf file will be generated.
        /// </summary>
        /// <param name="sourceFiles"></param>        
        /// <returns></returns>
        /***********Method  MergeDocuments Added by:Zeeshan*******/
        public bool MergeDocuments(String[] sourceFiles)
        {

            try
            {
                //New PDF Filename
                String mergedFileName = FileName;

                if (sourceFiles.Length < 1)
                {
                    throw new Exception("One or more files are requred to merge.");
                }


                //build URI to get page count
                String strURI = Product.BaseProductUri + "/pdf/" + mergedFileName + "/merge";
                String signedURI = Utils.Sign(strURI);

                SourceFilesList sourcefileslist = new SourceFilesList();
                sourcefileslist.List = sourceFiles;

                string jsondata = JsonConvert.SerializeObject(sourcefileslist);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT", jsondata, "json"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Appends two Pdf documents. The newPdf is appended at the end of basePdf
        /// </summary>
        /// <param name="basePdf"></param>
        /// <param name="newPdf"></param>
        /// <returns></returns>

        public bool AppendDocument(string basePdf, string newPdf)
        {

            try
            {
                //Saving Exisiting File name
                String sOldFile = FileName;

                //Getting Total page in PDF
                FileName = newPdf;
                int iPageCount = GetPageCount();

                //Setting Old File name again
                FileName = sOldFile;

                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + basePdf + "/appendDocument?appendFile=" + newPdf + "&startPage=1&endPage=" + iPageCount.ToString();
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Splits pages 2-3 from the PDF document.
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <returns></returns>
        /***********Method  SplitDocument Added by:Zeeshan*******/
        public LinkResponse[] SplitDocument(int from, int to)
        {

            try
            {
                //build URI 
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/split?from=" + from + "&to=" + to;
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                SplitPDFResponse responseStream = JsonConvert.DeserializeObject<SplitPDFResponse>(parsedJSON.ToString());
                return responseStream.Result.Documents;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Splits pages 2-3 from the PDF document in diff format
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        /***********Method  SplitDocument Added by:Zeeshan*******/
        public LinkResponse[] SplitDocument(int from, int to, SplitDocumentFormat format)
        {

            try
            {
                //build URI 
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/split?from=" + from + "&to=" + to + "&format=" + format.ToString();
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                SplitPDFResponse responseStream = JsonConvert.DeserializeObject<SplitPDFResponse>(parsedJSON.ToString());
                return responseStream.Result.Documents;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Splits pages of PDF document.
        /// </summary>
        /// <returns></returns>
        /***********Method  SplitDocument Added by:Zeeshan*******/
        public LinkResponse[] SplitDocument()
        {

            try
            {
                //build URI 
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/split";
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                SplitPDFResponse responseStream = JsonConvert.DeserializeObject<SplitPDFResponse>(parsedJSON.ToString());
                return responseStream.Result.Documents;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Appends two Pdf documents. The start and end pages number newPdf is given and it is appended at the end of basePdf
        /// </summary>
        /// <param name="basePdf"></param>
        /// <param name="newPdf"></param>
        /// <param name="startPage"></param>
        /// <param name="endPage"></param>
        /// <returns></returns>

        public bool AppendDocument(string basePdf, string newPdf, int startPage, int endPage)
        {

            try
            {

                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + basePdf + "/appendDocument/?appendFile=" + newPdf + "&startPage=" + startPage.ToString() + "&endPage=" + endPage.ToString();
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Adds new page to opened Pdf document
        /// </summary>
        /// <returns></returns>

        public bool AddNewPage()
        {

            try
            {

                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages";
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds new page to opened Pdf document
        /// </summary>
        /// <returns></returns>

        public bool SaveAsTiff(string outputFile, string compression, string folderName)
        {

            try
            {
                //build URI 
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/SaveAs/tiff?resultFile=" + outputFile + "&compression=" + compression + "&folder=" + folderName;
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// to add signature to the document by using specific form field.
        /// </summary>
        /// <returns></returns>
        /***********Method  AddSignature Added by:Zeeshan*******/
        public bool AddSignature(Signature sign)
        {

            try
            {

                string strJSON = JsonConvert.SerializeObject(sign);
                //build URI to get page coun
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/sign";
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST", strJSON));

                //further process JSON response
                strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// add form field
        /// </summary>
        /// <returns></returns>
        /***********Method  InsertFormField Added by:Zeeshan*******/
        public bool InsertFormField(FormField formField)
        {

            try
            {

                string strJSON = JsonConvert.SerializeObject(formField);
                //build URI 
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/fields/"+formField.Name;
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT", strJSON));

                //further process JSON response
                strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /***********Method  InsertFormFields Added by:Zeeshan*******/
        public bool InsertFormFields(FormFields formField)
        {

            try
            {

                string strJSON = JsonConvert.SerializeObject(formField);
                //build URI 
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/fields";
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT", strJSON));

                //further process JSON response
                strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        ///  SaveAs Tiff by passing settings
        /// </summary>
        /// <returns></returns>
        /***********Method  ProtectWorksheet Added by:Zeeshan*******/
        public bool SaveAsTiff(SaveAsTiffOptions image, string folderName)
        {

            try
            {


                string strJSON = JsonConvert.SerializeObject(image);
                //build URI to get page coun
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/SaveAs/tiff?folder=" + folderName;
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT", strJSON));

                //further process JSON response
                strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Deletes selected page in Pdf document
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>

        public bool DeletePage(int pageNumber)
        {
            try
            {

                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString();
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "DELETE"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Moves selected page in Pdf document to new location
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="newLocation"></param>
        /// <returns></returns>
        public bool MovePage(int pageNumber, int newLocation)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/movePage?newIndex=" + newLocation.ToString();
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///  Replace Image in PDF File using Local Image Stream
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="imageIndex"></param>
        /// <param name="imageStream"></param>
        /// <returns></returns>
        public bool ReplaceImageUsingStream(int pageNumber, int imageIndex, Stream imageStream)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/images/" + imageIndex.ToString();

                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST", imageStream);

                StreamReader reader = new StreamReader(responseStream);

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Replace Image in PDF document using Image File uploaded on Server
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="imageIndex"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool ReplaceImageUsingFile(int pageNumber, int imageIndex, string fileName)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/images/" + imageIndex.ToString() + "?imageFile=" + fileName;

                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST");

                StreamReader reader = new StreamReader(responseStream);

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
