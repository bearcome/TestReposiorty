using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CXCVCapitalIntrant.IBLL
{
    public interface IBaseBLL<T> where T:class
    {
        bool AddEntity(T obj);

        Task<bool> AddEntityAsync(T obj);

        int AddList(IEnumerable<T> list);

        Task<int> AddListAsync(IEnumerable<T> list);

        bool DeleteEntity(T obj);

        Task<bool> DeleteEntityAsync(T obj);

        int DeleteList(List<T> list);

        Task<int> DeleteListAsync(List<T> list);

        //void ExecuteBulkInsert(string destinationTableName, DataTable sourcedt);

        void ExecuteDeleteByIdWithSql(string destinationTableName, string columnName, int id);

        Task ExecuteDeleteByIdWithSqlAsync(string destinationTableName, string columnName, int id);

        List<T> GetAllListBySql(string sqlStr, params SqlParameter[] parameters);

        Task<List<T>> GetAllListBySqlAsync(string sqlStr, params SqlParameter[] parameters);

        void ExecuteSqlCommand(string sqlStr, params SqlParameter[] parameters);

        Task ExecuteSqlCommandAsync(string sqlStr, params SqlParameter[] parameters);

        int GetCount(Expression<Func<T, bool>> whereLamda);

        Task<int> GetCountAsync(Expression<Func<T, bool>> whereLamda);

        T GetEntity(Expression<Func<T, bool>> whereLamda);

        Task<T> GetEntityAsync(Expression<Func<T, bool>> whereLamda);

        List<T> GetList(Expression<Func<T, bool>> whereLamda);
        List<T> GetListBySql(string sql);

        List<T> GetList(Expression<Func<T, bool>> whereLamda, string orderBy, bool isASC);

        List<T> GetList(Expression<Func<T, bool>> whereLamda, string orderBy, bool isASC, int count);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> whereLamda);

        List<T> GetListByPage(Expression<Func<T, bool>> whereLamda, string orderby, bool isASC, int pageIndex, int pageSize, out int totalCount);

        DateTime GetSystemDateTime();

        bool UpdateEntity(T obj, params string[] notUpdatePropStrings);

        Task<bool> UpdateEntityAsync(T obj, params string[] notUpdatePropStrings);

        int UpdateList(List<T> list, params string[] notUpdatePropStrings);

        Task<int> UpdateListAsync(List<T> list, params string[] notUpdatePropStrings);
    }
}
