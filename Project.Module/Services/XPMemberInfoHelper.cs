using System;
using Xafari.FW.ExpressApp.Xpo;
using Xafari.FW.ExpressApp;
using Xafari.FW.Xpo.Metadata;

namespace Project.Module.Services
{
    /// <summary>Управляет расширением метаданных объектов
    /// </summary>
    public static class XPMemberInfoHelper
    {
        /// <summary>Добавляет новое свойство к указаному типу данных
        /// </summary>
        /// <param name="classExt">Тип данных, который необходимо расширить</param>
        /// <param name="propertyName">Наименование нового свойства</param>
        /// <param name="propertyType">Тип добавляемого свойства</param>
        /// <param name="referenceType">Тип данных, если свойство ссылочное. В противном случае - null</param>
        /// <param name="nonPersistent">True, если свойство несохраняемое. Иначе – false</param>
        /// <param name="nonPublic">True, если свойство непубличное. Иначе - false</param>
        /// <param name="attributes">Массив, содержащий атрибуты свойства</param>
        /// <returns>Созданное свойство</returns>
        public static XPCustomMemberInfo CreateMember(
            Type classExt,
            string propertyName,
            Type propertyType,
            Type referenceType,
            bool nonPersistent,
            bool nonPublic,
            params Attribute[] attributes)
        {
            XPDictionary xpDict = XpoTypesInfoHelper.GetXpoTypeInfoSource().XPDictionary;
            XPClassInfo owner = xpDict.GetClassInfo(classExt);
            XPClassInfo propertyClassInfo = referenceType != null ? xpDict.GetClassInfo(referenceType) : null;
            XPCustomMemberInfo member = new XPCustomMemberInfo(owner, propertyName, propertyType, propertyClassInfo,
                nonPersistent, nonPublic);
            foreach (Attribute attr in attributes)
            {
                member.AddAttribute(attr);
                XafTypesInfo.Instance.RefreshInfo(classExt);
            }
            if (attributes.Length == 0)
                XafTypesInfo.Instance.RefreshInfo(classExt);
            return member;
        }
    }
}
