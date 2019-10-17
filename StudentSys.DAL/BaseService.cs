using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    //继承自动销毁
    public class BaseService<T> : IDisposable where T : BaseEntity, new()
    {
        protected readonly StudentContext _db;
        public BaseService(StudentContext db) => _db = db;

        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose() => _db.Dispose();

        /// <summary>
        /// 创建信息，false不继续创建，true继续创建
        /// </summary>
        /// <param name="t"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task CreateAsync(T t, bool saved = true)
        {
            _db.Set<T>().Add(t);

            if (saved)
                await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 是否继续保存,false不继续，true继续
        /// </summary>
        /// <param name="isValid"></param>
        /// <returns></returns>
        public async Task SaveAsync(bool isValid = true)
        {
            if (!isValid)
            {
                _db.Configuration.ValidateOnSaveEnabled = false;
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="t"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task EditAsvnc(T t, bool saved = true)
        {
            _db.Entry(t).State = EntityState.Modified;
            {
                await SaveAsync(isValid: false);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task Remove(Guid id, bool saved = true)
        {
            T t = new T()
            {
                Id = id
            };
            _db.Entry(t).State = EntityState.Unchanged;
            t.IsRemoved = true;
            if (saved)
            {
                await SaveAsync(isValid: false);
            }
        }

        //                                                                   不删除的显示出来
        /// <summary>
        /// 获得全部信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll() => _db.Set<T>().AsNoTracking().Where(m => !m.IsRemoved);

        /// <summary>
        /// 按顺序获取
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate) => GetAll().Where(predicate);

        /// <summary>
        /// 按倒序获取
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate,bool asc)
        {
            var data = GetAll(predicate);
            if (asc)
            {
                return data.OrderBy(m => m.CreateTime);
            }
            return data.OrderByDescending(m => m.CreateTime);
        }

        /// <summary>
        /// 分页获取信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="asc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool asc, int pageIndex, int pageSize = 10)
            => GetAll(predicate, asc).Skip(pageSize * pageIndex).Take(pageSize);

        /// <summary>
        /// 获取单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetOne(Guid id) => await GetAll().FirstAsync(predicate: m => m.Id == id);

    }
}
