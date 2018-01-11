using EasySystem.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Controller
{
    public class StampController
    {
        EasySystemDBContext context = new EasySystemDBContext();

        public int Save(Business_StampSheet stampSheet)
        {
            if(string.IsNullOrEmpty(stampSheet.StampSheetID))
            {
                context.Business_StampSheets.Add(stampSheet);
            }
            else
            {
                Business_StampSheet old = context.Business_StampSheets.Find(stampSheet.StampSheetID);
                context.Entry(stampSheet).CurrentValues.SetValues(stampSheet);
            }
            return context.SaveChanges();
        }

        
    }
}
