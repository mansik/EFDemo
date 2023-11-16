using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace EFDemo
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        NorthwindEntities db;
        private void FormMain_Load(object sender, EventArgs e)
        {
            db = new NorthwindEntities();
            db.Customers.Load();
            customerBindingSource.DataSource = db.Customers.Local;
        }

        private void addButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            customerBindingSource.AddNew();
        }

        private void deleteButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                customerBindingSource.RemoveCurrent();
        }

        private void updateButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            db.SaveChanges();
            XtraMessageBox.Show("Your date has been sucessfully saved!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 취소시 작업
        /// https://learn.microsoft.com/ko-kr/ef/core/change-tracking/
        /// 
        /// 모든 엔터티는 특정 EntityState와 연결됩니다. 
        /// Detached 엔터티는 DbContext에서 추적되고 있지 않습니다.
        /// Added 엔터티는 새 엔터티이며, 아직 데이터베이스에 삽입되지 않았습니다. 이는 SaveChanges가 호출될 때 삽입됨을 의미합니다.
        /// Unchanged 엔터티는 데이터베이스에서 쿼리된 이후 변경되지 않았습니다.쿼리에서 반환된 모든 엔터티는 처음에 이 상태입니다.
        /// Modified 엔터티는 데이터베이스에서 쿼리된 이후 변경되었습니다. 따라서 SaveChanges가 호출될 때 업데이트됩니다.
        /// Deleted 엔터티는 데이터베이스에 존재하지만 SaveChanges가 호출될 때 삭제하도록 표시됩니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var changed = db.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
            foreach (var obj in changed)
            {
                switch (obj.State)
                {
                    case EntityState.Modified: // 수정된 경우 원본으로 바꾸고, 데이터베이스에서 쿼리된 이후 변경되지 않은 상태로 변경
                        obj.CurrentValues.SetValues(obj.OriginalValues);
                        obj.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added: // 추가된 경우 DBContext에서 추적하지 않는 상태로 변경
                        obj.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted: // 삭제된 것인 경우 데이터베이스에서 쿼리된 이후 변경되지 않은 상태로 변경
                        obj.State = EntityState.Unchanged;
                        break;
                }
            }
            customerBindingSource.ResetBindings(false); //BindingSource에 바인딩된 컨트롤에서 목록의 모든 항목을 다시 읽고 표시된 값을 새로 고치도록 합니다.
            // false : 값만 변경
        }
    }
}
