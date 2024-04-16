using PromAktiv.Core.Module.MultipleChoice;
using PromAktiv.Module.Parameters;
using System.ComponentModel;
using Xafari.FW.ExpressApp.DC;
using Xafari.FW.ExpressApp.Model;
using Xafari.FW.Persistent.Base;
using Xafari.FW.Xpo;
using Xafari;
using PromAktiv.Core.Module;
using System.Collections;
using Xafari.FW.Data.Filtering;
using Xafari.FW.ExpressApp;
using Xafari.SmartDesign;

namespace Project.Module.BusinessObjects
{
    /// <summary>Множнственный фильтр для Площадок</summary>
    [NonPersistent]
    [DomainComponent]
    [XafDisplayName("Множественный фильтр")]
    [ImageName("Action_Filter")]
    [NotAudited]
    [CreateDetailView(Layout = "IsEmployee;Employees;IsArea;Areas;")]
    public class AreaFilterExt : DocumentFilterExt
    {
        /// <summary>Конструктор</summary>
        public AreaFilterExt(Session session) : base(session) =>
            UseDefaultValueSet.Add(nameof(IsArea));

        #region Вышестоящая площадка
        private bool isArea;
        /// <summary>Чекбокс</summary>
        [ImmediatePostData]
        [ModelDefault("Caption", "Вышестоящая площадка")]
        public bool IsArea
        {
            get => isArea;
            set => SetPropertyValue1(nameof(IsArea), ref isArea, value);
        }

        /// <summary>Коллекция выбранных объектов</summary>
        [NonPersistent]
        [StorageCollection("Areas")]
        [ModelDefault("ShowCaption", "False")]
        public BindingList<Area> Areas => GetStoredCollection<Area>(nameof(Areas));
        #endregion

        /// <summary>Метод очистки параметров</summary>
        public override void Clear()
        {
            base.Clear();
            var target = this;
            ClearAndDeletePick(target.Areas, nameof(Areas));
            target.IsArea = false;
            Session.CommitTransaction();
        }
        /// <summary>Очистка выбранных записей</summary>
        protected override void ClearAndDeletePick(IList propertyList, string propertyName)
        {
            DeleteFromPick(propertyName);
            propertyList.Clear();
        }
        private void DeleteFromPick(string propertyName)
        {
            string str = string.Format("{0}-{1}-{2}", SecuritySystem.CurrentUserId, ViewId, propertyName);
            using UnitOfWork unitOfWork = XpoSessionDefault.CreateUnitOfWork();
            PickKey pickKey = unitOfWork.FindObject<PickKey>(CriteriaOperator.Parse("Context=?", str));
            if (pickKey != null && pickKey.Picks.Count > 0)
                unitOfWork.Delete(pickKey.Picks);
            unitOfWork.CommitChanges();
        }
    }
}
