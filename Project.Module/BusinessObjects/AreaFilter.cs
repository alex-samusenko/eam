using PromAktiv.Module.Parameters;
using Xafari.FW.ExpressApp.DC;
using Xafari.FW.Persistent.Base;
using Xafari.FW.Xpo;
using Xafari;
using Xafari.FW.ExpressApp.Model;
using Xafari.SmartDesign;

namespace Project.Module.BusinessObjects
{
    /// <summary>Фильтр для Площадок</summary>
    [DomainComponent]
    [ImageName("Action_Filter")]
    [NotAudited]
    [NonPersistent]
    [CreateDetailView(Layout = "ByType;Employee;")]
    [CreateDetailView(Id = "AreaCustomFilter_DetailView", Layout = "FilterByUserRoleCollection")]
    public class AreaFilter(Session session) : ДокументФильтр(session)
    {
        private TypeAreaFilter byType = TypeAreaFilter.All;
        /// <summary>Фильтр по типу площадки</summary>
        [ImmediatePostData]
        [ModelDefault("Caption", "По типу")]
        public TypeAreaFilter ByType
        {
            get => byType;
            set => SetPropertyValue(nameof(ByType), ref byType, value);
        }

        /// <summary>Переопределение метода очистки</summary>
        public override void Clear()
        {
            this.ByType = TypeAreaFilter.All;
            this.Employee = null;
        }
    }

    /// <summary> Перечисление Тип площадки для фильтра
    /// Используется в фильтре ByType
    /// </summary>
    public enum TypeAreaFilter
    {
        [XafDisplayName("Основная")]
        Main = 1,
        [XafDisplayName("Дополнительная")]
        Additional = 0,
        [XafDisplayName("Все")]
        All = 2
    };
}
