﻿namespace JavaLanguageService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.Text.Tagging;
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Utilities;
    using Microsoft.VisualStudio.Text;

    //[Export(typeof(ITaggerProvider))]
    [ContentType(Constants.JavaContentType)]
    [TagType(typeof(IOutliningRegionTag))]
    public sealed class OutliningTaggerProvider : ITaggerProvider
    {
        [Import]
        internal JavaBackgroundParserService JavaBackgroundParserService;

        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            Func<OutliningTagger> creator = () => new OutliningTagger(buffer, JavaBackgroundParserService.GetBackgroundParser(buffer));
            return buffer.Properties.GetOrCreateSingletonProperty<OutliningTagger>(creator) as ITagger<T>;
        }
    }
}