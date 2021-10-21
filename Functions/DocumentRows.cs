using SAPbobsCOM;

namespace SapExtensions.Functions
{
    public static class DocumentRows
    {
        public static Documents SetLineNum(this Documents document, int lineNum)
        {
            int totalRows = document.Lines.Count;

            for (var i = 0; i < totalRows; i++)
            {
                try { document.Lines.SetCurrentLine(i); }
                catch { continue; }

                if (document.Lines.LineNum != lineNum) continue;
                break;
            }

            return document;
        }

        public static Documents DeleteRow(this Documents document, int lineNum)
        {
            int totalRows = document.Lines.Count;

            for (var i = 0; i < totalRows; i++)
            {
                try { document.Lines.SetCurrentLine(i); }
                catch { continue; }

                if (document.Lines.LineNum != lineNum) continue;
                document.Lines.Delete();
                break;
            }

            return document;
        }
    }
}
