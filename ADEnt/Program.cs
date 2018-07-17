using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ADEnt.Module;

namespace ADEnt
{
    class Program
    {
        private static MCSEntities1 db = new MCSEntities1();
        static void Main(string[] args)
        {
            MCSEntities1 db = new MCSEntities1();
            db.Database.Log = Console.Write;

            #region //Явная загрузка

            TablesModel model = db.TablesModels.Find(1);

            foreach (var source in db.TablesSNPrefixes.Where(w=>w.intModelID==model.intModelID))
            {
                model.TablesSNPrefixes.Add(source);
            }

            //db.Entry(model)
            //    .Collection(c => c.TablesSNPrefixes)
            //    .Load();

            #endregion

            return;

            #region //Отложенная(ленивая) загрузка
            foreach (var tablesModel in db.TablesModels.Take(5))
            {
                Console.WriteLine(tablesModel.strName);
                foreach (var tablesSnPrefix in tablesModel.TablesSNPrefixes)
                {
                    Console.WriteLine("    - " + tablesSnPrefix.strPrefix);
                }
            }
            #endregion

            return;

            #region//Прямая загрузка
            List<newEquipment> qeuipments =
                db.newEquipments
                    .Include(d => d.TablesLocation)
                    .Include(d => d.TablesModel)
                    .Include(d => d.TablesModel.TablesSNPrefixes)
                    .ToList();

            Console.WriteLine("--------------------------------------------------------------");
            foreach (var newEquipment in qeuipments)
            {
                Console.WriteLine(newEquipment.intGarageRoom);
                foreach (var pref in newEquipment.TablesModel.TablesSNPrefixes)
                {
                    Console.WriteLine("-> " + pref.strPrefix);
                }
            }
            Console.WriteLine("--------------------------------------------------------------");

#endregion
        }
    }
}
