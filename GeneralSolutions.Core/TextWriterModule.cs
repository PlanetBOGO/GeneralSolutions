using System;
using System.Collections.Generic;
using System.IO;


namespace GeneralSolutions
{
    public class TextWriterModule : OutputModuleBase<TextWriter, String>, ITextWriter
    {
        public TextWriterModule()
        {

        }

        public TextWriterModule(TextWriter writer) : this()
        {            
            Context = writer;
        }

        public override void Write(String text)
        {
            if (!String.IsNullOrEmpty(text))
                Context.Write(text);
        }

        public virtual void Write(String text, String lineBreak)
        {
            if (!String.IsNullOrEmpty(text))
            {
                Context.Write(text);
                Context.Write(lineBreak);
            }
        }

        public virtual void Write(IEnumerable<string> enumerable)
        {
            foreach (var e in enumerable)
                if (e != null)
                    Context.Write(e.ToString());
        }

        public virtual void Write(IEnumerable<string> enumerable, String lineBreak)
        {
            foreach (var e in enumerable)
                if (e != null)
                {
                    Context.Write(e.ToString());
                    Context.Write(lineBreak);
                }
        }

    }

}

////////////////////////////////////////////////////////////////////////////////////
// Implemenation details in VS2013
// - TextWriter is module context
// - Writes String or Collection of Objects



