﻿using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    /// <summary>
    ///  Represents response from the worksheets resource
    /// </summary>
    public class WorksheetsResponse : Aspose.Cloud.Common.BaseResponse
    {

        public List<Worksheet> WorksheetList { get; set; }

        public LinkResponse Link { get; set; }

    }
}
