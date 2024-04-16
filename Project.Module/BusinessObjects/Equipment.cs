using PromAktiv.Core.CD.Module.ITM;
using PromAktiv.Core.Module;
using System.ComponentModel;
using Xafari.FW.ExpressApp.ConditionalAppearance;
using Xafari.FW.ExpressApp.DC;
using Xafari.FW.ExpressApp.Model;
using Xafari.FW.Persistent.Base;
using Xafari.FW.Persistent.Validation;
using Xafari.FW.Xpo;
using Xafari.SmartDesign;

namespace Project.Module.BusinessObjects
{
    /// <summary>Оборудование площадок</summary>
    [DefaultClassOptions]
    [XafDisplayName("Комплектация площадки")]
    [ImageName("СоставОборудования")]
    [SmartDesignStrategy(typeof(XafSmartDesignStrategy))]
    [RuleCriteria("RuleQtyCheck", DefaultContexts.Save, "[Qty] > 0",
        CustomMessageTemplate = "Количество должно быть больше нуля!", SkipNullOrEmptyValues = false)]
    public class Equipment(Session session) : БазовыйОбъект(session)
    {
        private НоменклатурнаяПозиция item;
        [ModelDefault("Caption", "Номенклатура")]
        public НоменклатурнаяПозиция Item
        {
            get => item;
            set => SetPropertyValue(nameof(Item), ref item, value);
        }

        private decimal qty;
        /// <summary>Количество номенклатуры</summary>
        [ModelDefault("Caption", "Количество")]
        [ModelDefault("DisplayFormat", "0")]
        [ModelDefault("EditMask", "f")]
        [RuleRange("RuleRangeQty", DefaultContexts.Save, 1, 50,
            CustomMessageTemplate = "Количество должно быть в диапазоне от 1 до 50!")]
        [Appearance("EquipmentNullQty", AppearanceItemType = "ViewItem", Criteria = "Qty < 1",
            Context = "Any", BackColor = "Info", Priority = 1)]
        public decimal Qty
        {
            get => qty;
            set => SetPropertyValue(nameof(Qty), ref qty, value);
        }

        private Area venue;
        /// <summary>Ссылка на площадку</summary>
        [Association("КомплектацияПлощадки")]
        [ModelDefault("Caption", "Площадка")]
        [Browsable(false)] // не отображать на форме
        public Area Venue
        {
            get => venue;
            set => SetPropertyValue(nameof(Venue), ref venue, value);
        }

        /// <summary>Событие при изменении объекта</summary>
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "Qty":
                    // При изменении свойства Qty комплектации пересчитаем Qty площадки
                    Venue.RunDelayedIfNotOnForm(Venue.CalcQty);
                    break;
            }
        }

        /// <summary>Событие при удалении объекта</summary>
        protected override void OnDeleting()
        {
            Venue.RunDelayedIfNotOnForm(Venue.CalcQty);
            base.OnDeleting();

        }

    }
}
