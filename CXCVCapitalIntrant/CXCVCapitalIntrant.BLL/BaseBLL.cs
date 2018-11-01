using CXCVCapitalIntrant.DAL;
using CXCVCapitalIntrant.IBLL;
using CXCVCapitalIntrant.IDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CXCVCapitalIntrant.BLL
{
    public class BaseBLL<T>:IBaseBLL<T> where T:class
    {

        protected IBaseDAL<T> _baseDAL { get; set; }

        protected BaseBLL() {
            _baseDAL = new BaseDAL<T>();
        }


        public virtual bool AddEntity(T obj)
        {
            return _baseDAL.AddEntity(obj);
        }

        public virtual async Task<bool> AddEntityAsync(T obj)
        {
            return await _baseDAL.AddEntityAsync(obj);
        }

        public virtual int AddList(IEnumerable<T> list)
        {
            return _baseDAL.AddList(list);
        }

        public virtual async Task<int> AddListAsync(IEnumerable<T> list)
        {
            return await _baseDAL.AddListAsync(list);
        }

        public virtual bool DeleteEntity(T obj)
        {
            return _baseDAL.DeleteEntity(obj);
        }

        public virtual async Task<bool> DeleteEntityAsync(T obj)
        {
            return await _baseDAL.DeleteEntityAsync(obj);
        }

        public int DeleteList(List<T> list)
        {
            return _baseDAL.DeleteList(list);
        }

        public async Task<int> DeleteListAsync(List<T> list)
        {
            return await _baseDAL.DeleteListAsync(list);
        }


        public void ExecuteDeleteByIdWithSql(string destinationTableName, string columnName, int id)
        {
            var sql = $"DELETE FROM  {destinationTableName} WHERE {columnName} = {id}";
            _baseDAL.ExecuteSqlCommand(sql);
        }

        public async Task ExecuteDeleteByIdWithSqlAsync(string destinationTableName, string columnName, int id)
        {
            var sql = $"DELETE FROM  {destinationTableName} WHERE {columnName} = {id}";
            await _baseDAL.ExecuteSqlCommandAsync(sql);
        }

        public List<T> GetAllListBySql(string sqlStr, params SqlParameter[] parameters)
        {
            return _baseDAL.ExecuteSQL(sqlStr, parameters);
        }

        public Task<List<T>> GetAllListBySqlAsync(string sqlStr, params SqlParameter[] parameters)
        {
            return _baseDAL.ExecuteSQLAsync(sqlStr, parameters);
        }

        public void ExecuteSqlCommand(string sqlStr, params SqlParameter[] parameters)
        {
            _baseDAL.ExecuteSqlCommand(sqlStr, parameters);
        }

        public async Task ExecuteSqlCommandAsync(string sqlStr, params SqlParameter[] parameters)
        {
            await _baseDAL.ExecuteSqlCommandAsync(sqlStr, parameters);
        }

        public virtual int GetCount(Expression<Func<T, bool>> whereLamda)
        {
            return _baseDAL.GetCount(whereLamda);
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> whereLamda)
        {
            return await _baseDAL.GetCountAsync(whereLamda);
        }

        public virtual T GetEntity(Expression<Func<T, bool>> whereLamda)
        {
            return _baseDAL.GetEntity(whereLamda);
        }

        public virtual async Task<T> GetEntityAsync(Expression<Func<T, bool>> whereLamda)
        {
            return await _baseDAL.GetEntityAsync(whereLamda);
        }

        /// <summary>
        /// 根据条件查询 返回集合
        /// </summary>
        /// <param name="whereLamda">查询条件 没有条件则为null</param>
        /// <returns></returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> whereLamda)
        {
            return _baseDAL.GetList(whereLamda);
        }
        public virtual List<T> GetListBySql(string sql)
        {
            return _baseDAL.ExecuteSQL(sql);
        }


        public virtual List<T> GetList(Expression<Func<T, bool>> whereLamda, int count)
        {
            return _baseDAL.GetList(whereLamda, count);
        }

        /// <summary>
        /// 根据条件查询 返回集合
        /// </summary>
        /// <param name="whereLamda">查询条件 没有条件则为null</param>
        /// <param name="orderBy">orderBy字段，注意大小写敏感</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> whereLamda, string orderBy, bool isAsc)
        {
            return _baseDAL.GetList(whereLamda, orderBy, isAsc);
        }

        /// <summary>
        /// 根据条件查询 返回集合
        /// </summary>
        /// <param name="whereLamda">查询条件 没有条件则为null</param>
        /// <param name="orderBy">orderBy字段，注意大小写敏感</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="count">取前count条</param>
        /// <returns></returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> whereLamda, string orderBy, bool isAsc, int count)
        {
            return _baseDAL.GetList(whereLamda, orderBy, isAsc, count);
        }

        /// <summary>
        /// 根据条件查询 返回集合
        /// </summary>
        /// <param name="whereLamda">查询条件 没有条件则为null</param>
        /// <returns></returns>
        public async virtual Task<List<T>> GetListAsync(Expression<Func<T, bool>> whereLamda)
        {
            return await _baseDAL.GetListAsync(whereLamda);
        }

        /// <summary>
        /// 根据条件查询 返回集合(分页)
        /// </summary>
        /// <param name="whereLamda">查询条件 查询所有，则为null</param>
        /// <param name="orderbyLamda">排序字段，如:UserID 注意大小写敏感</param>
        /// <param name="isAsc">是否是升序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public virtual List<T> GetListByPage(Expression<Func<T, bool>> whereLamda, string orderby, bool isAsc, int pageIndex, int pageSize, out int totalCount)
        {
            return _baseDAL.GetListByPage(whereLamda, orderby, isAsc, pageIndex, pageSize, out totalCount);
        }

        public DateTime GetSystemDateTime()
        {
            return DateTime.Now;
        }

        public virtual bool UpdateEntity(T obj, params string[] notUpdatePropStrings)
        {
            return _baseDAL.UpdateEntity(obj, notUpdatePropStrings);
        }


        public virtual async Task<bool> UpdateEntityAsync(T obj, params string[] notUpdatePropStrings)
        {
            return await _baseDAL.UpdateEntityAsync(obj, notUpdatePropStrings);
        }

        public virtual int UpdateList(List<T> list, params string[] notUpdatePropStrings)
        {
            return _baseDAL.UpdateList(list, notUpdatePropStrings);
        }


        public virtual async Task<int> UpdateListAsync(List<T> list, params string[] notUpdatePropStrings)
        {
            return await _baseDAL.UpdateListAsync(list, notUpdatePropStrings);
        }
    }
}
