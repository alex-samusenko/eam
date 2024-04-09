using Project.Module.Services;
using PromAktiv.Core.CD.Module.RES.Resource;
using System;
using Xafari.FW.ExpressApp.DC;
using Xafari.FW.Xpo;

namespace Project.Module.ObjectsExtensions
{
    /// <summary>Расширяет справочник Сотрудники
    /// </summary>
    public static class EmployeeExtension
    {
        /// <summary>Добавляем поле И.О. Фамилия
        /// </summary>
        public static void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            Type typeExt = typeof(Сотрудник);
            // добавим новый string реквизит Сотрудник.ShortNameIOF И.О. Фамилия
            XPMemberInfoHelper.CreateMember(typeExt, "ShortIOF", typeof(string), null, false, false,
                new XafDisplayNameAttribute("ИОФ краткое"), new SizeAttribute(100));
        }
    }
}
