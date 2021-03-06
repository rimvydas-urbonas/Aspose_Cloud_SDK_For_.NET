﻿using System.Collections.Generic;

namespace Aspose.Cloud.Slides
{
    /// <summary>
    /// represents container part of the slides resource response
    /// </summary>
    public class TextItemsEnvelop
    {

        public List<string> AlternateLinks { get; set; }
        public List<ShapeURI> Links { get; set; }
        public UriResponse SelfUri { get; set; }
        public List<TextItem> Items { get; set; }
    }
}
