/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2024-05-30 15: 38:33
 ******************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data;
using MySql.Data.MySqlClient;
using System.Text;
using TinyFx.Data.MySql;

namespace Lobby.Flow.DAL
{
	#region EO
	/// <summary>
	/// 运营商的提现审批策略表
	/// 【表 sc_cash_audit_templ 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sc_cash_audit_templEO : IRowMapper<Sc_cash_audit_templEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sc_cash_audit_templEO()
		{
			this.Status = false;
			this.RecDate = DateTime.Now;
			this.ModifiedDate = DateTime.Now;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalOperatorID;
		/// <summary>
		/// 【数据库中的原始主键 OperatorID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalOperatorID
		{
			get { return _originalOperatorID; }
			set { HasOriginal = true; _originalOperatorID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "OperatorID", OperatorID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 运营商编码
		/// 【主键 varchar(50)】
		/// </summary>
		[DataMember(Order = 1)]
		public string OperatorID { get; set; }
		/// <summary>
		/// 状态0-无效1-有效
		/// 【字段 tinyint(1)】
		/// </summary>
		[DataMember(Order = 2)]
		public bool Status { get; set; }
		/// <summary>
		/// 记录时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 3)]
		public DateTime RecDate { get; set; }
		/// <summary>
		/// 更新时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 4)]
		public DateTime ModifiedDate { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sc_cash_audit_templEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sc_cash_audit_templEO MapDataReader(IDataReader reader)
		{
		    Sc_cash_audit_templEO ret = new Sc_cash_audit_templEO();
			ret.OperatorID = reader.ToString("OperatorID");
			ret.OriginalOperatorID = ret.OperatorID;
			ret.Status = reader.ToBoolean("Status");
			ret.RecDate = reader.ToDateTime("RecDate");
			ret.ModifiedDate = reader.ToDateTime("ModifiedDate");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 运营商的提现审批策略表
	/// 【表 sc_cash_audit_templ 的操作类】
	/// </summary>
	[Obsolete]
	public class Sc_cash_audit_templMO : MySqlTableMO<Sc_cash_audit_templEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sc_cash_audit_templ`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sc_cash_audit_templMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sc_cash_audit_templMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sc_cash_audit_templMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sc_cash_audit_templEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sc_cash_audit_templEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sc_cash_audit_templEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`OperatorID`, `Status`, `RecDate`, `ModifiedDate`) VALUE (@OperatorID, @Status, @RecDate, @ModifiedDate);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@ModifiedDate", item.ModifiedDate, MySqlDbType.DateTime),
			};
		}
		public int AddByBatch(IEnumerable<Sc_cash_audit_templEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sc_cash_audit_templEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sc_cash_audit_templEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`OperatorID`, `Status`, `RecDate`, `ModifiedDate`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.OperatorID}',{item.Status},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}','{item.ModifiedDate.ToString("yyyy-MM-dd HH:mm:ss")}'),");
				if (count == batchCount)
				{
					count = 0;
					sql.Insert(0, insertSql);
					var ret = sql.ToString().TrimEnd(',');
					sql.Clear();
	                yield return ret;
				}
			}
			if (sql.Length > 0)
			{
	            sql.Insert(0, insertSql);
	            yield return sql.ToString().TrimEnd(',');
	        }
	    }
	    #endregion // Add
	    
		#region Remove
		#region RemoveByPK
		/// <summary>
		/// 按主键删除
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string operatorID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(operatorID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string operatorID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(operatorID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string operatorID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OperatorID` = @OperatorID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sc_cash_audit_templEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.OperatorID, tm_);
		}
		public async Task<int> RemoveAsync(Sc_cash_audit_templEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.OperatorID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">状态0-无效1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByStatus(bool status, TransactionManager tm_ = null)
		{
			RepairRemoveByStatusData(status, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByStatusAsync(bool status, TransactionManager tm_ = null)
		{
			RepairRemoveByStatusData(status, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByStatusData(bool status, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Status` = @Status";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
		}
		#endregion // RemoveByStatus
		#region RemoveByRecDate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRecDate(DateTime recDate, TransactionManager tm_ = null)
		{
			RepairRemoveByRecDateData(recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRecDateAsync(DateTime recDate, TransactionManager tm_ = null)
		{
			RepairRemoveByRecDateData(recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRecDateData(DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `RecDate` = @RecDate";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
		}
		#endregion // RemoveByRecDate
		#region RemoveByModifiedDate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "modifiedDate">更新时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByModifiedDate(DateTime modifiedDate, TransactionManager tm_ = null)
		{
			RepairRemoveByModifiedDateData(modifiedDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByModifiedDateAsync(DateTime modifiedDate, TransactionManager tm_ = null)
		{
			RepairRemoveByModifiedDateData(modifiedDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByModifiedDateData(DateTime modifiedDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `ModifiedDate` = @ModifiedDate";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ModifiedDate", modifiedDate, MySqlDbType.DateTime));
		}
		#endregion // RemoveByModifiedDate
		#endregion // RemoveByXXX
	    
		#region RemoveByFKOrUnique
		#endregion // RemoveByFKOrUnique
		#endregion //Remove
	    
		#region Put
		#region PutItem
		/// <summary>
		/// 更新实体到数据库
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(Sc_cash_audit_templEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sc_cash_audit_templEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sc_cash_audit_templEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID, `Status` = @Status WHERE `OperatorID` = @OperatorID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Byte),
				Database.CreateInParameter("@OperatorID_Original", item.HasOriginal ? item.OriginalOperatorID : item.OperatorID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sc_cash_audit_templEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sc_cash_audit_templEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += await PutAsync(item, tm_);
			}
			return ret;
		}
		#endregion // PutItem
		
		#region PutByPK
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operatorID, string set_, params object[] values_)
		{
			return Put(set_, "`OperatorID` = @OperatorID", ConcatValues(values_, operatorID));
		}
		public async Task<int> PutByPKAsync(string operatorID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`OperatorID` = @OperatorID", ConcatValues(values_, operatorID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operatorID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`OperatorID` = @OperatorID", tm_, ConcatValues(values_, operatorID));
		}
		public async Task<int> PutByPKAsync(string operatorID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`OperatorID` = @OperatorID", tm_, ConcatValues(values_, operatorID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operatorID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`OperatorID` = @OperatorID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string operatorID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`OperatorID` = @OperatorID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "status">状态0-无效1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(string operatorID, bool status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(operatorID, status, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutStatusByPKAsync(string operatorID, bool status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(operatorID, status, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutStatusByPKData(string operatorID, bool status, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Status` = @Status  WHERE `OperatorID` = @OperatorID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Byte),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "status">状态0-无效1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatus(bool status, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutStatusAsync(bool status, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Byte);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutStatus
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(string operatorID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(operatorID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRecDateByPKAsync(string operatorID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(operatorID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRecDateByPKData(string operatorID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `OperatorID` = @OperatorID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDate(DateTime recDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate";
			var parameter_ = Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRecDateAsync(DateTime recDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate";
			var parameter_ = Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRecDate
		#region PutModifiedDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "modifiedDate">更新时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutModifiedDateByPK(string operatorID, DateTime modifiedDate, TransactionManager tm_ = null)
		{
			RepairPutModifiedDateByPKData(operatorID, modifiedDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutModifiedDateByPKAsync(string operatorID, DateTime modifiedDate, TransactionManager tm_ = null)
		{
			RepairPutModifiedDateByPKData(operatorID, modifiedDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutModifiedDateByPKData(string operatorID, DateTime modifiedDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `ModifiedDate` = @ModifiedDate  WHERE `OperatorID` = @OperatorID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ModifiedDate", modifiedDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "modifiedDate">更新时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutModifiedDate(DateTime modifiedDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ModifiedDate` = @ModifiedDate";
			var parameter_ = Database.CreateInParameter("@ModifiedDate", modifiedDate, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutModifiedDateAsync(DateTime modifiedDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ModifiedDate` = @ModifiedDate";
			var parameter_ = Database.CreateInParameter("@ModifiedDate", modifiedDate, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutModifiedDate
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sc_cash_audit_templEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.OperatorID) == null)
			{
				Add(item, tm);
			}
			else
			{
				Put(item, tm);
				ret = false;
			}
			return ret;
		}
		public async Task<bool> SetAsync(Sc_cash_audit_templEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.OperatorID) == null)
			{
				await AddAsync(item, tm);
			}
			else
			{
				await PutAsync(item, tm);
				ret = false;
			}
			return ret;
		}
		
		#endregion // Set
		
		#region Get
		#region GetByPK
		/// <summary>
		/// 按 PK（主键） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sc_cash_audit_templEO GetByPK(string operatorID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(operatorID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sc_cash_audit_templEO.MapDataReader);
		}
		public async Task<Sc_cash_audit_templEO> GetByPKAsync(string operatorID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(operatorID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sc_cash_audit_templEO.MapDataReader);
		}
		private void RepairGetByPKData(string operatorID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 Status（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public bool GetStatusByPK(string operatorID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
			};
			return (bool)GetScalar("`Status`", "`OperatorID` = @OperatorID", paras_, tm_);
		}
		public async Task<bool> GetStatusByPKAsync(string operatorID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
			};
			return (bool)await GetScalarAsync("`Status`", "`OperatorID` = @OperatorID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRecDateByPK(string operatorID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`RecDate`", "`OperatorID` = @OperatorID", paras_, tm_);
		}
		public async Task<DateTime> GetRecDateByPKAsync(string operatorID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`RecDate`", "`OperatorID` = @OperatorID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 ModifiedDate（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetModifiedDateByPK(string operatorID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`ModifiedDate`", "`OperatorID` = @OperatorID", paras_, tm_);
		}
		public async Task<DateTime> GetModifiedDateByPKAsync(string operatorID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`ModifiedDate`", "`OperatorID` = @OperatorID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-无效1-有效</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByStatus(bool status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByStatusAsync(bool status)
		{
			return await GetByStatusAsync(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-无效1-有效</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByStatus(bool status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByStatusAsync(bool status, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-无效1-有效</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByStatus(bool status, int top_)
		{
			return GetByStatus(status, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByStatusAsync(bool status, int top_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-无效1-有效</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByStatus(bool status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByStatusAsync(bool status, int top_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-无效1-有效</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByStatus(bool status, string sort_)
		{
			return GetByStatus(status, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByStatusAsync(bool status, string sort_)
		{
			return await GetByStatusAsync(status, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-无效1-有效</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByStatus(bool status, string sort_, TransactionManager tm_)
		{
			return GetByStatus(status, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByStatusAsync(bool status, string sort_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-无效1-有效</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByStatus(bool status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_templEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByStatusAsync(bool status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Byte));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_templEO.MapDataReader);
		}
		#endregion // GetByStatus
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByRecDateAsync(DateTime recDate, int top_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByRecDateAsync(DateTime recDate, string sort_)
		{
			return await GetByRecDateAsync(recDate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_templEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_templEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#region GetByModifiedDate
		
		/// <summary>
		/// 按 ModifiedDate（字段） 查询
		/// </summary>
		/// /// <param name = "modifiedDate">更新时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByModifiedDate(DateTime modifiedDate)
		{
			return GetByModifiedDate(modifiedDate, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByModifiedDateAsync(DateTime modifiedDate)
		{
			return await GetByModifiedDateAsync(modifiedDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ModifiedDate（字段） 查询
		/// </summary>
		/// /// <param name = "modifiedDate">更新时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByModifiedDate(DateTime modifiedDate, TransactionManager tm_)
		{
			return GetByModifiedDate(modifiedDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByModifiedDateAsync(DateTime modifiedDate, TransactionManager tm_)
		{
			return await GetByModifiedDateAsync(modifiedDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ModifiedDate（字段） 查询
		/// </summary>
		/// /// <param name = "modifiedDate">更新时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByModifiedDate(DateTime modifiedDate, int top_)
		{
			return GetByModifiedDate(modifiedDate, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByModifiedDateAsync(DateTime modifiedDate, int top_)
		{
			return await GetByModifiedDateAsync(modifiedDate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ModifiedDate（字段） 查询
		/// </summary>
		/// /// <param name = "modifiedDate">更新时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByModifiedDate(DateTime modifiedDate, int top_, TransactionManager tm_)
		{
			return GetByModifiedDate(modifiedDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByModifiedDateAsync(DateTime modifiedDate, int top_, TransactionManager tm_)
		{
			return await GetByModifiedDateAsync(modifiedDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ModifiedDate（字段） 查询
		/// </summary>
		/// /// <param name = "modifiedDate">更新时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByModifiedDate(DateTime modifiedDate, string sort_)
		{
			return GetByModifiedDate(modifiedDate, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByModifiedDateAsync(DateTime modifiedDate, string sort_)
		{
			return await GetByModifiedDateAsync(modifiedDate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ModifiedDate（字段） 查询
		/// </summary>
		/// /// <param name = "modifiedDate">更新时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByModifiedDate(DateTime modifiedDate, string sort_, TransactionManager tm_)
		{
			return GetByModifiedDate(modifiedDate, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByModifiedDateAsync(DateTime modifiedDate, string sort_, TransactionManager tm_)
		{
			return await GetByModifiedDateAsync(modifiedDate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ModifiedDate（字段） 查询
		/// </summary>
		/// /// <param name = "modifiedDate">更新时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_templEO> GetByModifiedDate(DateTime modifiedDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ModifiedDate` = @ModifiedDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ModifiedDate", modifiedDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_templEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_templEO>> GetByModifiedDateAsync(DateTime modifiedDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ModifiedDate` = @ModifiedDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ModifiedDate", modifiedDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_templEO.MapDataReader);
		}
		#endregion // GetByModifiedDate
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
