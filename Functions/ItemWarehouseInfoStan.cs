using System.Collections.Generic;
using SAPbobsCOM;

namespace SapExtensions.Functions
{
    public static class ItemWarehouseInfoStan
    {
        public static int GetByWhsCode(this ItemWarehouseInfo itemWarehouse, string whsCode)
        {
            int lRetCode = -1;

            for (var line = 0; line < itemWarehouse.Count; line++)
            {
                itemWarehouse.SetCurrentLine(line);

                try { itemWarehouse.SetCurrentLine(line); }
                catch { continue; }

                if (itemWarehouse.WarehouseCode != whsCode) continue;
                lRetCode = 0;
                break;
            }
            return lRetCode;
        }

        public static List<string> GetAssignedWhs(this ItemWarehouseInfo itemWarehouse)
        {
            var response = new List<string>();

            for (var lineIndex = 0; lineIndex < itemWarehouse.Count; lineIndex++)
            {
                try { itemWarehouse.SetCurrentLine(lineIndex); }
                catch { continue; }

                response.Add(itemWarehouse.WarehouseCode);
            }

            return response;
        }
    }
}
