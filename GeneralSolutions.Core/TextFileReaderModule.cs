﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class TextFileReaderModule : ModuleBase<String>, ITextReader     
    {        
        public String Read()
        {
            String text = File.ReadAllText(Context);
            
            return text;
        }

    }
}
