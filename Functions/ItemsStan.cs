using SAPbobsCOM;

namespace SapExtensions.Functions
{
    public static class ItemsStan
    {
        public static int SetWhsCode(this Items item, string whsCode)
        {
            int lRetCode = -1;

            for (var line = 0; line < item.WhsInfo.Count; line++)
            {
                item.WhsInfo.SetCurrentLine(line);

                try { item.WhsInfo.SetCurrentLine(line); }
                catch { continue; }

                if (item.WhsInfo.WarehouseCode != whsCode) continue;
                lRetCode = 0;
                break;
            }
            return lRetCode;
        }
    }
}
