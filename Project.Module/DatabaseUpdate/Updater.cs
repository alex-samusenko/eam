using System;
using System.Linq;
using System.Collections.Generic;
using Xafari.FW.ExpressApp;
using Xafari.FW.ExpressApp.Updating;
using Xafari.FW.Xpo;
using Xafari.FW.Data.Filtering;
using Xafari;
using PromAktiv.Core.Module;
using PromAktiv.Core.CD.Module.RES.Resource;
using PromAktiv.Module.Снабжение;
using Xafari.BC;
using System.Diagnostics;
using Xafari.FW.Xpo.DB;
using Xafari.FW.Xpo.Generators;

namespace Projet.Module.DatabaseUpdate
{
    /// <summary>
    /// Class Updater.
    /// </summary>
    public class Updater : XafariModuleUpdater
    {
        /// <summary>
        /// Initializes a new instance of the ModuleUpdater.
        /// </summary>
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) {
        }
        /// <summary>
        /// Performs a database update after the database schema is updated.
        /// </summary>
        public override void SafeUpdateDatabaseAfterUpdateSchema()
        {
            Trace.TraceInformation("Текущая версия БД: {0}", CurrentDBVersion.ToString());
            Trace.TraceInformation("Начало выполнения функции SafeUpdateDatabaseAfterUpdateSchema в модуле: [{0}]", this.GetType().FullName);
            base.SafeUpdateDatabaseAfterUpdateSchema();
            //Добавить Сотрудников
            FillEmployeeShortIof(ObjectSpace.Xafari().Session);
            //Удалить все удаленные записи Изготовителей
            var criteria = CriteriaOperator.Parse("GCRecord is not null");
            XpoBatch.Delete<Изготовитель>(ObjectSpace.Xafari().Session, criteria, true);
            Trace.TraceInformation("Окончание выполнения функции SafeUpdateDatabaseAfterUpdateSchema в модуле: [{0}]", this.GetType().FullName);
        }
        /// <summary> Заполнение поля ShortIOF у всех работников
        /// </summary>
        private void FillEmployeeShortIof(Session session)
        {
            var classInfo = session.GetClassInfo(typeof(Сотрудник));
            var uow = new UnitOfWork();
            var employees = uow.GetObjects(classInfo, CriteriaOperator.Parse("[ShortIOF] is null or [ShortIOF] = ''"), new SortingCollection(), 0, 0, false, true);
            foreach (Сотрудник employee in employees)
            {
                var propertyValueStore = new Dictionary<string, Object>(1)
                { { "ShortIOF", FormatFullName(employee.Наименование) } };
                XpoBatch.Update<Сотрудник>(employee.Session, propertyValueStore, CriteriaOperator.Parse("Oid == ?", employee.Oid));
            }
        }
        /// <summary> Преобразует Фамилия Имя Отчество в И.О. Фамилия
        /// </summary>
        /// <param name="fio">Фамилия Имя Отчество</param>
        /// <returns>И.О. Фамилия</returns>
        public static string FormatFullName(string fio)
        {
            var arrayFio = fio.Split(' ');
            var resFio = "";
            if (arrayFio.Count() == 1)
                resFio = arrayFio[0];
            else if (arrayFio.Count() == 2)
                resFio = string.Format("{1}. {0}", arrayFio[0], arrayFio[1].Substring(0, 1));
            else if (arrayFio.Count() > 2)
                resFio = string.Format("{1}.{2}. {0}", arrayFio[0], arrayFio[1].Substring(0, 1), arrayFio[2].Substring(0, 1));
            return resFio;
        }
        /// <summary> Заполнение поля ShortIOF у всех работников с подготовкой
        /// </summary>
        private void FillEmployeeShortIofWithPrepare(Session session)
        {
            var uow = new UnitOfWork();
            var classInfo = session.GetClassInfo(typeof(Сотрудник));
            var employees = uow.GetObjects(classInfo, CriteriaOperator.Parse("[ShortIOF] is null or [ShortIOF] = ''"),
                new SortingCollection(), 0, 0, false, true);
            BatchWideDataHolder4Modification batchWideDataHolder = new BatchWideDataHolder4Modification(session);
            List<ModificationStatement> modificationStatement = new List<ModificationStatement>();
            foreach (Сотрудник employee in employees)
            {
                var propertyValueStore = new Dictionary<string, Object>(1)
                { { "ShortNameIOF", FormatFullName(employee.Наименование) } };
                //Подготовим команды для обновления
                var mtrUpdateStatement = XpoBatch.PrepareUpdate(classInfo, session, batchWideDataHolder, propertyValueStore, CriteriaOperator.Parse("Oid == ?", employee.Oid));
                modificationStatement.AddRange(mtrUpdateStatement);
            }
            //Модификация
            if (modificationStatement.Count > 0)
                XpoBatch.ModifyData(session, modificationStatement);
        }
    }
}
