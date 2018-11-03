using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CXCVCapitalIntrant.IDAL;
using CXCVCapitalIntrant.Model;
using CXCVCapitalIntrant.Common.Extensions;
using MySql.Data.MySqlClient;

namespace CXCVCapitalIntrant.DAL
{
    public class BaseDAL<T> : IBaseDAL<T> where T : class
    {
        private readonly cvcxcapital_sysdataEntities _dbContext;
        public BaseDAL()
        {
            _dbContext = DBContextFactory.CreateContext();
        }

        public bool AddEntity(T obj)
        {
            InternalAdd(obj);
            var result = _dbContext.SaveChanges() > 0;
            DetachedEntityState(obj);
            return result;
        }

        public async Task<bool> AddEntityAsync(T obj)
        {
            InternalAdd(obj);
            var result = await _dbContext.SaveChangesAsync() > 0;
            DetachedEntityState(obj);
            return result;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int AddList(IEnumerable<T> list)
        {
            if (list == null) return 0;
            OpenOptimize();
            InternalAddList(list);
            var result = _dbContext.SaveChanges();
            CloseOptimize();
            DetachedEntityStateList(list.ToList());
            return result;
        }

        public async Task<int> AddListAsync(IEnumerable<T> list)
        {
            if (list == null) return 0;
            OpenOptimize();
            InternalAddList(list);
            var result = await _dbContext.SaveChangesAsync();
            CloseOptimize();
            DetachedEntityStateList(list.ToList());
            return result;
        }

        public bool DeleteEntity(T obj)
        {
            InternalDelete(obj);
            var result = _dbContext.SaveChanges() > 0;
            DetachedEntityState(obj);
            return result;
        }

        public async Task<bool> DeleteEntityAsync(T obj)
        {
            InternalDelete(obj);
            var result = await _dbContext.SaveChangesAsync() > 0;
            DetachedEntityState(obj);
            return result;
        }

        public int DeleteList(List<T> list)
        {
            if (list == null || list.Count == 0) return 0;
            OpenOptimize();
            InternalDeleteList(list);
            var result = _dbContext.SaveChanges();
            CloseOptimize();
            DetachedEntityStateList(list);
            return result;
        }

        public async Task<int> DeleteListAsync(List<T> list)
        {
            if (list == null || list.Count == 0) return 0;
            OpenOptimize();
            InternalDeleteList(list);
            var result = await _dbContext.SaveChangesAsync();
            CloseOptimize();
            DetachedEntityStateList(list);
            return result;
        }

        /// <summary>
        /// 优化EF 批量操作  
        /// 操作完成后要 恢复该设置
        /// </summary>
        private void OpenOptimize()
        {
            _dbContext.Configuration.AutoDetectChangesEnabled = false;
            _dbContext.Configuration.LazyLoadingEnabled = false;
            _dbContext.Configuration.ValidateOnSaveEnabled = false;
        }
        /// <summary>
        /// 恢复优化EF 到默认配置  
        /// </summary>
        private void CloseOptimize()
        {
            _dbContext.Configuration.AutoDetectChangesEnabled = false;
            _dbContext.Configuration.LazyLoadingEnabled = false;
            _dbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        public List<T> ExecuteSQL(string sql, params MySqlParameter[] parms)
        {
            return parms != null ? _dbContext.Database.SqlQuery<T>(sql, parms).ToList() : _dbContext.Database.SqlQuery<T>(sql).ToList();
        }

        public async Task<List<T>> ExecuteSQLAsync(string sql, params MySqlParameter[] parms)
        {
            return await (parms != null ? _dbContext.Database.SqlQuery<T>(sql, parms) : _dbContext.Database.SqlQuery<T>(sql)).ToListAsync();
        }

        /// <summary>
        /// 直接执行Sql 返回受影响的行数。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql, params MySqlParameter[] parms)
        {
            return _dbContext.Database.ExecuteSqlCommand(sql, parms);
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params MySqlParameter[] parms)
        {
            return await (parms != null ? _dbContext.Database.ExecuteSqlCommandAsync(sql, parms) : _dbContext.Database.ExecuteSqlCommandAsync(sql));
        }

        public int GetCount(Expression<Func<T, bool>> whereLamda)
        {
            return whereLamda != null ? _dbContext.Set<T>().Count(whereLamda) : _dbContext.Set<T>().Count();
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> whereLamda)
        {
            return await (whereLamda != null ? _dbContext.Set<T>().CountAsync(whereLamda) : _dbContext.Set<T>().CountAsync());
        }

        public T GetEntity(Expression<Func<T, bool>> whereLamda)
        {
            return _dbContext.Set<T>().AsNoTracking().FirstOrDefault(whereLamda);
        }

        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> whereLamda)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(whereLamda);
        }

        /// <summary>
        /// 根据条件查询 返回集合
        /// </summary>
        /// <param name="whereLamda">查询条件 没有条件则为null</param>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> whereLamda)
        {
            return GetIQueryable(whereLamda).ToList();
        }

        /// <summary>
        /// 根据条件返回集合的前多少条
        /// </summary>
        /// <param name="whereLamda"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> whereLamda, int count)
        {
            return GetIQueryable(whereLamda).Take(count).ToList();
        }

        /// <summary>
        /// 根据条件查询 返回集合
        /// </summary>
        /// <param name="whereLamda">查询条件 没有条件则为null</param>
        /// <param name="orderBy">orderBy字段，注意大小写敏感</param>
        /// <param name="isASC">是否升序</param>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> whereLamda, string orderBy, bool isASC)
        {
            IQueryable<T> query = GetListWithOrder(whereLamda, orderBy, isASC);
            return query.ToList();
        }



        /// <summary>
        /// 根据条件查询 返回集合(取前count条)
        /// </summary>
        /// <param name="whereLamda">查询条件 没有条件则为null</param>
        /// <param name="orderBy">orderBy字段，注意大小写敏感</param>
        /// <param name="isASC">是否升序</param>
        /// <param name="count">取前count条</param>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> whereLamda, string orderBy, bool isASC, int count)
        {
            var query = GetListWithOrder(whereLamda, orderBy, isASC);
            return query.Take(count).ToList();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> whereLamda)
        {
            return await GetIQueryable(whereLamda).ToListAsync();
        }

        public List<T> GetListByPage(Expression<Func<T, bool>> whereLamda, string orderBy, bool isASC, int pageIndex, int pageSize, out int totalCount)
        {
            var begin = (pageIndex - 1) * pageSize;
            IQueryable<T> query;
            if (whereLamda == null)
            {
                totalCount = _dbContext.Set<T>().Count();
                query = (_dbContext.Set<T>()).Where(item => true);
            }
            else
            {
                totalCount = _dbContext.Set<T>().Count(whereLamda);
                query = (_dbContext.Set<T>()).Where(whereLamda);
            }

            query = query.OrderBy(orderBy, isASC ? ListSortDirection.Ascending : ListSortDirection.Descending);
            return query.AsNoTracking().Skip(begin).Take(pageSize).ToList();
        }

        public bool UpdateEntity(T obj, params string[] notUpdatePropStrings)
        {
            InternalUpdate(obj, notUpdatePropStrings);
            bool result = _dbContext.SaveChanges() > 0;
            DetachedEntityState(obj);
            return result;
        }

        public async Task<bool> UpdateEntityAsync(T obj, params string[] notUpdatePropStrings)
        {
            InternalUpdate(obj, notUpdatePropStrings);
            var result = await _dbContext.SaveChangesAsync() > 0;
            DetachedEntityState(obj);
            return result;
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int UpdateList(List<T> list, params string[] notUpdatePropStrings)
        {
            if (list == null || list.Count == 0) return 0;
            OpenOptimize();
            InternalUpdateList(list, notUpdatePropStrings);
            var result = _dbContext.SaveChanges();
            CloseOptimize();
            DetachedEntityStateList(list);
            return result;
        }

        public async Task<int> UpdateListAsync(List<T> list, params string[] notUpdatePropStrings)
        {
            if (list == null || list.Count == 0) return 0;
            OpenOptimize();
            InternalUpdateList(list, notUpdatePropStrings);
            var result = await _dbContext.SaveChangesAsync();
            CloseOptimize();
            DetachedEntityStateList(list);
            return result;
        }

        /// <summary>
        /// 根据条件查询 返回IQueryable ,不执行查询，只有在ToLis、Select、遍历时等操作才会执行实际的查询
        /// 比如当只获取指定字段时或者获取Count时
        /// </summary>
        /// <param name="whereLamda">查询条件 没有条件则为null</param>
        /// <returns></returns>
        private IQueryable<T> GetIQueryable(Expression<Func<T, bool>> whereLamda)
        {
            if (whereLamda == null)
            {
                return _dbContext.Set<T>().AsNoTracking();
            }
            return _dbContext.Set<T>().AsNoTracking().Where(whereLamda);
        }

        private IQueryable<T> GetListWithOrder(Expression<Func<T, bool>> whereLamda, string orderBy, bool isAsc)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (whereLamda != null)
            {
                query = _dbContext.Set<T>().Where(whereLamda);
            }

            query = query.AsNoTracking().OrderBy(orderBy, isAsc ? ListSortDirection.Ascending : ListSortDirection.Descending);
            return query;
        }

        private void InternalAdd(T obj)
        {
            _dbContext.Set<T>().Add(obj);
        }

        private void InternalAddList(IEnumerable<T> list)
        {
            foreach (var obj in list)
            {
                InternalAdd(obj);
            }
        }

        private void InternalDelete(T obj)
        {
            var dbSet = _dbContext.Set<T>();
            dbSet.Attach(obj);
            dbSet.Remove(obj);
        }

        private void InternalDeleteList(List<T> list)
        {
            var dbSet = _dbContext.Set<T>();
            foreach (var obj in list)
            {
                dbSet.Attach(obj);
                dbSet.Remove(obj);
            }
        }

        private void InternalUpdate(T obj, string[] notUpdatePropStrings)
        {
            var entry = _dbContext.Entry(obj);
            entry.State = EntityState.Modified;
            if (notUpdatePropStrings == null) return;
            foreach (var propStr in notUpdatePropStrings)
            {
                entry.Property(propStr).IsModified = false;
            }
        }

        private void InternalUpdateList(List<T> list, string[] notUpdatePropStrings)
        {
            foreach (var obj in list)
            {
                InternalUpdate(obj, notUpdatePropStrings);
            }
        }
        private void DetachedEntityState(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Detached;
        }
        private void DetachedEntityStateList(List<T> list)
        {
            foreach (var obj in list)
            {
                DetachedEntityState(obj);
            }
        }

    }
}
