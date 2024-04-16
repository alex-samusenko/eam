using PromAktiv.Core.CD.Module.RES.Resource;
using PromAktiv.Core.Module;
using System;
using System.ComponentModel;
using Xafari.BC;
using Xafari.FW.Drawing;
using Xafari.FW.ExpressApp.ConditionalAppearance;
using Xafari.FW.ExpressApp.DC;
using Xafari.FW.ExpressApp.Model;
using Xafari.FW.Persistent.Base;
using Xafari.FW.Persistent.Validation;
using Xafari.FW.Xpo;
using Xafari.SmartDesign;

namespace Project.Module.BusinessObjects
{
    /// <summary>Площадки</summary>
    [DefaultClassOptions]
    [XafDisplayName("Площадка")]
    [ImageName("BO_Address")]
    [BOCategory("Responsible", typeof(Сотрудник), "Employee.Oid = '{0:Oid}'", Caption = "Ответственный")]
    [CreateDetailView(Layout = "Код;CurrentStatus;Наименование;AreaEquipments;" + "Дополнительно[TypeArea,Employee,Comment];")]
    [CreateListView(Layout = "Код;Наименование;Employee;Qty;CreateDate", IsDefaultGridListView = true)]
    //Id = "Area_DetailView_Additional",
    [RuleCombinationOfPropertiesIsUnique("UniquePropertiesArea", DefaultContexts.Save, "Наименование,TypeArea",
        messageTemplate: "Комбинация Наименование и Тип площадки должна быть уникальна!")]
    /*[RuleIsReferenced("", DefaultContexts.Delete, typeof(Area), "Parent", InvertResult = true,
        CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction,
        MessageTemplateMustBeReferenced = "Площадка {TargetObject} не должна иметь подчиненных.")]*/
    [Appearance("AreaArchive", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "[СтатусОбъекта] = 'Archive'",
        Context = "ListView", BackColor = "White", FontColor = "GrayText", FontStyle = DXFontStyle.Italic)]
    [Appearance("CalcEnabled", AppearanceItemType = "Action", TargetItems = "Area.CalcQty",
        Criteria = "[СтатусОбъекта] = 'Archive'", Context = "Any", Enabled = false)]
    //[Persistent("Platform")]
    public class Area : Справочник
    {
        /// <summary>Обязательный конструктор</summary>
        public Area(Session session)
            : base(session)
        { }

        private TypeArea typeArea;
        /// <summary>Тип площадки</summary>
        [ModelDefault("Caption", "Тип площадки")]
        [VisibleInDetailView(true)]
        public TypeArea TypeArea
        {
            get => typeArea;
            set => SetPropertyValue(nameof(TypeArea), ref typeArea, value);
        }

        private Сотрудник employee;
        /// <summary>Ответственный</summary>
        [ModelDefault("Caption", "Ответственный")]
        [VisibleInAllView(true)]
        [RuleRequiredField("RuleRequiredEmployee", DefaultContexts.Save,
            "Поле Ответственный должно быть заполнено!")]
        public Сотрудник Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        /// <summary>Коллекция оборудования на площадке</summary>
        [Association("КомплектацияПлощадки")]
        [Xafari.FW.Xpo.Aggregated]
        [XafDisplayName("Комплектация")]
        [VisibleInDetailView(true)]
        [CreateListView(Layout = "Item;Qty")] //, ListViewType = ListViewType.LookupListView
        public XPCollection<Equipment> AreaEquipments
        {
            get => GetCollection<Equipment>(nameof(AreaEquipments));
        }

        /// <summary>Общее количество номенклатуры по площадке</summary>
        [ModelDefault("Caption", "Количество")]
        [ModelDefault("DisplayFormat", "0")]
        [ModelDefault("EditMask", "f")]
        [ModelDefault("Caption", "Количество всего")]
        public decimal Qty
        {
            get => GetPropertyValue<decimal>(nameof(Qty));
            set => SetPropertyValue<decimal>(nameof(Qty), value);
        }

        /// <summary>Пересчет общего количества номенклатуры по площадке</summary>
        [Action(Caption = "Пересчет", ConfirmationMessage = "Пересчитать количество?",
            ImageName = "CalculateParameters", AutoCommit = true)]
        public void CalcQty()
        {
            decimal qty = 0m;
            foreach (var equipment in AreaEquipments)
                qty += equipment.Qty;
            this.Qty = qty;
            //ObjectSpace.CommitChanges();
        }

        private DateTime createDate;
        /// <summary>Дата оформления площадки</summary>
        [XafDisplayName("Дата"), ToolTip("Дата оформления площадки")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask", "D")]
        [VisibleInListView(true)]
        public DateTime CreateDate
        {
            get => createDate;
            set => SetPropertyValue(nameof(CreateDate), ref createDate, value);
        }

        /// <summary>Вычисляемое полее для правила ограничения позиций оборудования площадки</summary>
        [Browsable(false)]
        [RuleFromBoolProperty("ItemQtyExceeded", DefaultContexts.Save,
            CustomMessageTemplate = "Количество позиций комплектации не должно превышать 5")]
        public bool ItemQtyExceeded
        {
            get => AreaEquipments.Count <= 5;
        }

        private string comment;
        /// <summary>Комментарий</summary>
        [XafDisplayName("Комментарий")]
        [RuleRegularExpression("RuleRegExpComment", DefaultContexts.Save, @"\b(\w+?)\s+\1\b",
            InvertResult = true, ResultType = ValidationResultType.Information, CustomMessageTemplate = "В комментарии найдены повторяющиеся слова!")]
        public string Comment
        {
            get => comment;
            set => SetPropertyValue(nameof(Comment), ref comment, value);
        }
    }

    /// <summary>Перечисление типов площадок</summary>
    public enum TypeArea
    {
        [XafDisplayName("Основная")]
        Main = 1,
        [XafDisplayName("Дополнительная")]
        Additional = 0
    }
}
