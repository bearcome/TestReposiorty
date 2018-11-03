using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CXCVCapitalIntrant.IDAL
{
    public interface IBaseDAL<T>
    {
        bool AddEntity(T obj);
        Task<bool> AddEntityAsync(T obj);
        int AddList(IEnumerable<T> list);
        Task<int> AddListAsync(IEnumerable<T> list);
        bool DeleteEntity(T obj);
        Task<bool> DeleteEntityAsync(T obj);
        int DeleteList(List<T> list);
        Task<int> DeleteListAsync(List<T> list);
        List<T> ExecuteSQL(string sql, params MySqlParameter[] parms);
        Task<List<T>> ExecuteSQLAsync(string sql, params MySqlParameter[] parms);
        int ExecuteSqlCommand(string sql, params MySqlParameter[] parms);
        Task<int> ExecuteSqlCommandAsync(string sql, params MySqlParameter[] parms);
        int GetCount(Expression<Func<T, bool>> whereLamda);
        List<T> GetList(Expression<Func<T, bool>> whereLamda, int count);
        Task<int> GetCountAsync(Expression<Func<T, bool>> whereLamda);
        T GetEntity(Expression<Func<T, bool>> whereLamda);
        Task<T> GetEntityAsync(Expression<Func<T, bool>> whereLamda);
        List<T> GetList(Expression<Func<T, bool>> whereLamda);
        List<T> GetList(Expression<Func<T, bool>> whereLamda, string orderBy, bool isASC);
        List<T> GetList(Expression<Func<T, bool>> whereLamda, string orderBy, bool isASC, int count);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> whereLamda);
        List<T> GetListByPage(Expression<Func<T, bool>> whereLamda, string orderBy, bool isASC, int pageIndex, int pageSize, out int totalCount);
        bool UpdateEntity(T obj, params string[] notUpdatePropStrings);
        Task<bool> UpdateEntityAsync(T obj, params string[] notUpdatePropStrings);
        int UpdateList(List<T> list, params string[] notUpdatePropStrings);
        Task<int> UpdateListAsync(List<T> list, params string[] notUpdatePropStrings);
    }
}
